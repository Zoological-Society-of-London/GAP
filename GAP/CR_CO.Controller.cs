using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography;
using System.Timers;
using System.Globalization;
using System.ServiceModel;
using System.Diagnostics;
using System.Xml.Linq;

using log4net;

using hmrcclasses;
using CR_CO.Helpers;

//COMIC RELIEF GIFT AID INTERFACE LINK (GAIL) SOFTWARE LICENCE

//Permission is hereby granted, free of charge, to the person to whom we have provided a copy of this software and associated documentation files (the "Software"), to use the Software for their own internal business purposes only, including without limitation the rights to use, copy and modify the Software. Any transfer of the Software or any of the rights therein to any third party is prohibited.
//You may not deal with the Software in any manner not authorised under this licence, and your rights under this licence will terminate automatically should you attempt to do so.

//The following copyright notice and this permission notice shall be included in all copies or substantial portions of the Software: “This software has been developed using Comic Relief’s Gift Aid Interface Link software (Copyright 2013 Comic Relief)”.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL COMIC RELIEF BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//IN NO CIRCUMSTANCES SHALL COMIC RELIEF BE LIABLE TO YOU FOR ANY LOSS, LIABILITY, COST OR EXPENSE, WHETHER DIRECT OR INDIRECT, AND WHETHER OR NOT CAUSED BY ITS NEGLIGENCE, ARISING FROM YOUR USE OR INABILITY TO USE THE SOFTWARE (INCLUDING BUT NOT LIMITED TO LOSS OR CORRUPTION OF DATA).

namespace CR_CO
{
    /// <summary>
    /// This class sits between the user interface and the HMRC serializer classes. 
    /// It creates xml documents from an input (data table), adds passwords and irmarks to the xml,
    /// sends the documents to the Government Gateway, and reads replies 
    /// </summary>
    public class GiftAidSubmissionProcessController
    {
        private static DataTable datatable;
        private static string _resp = "none";
        private static string _correlationId = "";
        private static int _pollInterval = 0;
        private static int _counter;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static string _env = "";
        private static System.Timers.Timer _timer;
        private static string _resultFileFirstPart;
        private static string _returnValue = "";
        private static bool _diskPolling = true;
        private static string _pollURI = "";

        public static DataTable Data
        {
            get { return datatable; }
            set { datatable = value; }
        }

        public static string Env
        {
            get { return _env; }
            set { _env = value; }
        }

        public static string PollURI
        {
            get { return _pollURI; }
            set { _pollURI = value; }
        }

        /// <summary>
        /// Access to the value which determines whether Poll Messages should be written to disk or
        /// just stored in memory
        /// </summary>
        public static bool DiskPolling
        {
            get { return _diskPolling; }
            set { _diskPolling = value; }
        }

        /// <summary>
        /// Pre-processes input table to ensure necessary columns are present and splits into 
        /// tables of smaller size if input table exceeds batch size
        /// </summary>
        /// <param name="TableToClone"></param>
        /// <param name="RowLimit"></param>
        /// <returns></returns>
        private static List<DataTable> HandleDataTable(DataTable TableToClone, int RowLimit)
        {
            try
            {
                if (!(TableToClone.Columns.Contains("Fore") &&
                TableToClone.Columns.Contains("Sur") &&
                TableToClone.Columns.Contains("House") &&
                TableToClone.Columns.Contains("Postcode") &&
                TableToClone.Columns.Contains("Date") &&
                TableToClone.Columns.Contains("Total")))
                {
                    log.Error("Table column missing");
                    throw new Exception();
                }

                List<DataTable> tables = new List<DataTable>();
                int count = 0;
                DataTable CopyTable = null;
                foreach (DataRow dr in TableToClone.Rows)
                {
                    if ((count++ % RowLimit) == 0)
                    {
                        CopyTable = new DataTable();
                        CopyTable = TableToClone.Clone();
                        tables.Add(CopyTable);
                    }
                    CopyTable.ImportRow(dr);
                }

                log.Info(String.Format("InputTable split into {0} tables", tables.Count));

                return tables;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
        }
        
        /// <summary>
        /// Sequences all aspects of GiftAid claim process
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="ofile"></param>
        /// <param name="resultsfile"></param>
        /// <param name="env"></param>
        /// <returns></returns>
        public static string NewClaimSubmissionProcess(DataTable dt, string ofile, string resultsfile, string env, string userpassword = "", string passwordmethod = "")
        {         
            _env = env;
            _resultFileFirstPart = resultsfile;
            
            log.Info("Process started");

            if(_env != "local" && _env != "test" && _env != "live")
            {   
                log.Info("Environment not set properly. Must be 'local','test', or 'live'. Start again");
                return String.Empty;
            }

            try
            {
                int RowLimit = Convert.ToInt32(ConfigurationManager.AppSettings["BatchSize"]);
                List<DataTable> MessagesList = GiftAidSubmissionProcessController.HandleDataTable(dt,RowLimit);

                int FileNameIncrement = 1;
                string ModifiedFilename = "";

                foreach (DataTable InputTable in MessagesList)
                {
                    if (MessagesList.Count == 1)
                        ModifiedFilename = ofile;
                    else
                    {
                        ModifiedFilename = ofile.Substring(0, ofile.Length - 4) + "_File" + FileNameIncrement.ToString() + ".xml";
                        FileNameIncrement++;
                    }

                    GiftAidSubmissionProcessController._createMessage(InputTable, ModifiedFilename, env);

                    // check state of dt in create message
                    // public createmessage needs to do the parsing then invoke create message...
                    // then split it up if >50k rows

                    log.Info("IR68 submission message created");

                    XmlDocument doc = new XmlDocument();
                    doc.PreserveWhitespace = true;
                    doc.Load(ModifiedFilename);

                    byte[] bytes = Encoding.UTF8.GetBytes(doc.OuterXml);

                    if (ConfigurationManager.AppSettings["errordebug"] == "off")
                    {
                        string IRMakr = GiftAidSubmissionProcessController.GetIRMark(bytes, ModifiedFilename);
                        log.Debug(IRMakr);
                        log.Debug(String.Format("IRmark {0} added", IRMakr));
                    }

                    if (userpassword != "")
                    {
                        XDocument OutputXML = XDocument.Load(ModifiedFilename);
                        OutputXML = AddPassword(OutputXML, userpassword, passwordmethod);
                        OutputXML.Save(ModifiedFilename);
                        log.Debug("Password written to XML file on disk");
                    }

                    // Get a URI based on the environment type
                    string SubmissionURI = CRCOStringFunctions.SetURI(env, "Send");

                    log.Info("Sending data to gateway");
                    XmlDocument XmlResponse = GiftAidSubmissionProcessController.DespatchToGateway(ModifiedFilename, SubmissionURI);
                    GiftAidSubmissionProcessController.ReadResponse(XmlResponse);

                    //write response with appropriate name to file now
                    _returnValue = _correlationId + "_" + _env + "_" + FileNameIncrement.ToString() + "_" + _resp;
                    System.IO.File.WriteAllText(_resultFileFirstPart + _returnValue + ".xml", XmlResponse.InnerXml);

                    if (_pollInterval > 0 && _resp == "acknowledgement")
                    {
                        //use counter to skip to delete statement after reps of polling

                        _timer = new System.Timers.Timer(_pollInterval * 1000);
                        _timer.Elapsed += new ElapsedEventHandler(OnTimer);
                        _timer.Enabled = true;

                        while (_resp != "response")
                        {
                            // @TODO: If _resp != "response" || "error" after ReasonableWaitInMinutes * 60000 then 
                            // write out correlation id status 'suspended' and return
                            // 
                            if (_counter >= 10)
                                break;
                            if (_resp == "error")
                                break;
                        }
                        log.Info("Polling finished");
                    }

                    if (_resp == "error")
                    {
                        log.Info("GATEWAY RETURNED ERROR");
                        log.Info(OutputResponseTable());
                    }

                    if (_resp == "response" && _env != "local")
                        DeleteRequest(_correlationId);
						
					// Need to reset these variables shared between data tables
                    _correlationId = "";
                    _counter = 0;
                    _pollInterval = 0;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
                log.Info("Process finished with failure");
                return "FAILED";
            }

            log.Info("Process finished with success");

            _correlationId = String.Empty;
            return _returnValue;

        }

        /// <summary>
        /// Public entry method for converting an input file into Gift Aid submission messages
        /// </summary>
        /// <param name="InputDataTable"></param>
        /// <param name="OutputFilename"></param>
        /// <param name="env"></param>
        public static void CreateMessages(DataTable InputDataTable, string OutputFilename, string env, string UserPassword = "", string PasswordMethod = "")
        {
            try
            {
                log.Debug("Create message called");
                int RowLimit = Convert.ToInt32(ConfigurationManager.AppSettings["BatchSize"]);
                List<DataTable> MessageList = GiftAidSubmissionProcessController.HandleDataTable(InputDataTable, RowLimit);
                int FileNameIncrement = 1;
                string ModifiedFilename = "";
                string _irmark;
                foreach (DataTable dt in MessageList)
                {
                    if (MessageList.Count == 1)
                    {
                        _createMessage(dt, OutputFilename, env);
                        _irmark = AddIRMark(OutputFilename);
                        if (UserPassword != "")
                        {
                            XDocument OutputXML = XDocument.Load(OutputFilename);
                            OutputXML = AddPassword(OutputXML, UserPassword, PasswordMethod);
                            OutputXML.Save(OutputFilename);
                        }
                        
                    }
                    else
                    {
                        ModifiedFilename = OutputFilename.Substring(0,OutputFilename.Length-4) + "_File" + FileNameIncrement.ToString() + ".xml";
                        _createMessage(dt, ModifiedFilename, env);
                        _irmark = AddIRMark(ModifiedFilename);
                        if (UserPassword != "")
                        {
                            XDocument OutputXML = XDocument.Load(OutputFilename);
                            OutputXML = AddPassword(OutputXML, UserPassword, PasswordMethod);
                            OutputXML.Save(ModifiedFilename);
                        }
                        FileNameIncrement++;                      
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

        }

        /// <summary>
        /// Controls creation of a GovGateway GiftAid submission message based on input data
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="ofile"></param>
        /// <param name="env"></param>
        private static void _createMessage(DataTable dt, string ofile, string env)
        {
            try
            {
                log.Debug("GovTalkGateway message creation started");
                GovTalkGateway Submission = new GovTalkGateway(dt);
                GovTalkMessage NewGovTalkMessage = Submission.CreateRequestMessage(env);
                GiftAidSubmissionProcessController.SerializeObjectToFile(NewGovTalkMessage, ofile);

                log.Debug("File created successfully");
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
                throw ex;
            }
        }

        /// <summary>
        /// Sends Xml files on disk to Government Gateway endpoints
        /// </summary>
        /// <param name="SendFile"></param>
        /// <param name="URI"></param>
        /// <returns></returns>
        public static XmlDocument DespatchToGateway(string SendFile, string URI)
        {
            XmlDocument XmlResponse = new XmlDocument();
            try
            {
                CR_CO.Dispatcher DespatchRequest = new Dispatcher();
                XmlResponse = DespatchRequest.SendToGateway(SendFile, URI);

            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
            return XmlResponse;
        }

        /// <summary>
        /// Sends Xml docs in memory to Government Gateway endpoints
        /// </summary>
        /// <param name="SendDoc"></param>
        /// <param name="URI"></param>
        /// <returns></returns>
        public static XmlDocument DespatchToGateway(XmlDocument SendDoc, string URI)
        {
            XmlDocument XmlResponse = new XmlDocument();
            try
            {
                CR_CO.Dispatcher DespatchRequest = new Dispatcher();
                XmlResponse = DespatchRequest.SendToGateway(SendDoc, URI);

            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
            return XmlResponse;
        }

        /// <summary>
        /// Reads Government Gateway Xml responses
        /// </summary>
        /// <param name="xmlresp"></param>
        public static void ReadResponse(XmlDocument xmlresp)
        {
            HMRCDataTable ResponseTable = new HMRCDataTable();

            try
            {
                GovTalkGateway ResponseReader = new GovTalkGateway();
                GovTalkMessage Message = new GovTalkMessage();
                Message = ResponseReader.ReadAcknowledgementAndResponse(xmlresp);

               if (String.IsNullOrEmpty(_correlationId))
                    _correlationId = ResponseReader.CorrelationId;

                _resp = ResponseReader.GatewayResponse;

                // Set the poll URI
                PollURI = Message.Header.MessageDetails.ResponseEndPoint.Value;
                
                if (_resp == "error")
                {
                    ResponseTable.AddErrorResponseColumns();
                    ResponseTable.AddErrorResponseRow(Message);
                }

                if (ResponseReader.PollInterval > 0)
                    _pollInterval = ResponseReader.PollInterval;

                log.Info(String.Format("Response received and read. Response type is {0}. CorrelationID is {1}", _resp, String.IsNullOrEmpty(_correlationId) ? "Nothing": _correlationId));

                if (ResponseReader.SuccessResponse != null)
                {
                    string message = "";
                    for (int i = 0; i < ResponseReader.SuccessResponse.Message.Length; i++)
                    {
                        message += "Message " + (i+1).ToString() + ": Code = " 
                            +ResponseReader.SuccessResponse.Message[i].code.ToString() + "; " 
                            + ResponseReader.SuccessResponse.Message[i].Value.ToString() + "; \n";
                    }

                    string FinalMessage = String.Format("Success Response with IRreceipt: {0}, Accepted time: {1}, Message Code: {2}, Message body: {3}",
                        ResponseReader.SuccessResponse.IRmarkReceipt.Message.Value.ToString(), ResponseReader.SuccessResponse.AcceptedTime,
                        ResponseReader.SuccessResponse.IRmarkReceipt.Message.code,
                        message
                        );
                    log.Info(FinalMessage);
                }

                // DataResponse case
                if (Message.Body.StatusReport != null)
                {
                    ResponseTable.AddGatewayColumns();
                    ResponseTable.AddStatusReportColumns();
                    ResponseTable.AddStatusReportRow(Message);
                }

                Data = ResponseTable.GetTable();
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
        }

        /// <summary>
        /// Creates and sends messages to the poll URI
        /// </summary>
        public static void PollService()
        {
            try
            {
                string PollTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss", CultureInfo.InvariantCulture);
                string PollMsgFileName = ConfigurationManager.AppSettings["TempFolder"].ToString() + @"\TestPollMessage" + PollTime + ".xml";
                string PollMsgResults = ConfigurationManager.AppSettings["TempFolder"].ToString() + @"\PollMessageResults" + PollTime + ".xml";

                //createPollMessage

                GovTalkGateway PollingService = new GovTalkGateway();
                GovTalkMessage PollMessage =
                    PollingService.CreatePollMessage(_correlationId);

                //send Poll Message

                log.Info("Sending poll msg ...");

                string PollURI = String.IsNullOrEmpty(_pollURI) ? CRCOStringFunctions.SetURI(_env, "Poll"): _pollURI;

                XmlDocument XmlResponse = new XmlDocument();

                if (_diskPolling)
                {
                    GiftAidSubmissionProcessController.SerializeObjectToFile(PollMessage, PollMsgFileName);
                    log.Debug("Poll URI Is " + PollURI);
                    XmlResponse = GiftAidSubmissionProcessController.DespatchToGateway(PollMsgFileName, PollURI);
                }
                else
                {
                    XmlDocument PollDoc = GiftAidSubmissionProcessController.SerializeInMemory(PollMessage);
                    log.Debug("Poll URI Is " + PollURI);
                    XmlResponse = GiftAidSubmissionProcessController.DespatchToGateway(PollDoc, PollURI);
                }


                //readPollAcknowledgement
                log.Info("Reading poll reply msg ...");
                GiftAidSubmissionProcessController.ReadResponse(XmlResponse);

                _counter++;
                log.Info("Counter is now: " + _counter.ToString());

                if (_resp == "response" && !Object.ReferenceEquals(null,_timer))
                {
                    _timer.Stop();
                    _timer.Dispose();
                    _returnValue = _correlationId + "_" + _env + "_" + _resp;
                    System.IO.File.WriteAllText(_resultFileFirstPart + _returnValue + ".xml", XmlResponse.InnerXml);
                    return;
                }

                if (_resp == "error" && !Object.ReferenceEquals(null, _timer))
                {
                    _timer.Stop();
                    _timer.Dispose();
                    _returnValue = _correlationId + "_" + _env + "_" + _resp;
                    System.IO.File.WriteAllText(_resultFileFirstPart + _returnValue + ".xml", XmlResponse.InnerXml);
                    return;
                }

                System.IO.File.WriteAllText(PollMsgResults + _returnValue + ".xml", XmlResponse.InnerXml);
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
        }

        /// <summary>
        /// Creates and sends delete requests to the submission URI
        /// </summary>
        /// <param name="correlationId"></param>
        public static void DeleteRequest(string correlationId, string deleteMsgFileName = "", string deleteMsgResults = "")
        {
            try
            {
                string DeleteTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss", CultureInfo.InvariantCulture);
                string DeleteMsgFileName = deleteMsgFileName == "" ? ConfigurationManager.AppSettings["TempFolder"].ToString() + @"\TestDeleteMessage" + DeleteTime + ".xml" : deleteMsgFileName;
                string DeleteMsgResults = deleteMsgResults == "" ? ConfigurationManager.AppSettings["TempFolder"].ToString() + @"\DeleteMessageResults_" + DeleteTime + "_" : deleteMsgResults;

                GovTalkGateway DeleteSubmission = new GovTalkGateway();
                GovTalkMessage DeleteMessage =
                    DeleteSubmission.CreateDeleteRequest(correlationId);
                GiftAidSubmissionProcessController.SerializeObjectToFile(DeleteMessage, DeleteMsgFileName);

                //send Delete Message

                log.Info("Sending delete msg ..");
                string DeleteURI = CRCOStringFunctions.SetURI(_env, "Send");

                XmlDocument XmlResponse = GiftAidSubmissionProcessController.DespatchToGateway(DeleteMsgFileName, DeleteURI);

                //readPollAcknowledgement
                log.Info("Reading delete reply msg ...");
                GiftAidSubmissionProcessController.ReadResponse(XmlResponse);

                if (_resp == "response" && !Object.ReferenceEquals(null, _timer))
                {
                    _timer.Stop();
                    _timer.Dispose();
                    _returnValue = _correlationId + "_" + _env + "_" + _resp;
                    System.IO.File.WriteAllText(DeleteMsgResults+"_"+_correlationId+"_DeleteResponse.xml", XmlResponse.InnerXml);
                    return;
                }

                if (_resp == "error" && !Object.ReferenceEquals(null, _timer))
                {
                    _timer.Stop();
                    _timer.Dispose();
                    _returnValue = _correlationId + "_" + _env + "_" + _resp;
                    System.IO.File.WriteAllText(DeleteMsgResults+"_"+_correlationId+"_DeleteError.xml", XmlResponse.InnerXml);
                    return;
                }

                System.IO.File.WriteAllText(DeleteMsgResults + _returnValue + ".xml", XmlResponse.InnerXml);

            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }

        }

        /// <summary>
        /// Creates and sends data requests to the submission URI
        /// </summary>
        public static XmlDocument DataRequest(string DataRequestMsgFileName, string DataRequestMsgResults)
        {
            try
            {
                GovTalkGateway DataRequestSubmission = new GovTalkGateway();
                GovTalkMessage DataRequestMessage =
                    DataRequestSubmission.CreateDataRequest();
                GiftAidSubmissionProcessController.SerializeObjectToFile(DataRequestMessage, DataRequestMsgFileName);

                log.Debug("Sending data request message ... ");
                string DataRequestURI = CRCOStringFunctions.SetURI(_env, "Send");

                if (String.IsNullOrEmpty(DataRequestURI))
                {
                    Exception URIError = new Exception("The Data Request URI is null or empty. Check environment");
                    throw URIError;
                }
                    
                XmlDocument XmlResponse = GiftAidSubmissionProcessController.DespatchToGateway(DataRequestMsgFileName, DataRequestURI);

                System.IO.File.WriteAllText(DataRequestMsgResults, XmlResponse.InnerXml);

                log.Debug("Reading reply msg ...");
                GiftAidSubmissionProcessController.ReadResponse(XmlResponse);

                return XmlResponse;

            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
                throw ex;
            }
        }

        /// <summary>
        /// Sends a file to Gateway and returns correlationId of first response
        /// </summary>
        /// <returns></returns>
        public static string SendFileWithoutPoll(string FileToSend, string URI, string ResultsFile)
        {
            try
            {
                //sendfile
                XmlDocument xmlReply = DespatchToGateway(FileToSend, URI);

                //Read response
                ReadResponse(xmlReply);

                //Save response to resultsfile
                System.IO.File.WriteAllText(ResultsFile+_correlationId+".xml", xmlReply.InnerXml);

                return _correlationId;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
        }

        /// <summary>
        /// Resumes an unfinished request based on the correlation ID
        /// </summary>
        /// <param name="correlationId"></param>
        public static void ResumePendingRequest(string correlationId, string PollMsgFileName, string PollMsgResults)
        {
            try
            {
                //createPollMessage

                GovTalkGateway PollingService = new GovTalkGateway();
                GovTalkMessage PollMessage =
                    PollingService.CreatePollMessage(correlationId);

                //send Poll Message

                log.Info("Sending poll msg ...");

                string PollURI = CRCOStringFunctions.SetURI(_env, "Poll");
                    
                XmlDocument XmlResponse = new XmlDocument();

                if (_diskPolling)
                {
                    GiftAidSubmissionProcessController.SerializeObjectToFile(PollMessage, PollMsgFileName);
                    XmlResponse = GiftAidSubmissionProcessController.DespatchToGateway(PollMsgFileName, PollURI);
                }
                else
                {
                    XmlDocument PollDoc = GiftAidSubmissionProcessController.SerializeInMemory(PollMessage);
                    XmlResponse = GiftAidSubmissionProcessController.DespatchToGateway(PollDoc, PollURI);
                }
                //readPollAcknowledgement
                log.Info("Reading poll reply msg ...");
                GiftAidSubmissionProcessController.ReadResponse(XmlResponse);

                //write results to file
                System.IO.File.WriteAllText(PollMsgResults + correlationId + ".xml", XmlResponse.InnerXml);

            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }

        }

        /// <summary>
        /// Helper method for polling service
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void OnTimer(Object source, ElapsedEventArgs e)
        {
            //interval is in seconds
            //do the thing - if we want to use this for other calls need to use a switch here
            log.Info("Polling service ...");
            PollService();
        }

        /// <summary>
        /// Controls serialization of objects to Xml
        /// </summary>
        /// <param name="gtMsg"></param>
        /// <param name="OutputFile"></param>
        public static void SerializeObjectToFile(GovTalkMessage gtMsg, string OutputFile)
        {
            try
            {
                string filename = OutputFile;

                using (Stream stream = File.Open(filename, FileMode.Create))
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    // Need to change the namespace declarations in the GovTalkMessage attributes
                    ns.Add(String.Empty, "http://www.govtalk.gov.uk/CM/envelope");

                    XmlSerializer serializer =
                                new XmlSerializer(typeof(GovTalkMessage));
                    serializer.Serialize(stream, gtMsg, ns);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
        }

        public static XmlElement SerializeIREnvelope(IRenvelope ire)
        {
            try
            {
                using (MemoryStream memStream = new MemoryStream())
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add(String.Empty, "http://www.govtalk.gov.uk/taxation/charities/r68/1");

                    var knownTypes = new Type[] { typeof(IRenvelope), typeof(R68Claim) };

                    XmlSerializer serializer =
                        new XmlSerializer(typeof(IRenvelope),knownTypes);

                    XmlTextWriter tw = new XmlTextWriter(memStream, UTF8Encoding.UTF8);

                    XmlDocument doc = new XmlDocument();
                    tw.Formatting = Formatting.Indented;
                    tw.IndentChar = ' ';
                    serializer.Serialize(tw, ire, ns);
                    memStream.Seek(0, SeekOrigin.Begin);
                    doc.Load(memStream);
                    XmlElement returnVal = doc.DocumentElement;

                    log.Debug("IRenvelope messages serialized in memory"); 

                    return returnVal;
                }
            }
            catch (Exception ex)
            {
                log.Debug("IRenvelope message not serialised in memory");
                log.Error(ex);
                throw;
            }
        }

        public static XmlDocument SerializeInMemory(GovTalkMessage gtm)
        {
            try
            {
                using (MemoryStream memStream = new MemoryStream())
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add(string.Empty, "http://www.govtalk.gov.uk/CM/envelope");

                    XmlSerializer serializer =
                                    new XmlSerializer(typeof(GovTalkMessage));

                    XmlTextWriter tw = new XmlTextWriter(memStream, UTF8Encoding.UTF8);
                    XmlDocument doc = new XmlDocument();
                    tw.Formatting = Formatting.Indented;
                    tw.IndentChar = ' ';
                    serializer.Serialize(memStream, gtm, ns);

                    memStream.Seek(0, SeekOrigin.Begin);
                    doc.Load(memStream);

                    log.Debug("GovTalkMsg serialized in memory");

                    return doc;
                }
            }
            catch (Exception ex)
            {
                log.Debug("GovTalkMsg not serialized in memory");
                log.Error(ex);
                throw;
            }

        }

        public static string AddIRMark(string XmlFilename)
        {
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.Load(XmlFilename);
            byte[] bytes = Encoding.UTF8.GetBytes(doc.OuterXml);
            string IRMark = GiftAidSubmissionProcessController.GetIRMark(bytes, XmlFilename);
            log.Debug(IRMark);
            log.Info(String.Format("IRmark {0} added", IRMark));
            return IRMark;
        }

        /// <summary>
        ///  Returns XML document (Gov Gateway message) with password added
        /// </summary>
        /// <param name="xdoc"></param>
        /// <param name="UserPassword"></param>
        /// <returns></returns>
        public static XDocument AddPassword(XDocument xdoc, string UserPassword, string PasswordMethod = "")
        {
            log.Info("Adding input password");
            
            bool MD5Pasword = false;

            if (PasswordMethod == "" && ConfigurationManager.AppSettings["PasswordMethod"] != "MD5")
                MD5Pasword = false;
            else
            {
                MD5Pasword = true;
                log.Info("Password will be MD5-hashed");
            }

            try
            {
                if (MD5Pasword)
                    UserPassword = Helpers.CRCOStringFunctions.MD5Hash(UserPassword);

                XElement root = XElement.Parse(xdoc.ToString());
                XNamespace GovTalk = "http://www.govtalk.gov.uk/CM/envelope";

                IEnumerable<XElement> PasswordTree =
                    (from el in root.Descendants(GovTalk + "Value")
                     select el);

                if(PasswordTree.Count() == 0)
                {
                    log.Info("Value (password) element not found.");
                    return xdoc;
                }

                if (PasswordTree.ElementAt(0).Name.LocalName != "Value")
                {
                    log.Info("Add password method has not found the 'value' (password) element");
                    return xdoc;
                }

                XElement Password = PasswordTree.ElementAt(0);
                XElement NewPassword = new XElement(GovTalk + "Value", UserPassword);
                Password.ReplaceWith(NewPassword);

                if (MD5Pasword)
                {
                    IEnumerable<XElement> MethodTree =
                        (from el in root.Descendants(GovTalk + "Method")
                         select el);
                    XElement PassMethod = MethodTree.ElementAt(0);
                    XElement NewMethod = new XElement(GovTalk + "Method", "MD5");
                    PassMethod.ReplaceWith(NewMethod);
                }

                XDocument NewXDoc = new XDocument(root);

                log.Info("Password added to XML in memory");
                return NewXDoc;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates the Gateway IR Mark for the submission messages
        /// Derived from http://neophytedeveloper.wordpress.com/
        /// </summary>
        /// <param name="Xml">byte array of xml document</param>
        /// <param name="ofile">Name of destination file saved to disk</param>
        /// <returns></returns>
        public static string GetIRMark(byte[] Xml, string ofile)
        {
            string vbLf = "\n";
            string vbCrLf = "\r\n";
            string result = String.Empty;
            try
            {
                // Convert Byte array to string
                string text = Encoding.UTF8.GetString(Xml);

                //load new XmlDocument with xml text
                XmlDocument doc = new XmlDocument();
                doc.PreserveWhitespace = true;
                doc.LoadXml(text);

                XmlNode root = doc.DocumentElement;

                XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
                ns.AddNamespace("govtalkgateway", doc.DocumentElement.NamespaceURI);

                // Create an XML document of just the body section
                XmlNode Body = doc.SelectSingleNode("//govtalkgateway:Body", ns);

                ns.AddNamespace("ir68", Body.FirstChild.NextSibling.NamespaceURI);

                XmlDocument xmlBody = new XmlDocument();
                xmlBody.PreserveWhitespace = true;
                xmlBody.LoadXml(Body.OuterXml);

                // Remove any existing IRMark   
                XmlNode nodeIr = xmlBody.SelectSingleNode("//ir68:IRmark", ns);
                XmlNode IrMarkPlaceHolder = nodeIr;
                if (nodeIr != null)
                {
                    IrMarkPlaceHolder = nodeIr.PreviousSibling;
                    nodeIr.ParentNode.RemoveChild(nodeIr);
                }

                // Normalise the document using C14N (Canonicalisation)  
                XmlDsigC14NTransform c14n = new XmlDsigC14NTransform();
                c14n.LoadInput(xmlBody);
                using (Stream S = (Stream)c14n.GetOutput())
                {
                    byte[] Buffer = new byte[S.Length];

                    // Convert to string and normalise line endings  
                    S.Read(Buffer, 0, (int)S.Length);
                    text = Encoding.UTF8.GetString(Buffer);
                    text = text.Replace("&#xD;", "");
                    text = text.Replace(vbCrLf, vbLf);
                    text = text.Replace(vbCrLf, vbLf);

                    // Convert the final document back into a byte array 
                    byte[] b = Encoding.UTF8.GetBytes(text);

                    // Create the SHA-1 hash from the final document 
                    SHA1 SHA = SHA1.Create();
                    byte[] hash = SHA.ComputeHash(b);

                    result = Convert.ToBase64String(hash);
                }

                // attempt to re-insert the IRmark

                XmlNode IRmarkNode = root.SelectSingleNode("//*[contains(name(),'IRmark')]");

                if (!String.IsNullOrEmpty(IRmarkNode.InnerText))
                {
                    root.SelectSingleNode("//*[contains(name(),'IRmark')]").LastChild.Value = result;
                }
                else
                    if (root.SelectSingleNode("//*[contains(name(),'IRmark')]") != null)
                    {
                        IRmarkNode.InnerText = result;
                    }
                    else
                    {
                        log.Info("No IRmark");
                    }

                using (XmlTextWriter writer = new XmlTextWriter(ofile, null))
                {
                    // writer.Formatting = Formatting.Indented;
                    doc.Save(writer);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
            return result;
        }

        /// <summary>
        /// Helper method for checking configuration settings
        /// </summary>
        /// <returns></returns>
        public static string CheckConfiguredValue()
        {
            string TestValue = ConfigurationManager.AppSettings["ReasonableWaitInMinutes"];

            return TestValue;
        }

        public static string OutputResponseTable()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();

            foreach (DataRow dr in Data.Rows)
            {
                builder.Append("\n---ROW---\n");
                foreach (DataColumn dc in dr.Table.Columns)
                {
                    builder.Append(dc.ColumnName);
                    builder.Append(": ");
                    builder.Append(dr[dc]);
                    builder.Append("\n");
                }

            }

            return builder.ToString();
        }
    }
}

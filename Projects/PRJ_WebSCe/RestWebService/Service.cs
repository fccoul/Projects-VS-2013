using REST_WebSCe;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Serialization;


namespace RestWebService
{
    public class Service:IHttpHandler
    {

        private DAL dal;
        
        private Employee emp;
        private ErrorHandler errHandler;

        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }

        public void ProcessRequest(HttpContext context)
        {
            //Handling CRUD
            switch (context.Request.HttpMethod)
            {
                case "GET": READ(context);
                    break;
                case "POST": CREATE(context);
                    break;
                case "PUT": UPDATE(context);
                    break;
                case "DELETE": DELETE(context);
                    break;
                default:
                    break;
            }
        }


        #region fonctions  CRUD

        private void READ(HttpContext context)
        {
            try
            {
                int employeeCode = Convert.ToInt16(context.Request["id"]);
                //............
                string strConnString = @"Data Source=GSEW0263;Initial Catalog=DB_WebSCe;User ID=sa;Password=P@ssw0rd";

                dal = new DAL(strConnString);
                //............

                emp = dal.GetEmployee(employeeCode);
                if (emp == null)
                    context.Response.Write(employeeCode + "No Employe Found");

                string serializedEmployee = Serialize(emp);
            }
            catch (Exception ex)
            {

                WriteResponse("Error in Read");
                errHandler.ErrorMessage = dal.GetException();
                errHandler.ErrorMessage = ex.Message.ToString();
            }
        }

        /*
         * Extract the Employee class from the message body of the POST request. 
         * This is done by using the BinaryRead() method of the Request class which reads the message body as bytes.
            Deserialize employee information from bytes[] to the Employee class.
            Perform an Insert operation in the database using the Data Access Layer.
         * */
        private void CREATE(HttpContext context)
        {
             // HTTP POST sends name/value pairs to a web server
                // dat is sent in message body

                //The most common use of POST, by far, is to submit HTML form data to CGI scripts.
                
                // This Post task handles cookies and remembers them across calls. 
                // This means that you can post to a login form, receive authentication cookies, 
                // then subsequent posts will automatically pass the correct cookies. 
                // The cookies are stored in memory only, they are not written to disk and 
                // will cease to exist upon completion of the build.
              
                // The POST Request structure - Typical POST Request
                // POST /path/script.cgi HTTP/1.0
                // From: frog@jmarshall.com
                // User-Agent: HTTPTool/1.0
                // Content-Type: application/x-www-form-urlencoded
                // Content-Length: 32

                // home=Cosby&favorite+flavor=flies


            try
            {
                // Extract the content of the Request and make a employee class
                // The message body is posted as bytes. read the bytes
                byte[] postData = context.Request.BinaryRead(context.Request.ContentLength);
                //Convert the bytes to string using Encoding class
                string str = Encoding.UTF8.GetString(postData);
                //// deserialize xml into employee class
                emp = Deserialize(postData);
                // Insert data in database
                dal.AddEmployee(emp);
            }
            catch (Exception ex)
            {
                WriteResponse("Error in Create");
                errHandler.ErrorMessage = dal.GetException();
                errHandler.ErrorMessage = ex.Message.ToString();
                
                
            }
        }

        private void UPDATE(HttpContext context)
        {
            //The PUT Method

            // The PUT method requests that the enclosed entity be stored
            // under the supplied URL. If the URL refers to an already 
            // existing resource, the enclosed entity should be considered
            // as a modified version of the one residing on the origin server. 
            // If the URL does not point to an existing resource, and that 
            // URL is capable of being defined as a new resource by the 
            // requesting user agent, the origin server can create the 
            // resource with that URL.
            // If the request passes through a cache and the URL identifies 
            // one or more currently cached entities, those entries should 
            // be treated as stale. Responses to this method are not cacheable.


            // Common Problems
            // The PUT method is not widely supported on public servers 
            // due to security concerns and generally FTP is used to 
            // upload new and modified files to the webserver. 
            // Before executing a PUT method on a URL, it may be worth 
            // checking that PUT is supported using the OPTIONS method.

            try
            {
                byte[] PUTRequestByte = context.Request.BinaryRead(context.Request.ContentLength);
                context.Response.Write(PUTRequestByte);

                //Desrialize employee
                emp = (Employee)Deserialize(PUTRequestByte);
                dal.UpdateEmployee(emp);
            }
            catch (Exception ex)
            {
                WriteResponse("Error in Update");
                errHandler.ErrorMessage = dal.GetException();
                errHandler.ErrorMessage = ex.Message.ToString();
                 
            }
        }
      
        //Get the employee code from the query string of the URL.
        //Perform the Delete operation in the database.
        private void DELETE(HttpContext context)
        {
            try
            {
                int EmpCode = Convert.ToInt16(context.Request["id"]);
                dal.DeleteEmployee(EmpCode);
                WriteResponse("Employee Deleted Successfully");
            }
            catch (Exception ex)
            {
                WriteResponse("Erro in delete");
                errHandler.ErrorMessage = dal.GetException();
                errHandler.ErrorMessage = ex.Message.ToString();
                 
            }
        }

        


        #endregion

        #region Utility Functions

            private string Serialize(Employee emp)
            {
                try
                {
                    string XmlizedString = null;
                    XmlSerializer xs = new XmlSerializer(typeof(Employee));
                    //create an instance of the MemoryStream class since we intend to keep the XML string 
                    //in memory instead of saving it to a file.
                    MemoryStream memoryStream = new MemoryStream();
                    //XmlTextWriter - fast, non-cached, forward-only way of generating streams or files 
                    //containing XML data
                    XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                    //Serialize emp in the xmlTextWriter
                    //methode serialize:write the XML into a memory stream
                    xs.Serialize(xmlTextWriter, emp);
                    //Get the BaseStream of the xmlTextWriter in the Memory Stream
                    memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                    //Convert to array
                    XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
                    return XmlizedString;
                }
                catch (Exception ex) 
                {
                    errHandler.ErrorMessage = ex.Message.ToString();
                    throw;
                }
            }

            private Employee Deserialize(byte[] xmlByteData)
            {
                XmlSerializer ds = new XmlSerializer(typeof(Employee));
                MemoryStream memoryStream = new MemoryStream(xmlByteData);
                Employee emp = new Employee();
                emp =(Employee) ds.Deserialize(memoryStream);
                return emp;
            }

            private string UTF8ByteArrayToString(byte[] characters)
            {
                UTF8Encoding encoding = new UTF8Encoding();
                string ConstructedString = encoding.GetString(characters);
                return ConstructedString;
            }

            private void WriteResponse(string strMessage)
            {
                HttpContext.Current.Response.Write(strMessage);
            } 

        #endregion

    }
}

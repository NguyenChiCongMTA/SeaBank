using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using SafeControl.Base;
using System.Net;
using System.Windows.Forms;
namespace SafeControl.Dictionary
{
    /// <summary>
    /// Thư viện thao tác Ftp
    /// </summary>
    [Serializable]
    public class MFtp : MBase
    {
        #region Example
        ///* Create Object Instance */
        //ftp ftpClient = new ftp(@"ftp://10.10.10.10/", "user", "password");

        ///* Upload a File */
        //ftpClient.upload("etc/test.txt", @"C:\Users\metastruct\Desktop\test.txt");

        ///* Download a File */
        //ftpClient.download("etc/test.txt", @"C:\Users\metastruct\Desktop\test.txt");

        ///* Delete a File */
        //ftpClient.delete("etc/test.txt");

        ///* Rename a File */
        //ftpClient.rename("etc/test.txt", "test2.txt");

        ///* Create a New Directory */
        //ftpClient.createDirectory("etc/test");

        ///* Get the Date/Time a File was Created */
        //string fileDateTime = ftpClient.getFileCreatedDateTime("etc/test.txt");
        //Console.WriteLine(fileDateTime);

        ///* Get the Size of a File */
        //string fileSize = ftpClient.getFileSize("etc/test.txt");
        //Console.WriteLine(fileSize);

        ///* Get Contents of a Directory (Names Only) */
        //string[] simpleDirectoryListing = ftpClient.directoryListDetailed("/etc");
        //for (int i = 0; i < simpleDirectoryListing.Count(); i++) { Console.WriteLine(simpleDirectoryListing[i]); }

        ///* Get Contents of a Directory with Detailed File/Directory Info */
        //string[] detailDirectoryListing = ftpClient.directoryListDetailed("/etc");
        //for (int i = 0; i < detailDirectoryListing.Count(); i++) { Console.WriteLine(detailDirectoryListing[i]); }
        ///* Release Resources */
        //ftpClient = null;
        #endregion
        /////////////////////////////////////////////////////////////////////
        #region Declare
        public string host = null;
        public string port = null;
        public string user = null;
        public string pass = null;
        private FtpWebRequest ftpRequest = null;
        private FtpWebResponse ftpResponse = null;
        private Stream ftpStream = null;
        private int bufferSize = 2048;
        #endregion
        /////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////
        #region Sub/Func
        /// <summary>
        /// Hàm khởi tạo lớp
        /// </summary>
        /// CreateBy: truongnm 13.08.2020
        public MFtp()
        {
            user = "administrator";
            pass = "123@abc";
        }
        public MFtp(string sPath)
        {
            loadConfig(sPath);
        }
        private void loadConfig(string sPath)
        {
            string[] sConfig = System.IO.File.ReadAllText(sPath).Split('|');
            host = sConfig[0]; port = sConfig[1]; user = sConfig[2]; pass = sConfig[3];
        }
        public void writeConfig(string sPath)
        {
            using (StreamWriter writetext = new StreamWriter(sPath))
            {
                writetext.Write(String.Format("{0}|{1}|{2}|{3}", host, port, user, pass));
            }
        }
        public MFtp(string hostIP, string Port, string userName, string password) 
        {
            host = hostIP; port = Port; user = userName; pass = password; 
        }

        /* Download File */
        /// <summary>
        /// Hàm Download File
        /// </summary>
        /// CreateBy: truongnm 13.08.2020
        public void download(string remoteFile, string localFile)
        {
            try
            {
                //filePath = <<The full path where the file is to be created.>>, 
                //fileName = <<Name of the file to be created(Need not be the name of the file on FTP server).>>
                FileStream outputStream = new FileStream(localFile, FileMode.Create);

                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + host + ":" + port + "/" + remoteFile));
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                ftpRequest.UseBinary = true;
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];

                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }

                ftpStream.Close();
                outputStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                MMessageBox.Error(ex.Message);
            }
            return;
        }
        /// <summary>
        /// Hàm Download File
        /// </summary>
        /// CreateBy: truongnm 13.08.2020
        public void downloadFullRemotePath(string remoteFilePath, string localFile)
        {
            try
            {
                //filePath = <<The full path where the file is to be created.>>, 
                //fileName = <<Name of the file to be created(Need not be the name of the file on FTP server).>>
                FileStream outputStream = new FileStream(localFile, FileMode.Create);

                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(remoteFilePath));
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                ftpRequest.UseBinary = true;
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];

                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }

                ftpStream.Close();
                outputStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                MMessageBox.Error(ex.Message);
            }
            return;
        }
        /// <summary>
        /// Hàm Download File
        /// </summary>
        /// CreateBy: truongnm 13.08.2020
        public void downloadFullRemotePath(string host, string remoteFilePath, string localFile)
        {
            try
            {
                //filePath = <<The full path where the file is to be created.>>, 
                //fileName = <<Name of the file to be created(Need not be the name of the file on FTP server).>>
                FileStream outputStream = new FileStream(localFile, FileMode.Create);

                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(host + remoteFilePath));
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                ftpRequest.UseBinary = true;
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];

                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }

                ftpStream.Close();
                outputStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                MMessageBox.Error(ex.Message);
            }
            return;
        }

        /* Upload File */
        /// <summary>
        /// Hàm Upload File
        /// </summary>
        /// CreateBy: truongnm 13.08.2020
        public void upload(string remoteFile, string localFile, ref string remotePath)
        {
            FileInfo fileInf = new FileInfo(localFile);
            /* Create an FTP Request */
            // Create FtpWebRequest object from the Uri provided
            ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + host + ":" + port + "/upload/" + remoteFile));
            remotePath = "ftp://" + host + ":" + port + "/upload/" + remoteFile;
            //remotePath = remoteFile;
            // Provide the WebPermission Credintials
            ftpRequest.Credentials = new NetworkCredential(user, pass);

            // By default KeepAlive is true, where the control connection is not closed
            // after a command is executed.
            ftpRequest.KeepAlive = false;

            // Specify the command to be executed.
            ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;

            // Specify the data transfer type.
            ftpRequest.UseBinary = true;

            // Notify the server about the size of the uploaded file
            ftpRequest.ContentLength = fileInf.Length;

            // The buffer size is set to 2kb
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;

            // Opens a file stream (System.IO.FileStream) to read the file to be uploaded
            FileStream fs = fileInf.OpenRead();

            try
            {
                // Stream to which the file to be upload is written
                Stream strm = ftpRequest.GetRequestStream();

                // Read from the file stream 2kb at a time
                contentLen = fs.Read(buff, 0, buffLength);

                // Till Stream content ends
                while (contentLen != 0)
                {
                    // Write Content from the file stream to the FTP Upload Stream
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }

                // Close the file stream and the Request Stream
                strm.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MMessageBox.Error(ex.Message); 
            }
            return;
        }

        /* Delete File */
        public void delete(string deleteFile)
        {
            try
            {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)WebRequest.Create(new Uri("ftp://" + host + ":" + port + "/" + deleteFile));
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Resource Cleanup */
                ftpResponse.Close();
                ftpRequest = null;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return;
        }
        public void deleteFromPath(string deleteFilePath, string sHost)
        {
            try
            {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)WebRequest.Create(new Uri(sHost + deleteFilePath));
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Resource Cleanup */
                ftpResponse.Close();
                ftpRequest = null;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return;
        }
        public void deleteFromPath(string deleteFilePath)
        {
            try
            {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)WebRequest.Create(new Uri(deleteFilePath));
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Resource Cleanup */
                ftpResponse.Close();
                ftpRequest = null;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return;
        }
        /* Rename File */
        public void rename(string currentFileNameAndPath, string newFileName)
        {
            try
            {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)WebRequest.Create(new Uri("ftp://" + host + ":" + port + "/" + currentFileNameAndPath));
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.Rename;
                /* Rename the File */
                ftpRequest.RenameTo = newFileName;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Resource Cleanup */
                ftpResponse.Close();
                ftpRequest = null;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return;
        }

        /* Create a New Directory on the FTP Server */
        public void createDirectory(string newDirectory)
        {
            try
            {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)WebRequest.Create(new Uri("ftp://" + host + ":" + port + "/" + newDirectory));
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Resource Cleanup */
                ftpResponse.Close();
                ftpRequest = null;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return;
        }

        /* Get the Date/Time a File was Created */
        public string getFileCreatedDateTime(string fileName)
        {
            try
            {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + host + ":" + port + "/" + fileName));
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.GetDateTimestamp;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Establish Return Communication with the FTP Server */
                ftpStream = ftpResponse.GetResponseStream();
                /* Get the FTP Server's Response Stream */
                StreamReader ftpReader = new StreamReader(ftpStream);
                /* Store the Raw Response */
                string fileInfo = null;
                /* Read the Full Response Stream */
                try { fileInfo = ftpReader.ReadToEnd(); }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                /* Resource Cleanup */
                ftpReader.Close();
                ftpStream.Close();
                ftpResponse.Close();
                ftpRequest = null;
                /* Return File Created Date Time */
                return fileInfo;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            /* Return an Empty string Array if an Exception Occurs */
            return "";
        }

        /* Get the Size of a File */
        public string getFileSize(string fileName)
        {
            try
            {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + host + ":" + port + "/" + fileName));
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.GetFileSize;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Establish Return Communication with the FTP Server */
                ftpStream = ftpResponse.GetResponseStream();
                /* Get the FTP Server's Response Stream */
                StreamReader ftpReader = new StreamReader(ftpStream);
                /* Store the Raw Response */
                string fileInfo = null;
                /* Read the Full Response Stream */
                try { while (ftpReader.Peek() != -1) { fileInfo = ftpReader.ReadToEnd(); } }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                /* Resource Cleanup */
                ftpReader.Close();
                ftpStream.Close();
                ftpResponse.Close();
                ftpRequest = null;
                /* Return File Size */
                return fileInfo;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            /* Return an Empty string Array if an Exception Occurs */
            return "";
        }

        /* List Directory Contents File/Folder Name Only */
        public string[] directoryListSimple(string directory)
        {
            try
            {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + host + ":" + port + "/" + directory));
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Establish Return Communication with the FTP Server */
                ftpStream = ftpResponse.GetResponseStream();
                /* Get the FTP Server's Response Stream */
                StreamReader ftpReader = new StreamReader(ftpStream);
                /* Store the Raw Response */
                string directoryRaw = null;
                /* Read Each Line of the Response and Append a Pipe to Each Line for Easy Parsing */
                try { while (ftpReader.Peek() != -1) { directoryRaw += ftpReader.ReadLine() + "|"; } }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                /* Resource Cleanup */
                ftpReader.Close();
                ftpStream.Close();
                ftpResponse.Close();
                ftpRequest = null;
                /* Return the Directory Listing as a string Array by Parsing 'directoryRaw' with the Delimiter you Append (I use | in This Example) */
                try { string[] directoryList = directoryRaw.Split("|".ToCharArray()); return directoryList; }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            /* Return an Empty string Array if an Exception Occurs */
            return new string[] { "" };
        }

        /* List Directory Contents in Detail (Name, Size, Created, etc.) */
        public string[] directoryListDetailed(string directory)
        {
            try
            {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + host + ":" + port + "/" + directory));
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Establish Return Communication with the FTP Server */
                ftpStream = ftpResponse.GetResponseStream();
                /* Get the FTP Server's Response Stream */
                StreamReader ftpReader = new StreamReader(ftpStream);
                /* Store the Raw Response */
                string directoryRaw = null;
                /* Read Each Line of the Response and Append a Pipe to Each Line for Easy Parsing */
                try { while (ftpReader.Peek() != -1) { directoryRaw += ftpReader.ReadLine() + "|"; } }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                /* Resource Cleanup */
                ftpReader.Close();
                ftpStream.Close();
                ftpResponse.Close();
                ftpRequest = null;
                /* Return the Directory Listing as a string Array by Parsing 'directoryRaw' with the Delimiter you Append (I use | in This Example) */
                try { string[] directoryList = directoryRaw.Split("|".ToCharArray()); return directoryList; }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            /* Return an Empty string Array if an Exception Occurs */
            return new string[] { "" };
        }
        public Image getImageUrl(string Url)
        {
            try
            {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)WebRequest.Create(new Uri(Url));
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                Image getImage = null;
                using (var stream = ftpResponse.GetResponseStream())
                {
                    getImage = Bitmap.FromStream(stream);
                }
                /* Resource Cleanup */
                ftpResponse.Close();
                ftpRequest = null;
                return getImage;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return null;
        }
        public Image getImageUrl(string Url, string Host)
        {
            try
            {
                // ----------------
                // Lấy đường dẫn host từ tham số hệ thống
                // CreateBy: truongnm 30-10-2017
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)WebRequest.Create(new Uri(Host + Url));
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                Image getImage = null;
                using (var stream = ftpResponse.GetResponseStream())
                {
                    getImage = Bitmap.FromStream(stream);
                }
                /* Resource Cleanup */
                ftpResponse.Close();
                ftpRequest = null;
                return getImage;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return null;
        }
        public FileInfo getPDFUrl(string Url)
        {
            try
            {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)WebRequest.Create(new Uri(Url));
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                FileInfo getPDF = null;
                using (var stream = ftpResponse.GetResponseStream())
                {

                }
                /* Resource Cleanup */
                ftpResponse.Close();
                ftpRequest = null;
                return getPDF;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return null;
        }
        public FileInfo getPDFUrl(string Url, string Host)
        {
            try
            {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)WebRequest.Create(new Uri(Host + Url));
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                FileInfo getPDF = null;
                using (var stream = ftpResponse.GetResponseStream())
                {

                }
                /* Resource Cleanup */
                ftpResponse.Close();
                ftpRequest = null;
                return getPDF;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return null;
        }
        
        #endregion
        /////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////
        #region Override
        
        #endregion
        /////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////
        #region Event
        
        #endregion
        /////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.SqlServer.Dts.Runtime;
using System.Windows.Forms;
using System.IO;
using Tamir.SharpSsh;

namespace SSHFTPTask
{
    [
    DtsTask
        (
        DisplayName = "SSHFTPTask",
        Description = "SSHFTPTask",
        UITypeName = "SSHFTPTaskUI.SSHFTPTaskUI,SSHFTPTaskUI,Version=1.0.0.0,Culture=Neutral,PublicKeyToken=0dac3d2710f330b6")
    ]
    public class SSHFTPTask : Task, IDTSComponentPersist
    {
        public string SSHConnMgrName
        {
            get { return _SSHconnMgrName; }
            set { _SSHconnMgrName = value; }
        }
        private string _SSHconnMgrName;

        public string SendFilesSourceConnectionManagerName
        {
            get { return _sendFilesSourceConnectionManagerName; }
            set { _sendFilesSourceConnectionManagerName = value; }
        }
        private string _sendFilesSourceConnectionManagerName;

        public string SendFilesDestinationDirectory
        {
            get { return _sendFilesDestinationDirectory; }
            set { _sendFilesDestinationDirectory = value; }
        }
        private string _sendFilesDestinationDirectory;

        public string ReceiveFilesDestinationConnectionManagerName
        {
            get { return _receiveFilesDestinationConnectionManagerName; }
            set { _receiveFilesDestinationConnectionManagerName = value; }
        }
        private string _receiveFilesDestinationConnectionManagerName;

        public string ReceiveFilesSourceFile
        {
            get { return _receiveFilesSourceFile; }
            set { _receiveFilesSourceFile = value; }
        }
        private string _receiveFilesSourceFile;

        public SSHFTPOperation Operation
        {
            get { return _operation; }
            set { _operation = value; }
        }
        private SSHFTPOperation _operation;

        public override DTSExecResult Validate(Connections connections, VariableDispenser variableDispenser, IDTSComponentEvents componentEvents, IDTSLogging log)
        {

            //SSH Connection Manager
            if (StringUtil.NullOrEmpty(_SSHconnMgrName))
            {
                fireError(componentEvents, "No SSH Connection Manager selected.");
                return DTSExecResult.Failure;
            }
            ConnectionManager cSSH = getConnectionManager(connections, _SSHconnMgrName);
            if (cSSH == null)
            {
                fireError(componentEvents, "No SSH Connection Manager selected.");
                return DTSExecResult.Failure;
            }

            //Send Files
            if (_operation == SSHFTPOperation.SendFiles)
            {
                if (StringUtil.NullOrEmpty(_sendFilesSourceConnectionManagerName))
                {
                    fireError(componentEvents, "No Send Files Source Connection Manager selected.");
                    return DTSExecResult.Failure;
                }
                ConnectionManager cSend = getConnectionManager(connections, _sendFilesSourceConnectionManagerName);
                if (cSend == null)
                {
                    fireError(componentEvents, "No Send Files Source Connection Manager selected.");
                    return DTSExecResult.Failure;
                }
                if (StringUtil.NullOrEmpty(_sendFilesDestinationDirectory))
                {
                    fireError(componentEvents, "No Send Files Destination Directory Specified.");
                    return DTSExecResult.Failure;
                }
            }

            //Receive Files
            if (_operation == SSHFTPOperation.ReceiveFiles)
            {
                if (StringUtil.NullOrEmpty(_receiveFilesDestinationConnectionManagerName))
                {
                    fireError(componentEvents, "No Receive Files Destination Connection Manager selected.");
                    return DTSExecResult.Failure;
                }
                ConnectionManager cReceive = getConnectionManager(connections, _receiveFilesDestinationConnectionManagerName);
                if (cReceive == null)
                {
                    fireError(componentEvents, "No Receive Files Destination Connection Manager selected.");
                    return DTSExecResult.Failure;
                }
                if (StringUtil.NullOrEmpty(_receiveFilesSourceFile))
                {
                    fireError(componentEvents, "No Receive Files Source File specified.");
                    return DTSExecResult.Failure;
                }
            }
            return DTSExecResult.Success;
        }

        private void fireError(IDTSComponentEvents componentEvents, string description)
        {
            componentEvents.FireError(0, "SSHFTPTask", description, "", 0);
        }

        private bool isDirectory(string path)
        {
            return (File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory;
        }

        private ConnectionManager getConnectionManager(Connections connections, string name)
        {
            ConnectionManager c = null;
            foreach (ConnectionManager conn in connections)
            {
                if (conn.Name == name)
                {
                    c = conn;
                }
            }
            return c;
        }

        public override DTSExecResult Execute(Connections connections, VariableDispenser variableDispenser, IDTSComponentEvents componentEvents, IDTSLogging log, object transaction)
        {
            ConnectionManager cSSH = getConnectionManager(connections, _SSHconnMgrName);
            List<KeyValuePair<string, string>> connParams = (List<KeyValuePair<string, string>>)cSSH.AcquireConnection(transaction);

            string host = connParams.Find(t => t.Key == "Host").Value;
            string username = connParams.Find(t => t.Key == "Username").Value;
            string password = connParams.Find(t => t.Key == "Password").Value;
            int port = Convert.ToInt32(connParams.Find(t => t.Key == "Port").Value);

            if (_operation == SSHFTPOperation.SendFiles)
            {
                ConnectionManager cSend = getConnectionManager(connections, _sendFilesSourceConnectionManagerName);
                string sourceFile = cSend.AcquireConnection(transaction).ToString();
                SshTransferProtocolBase sshCp;
                sshCp = new Sftp(host, username);
                sshCp.Password = password;
                string localFile = sourceFile;
                string remoteFile = getRemotePathAndFile(_sendFilesDestinationDirectory, Path.GetFileName(sourceFile));
                try
                {
                    sshCp.Connect();
                    sshCp.Put(localFile, remoteFile);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    sshCp.Close();
                }
            }
            if (_operation == SSHFTPOperation.ReceiveFiles)
            {
                ConnectionManager cReceive = getConnectionManager(connections, _receiveFilesDestinationConnectionManagerName);
                string destinationDirectory = cReceive.AcquireConnection(transaction).ToString();
                SshTransferProtocolBase sshCp;
                sshCp = new Sftp(host, username);
                sshCp.Password = password;
                try
                {
                    sshCp.Connect();
                    sshCp.Get(_receiveFilesSourceFile, destinationDirectory);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    sshCp.Close();
                }
            }
            
            return DTSExecResult.Success;
        }

        private static string getRemotePathAndFile(string pathBase, string fileName)
        {
            StringBuilder sb = new StringBuilder();
            if (pathBase.EndsWith("/"))
            {
                sb.Append(pathBase);
                sb.Append(fileName);
            }
            else
            {
                sb.Append(pathBase);
                sb.Append("/");
                sb.Append(fileName);
            }
            return sb.ToString();
        }

        #region IDTSComponentPersist Members

        public void LoadFromXML(System.Xml.XmlElement node, IDTSInfoEvents infoEvents)
        {
            if (node.Name != "SSHFTPTask")
            {
                throw new Exception("Unexpected task element when loading task.");
            }
            else
            {
                try
                {
                    _SSHconnMgrName = node.Attributes.GetNamedItem("SSHconnMgrName").Value;
                    _sendFilesSourceConnectionManagerName = node.Attributes.GetNamedItem("sendFilesSourceConnectionManagerName").Value;
                    _sendFilesDestinationDirectory = node.Attributes.GetNamedItem("sendFilesDestinationDirectory").Value;
                    _receiveFilesDestinationConnectionManagerName = node.Attributes.GetNamedItem("receiveFilesDestinationConnectionManagerName").Value;
                    _receiveFilesSourceFile = node.Attributes.GetNamedItem("receiveFilesSourceFile").Value;
                    if (node.Attributes.GetNamedItem("operation").Value == string.Empty) { _operation = SSHFTPOperation.SendFiles; }
                    if (node.Attributes.GetNamedItem("operation").Value == "SendFiles") { _operation = SSHFTPOperation.SendFiles; }
                    if (node.Attributes.GetNamedItem("operation").Value == "ReceiveFiles") { _operation = SSHFTPOperation.ReceiveFiles; }
                }
                catch
                {
                    throw;
                }
            }
        }

        public void SaveToXML(System.Xml.XmlDocument doc, IDTSInfoEvents infoEvents)
        {
            XmlElement taskElement = doc.CreateElement(string.Empty, "SSHFTPTask", string.Empty);
            
            XmlAttribute SSHconnMgrNameAttribute = doc.CreateAttribute(string.Empty, "SSHconnMgrName", string.Empty);
            SSHconnMgrNameAttribute.Value = _SSHconnMgrName;
            
            XmlAttribute sendFilesSourceConnectionManagerNameAttribute = doc.CreateAttribute(string.Empty, "sendFilesSourceConnectionManagerName", string.Empty);
            sendFilesSourceConnectionManagerNameAttribute.Value = _sendFilesSourceConnectionManagerName;
            
            XmlAttribute sendFilesDestinationDirectoryAttribute = doc.CreateAttribute(string.Empty, "sendFilesDestinationDirectory", string.Empty);
            sendFilesDestinationDirectoryAttribute.Value = _sendFilesDestinationDirectory;
            
            XmlAttribute receiveFilesDestinationConnectionManagerNameAttribute = doc.CreateAttribute(string.Empty, "receiveFilesDestinationConnectionManagerName", string.Empty);
            receiveFilesDestinationConnectionManagerNameAttribute.Value = _receiveFilesDestinationConnectionManagerName;
            
            XmlAttribute receiveFilesSourceFileAttribute = doc.CreateAttribute(string.Empty, "receiveFilesSourceFile", string.Empty);
            receiveFilesSourceFileAttribute.Value = _receiveFilesSourceFile;
            
            XmlAttribute operationAttribute = doc.CreateAttribute(string.Empty, "operation", string.Empty);
            operationAttribute.Value = _operation.ToString();

            taskElement.Attributes.Append(SSHconnMgrNameAttribute);
            taskElement.Attributes.Append(sendFilesSourceConnectionManagerNameAttribute);
            taskElement.Attributes.Append(sendFilesDestinationDirectoryAttribute);
            taskElement.Attributes.Append(receiveFilesDestinationConnectionManagerNameAttribute);
            taskElement.Attributes.Append(receiveFilesSourceFileAttribute);
            taskElement.Attributes.Append(operationAttribute);
            doc.AppendChild(taskElement);
        }

        #endregion
    }

    public enum SSHFTPOperation
    {
        SendFiles,
        ReceiveFiles
    }
}

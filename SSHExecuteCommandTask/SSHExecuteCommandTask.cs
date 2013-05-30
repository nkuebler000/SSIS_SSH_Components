using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Dts.Runtime;
using System.Xml;
using Tamir.SharpSsh;
using System.IO;

namespace SSHExecuteCommandTask
{
    [
    DtsTask
        (
        DisplayName = "SSHExecuteCommandTask",
        Description = "SSHExecuteCommandTask",
        UITypeName = "SSHExecuteCommandTaskUI.SSHExecuteCommandTaskUI,SSHExecuteCommandTaskUI,Version=1.0.0.0,Culture=Neutral,PublicKeyToken=2e13f3dd909f5beb")
    ]
    public class SSHExecuteCommandTask : Task, IDTSComponentPersist
    {
        public string CommandText
        {
            get { return _commandText; }
            set { _commandText = value; }
        }
        private string _commandText;

        public string ConnMgrName
        {
            get { return _connMgrName; }
            set { _connMgrName = value; }
        }
        private string _connMgrName;

        public override DTSExecResult Validate(Connections connections, VariableDispenser variableDispenser, IDTSComponentEvents componentEvents, IDTSLogging log)
        {
            if (StringUtil.NullOrEmpty(_connMgrName)) 
            { 
                fireError(componentEvents, "No Connection Manager selected."); 
                return DTSExecResult.Failure; 
            }
            ConnectionManager c = getCurrentConnectionManager(connections);
            if (c == null) 
            {
                fireError(componentEvents, "No Connection Manager selected.");
                return DTSExecResult.Failure; 
            }
            if (c.Properties["Host"].GetValue(c) == null) 
            {
                fireError(componentEvents, "Host not configured.");
                return DTSExecResult.Failure; 
            }
            if (StringUtil.NullOrEmpty(c.Properties["Host"].GetValue(c).ToString())) 
            {
                fireError(componentEvents, "Host not configured.");
                return DTSExecResult.Failure; 
            }
            if (c.Properties["Username"].GetValue(c) == null) 
            {
                fireError(componentEvents, "Username not configured.");
                return DTSExecResult.Failure; 
            }
            if (StringUtil.NullOrEmpty(c.Properties["Username"].GetValue(c).ToString())) 
            {
                fireError(componentEvents, "Username not configured.");
                return DTSExecResult.Failure; 
            }
            if (c.Properties["Password"].GetValue(c) == null) 
            {
                fireError(componentEvents, "Password not configured.");
                return DTSExecResult.Failure; 
            }
            if (StringUtil.NullOrEmpty(c.Properties["Password"].GetValue(c).ToString())) 
            {
                fireError(componentEvents, "Password not configured.");
                return DTSExecResult.Failure; 
            }
            return DTSExecResult.Success;
        }

        private void fireError(IDTSComponentEvents componentEvents, string description)
        {
            componentEvents.FireError(0, "SSHExecuteCommandTask", description, "", 0);
        }

        private ConnectionManager getCurrentConnectionManager(Connections connections)
        {
            ConnectionManager c = null;
            foreach (ConnectionManager conn in connections)
            {
                if (conn.Name == _connMgrName)
                {
                    c = conn;
                }
            }
            return c;
        }

        public override DTSExecResult Execute(Connections connections, VariableDispenser variableDispenser, IDTSComponentEvents componentEvents, IDTSLogging log, object transaction)
        {
            ConnectionManager conn = getCurrentConnectionManager(connections);
            List<KeyValuePair<string, string>> connParams = (List<KeyValuePair<string, string>>)conn.AcquireConnection(transaction);

            string host = connParams.Find(t => t.Key == "Host").Value;
            string username = connParams.Find(t => t.Key == "Username").Value;
            string password = connParams.Find(t => t.Key == "Password").Value;
            int port = Convert.ToInt32(connParams.Find(t => t.Key == "Port").Value);

            SshExec exec = new SshExec(host, username);
            exec.Password = password;

            try
            {
                string stdOut = string.Empty;
                string stdErr = string.Empty;
                exec.Connect();
                StringReader sr = new StringReader(_commandText);
                while (true)
                {
                    string s = sr.ReadLine();
                    if (s != null && stdErr.Trim().Length == 0)
                    {
                        int res = exec.RunCommand(s, ref stdOut, ref stdErr);
                    }
                    else
                    {
                        if (stdErr.Trim().Length > 0)
                        {
                            fireError(componentEvents, stdErr);
                            return DTSExecResult.Failure;
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                fireError(componentEvents, ex.Message);
                return DTSExecResult.Failure;
            }
            finally
            {
                exec.Close();
            }
            return DTSExecResult.Success;
        }

        

        #region IDTSComponentPersist Members

        public void LoadFromXML(XmlElement node, IDTSInfoEvents infoEvents)
        {
            if (node.Name != "SSHExecuteCommandTask")
            {
                throw new Exception("Unexpected task element when loading task.");
            }
            else
            {
                try
                {
                    _commandText = node.Attributes.GetNamedItem("commandText").Value.Replace("\n", Environment.NewLine);
                    _connMgrName = node.Attributes.GetNamedItem("connMgrName").Value;
                }
                catch
                {
                    throw;
                }
            }
        }

        public void SaveToXML(XmlDocument doc, IDTSInfoEvents infoEvents)
        {
            XmlElement taskElement = doc.CreateElement(string.Empty, "SSHExecuteCommandTask", string.Empty);
            XmlAttribute commandTextAttribute = doc.CreateAttribute(string.Empty, "commandText", string.Empty);
            commandTextAttribute.Value = _commandText;
            XmlAttribute connMgrNameAttribute = doc.CreateAttribute(string.Empty, "connMgrName", string.Empty);
            connMgrNameAttribute.Value = _connMgrName;
            taskElement.Attributes.Append(commandTextAttribute);
            taskElement.Attributes.Append(connMgrNameAttribute);
            doc.AppendChild(taskElement);
        }

        #endregion
    }
}

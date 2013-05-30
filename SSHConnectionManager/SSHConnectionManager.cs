using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Dts.Runtime;

namespace SSHConnectionManager
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces"),
        DtsConnection(ConnectionType = "SSH", DisplayName = "SSHConnectionManager",
        Description = "Connection manager for SSH",
        UITypeName = "SSHConnectionManagerUI.SSHConnectionManagerUI,SSHConnectionManagerUI,Version=1.0.0.0,Culture=neutral,PublicKeyToken=5085fbac57c1b404")]
    public class SSHConnectionManager : ConnectionManagerBase
    {
        public string Host
        {
            get { return _host; }
            set { _host = value; }
        }
        private string _host = string.Empty;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        private string _username = string.Empty;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        private string _password = string.Empty;

        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }
        private int _port = 22;

        public override object AcquireConnection(object txn)
        {
            List<KeyValuePair<string, string>> connParams = new List<KeyValuePair<string, string>>();
            connParams.Add(new KeyValuePair<string, string>("Host", _host));
            connParams.Add(new KeyValuePair<string, string>("Username", _username));
            connParams.Add(new KeyValuePair<string, string>("Password", _password));
            connParams.Add(new KeyValuePair<string, string>("Port", _port.ToString()));
            return connParams;
        }

        public override DTSExecResult Validate(IDTSInfoEvents infoEvents)
        {
            if (StringUtil.NullOrEmpty(_host)) 
            {
                infoEvents.FireError(0, "SSHConnectionManager", "Host cannot be null or empty.", string.Empty, 0);
                return DTSExecResult.Failure; 
            }
            if (StringUtil.NullOrEmpty(_username)) 
            {
                infoEvents.FireError(0, "SSHConnectionManager", "Username cannot be null or empty.", string.Empty, 0);
                return DTSExecResult.Failure; 
            }
            if (StringUtil.NullOrEmpty(_password)) 
            {
                infoEvents.FireError(0, "SSHConnectionManager", "Password cannot be null or empty.", string.Empty, 0);
                return DTSExecResult.Failure; 
            }
            if (_port < 0 || _port > 65535) 
            {
                infoEvents.FireError(0, "SSHConnectionManager", "Password cannot be null or empty.", string.Empty, 0);
                return DTSExecResult.Failure; 
            }
            return base.Validate(infoEvents);
        }
    }
}

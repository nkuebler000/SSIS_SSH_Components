using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Dts.Runtime;
using SSHConnectionManager;

namespace SSHConnectionManagerUI
{
    public partial class SSHConnectionManagerUIForm : Form
    {

        private ConnectionManager _connectionManager;
        private IServiceProvider _serviceProvider;

        public string Host
        {
            get { return _host; }
            set { _host = value; }
        }
        private string _host;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        private string _username;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        private string _password;

        public string Port
        {
            get { return _port; }
            set { _port = value; }
        }
        private string _port;

        public SSHConnectionManagerUIForm()
        {
            InitializeComponent();
        }

        private void SSHConnectionManagerUI_Load(object sender, EventArgs e)
        {
            
        }

        public void Initialize(ConnectionManager connectionManager, IServiceProvider serviceProvider)
        {
            this._connectionManager = connectionManager;
            this._serviceProvider = serviceProvider;
            
            ConfigureControlsFromConnectionManager();
        }

        private void ConfigureControlsFromConnectionManager()
        {
            string tmpName =
                _connectionManager.Name;
            string tmpHost = 
                _connectionManager.Properties["Host"].GetValue(_connectionManager).ToString();
            string tmpUsername = 
                _connectionManager.Properties["Username"].GetValue(_connectionManager).ToString();
            string tmpPassword =
                _connectionManager.Properties["Password"].GetValue(_connectionManager).ToString();
            string tmpPort = 
                _connectionManager.Properties["Port"].GetValue(_connectionManager).ToString();
            
            if (!StringUtil.NullOrEmpty(tmpHost))
            {
                NametextBox.Text = tmpName;
            }
            if (!StringUtil.NullOrEmpty(tmpHost))
            {
                _host = tmpHost;
                HosttextBox.Text = tmpHost;
            }
            if (!StringUtil.NullOrEmpty(tmpUsername))
            {
                _username = tmpUsername;
                UsernametextBox.Text = tmpUsername;
            }
            if (!StringUtil.NullOrEmpty(tmpPassword))
            {
                _password = tmpPassword;
                PasswordtextBox.Text = tmpPassword;
            }
            if (!StringUtil.NullOrEmpty(tmpPort))
            {
                _port = tmpPort;
                PorttextBox.Text = tmpPort;
            }
        }

        private void ConfigureConnectionManagerFromControls()
        {
            string name = NametextBox.Text;
            string tmpHost = HosttextBox.Text;
            string tmpUsername = UsernametextBox.Text;
            string tmpPassword = PasswordtextBox.Text;
            int tmpPort = 0;
            try
            {
                tmpPort = Convert.ToInt32(PorttextBox.Text);
            }
            catch { }

            _connectionManager.Name = name;
            _connectionManager.Properties["Host"].SetValue(_connectionManager, tmpHost);
            _connectionManager.Properties["Username"].SetValue(_connectionManager, tmpUsername);
            _connectionManager.Properties["Password"].SetValue(_connectionManager, tmpPassword);
            _connectionManager.Properties["Port"].SetValue(_connectionManager, tmpPort);
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            ConfigureConnectionManagerFromControls();
            this.DialogResult = DialogResult.OK;
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

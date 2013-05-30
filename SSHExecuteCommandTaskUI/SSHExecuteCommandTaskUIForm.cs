using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Dts.Runtime;
using Microsoft.SqlServer.Dts.Runtime.Design;
using SSHConnectionManager;

namespace SSHExecuteCommandTaskUI
{
    public partial class SSHExecuteCommandTaskUIForm : Form
    {
        private TaskHost _taskHostValue;
        private IServiceProvider _serviceProvider;
        private IDtsConnectionService _dtsConnectionService;
        private string _commandText;
        private string _connMgrName;

        public SSHExecuteCommandTaskUIForm(TaskHost taskHostValue, IServiceProvider serviceProvider)
        {
            _taskHostValue = taskHostValue;
            _serviceProvider = serviceProvider;
            InitializeComponent();
            if (_taskHostValue.Properties["CommandText"].GetValue(_taskHostValue) != null)
            {
                _commandText = _taskHostValue.Properties["CommandText"].GetValue(_taskHostValue).ToString();
            }
            //ConnMgrName
            if (_taskHostValue.Properties["ConnMgrName"].GetValue(_taskHostValue) != null)
            {
                _connMgrName = _taskHostValue.Properties["ConnMgrName"].GetValue(_taskHostValue).ToString();
            }

            IDtsConnectionService dtsConnectionService =
                    (IDtsConnectionService)serviceProvider.GetService(typeof(IDtsConnectionService));
            _dtsConnectionService = dtsConnectionService;


            PopulateConnectionsCombo(ConnectionManagercomboBox, "SSH", _connMgrName);
            
        }

        private void SSHExecuteCommandTaskUIForm_Load(object sender, EventArgs e)
        {
            CommandTexttextBox.Text = _commandText;
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            _taskHostValue.Properties["ConnMgrName"].SetValue(_taskHostValue, _connMgrName);
            _taskHostValue.Properties["CommandText"].SetValue(_taskHostValue, CommandTexttextBox.Text);
            this.DialogResult = DialogResult.OK;
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void PopulateConnectionsCombo(ComboBox comboBox, string connectionType, string selectedItem)
        {
            // Prepare combo box by clearing, and adding the new connection item.
            comboBox.Items.Clear();
            comboBox.Items.Add("<New connection...>");

            // Enumerate connections, but for type supported.
            foreach (ConnectionManager connectionManager in
               _dtsConnectionService.GetConnectionsOfType(connectionType))
            {
                comboBox.Items.Add(connectionManager.Name);
            }

            // Set currently selected connection
            comboBox.SelectedItem = selectedItem;
        }

        private void ConnectionManagercomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboxBox = (ComboBox)sender;

            // Check for index 0 and <New Item...>
            if (comboxBox.SelectedIndex == 0)
            {
                // Use connection service to create a new connection.
                ArrayList newConns = _dtsConnectionService.CreateConnection("SSH");
                if (newConns.Count > 0)
                {
                    // A new connection has been created, so populate and select
                    ConnectionManager newConn = (ConnectionManager)newConns[0];
                    _connMgrName = newConn.Name;
                    PopulateConnectionsCombo(comboxBox, "SSH", newConn.Name);
                }
                else
                {
                    // Create connection has been cancelled
                    comboxBox.SelectedIndex = -1;
                }
            }
            else
            {
                _connMgrName = ConnectionManagercomboBox.SelectedItem.ToString();
            }
        }
    }
}

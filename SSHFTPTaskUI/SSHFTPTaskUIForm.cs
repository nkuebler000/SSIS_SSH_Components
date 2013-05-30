using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Dts.Runtime;
using Microsoft.SqlServer.Dts.Runtime.Design;
using SSHFTPTask;

namespace SSHFTPTaskUI
{
    public partial class SSHFTPTaskUIForm : Form
    {
        private TaskHost _taskHostValue;
        private IServiceProvider _serviceProvider;
        private IDtsConnectionService _dtsConnectionService;

        private string _SSHconnMgrName;
        
        private string _sendFilesSourceConnectionManagerName;
        private string _receiveFilesDestinationConnectionManagerName;

        public SSHFTPTaskUIForm(TaskHost taskHostValue, IServiceProvider serviceProvider)
        {
            _taskHostValue = taskHostValue;
            _serviceProvider = serviceProvider;
            InitializeComponent();
            if (_taskHostValue.Properties["SSHConnMgrName"].GetValue(_taskHostValue) != null)
            {
                _SSHconnMgrName = _taskHostValue.Properties["SSHConnMgrName"].GetValue(_taskHostValue).ToString();
            }
            if (_taskHostValue.Properties["SendFilesSourceConnectionManagerName"].GetValue(_taskHostValue) != null)
            {
                _sendFilesSourceConnectionManagerName = _taskHostValue.Properties["SendFilesSourceConnectionManagerName"].GetValue(_taskHostValue).ToString();
            }
            if (_taskHostValue.Properties["SendFilesDestinationDirectory"].GetValue(_taskHostValue) != null)
            {
                SendFilesDestinationdirectorytextBox.Text = _taskHostValue.Properties["SendFilesDestinationDirectory"].GetValue(_taskHostValue).ToString();
            }
            if (_taskHostValue.Properties["ReceiveFilesDestinationConnectionManagerName"].GetValue(_taskHostValue) != null)
            {
                _receiveFilesDestinationConnectionManagerName = _taskHostValue.Properties["ReceiveFilesDestinationConnectionManagerName"].GetValue(_taskHostValue).ToString();
            }
            if (_taskHostValue.Properties["ReceiveFilesSourceFile"].GetValue(_taskHostValue) != null)
            {
                 ReceiveFilesSourceFiletextBox.Text = _taskHostValue.Properties["ReceiveFilesSourceFile"].GetValue(_taskHostValue).ToString();
            }
            if (_taskHostValue.Properties["Operation"].GetValue(_taskHostValue) != null)
            {
                if ((SSHFTPOperation)_taskHostValue.Properties["Operation"].GetValue(_taskHostValue) == SSHFTPOperation.SendFiles)
                {
                    OperationTypecomboBox.SelectedIndex = 0;
                }
                if ((SSHFTPOperation)_taskHostValue.Properties["Operation"].GetValue(_taskHostValue) == SSHFTPOperation.ReceiveFiles)
                {
                    OperationTypecomboBox.SelectedIndex = 1;
                }
            }
            setPanels(OperationTypecomboBox);


            IDtsConnectionService dtsConnectionService =
                    (IDtsConnectionService)serviceProvider.GetService(typeof(IDtsConnectionService));
            _dtsConnectionService = dtsConnectionService;
            //OperationTypecomboBox.SelectedIndex = 0;
            PopulateConnectionsCombo(SSHConnectioncomboBox, "SSH", _SSHconnMgrName, null);
            PopulateConnectionsCombo(SendFilesSourceConnectioncomboBox, "FILE",
                _sendFilesSourceConnectionManagerName, DTSFileConnectionUsageType.FileExists);
            PopulateConnectionsCombo(DestinationConnectioncomboBox, "FILE",
                _receiveFilesDestinationConnectionManagerName, DTSFileConnectionUsageType.FolderExists);
        }

        private void setPanels(ComboBox c)
        {
            if (c.SelectedItem.ToString() == "Send Files")
            {
                SendFilesPanel.Enabled = true;
                ReceiveFilesPanel.Enabled = false;

            }
            if (c.SelectedItem.ToString() == "Receive Files")
            {
                SendFilesPanel.Enabled = false;
                ReceiveFilesPanel.Enabled = true;
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            setPanels(OperationTypecomboBox);
        }


        private void PopulateConnectionsCombo(ComboBox comboBox, 
                                                string connectionType, 
                                                string selectedItem, 
                                                DTSFileConnectionUsageType? uType)
        {
            // Prepare combo box by clearing, and adding the new connection item.
            comboBox.Items.Clear();
            comboBox.Items.Add("<New connection...>");

            // Enumerate connections, but for type supported.
            ArrayList connMgrs = _dtsConnectionService.GetConnectionsOfType(connectionType);
            connMgrs = returnConnectionsOfType(connMgrs, uType);
            foreach (ConnectionManager connectionManager in connMgrs)
            {
                comboBox.Items.Add(connectionManager.Name);
            }

            // Set currently selected connection
            comboBox.SelectedItem = selectedItem;
        }

        private ArrayList returnConnectionsOfType(ArrayList connections, DTSFileConnectionUsageType? uType)
        {
            if (uType != null)
            {
                for (int i = connections.Count - 1; i >= 0; i--)
                {
                    ConnectionManager conn = (ConnectionManager)connections[i];
                    DTSFileConnectionUsageType tmpUtype =
                        (DTSFileConnectionUsageType)conn.Properties["FileUsageType"].GetValue(conn);
                    if (tmpUtype != uType) { connections.RemoveAt(i); }
                }
            }
            return connections;
        }
        

        private void SSHConnectioncomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConnectionsCombo_SelectedIndexChanged((ComboBox)sender, ref _SSHconnMgrName, "SSH", null, null);
        }

        private void ConnectionsCombo_SelectedIndexChanged(ComboBox comboxBox, 
                                                            ref string connMgrNameVariable, 
                                                            string connMgrType, 
                                                            ConnectionManagerUIArgs connUIargs,
                                                            DTSFileConnectionUsageType? uType)
        {

            // Check for index 0 and <New Item...>
            if (comboxBox.SelectedIndex == 0)
            {
                // Use connection service to create a new connection.
                ArrayList newConns = _dtsConnectionService.CreateConnection(connMgrType, connUIargs);
                if (newConns.Count > 0)
                {
                    // A new connection has been created, so populate and select
                    ConnectionManager newConn = (ConnectionManager)newConns[0];
                    connMgrNameVariable = newConn.Name;
                    PopulateConnectionsCombo(comboxBox, connMgrType, newConn.Name, uType);
                }
                else
                {
                    // Create connection has been cancelled
                    //comboxBox.SelectedIndex = -1;
                }
            }
            else
            {
                connMgrNameVariable = comboxBox.SelectedItem.ToString();
            }
        }

        private void SendFilesSourceConnectioncomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FileConnectionManagerUIArgs args = new FileConnectionManagerUIArgs();
            args.SupportedUsageTypes = new DTSFileConnectionUsageType[] { DTSFileConnectionUsageType.FileExists };
            ConnectionsCombo_SelectedIndexChanged(
                (ComboBox)sender, ref _sendFilesSourceConnectionManagerName, "FILE", args, DTSFileConnectionUsageType.FileExists);
        }

        private void DestinationConnectioncomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FileConnectionManagerUIArgs args = new FileConnectionManagerUIArgs();
            args.SupportedUsageTypes = new DTSFileConnectionUsageType[] { DTSFileConnectionUsageType.FolderExists };
            ConnectionsCombo_SelectedIndexChanged(
                (ComboBox)sender, ref _receiveFilesDestinationConnectionManagerName, "FILE", args, 
                DTSFileConnectionUsageType.FolderExists);
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            _taskHostValue.Properties["SSHConnMgrName"].SetValue(_taskHostValue, _SSHconnMgrName);
            _taskHostValue.Properties["SendFilesSourceConnectionManagerName"].SetValue(_taskHostValue, _sendFilesSourceConnectionManagerName);
            _taskHostValue.Properties["SendFilesDestinationDirectory"].SetValue(_taskHostValue, SendFilesDestinationdirectorytextBox.Text);
            _taskHostValue.Properties["ReceiveFilesDestinationConnectionManagerName"].SetValue(_taskHostValue, _receiveFilesDestinationConnectionManagerName);
            _taskHostValue.Properties["ReceiveFilesSourceFile"].SetValue(_taskHostValue, ReceiveFilesSourceFiletextBox.Text);
            if (OperationTypecomboBox.SelectedItem.ToString() == "Send Files") 
            {
                _taskHostValue.Properties["Operation"].SetValue(_taskHostValue, SSHFTPOperation.SendFiles);
            }
            if (OperationTypecomboBox.SelectedItem.ToString() == "Receive Files")
            {
                _taskHostValue.Properties["Operation"].SetValue(_taskHostValue, SSHFTPOperation.ReceiveFiles);
            }

            this.DialogResult = DialogResult.OK;
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

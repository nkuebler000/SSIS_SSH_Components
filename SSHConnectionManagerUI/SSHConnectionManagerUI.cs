using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Dts.Design;
using Microsoft.SqlServer.Dts.Runtime;
using Microsoft.SqlServer.Dts.Runtime.Wrapper;
using Microsoft.SqlServer.Dts.Runtime.Design;
using System.Windows.Forms;


namespace SSHConnectionManagerUI
{
    public class SSHConnectionManagerUI : IDtsConnectionManagerUI
    {
        private ConnectionManager _connectionManager;
        private IServiceProvider _serviceProvider;

        #region IDtsConnectionManagerUI Members

        public void Delete(IWin32Window parentWindow)
        {
            
        }

        public bool Edit(IWin32Window parentWindow, 
            Connections connections, ConnectionManagerUIArgs connectionUIArg)
        {
            return editSSHConnection(parentWindow);
        }

        public void Initialize(ConnectionManager connectionManager, IServiceProvider serviceProvider)
        {
            this._connectionManager = connectionManager;
            this._serviceProvider = serviceProvider;
        }

        public bool New(IWin32Window parentWindow, 
            Connections connections, ConnectionManagerUIArgs connectionUIArg)
        {
            IDtsClipboardService clipboardService;
            clipboardService = 
                (IDtsClipboardService)this._serviceProvider.GetService(typeof(IDtsClipboardService));

            // If connection manager has been copied and pasted, take no action.
            if (clipboardService != null)
            {
                if (clipboardService.IsPasteActive) { return true; }
            }
            return editSSHConnection(parentWindow);
        }

        #endregion

        private bool editSSHConnection(IWin32Window parentWindow)
        {
            SSHConnectionManagerUIForm sshCMUIForm = new SSHConnectionManagerUIForm();

            sshCMUIForm.Initialize(_connectionManager, this._serviceProvider);
            if (sshCMUIForm.ShowDialog(parentWindow) == DialogResult.OK)
            {
                sshCMUIForm.Dispose();
                return true;
            }
            else
            {
                sshCMUIForm.Dispose();
                return false;
            }
        }
    }
}

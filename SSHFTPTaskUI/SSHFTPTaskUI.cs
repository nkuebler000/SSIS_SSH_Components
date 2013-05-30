using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Dts.Runtime;
using Microsoft.SqlServer.Dts.Runtime.Design;
using System.Windows.Forms;

namespace SSHFTPTaskUI
{
    public class SSHFTPTaskUI : IDtsTaskUI
    {
        private TaskHost _taskHostValue;
        private IServiceProvider _serviceprovider;
        private SSHFTPTaskUIForm _frm;
        #region IDtsTaskUI Members

        public void Delete(IWin32Window parentWindow)
        {
            
        }

        public ContainerControl GetView()
        {
            return _frm;
        }

        public void Initialize(TaskHost taskHost, IServiceProvider serviceProvider)
        {
            _taskHostValue = taskHost;
            _serviceprovider = serviceProvider;
            _frm = new SSHFTPTaskUIForm(_taskHostValue, _serviceprovider);
        }

        public void New(IWin32Window parentWindow)
        {
            
        }

        #endregion
    }
}

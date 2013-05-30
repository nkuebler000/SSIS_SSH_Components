using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Dts.Runtime;
using Microsoft.SqlServer.Dts.Runtime.Design;
using System.Windows.Forms;

namespace SSHExecuteCommandTaskUI
{
    public class SSHExecuteCommandTaskUI : IDtsTaskUI
    {
        private TaskHost _taskHostValue;
        private IServiceProvider _serviceprovider;
        private SSHExecuteCommandTaskUIForm frm;
        #region IDtsTaskUI Members

        public void Delete(IWin32Window parentWindow)
        {
            
        }

        public System.Windows.Forms.ContainerControl GetView()
        {
            return frm;
        }

        public void Initialize(TaskHost taskHost, IServiceProvider serviceProvider)
        {
            _taskHostValue = taskHost;
            _serviceprovider = serviceProvider;
            frm = new SSHExecuteCommandTaskUIForm(_taskHostValue, _serviceprovider);
            
        }

        public void New(IWin32Window parentWindow)
        {
            
        }

        #endregion
    }
}

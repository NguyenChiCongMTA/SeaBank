using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using DevExpress.XtraRichEdit.Import.Html;
using Quartz;
using SafeControl.Base;
using SafeControl.Bussiness;
using SafeControl.Classes;
using SafeControl.Classes.JobConfig;
using SafeControl.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SafeControl
{
    public class RefreshDataJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            fBase fBase = new fBase();
            MCopyData.bCopyDataBaseFirebirdFormFilePathConfig(Application.StartupPath + Constants.FilePathConstant.DATABASE_COPY_DATABASE_CONFIG);
            fBase.Command_LoadDataBaseInfor();
        }
    }
}

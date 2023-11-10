using SafeControl.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SafeControl
{
    public partial class fUpdateVersion : fBaseDialog
    {
        public fUpdateVersion()
        {
            InitializeComponent();
        }
        public override void InitData()
        {
            base.InitData();
            this.mlb_TieuDe.Text = this.Text;
        }
    }
}

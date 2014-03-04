using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModbusSample
{
    public partial class MotorsControl : UserControl
    {
        public MotorsControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            tableLayoutPanel3.SuspendLayout();
            for (int row = 0; row < 12; row++)
            {
                for (int col = 0; col < 6; col++)
                {
                    var c = new MotorControl();
                    c.Visible = false;
                    c.Index = row * 6 + col;
                    c.Vendor = Vendor;
                    //Controls.Add(c);
                    tableLayoutPanel3.Controls.Add(c);
                    tableLayoutPanel3.SetCellPosition(c, new TableLayoutPanelCellPosition(col, row));
                    c.Visible = true;
                }
            }
            tableLayoutPanel3.ResumeLayout();
        }

        public Vendor Vendor { get; set; }
    }
}

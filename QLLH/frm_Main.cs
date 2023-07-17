using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLLH
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        private void quảnLýKhóaHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //code cho event click QLKH

            frm_QLKH f = new frm_QLKH();
            f.TopLevel = false;
            Main_pnl.Controls.Clear();
            Main_pnl.Controls.Add(f);
            f.Show();
        }
        private void quảnLýSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_QLSV f = new frm_QLSV();
            f.TopLevel = false;
            Main_pnl.Controls.Clear();
            Main_pnl.Controls.Add(f);
            f.Show();
        }
        private void quảnLýGiảngViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_QLGV f = new frm_QLGV();
            f.TopLevel = false;
            Main_pnl.Controls.Clear();
            Main_pnl.Controls.Add(f);
            f.Show();
        }
        private void quảnLýLớpHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_QLLH f = new frm_QLLH();
            f.TopLevel = false;
            Main_pnl.Controls.Clear();
            Main_pnl.Controls.Add(f);
            f.Show();
        }
        private void frm_Main_Resize(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form f in fc) 
            { 
                if(f.Name == "frm_QLKH"|| f.Name == "frm_QLSV"|| f.Name == "frm_QLGV")
                {
                    f.Height = Main_pnl.Height;
                    f.Width = Main_pnl.Width;
                }
            }
            
        }

       
    }
}

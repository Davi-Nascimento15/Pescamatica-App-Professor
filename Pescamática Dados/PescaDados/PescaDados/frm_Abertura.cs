using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PescaDados
{
    public partial class frm_Abertura : Form
    {
        int tempo = 3;
        public frm_Abertura()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tempo--;
            if (tempo == 0)
            {
                timer1.Stop();
                Close();

            }
        }
        private void frm_Abertura_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}

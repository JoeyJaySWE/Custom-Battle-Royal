using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fighters_of_Fantacy.Forms
{
    public partial class NewFighter : Form
    {
        public NewFighter()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MainMenu.NavTo(new MainMenu());
        }
    }
}

using DevExpress.LookAndFeel;
using Fighters_of_Fantacy.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fighters_of_Fantacy
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();


            

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           
            NavTo(new NewFighter());
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {

        }

        public static void NavTo(Form newForm)
        {
            Form currentForm = Application.OpenForms[0];

            // Close the current form
            currentForm.Close();

            // Show the new form
            newForm.StartPosition = FormStartPosition.CenterScreen; // Optionally center the new form
            Application.Run(newForm);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceExample
{
    public partial class Form1 : Form
    {
        NumberService numberServce;

        public Form1()
        {
            InitializeComponent();

            numberServce = new NumberService();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResultLabel.Text = numberServce.ReturnResults(NumberBox1.Text, NumberBox2.Text);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AWForm
{
    public partial class Form1 : Form
    {

        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            int id = Int32.Parse(TBId.Text);
            viewerControl1.DefineID(id);
            viewerControl1.SearchImgAndButtons(id);
            
        }

        private void Form1_Load(object sender, EventArgs e)
            {
                TBId.Text = "5";

            }
    }    
}

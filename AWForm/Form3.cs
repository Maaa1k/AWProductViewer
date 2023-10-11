using AWProductViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AWForm
{
    public partial class Form3 : Form
    {

        private List<int> lengthProducts = new List<int>();
        
        private int counter = 0;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            DataAccess db = new DataAccess();
            lengthProducts = db.totalValueProducts();


            AddTwoProducts();

        }

        private int notDuplicate(int random)
        {
            Boolean exit = true;
            List<int> productsNotRepeat = new List<int>();

            Random rnd = new Random();
            while (exit)
            {
                foreach (var number in lengthProducts)
                {
                    Boolean locker = false;
                    foreach (var scan in productsNotRepeat)
                    {
                        if (scan == number)
                        {
                            locker = true;
                        }
                    }

                    if (locker != true)
                    {
                        productsNotRepeat.Add(number);
                        exit = false;

                    }
                    else
                    {
                        random = rnd.Next(lengthProducts.Count);
                    }
                }
            }
            return random;
        }

        private void AddTwoProducts()
        {
            
            

            for (int i = 0; i < 2; i++)
            {
                
                Random rnd = new Random();
                int random = rnd.Next(lengthProducts.Count);

                if (counter != 0)
                {
                    notDuplicate(random);
                }


                ViewerControl aW = new ViewerControl();

                controlFlowLayoutPanel.Controls.Add(aW);
                aW.DefineID(random);
                aW.SearchImgAndButtons(random);
                counter++;

                if (lengthProducts == null)
                {
                    MessageBox.Show("The list is Empty");
                    i = 2;
                }
            }

        }

        private void generateButton_MouseClick(object sender, MouseEventArgs e)
        {
            AddTwoProducts();
        }
    }
}

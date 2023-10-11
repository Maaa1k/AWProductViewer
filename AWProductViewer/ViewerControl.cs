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

namespace AWProductViewer
{
    public partial class ViewerControl : UserControl
    {
        List<Product> c = new List<Product>();
        private int _productModelID;
        private string size = null;
        private string color = null;
        private string bgColorBttn = null;
        private string bgSizeBttn = null;
        int filler = 341;
        Product productSingular = new Product();

        public ViewerControl()
        {
            InitializeComponent();
        }

        public void SearchImgAndButtons(int id)
        {
            _productModelID = id;
            
            

            Product photoProduct = new Product();
            PNLColor.Controls.Clear();
            PNLSize.Controls.Clear();

            DataAccess db2 = new DataAccess();
            c = db2.GetColors(_productModelID);

//          Buscamos el Product Model, si no tiene photoProduct pongo por defecto la 341
            DataAccess db = new DataAccess();
            try
            {
                string test = db.ShowProductModel("en", _productModelID).First().ToString();



                int filler = 341;

                photoProduct = db.GetPhoto(_productModelID);
                if (photoProduct != null)
                {
                    byte[] photo = photoProduct.LargePhoto;
                    MemoryStream ms = new MemoryStream(photo);
                    Image image = Image.FromStream(ms);
                    PBProduct.Image = image;
                }
                else
                {
                    photoProduct = db.GetPhoto(filler);
                    byte[] photo = photoProduct.LargePhoto;
                    MemoryStream ms = new MemoryStream(photo);
                    Image image = Image.FromStream(ms);
                    PBProduct.Image = image;

                }

            }
            catch
            {
                MessageBox.Show("Image Error", "Error", MessageBoxButtons.OK);
            }


            // Eliminamos colores y tallas repetidas
            if (c.Count != 0)

            {
                Product holder = c.First();


                List<Product> notRepeatC = new List<Product>();
                List<Product> notRepeatS = new List<Product>();

                foreach (var button in c)
                {
                    Boolean hola = false;
                    foreach (var rep in notRepeatC)
                    {

                        if (rep.Color == button.Color)
                        {
                            hola = true;
                        }

                    }
                    if (hola != true)
                    {
                        notRepeatC.Add(button);
                    }
                }

                foreach (var button in c)
                {
                    Boolean hola = false;
                    foreach (var rep in notRepeatS)
                    {

                        if (rep.Size == button.Size)
                        {
                            hola = true;
                        }

                    }
                    if (hola != true)
                    {
                        notRepeatS.Add(button);
                    }
                }

                color = notRepeatC.First().Color;
                size = notRepeatS.First().Size;

                // Creamos botones de color y talla

                if (color != null)
                {
                    int count = 0;
                    foreach (Product productColor in notRepeatC)
                    {

                        Button newButton = new Button();
                        newButton.Name = productColor.ProductID.ToString();
                        if (count == 0)
                        {
                            newButton.BackColor = Color.DarkGray;
                            count++;
                        }
                        newButton.Text = productColor.Color;
                        newButton.Click += SearchColor;
                        PNLColor.Controls.Add(newButton);

                    }
                    bgColorBttn = color;
                    int id_Product = db.GetPrice(_productModelID, color, size).ProductID;
                    TBId.Text = id_Product.ToString();

                    DataAccess db4 = new DataAccess();
                    Product photoProduct3 = db4.GetPhoto(id_Product);

                    if (photoProduct != null)
                    {
                        byte[] photo = photoProduct3.LargePhoto;
                        MemoryStream ms = new MemoryStream(photo);
                        Image image = Image.FromStream(ms);
                        PBProduct.Image = image;
                    }
                    else
                    {
                        photoProduct = db4.GetPhoto(filler);
                        byte[] photo = photoProduct3.LargePhoto;
                        MemoryStream ms = new MemoryStream(photo);
                        Image image = Image.FromStream(ms);
                        PBProduct.Image = image;

                    }

                }

                if (size != null)
                {
                    int countSize = 0;
                    foreach (Product productSize in notRepeatS)
                    {
                        Button newButton = new Button();
                        newButton.Name = productSize.ProductID.ToString();
                        if (countSize == 0)
                        {
                            newButton.BackColor = Color.DarkGray;
                            countSize++;
                        }
                        newButton.Text = productSize.Size;
                        newButton.Click += SearchSize;
                        PNLSize.Controls.Add(newButton);
                    }

                    bgSizeBttn = size;

                    int id_Product = db.GetPrice(_productModelID, color, size).ProductID;
                    TBId.Text = id_Product.ToString();

                    DataAccess db3 = new DataAccess();
                    Product photoProduct2 = db3.GetPhoto(id_Product);

                    if (photoProduct != null)
                    {
                        byte[] photo = photoProduct2.LargePhoto;
                        MemoryStream ms = new MemoryStream(photo);
                        Image image = Image.FromStream(ms);
                        PBProduct.Image = image;
                    }
                    else
                    {
                        photoProduct = db3.GetPhoto(filler);
                        byte[] photo = photoProduct2.LargePhoto;
                        MemoryStream ms = new MemoryStream(photo);
                        Image image = Image.FromStream(ms);
                        PBProduct.Image = image;

                    }
                }

            }

        }


        private int productModelID
        {
            get { return _productModelID; }
            set { _productModelID = value; }

        }

        public void DefineID(int id)
        {
            DataAccess db = new DataAccess();
            productModelID = id;
            List<Product> products = new List<Product>();
            products = db.TotalProducts();
            productSingular = products[productModelID];
            TBProductName.Text = productSingular.Name;

            TBId.Text = productSingular.ProductID.ToString();

            Product photoProduct;
            photoProduct = db.GetPhoto(filler);
            byte[] photo = photoProduct.LargePhoto;
            MemoryStream ms = new MemoryStream(photo);
            Image image = Image.FromStream(ms);
            PBProduct.Image = image;
        }
        public void defineName(string name)
        {
            TBProductName.Text = name;
        }
        private void ViewerControl_Load(object sender, EventArgs e)
        {
            TBId.Text = _productModelID.ToString();

        }


        public void defineImage(Image image)
        {
            PBProduct.Image = image;
        }

        private void TBId_TextChanged(object sender, EventArgs e)
        {

        }

        // Cuando clickamos en los botones de color y talla cambiamos color y buscamos precio, id, foto
        private void SearchColor(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();

            color = ((Button)sender).Text;
            bgColorBttn = color;


            foreach (var b in PNLColor.Controls)
            {
                if (((Button)b).Text == bgColorBttn)
                {
                    ((Button)b).BackColor = Color.DarkGray;
                }

                if (((Button)b).Text != bgColorBttn)
                {
                    ((Button)b).BackColor = default(Color);
                }

            }
            int id_Product = db.GetPrice(_productModelID, color, size).ProductID;
            TBId.Text = id_Product.ToString();
            DataAccess db2 = new DataAccess();
            Product photoProduct = db2.GetPhoto(id_Product);

            if (photoProduct != null)
            {
                byte[] photo = photoProduct.LargePhoto;
                MemoryStream ms = new MemoryStream(photo);
                Image image = Image.FromStream(ms);
                PBProduct.Image = image;
            }
            else
            {
                photoProduct = db.GetPhoto(filler);
                byte[] photo = photoProduct.LargePhoto;
                MemoryStream ms = new MemoryStream(photo);
                Image image = Image.FromStream(ms);
                PBProduct.Image = image;

            }


        }
        private void SearchSize(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();

            size = ((Button)sender).Text;
            bgSizeBttn = size;
            

            foreach (var b in PNLSize.Controls)
            {
                if (((Button)b).Text == bgSizeBttn)
                {
                    ((Button)b).BackColor = Color.DarkGray;
                }

                if (((Button)b).Text != bgSizeBttn)
                {
                    ((Button)b).BackColor = default(Color);
                }

            }
            int id_Product = db.GetPrice(_productModelID, color, size).ProductID;
            TBId.Text = id_Product.ToString();
            DataAccess db2 = new DataAccess();
            Product photoProduct = db2.GetPhoto(id_Product);

            if (photoProduct != null)
            {
                byte[] photo = photoProduct.LargePhoto;
                MemoryStream ms = new MemoryStream(photo);
                Image image = Image.FromStream(ms);
                PBProduct.Image = image;
            }
            else
            {
                photoProduct = db.GetPhoto(filler);
                byte[] photo = photoProduct.LargePhoto;
                MemoryStream ms = new MemoryStream(photo);
                Image image = Image.FromStream(ms);
                PBProduct.Image = image;

            }


        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWProductViewer
{
    class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal ListPrice { get; set; }
        public string Description { get; set; }
        public string ThumbnailPhotoFileName { get; set; }
        public string LargePhotoFileName { get; set; }
        public byte[] ThumbnailPhoto { get; set; }
        public byte[] LargePhoto { get; set; }
        public string ModelName { get; set; }
        public override string ToString()
        {
            return $"{ProductID}, {Name}, {Color} ,{Size}, {ListPrice}, {Description}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWForm
{
    class ProductModel
    {
        public int ProductModelID { get; set; }
        public string ProductModelName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal ListPrice { get; set; }

        public override string ToString()
        {
            return $"{ProductModelName}";
        }
    }
}

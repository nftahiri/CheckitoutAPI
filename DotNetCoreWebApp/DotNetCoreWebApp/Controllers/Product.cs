using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebApp.Controllers
{
    public class Product
    {
        //No argument constructor
        public Product()
        {
            ProductName = "";
            ProductCategory = "";
            ProductPrice = 0;
            Source = "";
            TimeGenerated = DateTime.MinValue;
        }

        // Constructor that takes arguments:
        public Product(string productName, string productCategory, double productPrice, string source, DateTime timeGenerated)
        {
            ProductName = productName;
            ProductCategory = productCategory;
            ProductPrice = productPrice;
            Source = source;
            TimeGenerated = timeGenerated;
        }

        public string ProductName
        {
            get;
            set;
        }

        public DateTime TimeGenerated
        {
            get;
            set;
        }

        public string ProductCategory
        {
            get;
            set;
        }

        public double ProductPrice
        {
            get;
            set;
        }

        public string Source
        {
            get;
            set;
        }
    }
}


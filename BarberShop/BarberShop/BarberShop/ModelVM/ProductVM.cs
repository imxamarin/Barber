using InstaBiz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InstaBiz.PCL.ModelVM
{
    public class ProductVM : BaseVM
    {
        string product;
        public string Product
        {
            get { return product; }
            set { product = value; RaisePropertyChanged("Product"); }
        }

        string details;
        public string Details
        {
            get { return details; }
            set { details = value; RaisePropertyChanged("Details"); }
        }

        string unitprice;
        public string UnitPrice
        {
            get { return unitprice; }
            set { unitprice = value; RaisePropertyChanged("UnitPrice"); }
        }

        string productCost;
        public string ProductCost
        {
            get { return productCost; }
            set { productCost = value; RaisePropertyChanged("ProductCost"); }
        }

        string group;
        public string Group
        {
            get { return group; }
            set { group = value; RaisePropertyChanged("Group"); }
        }

        string supplier;
        public string Supplier
        {
            get { return supplier; }
            set { supplier = value; RaisePropertyChanged("Supplier"); }
        }

        //ImageSource image;
        //public ImageSource Image
        //{
        //    get { return image; }
        //    set { image = value; RaisePropertyChanged("Image"); }
        //}

      


        Product producttag;
        public Product ProductTag
        {
            get { return producttag; }
            set { producttag = value; RaisePropertyChanged("ProductTag"); }
        }

        //ProductVM dynamicproducttag;
        //public ProductVM DynamicProductTag
        //{
        //    get { return dynamicproducttag; }
        //    set { dynamicproducttag = value; RaisePropertyChanged("DynamicProductTag"); }
        //}

      
    }
}

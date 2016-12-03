using BarberShop;
using InstaBiz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaBiz.PCL.ModelVM
{
    public class TaskVM : BaseVM
    {
        string order;
        public string Order
        {
            get { return order; }
            set { order = value;
                RaisePropertyChanged(nameof(Order));
            }
        }

        bool isheader = false;
        public bool IsHeader
        {
            get { return isheader; }
            set { isheader = value; RaisePropertyChanged(nameof(IsHeader)); }
        }

        //int jobtaskid;
        //public int JobTaskID
        //{
        //    get { return jobtaskid; }
        //    set { jobtaskid = value;  }
        //}

        string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        string details = "";
        public string Details
        {
            get { return details; }
            set
            {
                details = value.Trim();
                RaisePropertyChanged(nameof(Details));
            }
        }

        //string supplyestimate;
        //public string SupplyEstimate
        //{
        //    get { return supplyestimate; }
        //    set
        //    {
        //        supplyestimate = value;
                
        //    }
        //}

        //string labourestimate;
        //public string LabourEstimate
        //{
        //    get { return labourestimate; }
        //    set
        //    {
        //        labourestimate = value;
                
        //    }
        //}

        string clientcost;
        public string ClientCost
        {
            get { return clientcost; }
            set
            {
                clientcost = value;
                RaisePropertyChanged(nameof(ClientCost));
                //if (clientcost == null || clientcost == "")
                //    clientcost = "0";


                if (Quantity != null && Quantity != "" && ClientCost != null && ClientCost != "")
                    Total = (Convert.ToDecimal(Quantity) * Convert.ToDecimal(ClientCost.TrimStart('$'))).ToMoney();

                
            }
        }

        string tempClientCost;
        public string TempClientCost
        {
            get { return tempClientCost; }
            set
            {
                tempClientCost = value;
            }
        }

        string quantity;
        public string Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;

                //if (quantity == null || quantity == "")
                //    quantity = "1";


                if (Quantity != null && Quantity != "" && ClientCost != null && ClientCost != "")
                    Total = (Convert.ToDecimal(Quantity) * Convert.ToDecimal(ClientCost.TrimStart('$'))).ToMoney();
            }
        }

        string tempquantity;
        public string TempQuantity
        {
            get { return tempquantity; }
            set
            {
                tempquantity = value;
            }
        }

        string total;
        public string Total
        {
            get { return total; }
            set
            {
                total = value;
            }
        }

        bool include;
        public bool Include
        {
            get { return include; }
            set
            {
                include = value;
            }
        }

        bool spellCheckEnabled = false;
        public bool SpellCheckEnabled
        {
            get { return spellCheckEnabled; }
            set
            {
                spellCheckEnabled = value;
            }
        }

        bool showSigning = false;
        public bool ShowSigning
        {
            get { return showSigning; }
            set
            {
                showSigning = value;
            }
        }

        bool fadeTask = false;
        public bool FadeTask
        {
            get { return fadeTask; }
            set
            {
                fadeTask = value;
            }
        }

        bool showBoxes;
        public bool ShowBoxes
        {
            get { return showBoxes; }
            set
            {
                showBoxes = value;
                RaisePropertyChanged(nameof(ShowBoxes));
            }
        }

        bool showBlocks;
        public bool ShowBlocks
        {
            get { return showBlocks; }
            set
            {
                showBlocks = value;
                RaisePropertyChanged(nameof(ShowBlocks));
            }
        }


        bool editButton;
        public bool EditButton
        {
            get { return editButton; }
            set
            {
                editButton = value;
                RaisePropertyChanged(nameof(EditButton));
            }
        }

        bool showcatalog = false;
        public bool ShowCatalog
        {
            get { return showcatalog; }
            set
            {
                showcatalog = value;
                RaisePropertyChanged(nameof(ShowCatalog));
            }
        }

        bool isempty = false;
        public bool IsEmpty
        {
            get { return isempty; }
            set
            {
                isempty = value;
                RaisePropertyChanged(nameof(IsEmpty));
            }
        }

        TaskVM taskTag;
        public TaskVM TaskTag
        {
            get { return taskTag; }
            set
            {
                taskTag = value;
            }
        }





        InvoiceTask invoiceTask;
        public InvoiceTask InvoiceTask
        {
            get { return invoiceTask; }
            set
            {
                invoiceTask = value;
            }
        }

        //corderproduct productTask;
        //public corderproduct ProductTask
        //{
        //    get { return productTask; }
        //    set
        //    {
        //        productTask = value;
        //        RaisePropertyChanged("ProductTask");
        //    }
        //}

        //DynamicProduct dynamicproductTask;
        //public DynamicProduct DynamicProductTask
        //{
        //    get { return dynamicproductTask; }
        //    set
        //    {
        //        dynamicproductTask = value;
        //        RaisePropertyChanged("DynamicProductTask");
        //    }
        //}



    }
}

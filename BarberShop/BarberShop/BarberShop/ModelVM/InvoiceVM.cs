using GalaSoft.MvvmLight.Command;
using InstaBiz.Model;


using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace InstaBiz.PCL.ModelVM
{
    public class InvoiceVM : BaseVM
    {


        string jobid;
        public string JobID
        {
            get { return jobid; }
            set
            {
                jobid = value;
                //RaisePropertyChanged("JobID");
            }
        }

        string title = "Invoice ";
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                RaisePropertyChanged("Title");
            }
        }

        string pretitle;
        public string Pretitle
        {
            get { return pretitle; }
            set
            {
                pretitle = value;
                RaisePropertyChanged("Pretitle");
            }
        }

        string invoicecode;
        public string InvoiceCode
        {
            get { return invoicecode; }
            set
            {
                invoicecode = value;
                RaisePropertyChanged("InvoiceCode");
            }
        }

        string groupcode;
        public string GroupCode
        {
            get { return groupcode; }
            set
            {
                groupcode = value;
                RaisePropertyChanged("GroupCode");
            }
        }


        DateTimeOffset invoicedate;
        public DateTimeOffset InvoiceDate
        {
            get { return invoicedate; }
            set
            {
                invoicedate = value;
                RaisePropertyChanged("InvoiceDate");
            }
        }

        string duedate;
        public string DueDate
        {
            get { return duedate; }
            set
            {
                duedate = value;
                RaisePropertyChanged("DueDate");
            }
        }

        //string amount;
        //public string Amount
        //{
        //    get { return amount; }
        //    set
        //    {
        //        amount = value;
        //        RaisePropertyChanged("Amount");
        //    }
        //}

        string percentagedue;
        public string PercentageDue
        {
            get { return percentagedue; }
            set
            {
                percentagedue = value;
                RaisePropertyChanged("PercentageDue");
            }
        }

        string amountdue;
        public string AmountDue
        {
            get { return amountdue; }
            set
            {
                amountdue = value;
                RaisePropertyChanged("AmountDue");
            }
        }



        string subtotal;
        public string SubTotal
        {
            get { return subtotal; }
            set
            {
                subtotal = value;
                RaisePropertyChanged("SubTotal");
            }
        }

        string taxtotal;
        public string TaxTotal
        {
            get { return taxtotal; }
            set
            {
                taxtotal = value;
                RaisePropertyChanged("TaxTotal");
            }
        }

        string invoicetotal;
        public string InvoiceTotal
        {
            get { return invoicetotal; }
            set
            {
                invoicetotal = value;
                RaisePropertyChanged("InvoiceTotal");
            }
        }

        private string invoicetotalformatted;
        public string InvoiceTotalFormatted
        {
            get { return invoicetotalformatted; }
            set
            {
                invoicetotalformatted = value;
                RaisePropertyChanged("InvoiceTotalFormatted");
            }
        }

        string paid;
        public string Paid
        {
            get { return paid; }
            set
            {
                paid = value;
                RaisePropertyChanged("Paid");
            }
        }

        string remaining;
        public string Remaining
        {
            get { return remaining; }
            set
            {
                remaining = value;
                RaisePropertyChanged("Remaining");
            }
        }

        string totalbal;
        public string TotalBal
        {
            get { return totalbal; }
            set
            {
                totalbal = value;
                RaisePropertyChanged("TotalBal");
            }
        }

        string remainingoutoftotal;
        public string RemainingOutOfTotal
        {
            get { return remainingoutoftotal; }
            set
            {
                remainingoutoftotal = value;
                RaisePropertyChanged("RemainingOutOfTotal");
            }
        }

        string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                RaisePropertyChanged("Description");
            }
        }

        string address;
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                RaisePropertyChanged("Address");
            }
        }

        bool invoicesent;
        public bool InvoiceSent
        {
            get { return invoicesent; }
            set
            {
                invoicesent = value;
                RaisePropertyChanged("InvoiceSent");
            }
        }

        string invoicestatus;
        public string InvoiceStatus
        {
            get { return invoicestatus; }
            set
            {
                invoicestatus = value;
                RaisePropertyChanged("InvoiceStatus");
            }
        }

        string ponum;
        public string PONum
        {
            get { return ponum; }
            set
            {
                ponum = value;
                RaisePropertyChanged("PONum");
            }
        }

        string uninvoiced;
        public string Uninvoiced
        {
            get { return uninvoiced; }
            set
            {
                uninvoiced = value;
                RaisePropertyChanged("Uninvoiced");
            }
        }

        string uninvoicedPercent;
        public string UninvoicedPercent
        {
            get { return uninvoicedPercent; }
            set
            {
                uninvoicedPercent = value;
                RaisePropertyChanged("UninvoicedPercent");
            }
        }

      

        decimal tax;
        public decimal Tax
        {
            get { return tax; }
            set
            {
                tax = value;
                RaisePropertyChanged("Tax");
            }
        }

        bool istax;
        public bool IsTax
        {
            get { return istax; }
            set
            {
                istax = value;
                RaisePropertyChanged("IsTax");
            }
        }


     

        Invoice tag;
        public Invoice Tag
        {
            get { return tag; }
            set
            {
                tag = value;
                //RaisePropertyChanged("Tag");
            }
        }


        public string QuoteID { get; set; }





        
    }
}

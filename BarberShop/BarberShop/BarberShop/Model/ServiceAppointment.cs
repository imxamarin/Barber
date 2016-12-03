using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.PCL.Model
{
    public class ServiceAppointment
    {
        public string Id { get; set; }
        public string ClientID { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public string CompanyID { get; set; }
    }
}

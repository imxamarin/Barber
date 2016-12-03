using Barbershop.PCL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.PCL.Model
{
    public class UserFeedback
    {
        public string Id { get; set; }
        public string UserID { get; set; }
        public FeedbackType Type { get; set; }
        public string Message { get; set; }


    }
}

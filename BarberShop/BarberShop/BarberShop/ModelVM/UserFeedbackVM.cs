
using Barbershop.PCL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaBiz.PCL.ModelVM
{
    public class UserFeedbackVM
    {
        public string UserID { get; set; }
        public FeedbackType Type { get; set; }
        public string Message { get; set; }
        public string Upvotes { get; set; }

    }
}

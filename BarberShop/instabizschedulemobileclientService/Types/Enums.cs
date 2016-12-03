using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace instabizschedulemobileclientService.Types
{
    public class Enums
    {
        //public enum RefType
        //{
        //    Job, Client, Employee, Supplier, Vehicle, Mail, Company
        //}

        public enum CompanyType
        {
            Project, Dispatch, Appointment
        }

        public enum AccessLevel
        {
            Administrator, User, ProjectManager, Punchclock, Vehicle
        }


        public enum FeedbackType
        {
            Bug,
            Feature,
            Feedback
        }
    }
}
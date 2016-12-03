namespace Barbershop.PCL.Types
{
    public enum RefType
    {
        Job, Client, Employee, Supplier, Vehicle, Mail,
        Company
    }

    public enum CompanyType
    {
        Project, Dispatch, Appointment
    }

    public enum AccessLevel
    {
        Administrator, User, ProjectManager, Punchclock, Vehicle
    }

    public enum POStatus
    {
        Expense, Draft, Sent, Approved, Completed, Declined
    }

    public enum TermType
    {
        Quote, Invoice, Statement, PurchaseOrder
    }

    public enum AuthenticationType
    {
        Microsoft,
        Facebook,
        Twitter,
        AzureAD
    }

    public enum FeedbackType
    {
        Bug,
        Feature,
        Feedback
    }
}

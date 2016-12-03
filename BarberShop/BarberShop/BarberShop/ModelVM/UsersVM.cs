using InstaBiz.Model;


namespace InstaBiz.PCL.ModelVM
{
    public class UsersVM
    {
        string userid;
        public string UserID
        {
            get { return userid; }
            set
            {
                userid = value;
                //RaisePropertyChanged("UserID");
            }
        }

        string username;
        public string UserName
        {
            get { return username; }
            set
            {
                username = value;
                //RaisePropertyChanged("UserName");
            }
        }

        string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                //RaisePropertyChanged("Name");
            }
        }



        string lastlogged;
        public string LastLogged
        {
            get { return lastlogged; }
            set
            {
                lastlogged = value;
                //RaisePropertyChanged("LastLogged");
            }
        }

        string createdat;
        public string CreatedAt
        {
            get { return createdat; }
            set
            {
                createdat = value;
                //RaisePropertyChanged("CreatedAt");
            }
        }

        string accesslevel;
        public string AccessLevel
        {
            get { return accesslevel; }
            set
            {
                accesslevel = value;
                //RaisePropertyChanged("AccessLevel");
            }
        }

        bool isselected;
        public bool isSelected
        {
            get { return isselected; }
            set
            {
                isselected = value;
                //RaisePropertyChanged("isSelected");
            }
        }


        Users tag;
        public Users Tag
        {
            get { return tag; }
            set
            {
                tag = value;
                //RaisePropertyChanged("Tag");
            }
        }

        CompanyUser companyusertag;
        public CompanyUser CompanyUserTag
        {
            get { return companyusertag; }
            set
            {
                companyusertag = value;
                //RaisePropertyChanged("CompanyUserTag");
            }
        }
    }
}

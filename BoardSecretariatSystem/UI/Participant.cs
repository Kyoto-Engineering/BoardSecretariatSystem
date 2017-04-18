using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardSecretariatSystem.UI
{
    class Participant
    {
        private string name;
        private string fatherName;
        private string motherName;
        private DateTime dateofBirth;
        private string email;
        private string contactNo;


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string FatherName
        {
            get { return fatherName; }
            set { fatherName = value; }
        }

        public string MotherName
        {
            get { return motherName; }
            set { motherName = value; }
        }

        public DateTime DateofBirth
        {
            get { return dateofBirth; }
            set { dateofBirth = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string ContactNo
        {
            get { return contactNo; }
            set { contactNo = value; }
        }
    }
}

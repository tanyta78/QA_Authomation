using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSeleniumTests.Models
{
    public class RegistrationUser
    {
        private string firstName;
        private string lastName;
        private List<bool> martialStatus;
        private List<bool> hobbys;
        private string country;
        private string birthMonth;
        private string birthDay;
        private string birthYear;
        private string phone;
        private string userName;
        private string email;
        private string picture;
        private string description;
        private string password;
        private string confirmPassword;

        public RegistrationUser(String firstName,
                                String lastName,
                                List<bool> martialStatus,
                                List<bool> hobbys,
                                String country,
                                String birthMonth,
                                String birthDay,
                                String birthYear,
                                String phone,
                                String userName,
                                String email,
                                String picture,
                                String description,
                                String password,
                                String confirmPassword)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.martialStatus = martialStatus;
            this.hobbys = hobbys;
            this.country = country;
            this.birthMonth = birthMonth;
            this.birthDay = birthDay;
            this.birthYear = birthYear;
            this.phone = phone;
            this.userName = userName;
            this.email = email;
            this.picture = picture;
            this.description = description;
            this.password = password;
            this.confirmPassword = confirmPassword;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public List<bool> MatrialStatus
        {
            get { return this.martialStatus; }
            set { this.martialStatus = value; }
        }

        public List<bool> Hobbys
        {
            get { return this.hobbys; }
            set { this.hobbys = value; }
        }

        public string Country
        {
            get { return this.country; }
            set { this.country = value; }
        }

        public string BirthMonth
        {
            get { return this.birthMonth; }
            set { this.birthMonth = value; }
        }

        public string BirthDay
        {
            get { return this.birthDay; }
            set { this.birthDay = value; }
        }

        public string BirthYear
        {
            get { return this.birthYear; }
            set { this.birthYear = value; }
        }

        public string Phone
        {
            get { return this.phone; }
            set { this.phone = value; }
        }

        public string UserName
        {
            get { return this.userName; }
            set { this.userName = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public string Picture
        {
            get { return this.picture; }
            set { this.picture = value; }
        }

        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public string ConfirmPassword
        {
            get { return this.confirmPassword; }
            set { this.confirmPassword = value; }
        }
    }
}

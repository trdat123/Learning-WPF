using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using WpfApplication1.Models;
using WpfApplication1.Service;

namespace WpfApplication1.ViewModels
{
    public class CreateStudentViewModel : Screen, IDataErrorInfo
    {
        //constructor
        public CreateStudentViewModel()
        {
            DisplayName = "Create New Student";
        }

        //properties
        public IStudentService StudentService { get; set; }
        public BindableCollection<string> ClassList { get; set; }

        private string _studentId;
        public string StudentId
        {
            get { return _studentId; }
            set { _studentId = value; NotifyOfPropertyChange(() => StudentId); }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; NotifyOfPropertyChange(() => FirstName); }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; NotifyOfPropertyChange(() => LastName); }
        }

        private DateTime _birthDate;
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; NotifyOfPropertyChange(() => BirthDate); }
        }

        private bool _gender;
        public bool Gender
        {
            get { return _gender; }
            set { _gender = value; NotifyOfPropertyChange(() => Gender); }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set { _city = value; NotifyOfPropertyChange(() => City); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; NotifyOfPropertyChange(() => Email); }
        }

        private string _class;
        public string Class
        {
            get { return _class; }
            set { _class = value; NotifyOfPropertyChange(() => Class); }
        }

        //Validation
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();
        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string name]
        {
            get
            {
                string result = null;
                switch (name)
                {
                    case "StudentId":
                        if (string.IsNullOrWhiteSpace(StudentId))
                            result = "Student ID cannot be empty";
                        else if (StudentId.ToString().Length > 10)
                            result = "Student ID maximun length is 10 charaters";
                        else if (StudentId.All(char.IsLetter))
                            result = "Student ID cannot have letters";
                            break;
                    case "FirstName":
                        if (string.IsNullOrWhiteSpace(FirstName))
                            result = "First Name cannot be empty";
                        else if (FirstName.Length > 20)
                            result = "First Name maximun length is 20 charaters";
                        break;
                    case "LastName":
                        if (string.IsNullOrWhiteSpace(LastName))
                            result = "Last Name cannot be empty";
                        else if (LastName.Length > 20)
                            result = "Last Name maximun length is 20 charaters";
                        break;
                    case "BirthDate":
                        if (string.IsNullOrWhiteSpace(BirthDate.ToString()))
                            result = "Birth Date cannot be empty";
                        break;
                    case "Gender":
                        if (string.IsNullOrWhiteSpace(Gender.ToString()))
                            result = "Gender cannot be empty";
                        break;
                    case "City":
                        if (string.IsNullOrWhiteSpace(City))
                            result = "City cannot be empty";
                        else if (City.Length > 20)
                            result = "City maximun length is 20 charaters";
                        break;
                    case "Email":
                        if (string.IsNullOrWhiteSpace(Email))
                            result = "Email cannot be empty";
                        else if (StudentId.ToString().Length > 30)
                            result = "Email maximun length is 30 charaters";
                        break;
                    case "Class":
                        if (string.IsNullOrWhiteSpace(Class))
                            result = "Class cannot be empty";
                        break;
                }
                if (ErrorCollection.ContainsKey(name))
                    ErrorCollection[name] = result;
                else if (result != null)
                    ErrorCollection.Add(name, result);
                NotifyOfPropertyChange(() => ErrorCollection);
                return result;
            }
        }

        //buttons
        public bool CanSaveButton()
        {
            return !string.IsNullOrEmpty(ErrorCollection.ToString());
        }

        public void SaveButton()
        {
            StudentService.Add(new StudentModel { StudentId = StudentId, FirstName = FirstName, LastName = LastName, Birthdate = BirthDate, Gender = Gender.ToString(), City = City, Email = Email, Class = Class });
            MessageBox.Show("Student has been successfully saved!");
            TryClose();
        }

        public void CancelButton()
        {
            TryClose();
        }
    }
}

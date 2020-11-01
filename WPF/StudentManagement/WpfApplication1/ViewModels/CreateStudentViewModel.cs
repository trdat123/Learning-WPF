using Caliburn.Micro;
using System;
using System.Collections.Generic;
using WpfApplication1.Service;

namespace WpfApplication1.ViewModels
{
    public class CreateStudentViewModel : Screen
    {
        //constructor
        public CreateStudentViewModel()
        {
            DisplayName = "Create New Student";
            StudentService = new StudentService();
        }

        //properties
        public IStudentService StudentService { get; set; }

        private int _studentId;
        public int StudentId
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

        private DateTime _birthdate;
        public DateTime BirthDate
        {
            get { return _birthdate; }
            set { _birthdate = value; NotifyOfPropertyChange(() => BirthDate); }
        }

        private string _gender;
        public string Gender
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


        //buttons
        public void SaveButton()
        { 
            StudentService.Add(new Models.StudentModel { StudentId = StudentId, FirstName = FirstName, LastName = LastName, Birthdate = BirthDate, Gender = Gender, City = City, Email = Email, Class = Class });
            TryClose();
        }

        public void CancelButton()
        {
            TryClose();
        }
    }
}

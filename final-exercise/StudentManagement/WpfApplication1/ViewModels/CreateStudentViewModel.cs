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

        #region Properties
        public IStudentService StudentService { get; set; }
        public BindableCollection<string> ClassList { get; set; }

        private StudentModel _selectedStudent;

        public StudentModel SelectedStudent
        {
            get { return _selectedStudent; }
            set { _selectedStudent = value; NotifyOfPropertyChange(() => SelectedStudent); }
        }


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

        private DateTime _birthDate = DateTime.Today;
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; NotifyOfPropertyChange(() => BirthDate); }
        }

        private bool _boolGender = true; //radiobutton will bind into this prop
        public bool BoolGender
        {
            get { return _boolGender; }
            set { _boolGender = value; NotifyOfPropertyChange(() => BoolGender); }
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
        #endregion Properties

        #region Validation
        public Dictionary<string, string> ErrorCollection { get; set; } = new Dictionary<string, string>();

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
                string errorText = null; //a line of text that show when validate
                switch (name)
                {
                    case "StudentId":
                        if (string.IsNullOrWhiteSpace(StudentId))
                            errorText = "Student ID cannot be empty";
                        else if (StudentId.ToString().Length > 10)
                            errorText = "Student ID maximun length is 10 charaters";
                        else if (StudentId.Any(char.IsLetter))
                            errorText = "Student ID cannot have letters";
                            break;

                    case "FirstName":
                        if (string.IsNullOrWhiteSpace(FirstName))
                            errorText = "First Name cannot be empty";
                        else if (FirstName.Length > 20)
                            errorText = "First Name maximun length is 20 charaters";
                        break;

                    case "LastName":
                        if (string.IsNullOrWhiteSpace(LastName))
                            errorText = "Last Name cannot be empty";
                        else if (LastName.Length > 20)
                            errorText = "Last Name maximun length is 20 charaters";
                        break;

                    case "BirthDate":
                        break;

                    case "Gender":
                        break;

                    case "City":
                        if (string.IsNullOrWhiteSpace(City))
                            errorText = "City cannot be empty";
                        else if (City.Length > 20)
                            errorText = "City maximun length is 20 charaters";
                        break;

                    case "Email":
                        if (string.IsNullOrWhiteSpace(Email))
                            errorText = "Email cannot be empty";
                        else if (Email.ToString().Length > 30)
                            errorText = "Email maximun length is 30 charaters";
                        break;

                    case "Class":
                        if (string.IsNullOrWhiteSpace(Class))
                            errorText = "Class cannot be empty";
                        break;
                }
                if (ErrorCollection.ContainsKey(name)) 
                    ErrorCollection[name] = errorText;
                else if (errorText != null)
                    ErrorCollection.Add(name, errorText);
                NotifyOfPropertyChange(() => ErrorCollection);
                NotifyOfPropertyChange(() => CanSaveButton);
                return errorText;
            }
        }
        #endregion Validation

        #region Buttons
        public bool CanSaveButton
        {
            get
            {
                return ErrorCollection.All(s => s.Value == null);
                //Save button will enable when all error text is empty
            }
        }

        public void SaveButton()
        {
            GenderConvert();
            if (SelectedStudent == null) //save button will add student to studentlist
            {
                StudentService.Add(new StudentModel
                    { StudentId = StudentId,
                    FirstName = FirstName,
                    LastName = LastName,
                    Birthdate = BirthDate,
                    Gender = Gender,
                    City = City,
                    Email = Email,
                    Class = Class }
                );
            }
            else //save button will change data with selected student in mainviewmodel
            {
                SelectedStudent.StudentId = StudentId;
                SelectedStudent.FirstName = FirstName;
                SelectedStudent.LastName = LastName;
                SelectedStudent.Birthdate = BirthDate;
                SelectedStudent.Gender = Gender;
                SelectedStudent.City = City;
                SelectedStudent.Email = Email;
                SelectedStudent.Class = Class;
            }
            MessageBox.Show("Student has been successfully saved!");
            TryClose();
        }

        public void CancelButton()
        {
            MessageBoxResult result = MessageBox.Show("Do you want to close?", "Confirmation", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.OK:
                    TryClose();
                    break;
                case MessageBoxResult.Cancel:
                    break;
            }
        }
        #endregion Button

        public void GenderConvert()
        {
            if (BoolGender == true)
                Gender = "Male";
            else if (BoolGender == false)
                Gender = "Female";
            else
                Gender = null;
        }
    }
}

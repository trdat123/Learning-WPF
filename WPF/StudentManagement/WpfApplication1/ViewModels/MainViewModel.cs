using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;
using System.Xml.Linq;
using System.Xml.Serialization;
using WpfApplication1.Models;
using WpfApplication1.Service;

namespace WpfApplication1.ViewModels
{
    public class MainViewModel : Conductor<object>
    {
        //constructor
        public MainViewModel()
        {
            DisplayName = "Students List";
            StudentService = new StudentService();
            SearchCommand = new RelayCommand(Search);
            StudentList = new BindableCollection<StudentModel>(StudentService.SearchStudent(new StudentSearchCriteria()));
            ClassList = new BindableCollection<string>(StudentService.GetAllClasses());
        }

        //properties declaration
        public IStudentService StudentService { get; set; }
        public ICommand SearchCommand { get; set; }

        private BindableCollection<StudentModel> _studentList;
        public BindableCollection<StudentModel> StudentList
        {
            get { return _studentList; }
            set { _studentList = value; NotifyOfPropertyChange(() => StudentList); }
        }

        public BindableCollection<string> ClassList { get; set; }

        private StudentModel _selectedStudent;
        public StudentModel SelectedStudent
        {
            get { return _selectedStudent; }
            set {
                _selectedStudent = value;
                NotifyOfPropertyChange(() => SelectedStudent);
                NotifyOfPropertyChange(() => CanModifyButton);
            }
        }

        //Searchbox
        private string searchBox;
        public string SearchBox
        {
            get { return searchBox; }
            set {
                searchBox = value;
                NotifyOfPropertyChange(() => SearchBox);
                NotifyOfPropertyChange(() => CanClearButton);
            }
        }

        //Class combobox
        private string _selectedClass;
        public string SelectedClass
        {
            get { return _selectedClass; }
            set {
                _selectedClass = value;
                NotifyOfPropertyChange(() => SelectedClass);
                NotifyOfPropertyChange(() => CanClearButton);
            }
        }

        //Search button
        public void Search(object o)
        {
            StudentList.Clear();
            var result = StudentService.SearchStudent(new StudentSearchCriteria { SearchText = SearchBox, ClassName = SelectedClass });
            StudentList.AddRange(result);
        }

        //Reset button
        public bool CanClearButton
        {
            get
            {
                return !string.IsNullOrWhiteSpace(SearchBox) || !string.IsNullOrWhiteSpace(SelectedClass);
            }
        }

        public void ClearButton()
        {
            StudentList.Clear();
            SearchBox = "";
            SelectedClass = null;
            var resetStudentList = StudentService.SearchStudent(new StudentSearchCriteria { SearchText = "", ClassName = "" });
            StudentList.AddRange(resetStudentList);
        }

        //Load other window button
        IWindowManager manager = new WindowManager();
        public void CreateStuButton()
        {
            var detail = new CreateStudentViewModel();
            detail.StudentService = StudentService;
            detail.ClassList = ClassList;
            manager.ShowDialog(detail);

            //call search again to reset studentlist
            Search(StudentList);
        }

        //Update button can appear
        public bool CanModifyButton
        {
            get
            {
                return SelectedStudent != null;
            }
            
        }

        public void ModifyButton()
        {
            var detail = new CreateStudentViewModel();
            detail.SelectedStudent = SelectedStudent;
            detail.ClassList = ClassList;
            detail.StudentId = SelectedStudent.StudentId;
            detail.FirstName = SelectedStudent.FirstName;
            detail.LastName = SelectedStudent.LastName;
            detail.BirthDate = SelectedStudent.Birthdate;
            SelectedStudent.Gender = detail.Gender.ToString();
            detail.City = SelectedStudent.City;
            detail.Email = SelectedStudent.Email;
            detail.Class = SelectedStudent.Class;
            manager.ShowDialog(detail);

            //call search again to reset studentlist
            Search(StudentList);
        }

        public void RemoveButton()
        {
            StudentService.Remove();
            Search(StudentList);
        }
    }
}


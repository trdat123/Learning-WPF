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
            foreach (var item in result)
            {
                StudentList.Add(item);
            }
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
            manager.ShowDialog(new CreateStudentViewModel());
        }

        public void ModifyButton()
        {
            manager.ShowWindow(new ModifyStudentViewModel());
        }

    }
}


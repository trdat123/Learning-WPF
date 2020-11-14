using Caliburn.Micro;
using System.Linq;
using System.Windows;
using System.Windows.Input;
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
            SearchCommand = new RelayCommand(SearchButton);
            StudentList = new BindableCollection<StudentModel>(StudentService.SearchStudent(new StudentSearchCriteria()));
            ClassList = new BindableCollection<string>(StudentService.GetAllClasses());
        }

        #region Properties
        public IStudentService StudentService { get; set; }
        public ICommand SearchCommand { get; set; }

        private BindableCollection<StudentModel> _studentList;
        public BindableCollection<StudentModel> StudentList
        {
            get { return _studentList; }
            set
            {
                _studentList = value;
                NotifyOfPropertyChange(() => StudentList);
            }
        }

        public BindableCollection<string> ClassList { get; set; }

        private StudentModel _selectedStudent;
        public StudentModel SelectedStudent
        {
            get { return _selectedStudent; }
            set {
                _selectedStudent = value;
                NotifyOfPropertyChange(() => SelectedStudent);
            }
        }

        //Class combobox
        private string _selectedClass;
        public string SelectedClass
        {
            get { return _selectedClass; }
            set
            {
                _selectedClass = value;
                NotifyOfPropertyChange(() => SelectedClass);
                NotifyOfPropertyChange(() => CanClearButton);
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

        #endregion Properties

        #region Button
        //Search button
        public void SearchButton(object o)
        {
            StudentList.Clear();
            var result = StudentService.SearchStudent(new StudentSearchCriteria
            {
                SearchText = SearchBox,
                ClassName = SelectedClass
            });
            StudentList.AddRange(result);
        }

        //Reset button
        public bool CanClearButton
        {
            get
            {
                return !string.IsNullOrWhiteSpace(SearchBox) ||
                    !string.IsNullOrWhiteSpace(SelectedClass) ||
                    StudentList.Any(s => s.Checked == true);
            }
        }

        public void ClearButton()
        {
            StudentList.Clear();
            SearchBox = "";
            SelectedClass = null;
            StudentList.Where(s => s.Checked == false);
            SearchButton(StudentList); //call search again to reset studentlist
        }
        
        //Load "studentdetail window" button
        IWindowManager manager = new WindowManager();
        public void CreateStuButton()
        {
            var detail = new CreateStudentViewModel();
            detail.Title = "New Student";
            detail.StudentService = StudentService;
            detail.ClassList = ClassList;
            manager.ShowDialog(detail);        
            SearchButton(StudentList); //call search again to reset studentlist
        }

        //update student button
        public void ModifyButton()
        {
            if (SelectedStudent != null)
            {
                var detail = new CreateStudentViewModel();
                detail.Title = "Modify Student";
                detail.SelectedStudent = SelectedStudent;
                detail.ClassList = ClassList;
                detail.StudentId = SelectedStudent.StudentId;
                detail.FirstName = SelectedStudent.FirstName;
                detail.LastName = SelectedStudent.LastName;
                detail.BirthDate = SelectedStudent.Birthdate;
                detail.GenderConvert(SelectedStudent.Gender); //convert a gender type string to bool
                detail.City = SelectedStudent.City;
                detail.Email = SelectedStudent.Email;
                detail.Class = SelectedStudent.Class;
                manager.ShowDialog(detail);
                SearchButton(StudentList); //call search again to reset studentlist
            }
            else
            {
                MessageBox.Show("Please select student to update", "Wrong input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //delete student button
        public void RemoveButton()
        {
            if (StudentList.Any(s => s.Checked == true))
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete the students that you have selected?", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                switch (result)
                {
                    case MessageBoxResult.OK:
                        StudentService.Remove();
                        SearchButton(StudentList); //call search to reset studentlist
                        break;
                    case MessageBoxResult.Cancel:
                        break;
                }
            }
            else
                MessageBox.Show("Please select at least one student to delete", "Wrong input", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        #endregion Button
    }
}


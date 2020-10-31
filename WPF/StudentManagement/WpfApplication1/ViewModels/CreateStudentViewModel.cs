using Caliburn.Micro;
using System.Collections.Generic;

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
        private string _studentId;

        public string StudentId
        {
            get { return _studentId; }
            set { _studentId = value; NotifyOfPropertyChange(() => StudentId); }
        }



        //buttons
        public void SaveButton()
        {
            //List<StudentModel> students = new List<StudentModel>();
            //students.Add(new StudentModel() {StudentID = StudentID });
            //MainWindow main = (MainWindow)Application.Current.MainWindow;
            //main.StudentDataGrid.Items.Add(students);
            //Close();       

            StudentService.Add(new StudentModel() {  });
        }

        public void CancelButton()
        {
            TryClose();
        }
    }
}

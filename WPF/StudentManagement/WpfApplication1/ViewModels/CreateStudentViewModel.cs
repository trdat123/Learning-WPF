using Caliburn.Micro;
using System.Collections.Generic;

namespace WpfApplication1.ViewModels
{
    public class CreateStudentViewModel : Screen
    {
        public CreateStudentViewModel()
        {
            DisplayName = "Create New Student";
        }

        public void SaveButton()
        {
            //List<StudentModel> students = new List<StudentModel>();
            //students.Add(new StudentModel() {StudentID = StudentID });
            //MainWindow main = (MainWindow)Application.Current.MainWindow;
            //main.StudentDataGrid.Items.Add(students);
            //Close();       
            MainViewModel main = new MainViewModel();
            main.Students.Add(new Models.StudentModel());
            TryClose();
        }

        public void CancelButton()
        {
            TryClose();
        }
    }
}

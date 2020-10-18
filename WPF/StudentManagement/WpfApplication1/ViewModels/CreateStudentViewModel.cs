using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.Models;
using WpfApplication1.Views;

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
        }

        public void CancelButton()
        {
            TryClose();
        }
    }
}

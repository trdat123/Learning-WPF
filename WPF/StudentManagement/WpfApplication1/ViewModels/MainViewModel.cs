using Caliburn.Micro;
using System;
using WpfApplication1.Models;

namespace WpfApplication1.ViewModels
{
    public class MainViewModel : Conductor<object>
    {
        //properties declaration
        private BindableCollection<StudentModel> _students = new BindableCollection<StudentModel>();
        public BindableCollection<StudentModel> Students
        {
            get { return _students; }
            set { _students = value; }
        }

        //Create student button
        IWindowManager manager = new WindowManager();
        public void LoadCreateStu()
        {
            manager.ShowWindow(new CreateStudentViewModel());
        }

        //constructor
        public MainViewModel()
        {
            DisplayName = "Students List";
            Students.Add(new StudentModel() { StudentId = 123, FirstName = "john", LastName = "cena"}); 

            Console.ReadLine();
        } 
    }     
}


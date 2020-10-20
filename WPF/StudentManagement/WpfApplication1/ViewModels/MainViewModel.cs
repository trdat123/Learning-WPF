using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
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

        private StudentModel _selectedClass;
        public StudentModel SelectedClass
        {
            get { return _selectedClass; }
            set { _selectedClass = value; NotifyOfPropertyChange(() => SelectedClass); }
        }

        //Load other window button
        IWindowManager manager = new WindowManager();
        public void CreateStuButton()
        {
            manager.ShowWindow(new CreateStudentViewModel());
        }

        public void ModifyButton()
        {
            manager.ShowWindow(new ModifyStudentViewModel());
        }

        //constructor
        public MainViewModel()
        {
            DisplayName = "Students List";
            Dataset aa = Dataset.LoadFromFile(@"C:\Users\Tr Dat\Desktop\WindowsProgrammingExcercises\WPF\StudentManagement\WpfApplication1\Views\student_sample_data.xml");
            Students.AddRange(aa.Students);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, RoutedEventArgs e) 
        {
            List<Student> students = new List<Student>();
            students.Add(new Student { StudentID = idbox.Text, FirstName = firstnamebox.Text, LastName = lastnamebox.Text, Class = classbox.Text, Email = emailbox.Text });
            MainWindow main = (MainWindow)Application.Current.MainWindow;
            main.StudentDataGrid.Items.Add(students);
            Close();
        }

        public class Student
        {
            public string StudentID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Class { get; set; }
            public string Email { get; set; }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

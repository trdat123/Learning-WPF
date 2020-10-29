using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.Models;

namespace WpfApplication1.Service
{
    public interface IStudentService
    {
        List<StudentModel> SearchStudent(StudentSearchCriteria criteria);

        List<ClassModel> GetAllClasses();

        StudentModel Add(StudentModel student);

        StudentModel Update(StudentModel student);

        void Remove(int studentId);
    }
}

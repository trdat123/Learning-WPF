using System.Collections.Generic;
using WpfApplication1.Models;

namespace WpfApplication1.Service
{
    public interface IStudentService
    {
        List<StudentModel> SearchStudent(StudentSearchCriteria criteria);

        List<string> GetAllClasses();

        List<StudentModel> Add(StudentModel student);

        StudentModel Update(StudentModel student);

        void Remove();
    }
}

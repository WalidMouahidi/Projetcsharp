using System.Collections.Generic;

namespace Examen{
    class Administration
    {
        public List<Student> Students { get; set; }
        public List<Teacher> Teachers { get; set; }

        public Administration()
        {
            Students = new List<Student>();
            Teachers = new List<Teacher>();
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
            Console.WriteLine("Student added successfully.");
        }

        public void RemoveStudent(Student student)
        {
            Students.Remove(student);
            Console.WriteLine("Student removed successfully.");
        }

        public void AddTeacher(Teacher teacher)
        {
            Teachers.Add(teacher);
            Console.WriteLine("Teacher added successfully.");
        }

        public void RemoveTeacher(Teacher teacher)
        {
            Teachers.Remove(teacher);
            Console.WriteLine("Teacher removed successfully.");
        }
    }
}

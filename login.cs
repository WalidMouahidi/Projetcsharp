using System;
using System.Collections.Generic;

namespace Examen;

   class Login
{
    private List<Student> students;
    private List<Teacher> teachers;
    private List<Administration> administrators;

    public Login(List<Student> students, List<Teacher> teachers, List<Administration> administrators)
    {
        this.students = students;
        this.teachers = teachers;
        this.administrators = administrators;
    }

    public bool LoginStudent(int studentId)
{
    foreach (var student in students)
    {
        if (student.Id == studentId)
        {
            Console.WriteLine("Student login successful.");
            return true;
        }
    }

    Console.WriteLine("Student not found. Login failed.");
    return false;
}

    public bool LoginTeacher(int teacherId)
{
    Teacher teacher = teachers.Find(t => t.Id == teacherId);

    if (teacher != null)
    {
        Console.WriteLine($"Welcome, {teacher.Name}!");
        return true;
    }

    Console.WriteLine("Teacher not found. Login failed.");
    return false;
}


    public bool LoginAdministrator(string username, string password)
    {
        // In a real-world scenario, you would validate the username and password against a secure authentication system.
        // For simplicity, we are using a basic example here.

        if (username == "admin" && password == "adminpassword")
        {
            Console.WriteLine("Welcome, Administrator!");
            return true;
        }

        Console.WriteLine("Administrator login failed. Invalid credentials.");
        return false;
    }
}

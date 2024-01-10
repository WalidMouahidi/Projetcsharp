using System;
using System.Collections.Generic;
using System.Linq;

namespace Examen{

class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<string> AssignedCourses { get; set; }

    public static List<Teacher> Teachers = new List<Teacher>();

    public static void CreateTeacher(Teacher teacher , List<Teacher> teachers)
    {
        Teachers.Add(teacher);
        Console.WriteLine("Teacher added successfully.");
    }
    public  static List<Teacher> GetAllTeachers()
    {
        return Teachers;
    }
    public static void UpdateTeacher(int id, Teacher updatedTeacher)
    {
        Teacher existingTeacher = Teachers.FirstOrDefault(t => t.Id == id);

        if (existingTeacher != null)
        {
            existingTeacher.Name = updatedTeacher.Name;
            existingTeacher.AssignedCourses = updatedTeacher.AssignedCourses;

            Console.WriteLine("Teacher updated successfully.");
        }
        else
        {
            Console.WriteLine("Teacher not found.");
        }
    }

    public static void DeleteTeacher(int id)
    {
        Teacher teacherToRemove = Teachers.FirstOrDefault(t => t.Id == id);

        if (teacherToRemove != null)
        {
            Teachers.Remove(teacherToRemove);
            Console.WriteLine("Teacher deleted successfully.");
        }
        else
        {
            Console.WriteLine("Teacher not found.");
        }
    }

    public static void ViewTeacherDetails(int id)
    {
        Teacher teacher = Teachers.FirstOrDefault(t => t.Id == id);

        if (teacher != null)
        {
            Console.WriteLine($"ID: {teacher.Id}");
            Console.WriteLine($"Name: {teacher.Name}");
            Console.WriteLine("Assigned Courses:");

            foreach (var course in teacher.AssignedCourses)
            {
                Console.WriteLine($"- {course}");
            }
        }
        else
        {
            Console.WriteLine("Teacher not found.");
        }
    }

    public static void SearchTeachers(string criteria, string value)
    {
        List<Teacher> searchResults = new List<Teacher>();

        switch (criteria.ToLower())
        {
            case "name":
                searchResults = Teachers.Where(t => t.Name.ToLower().Contains(value.ToLower())).ToList();
                break;
            case "id":
                if (int.TryParse(value, out int id))
                {
                    Teacher teacher = Teachers.FirstOrDefault(t => t.Id == id);
                    if (teacher != null)
                        searchResults.Add(teacher);
                }
                break;
            // Add more cases for other criteria if needed

            default:
                Console.WriteLine("Invalid search criteria.");
                return;
        }

        if (searchResults.Any())
        {
            Console.WriteLine("Search results:");
            foreach (var result in searchResults)
            {
                Console.WriteLine($"ID: {result.Id}, Name: {result.Name}");
            }
        }
        else
        {
            Console.WriteLine("No matching teachers found.");
        }
    }
}

}
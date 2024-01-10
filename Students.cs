using System;
using System.Collections.Generic;
using System.Linq;

namespace Examen{
class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CurrentClass { get; set; }
    public int Level { get; set; }
    public string Expertise { get; set; }

    public static List<Student> students = new List<Student>();
     public List<string> Schedule { get; set; } = new List<string>();

    public static void CreateStudent(Student student,List<Student> students)
    {
        students.Add(student);
        Console.WriteLine("Student added successfully.");
    }
  public static void AddEventToSchedule(int id, string eventDetail)
{
    // Check if the id is within the valid range of the list
    if (id > 0 && id <= students.Count)
    {
        Student student = students[id - 1];

        student.Schedule.Add(eventDetail);

        Console.WriteLine($"Event added to the schedule of student {id}.");
    }
    else
    {
        Console.WriteLine("Invalid student ID. Please enter a valid ID.");
    }
}


    public static void UpdateStudent(int id, Student updatedStudent)
    {
        Student existingStudent = students.FirstOrDefault(s => s.Id == id);

        if (existingStudent != null)
        {
            existingStudent.Name = updatedStudent.Name;
            existingStudent.CurrentClass = updatedStudent.CurrentClass;
            existingStudent.Level = updatedStudent.Level;
            existingStudent.Expertise = updatedStudent.Expertise;

            Console.WriteLine("Student updated successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    public static void DeleteStudent(int id)
    {
        Student studentToRemove = students.FirstOrDefault(s => s.Id == id);

        if (studentToRemove != null)
        {
            students.Remove(studentToRemove);
            Console.WriteLine("Student deleted successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    public static void ViewStudentDetails(int id)
{
    Student student = students.FirstOrDefault(s => s.Id == id);
    if (student != null)
    {
        Console.WriteLine($"ID: {student.Id}");
        Console.WriteLine($"Name: {student.Name}");
        Console.WriteLine($"Current Class: {student.CurrentClass}");
        Console.WriteLine($"Level: {student.Level}");
        Console.WriteLine($"Expertise: {student.Expertise}");

        Console.WriteLine("Schedule:");
        foreach (var eventDetail in student.Schedule)
        {
            Console.WriteLine($"- {eventDetail}");
        }
    }
    else
    {
        Console.WriteLine("Student not found.");
    }
}

    public static void SearchStudents(string criteria, string value)
    {
        List<Student> searchResults = new List<Student>();

        switch (criteria.ToLower())
        {
            case "name":
                searchResults = students.Where(s => s.Name.ToLower().Contains(value.ToLower())).ToList();
                break;
            case "id":
                if (int.TryParse(value, out int id))
                {
                    Student student = students.FirstOrDefault(s => s.Id == id);
                    if (student != null)
                        searchResults.Add(student);
                }
                break;
            default:
                Console.WriteLine("Invalid search criteria.");
                return;
        }

        if (searchResults.Any())
        {
            Console.WriteLine("Search results:");
            foreach (var result in searchResults)
            {
                Console.WriteLine($"ID: {result.Id}, Name: {result.Name}, Current Class: {result.CurrentClass}");
            }
        }
        else
        {
            Console.WriteLine("No matching students found.");
        }
    }

    }
}
using Examen;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.CompilerServices;


class Program
{
    static void Main()
    {
        // Create an instance of the Administration class
        List<Student> studentsList = new List<Student>();
        List<Teacher> teachersList = new List<Teacher>();
        List<Administration> administratorsList = new List<Administration>();


        Login login = new Login(studentsList, teachersList, administratorsList);


        while (true)
        {
            Console.WriteLine("=== Main Menu ===");
            Console.WriteLine("a. Student Login");
            Console.WriteLine("b. Teacher Login");
            Console.WriteLine("c. Admin Login");
            Console.WriteLine("d. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "a":
                    Console.Write("Enter student ID: ");
                    if (int.TryParse(Console.ReadLine(), out int studentId))
                    {
                        if (login.LoginStudent(studentId)==true){
                        ManageStudents(login);}
                        else{
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid student ID.");
                    }
                    break;

                    case "b":
                    Console.Write("Enter teacher ID: ");
                    if (int.TryParse(Console.ReadLine(), out int TeacherId))
                    {
                    if (login.LoginTeacher(TeacherId))
                    {
                    ManageTeachers(login);
                    }
                    else
                    {
                    continue;
                    }
                }
                 else
                {
                     Console.WriteLine("Invalid input. Please enter a valid teacher ID.");
                }
                     break;

                    case "c":
                    Console.Write("Enter admin: ");

                    ManageAdmin(login,studentsList,teachersList);
                    break;







                // Other cases for teacher login, admin login, and exit...

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }



    static void ManageStudents(Login login)
    {
        {
    while (true)
    {
        Console.WriteLine("===== Student Menu =====");
        Console.WriteLine("a. View Details");
        Console.WriteLine("b. View Calendar");
        Console.WriteLine("c. View Schedule");
        Console.WriteLine("d. Add Event to Schedule");
        Console.WriteLine("e. Logout");
        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        switch (choice.ToLower())
        {
            case "a":
                Console.WriteLine("===== View Student Details =====");
                Console.Write("Enter ID of the student to view details: ");
                int viewId = int.Parse(Console.ReadLine());
                Student.ViewStudentDetails(viewId);
                break;

            case "b":
                Console.WriteLine("===== View Calendar =====");
                Calendar.DisplayWeeklySchedule();
                break;

            case "c":
                Console.WriteLine("===== View Schedule =====");
                Console.Write("Enter ID of the student to view schedule: ");
                if (int.TryParse(Console.ReadLine(), out int studentId))
                {
                    Student.ViewStudentDetails(studentId);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid student ID.");
                }
                break;

            case "d":
                Console.WriteLine("===== Add Event to Schedule =====");
                Console.Write("Enter ID of the student to add event: ");

                if (int.TryParse(Console.ReadLine(), out int addEventId))

                {
                    Console.Write("Enter event name: ");
                    string eventName = Console.ReadLine();

                    Console.Write("Enter event date (yyyy-MM-dd): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime eventDate))
                    {
                        Student.AddEventToSchedule(addEventId, $"{eventName} ({eventDate.ToString("yyyy-MM-dd")})");
                        Console.WriteLine($"Event added to the schedule of student {addEventId}.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Please enter a valid date (yyyy-MM-dd).");
                    }
                    }
                    else
          {
                    Console.WriteLine("Invalid input. Please enter a valid student ID.");
                    }
             break;

            case "e":
                Console.WriteLine("Logging out. Goodbye!");
                return;

            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }
        }
    }
    static void ManageTeachers(Login login)
    {
        while (true)
        {
            Console.WriteLine("===== Teachers Menu =====");
            Console.WriteLine("a. View Details");
            Console.WriteLine("b. Logout");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice.ToLower()){
                case"a":
                 Console.WriteLine("===== View Teacher Details =====");
                    Console.Write("Enter ID of the Teacher to view details: ");
                    int viewId = int.Parse(Console.ReadLine());

                    // Create an instance of the Student class to call non-static methods
                    Teacher Teacher = new Teacher();
                    Teacher.ViewTeacherDetails(viewId);
                    break;
               case "b":
                    Console.WriteLine("Logging out. Goodbye!");
                    return;
                     default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;


            }
}
    }
   static void ManageAdmin(Login login,List<Student> students,List<Teacher> teachers){
        while (true)
        {
            Console.WriteLine("===== Admin Menu =====");
            Console.WriteLine("a. Students");
            Console.WriteLine("b. Teachers");
            Console.WriteLine("c. Modules");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch(choice){
                case "a":
                 while(true){
                     Console.WriteLine("a. Add Students");
                     Console.WriteLine("b. List Students");
                     Console.WriteLine("c. Delete Students");
                     Console.WriteLine("d. Edit Students");
                     Console.WriteLine("e. Back to menu");
                      Console.Write("Enter your choice: ");
                     string walid = Console.ReadLine();
                     switch(walid){
                        case "a":
                                 Console.WriteLine("===== Add Student =====");
                                 Student newStudent = new Student();

                                 Console.Write("Enter ID: ");
                                 if (int.TryParse(Console.ReadLine(), out int studentId))
                                {
                                  newStudent.Id = studentId;

                                 Console.Write("Enter Name: ");
                                 newStudent.Name = Console.ReadLine();

                                 Console.Write("Enter Current Class: ");
                                 newStudent.CurrentClass = Console.ReadLine();

                                 Console.Write("Enter Level: ");
                                 if (int.TryParse(Console.ReadLine(), out int level))
                                 {
                                 newStudent.Level = level;

                                Console.Write("Enter Expertise: ");
                                newStudent.Expertise = Console.ReadLine();

                                 Student.CreateStudent(newStudent,students);
                                }
                                else
                                {
                                Console.WriteLine("Invalid input for Level. Please enter a valid integer.");
                                }
                                }
                                else
                                {
                                Console.WriteLine("Invalid input for ID. Please enter a valid integer.");
                                }
                                break;

                                case "b":
                              Console.WriteLine("===== View Student Details =====");
                              Console.Write("Enter ID of the student to view details: ");
                              int viewId = int.Parse(Console.ReadLine());

                    // Create an instance of the Student class to call non-static methods
                             Student student = new Student();
                            Student.ViewStudentDetails(viewId);
                             break;
                             case "c":
                            Console.WriteLine("===== Delete Student =====");
                            Console.Write("Enter ID of the student to delete: ");
                            int deleteId = int.Parse(Console.ReadLine());

                Student.DeleteStudent(deleteId);
                break;
                case "d":
                 Console.WriteLine("===== Edit Student =====");
                Console.Write("Enter ID of the student to edit: ");
                int editId = int.Parse(Console.ReadLine());

                Student updatedStudent = new Student();

                Console.Write("Enter Updated Name: ");
                updatedStudent.Name = Console.ReadLine();

                Console.Write("Enter Updated Current Class: ");
                updatedStudent.CurrentClass = Console.ReadLine();

                Console.Write("Enter Updated Level: ");
                updatedStudent.Level = int.Parse(Console.ReadLine());

                Console.Write("Enter Updated Expertise: ");
                updatedStudent.Expertise = Console.ReadLine();

                Student.UpdateStudent(editId, updatedStudent);
                break;
                 default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
                case "e":
                 Console.WriteLine("Returning to Main Menu.");
                return;

                     }



                 }
            case "b":
             while(true){
                     Console.WriteLine("a. Add Teachers");
                     Console.WriteLine("b. List Teachers");
                     Console.WriteLine("c. Delete Teachers");
                     Console.WriteLine("d. Edit Teachers");
                     Console.WriteLine("e. Back to menu");
                      Console.Write("Enter your choice: ");
                     string amad = Console.ReadLine();
                     switch(amad){
                            case "a":
                            Console.WriteLine("===== Add Teacher =====");
                            Teacher newTeacher = new Teacher();

                            Console.Write("Enter ID: ");
                            if (int.TryParse(Console.ReadLine(), out int teacherId))
                            {
                                newTeacher.Id = teacherId;

                                Console.Write("Enter Name: ");
                                newTeacher.Name = Console.ReadLine();

                                Console.Write("Enter Assigned Courses (comma-separated): ");
                                newTeacher.AssignedCourses = Console.ReadLine().Split(',').Select(course => course.Trim()).ToList();

                                Teacher.CreateTeacher(newTeacher,teachers);
                                }
                               else
                               {
                                Console.WriteLine("Invalid input for ID. Please enter a valid integer.");
                               }
                               break;

                               case "b":
                                Console.WriteLine("===== List Teachers =====");
                                foreach (var teacher in teachers)
                                {
                                 Console.WriteLine($"ID: {teacher.Id}, Name: {teacher.Name}");
                                }
                                 break;

                                 case "c":
                                Console.WriteLine("===== Delete Teacher =====");
                                Console.Write("Enter ID of the teacher to delete: ");
                                int deleteTeacherId = int.Parse(Console.ReadLine());

                                Teacher.DeleteTeacher(deleteTeacherId);
                                break;

                                case "d":
                                Console.WriteLine("===== Edit Teacher =====");
                                Console.Write("Enter ID of the teacher to edit: ");
                                int editTeacherId = int.Parse(Console.ReadLine());

                                Teacher updatedTeacher = new Teacher();

                                Console.Write("Enter Updated Name: ");
                                updatedTeacher.Name = Console.ReadLine();

                                Console.Write("Enter Updated Assigned Courses (comma-separated): ");
                                updatedTeacher.AssignedCourses = Console.ReadLine().Split(',').Select(course => course.Trim()).ToList();

                                Teacher.UpdateTeacher(editTeacherId, updatedTeacher);
                                break;

                                case "e":
                                Console.WriteLine("Returning to Main Menu.");
                                return;
                                }
                                }
                   break;
           case "c":
                 while (true)
            {
                Console.WriteLine("===== Modules Menu =====");
                Console.WriteLine("a. Add Module");
                Console.WriteLine("b. List Modules");
                Console.WriteLine("c. Update Module");
                Console.WriteLine("d. Delete Module");
                Console.WriteLine("e. List Module Courses");
                Console.WriteLine("f. Back to Admin Menu");
                Console.Write("Enter your choice: ");
                string moduleChoice = Console.ReadLine();

                switch (moduleChoice.ToLower())
                {
                    case "a":
                        Console.WriteLine("===== Add Module =====");
                        Console.Write("Enter Module Name: ");
                        string moduleName = Console.ReadLine();
                        Module.CreateModule(moduleName);
                        break;

                    case "b":
                        Console.WriteLine("===== List Modules =====");
                        Module.ViewAllModules();
                        break;

                    case "c":
                        Console.WriteLine("===== Update Module =====");
                        Console.Write("Enter Module ID to update: ");
                        if (int.TryParse(Console.ReadLine(), out int updateModuleId))
                        {
                            Console.Write("Enter New Module Name: ");
                            string newModuleName = Console.ReadLine();
                            Module.UpdateModule(updateModuleId, newModuleName);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for Module ID. Please enter a valid integer.");
                        }
                        break;

                    case "d":
                        Console.WriteLine("===== Delete Module =====");
                        Console.Write("Enter Module ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteModuleId))
                        {
                            Module.DeleteModule(deleteModuleId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for Module ID. Please enter a valid integer.");
                        }
                        break;

                    case "e":
                        Console.WriteLine("===== List Module Courses =====");
                        Console.Write("Enter Module ID to list courses: ");
                        if (int.TryParse(Console.ReadLine(), out int listModuleId))
                        {
                            Module.ListModuleCourses(listModuleId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for Module ID. Please enter a valid integer.");
                        }
                        break;

                    case "f":
                        Console.WriteLine("Returning to Admin Menu.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");

                break;



                     }

            }

    }



        }
   }
}
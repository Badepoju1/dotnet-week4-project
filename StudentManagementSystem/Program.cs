using System;
using System.Collections.Generic;

List<string> studentNames = new List<string>();
List<int> studentIDs = new List<int>();
List<double> studentGrades = new List<double>();
List<bool> enrollmentStatus = new List<bool>();

Console.WriteLine("\n=== Student Management System ===");
        Console.WriteLine("1. Add New Student");
        Console.WriteLine("2. View All Students");
        Console.WriteLine("3. Calculate Average Grade");
        Console.WriteLine("4. Find Student by ID");
        Console.WriteLine("5. Update Student Grade");
        Console.WriteLine("6. Delete Student");
        Console.WriteLine("7. Display Statistics");
        Console.WriteLine("8. Exit");

        Console.Write("\nSelect an option: ");
        int option = Convert.ToInt32(Console.ReadLine());

        if (option == 8)
        {
            Console.WriteLine("Program terminated. Thank you.");
            break;
        }

        switch (option)
        {
            case 1: // Student addition functionalities 

                Console.Write("Enter Student Fullname: ");
                string fullName = Console.ReadLine();

                Console.Write("Enter Student ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                if (id <= 0)
                {
                    Console.WriteLine("ID must be positive.");
                    break;
                }

                Console.Write("Enter student grade (0-100): ");
                double grade = Convert.ToDouble(Console.ReadLine());

                if (grade < 0 || grade > 100)
                {
                    Console.WriteLine("Grade must be between 0 and 100.");
                    break;
                }

                studentNames.Add(fullName);
                studentIDs.Add(id);
                studentGrades.Add(grade);
                enrollmentStatus.Add(true);

                Console.WriteLine("Student added successfully.");
                break;

            case 2: // Student record veiwing functionalities

                if (studentNames.Count == 0)
                {
                    Console.WriteLine("No students available.");
                    break;
                }

                Console.WriteLine("\nName\tID\tGrade\tStatus");

                for (int i = 0; i < studentNames.Count; i++)
                {
                    string status = studentGrades[i] >= 60 ? "Pass" : "Fail";

                    Console.WriteLine($"{studentNames[i]}\t{studentIDs[i]}\t{studentGrades[i]}\t{status}");
                }

                break;

            case 3: // implement grade calculations functionalities

                if (studentGrades.Count == 0)
                {
                    Console.WriteLine("No students to calculate average.");
                    break;
                }

                double total = 0;

                for (int i = 0; i < studentGrades.Count; i++)
                {
                    total += studentGrades[i];
                }

                double average = total / studentGrades.Count;

                Console.WriteLine($"Average Grade: {average:F2}");

                break;

            case 4: //

                Console.Write("Enter Student ID: ");
                int searchId = Convert.ToInt32(Console.ReadLine());

                int index = studentIDs.IndexOf(searchId);

                if (index != -1)
                {
                    Console.WriteLine("\nStudent Found");
                    Console.WriteLine($"Name: {studentNames[index]}");
                    Console.WriteLine($"Grade: {studentGrades[index]}");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }

                break;

            case 5:

                Console.Write("Enter Student ID: ");
                searchId = Convert.ToInt32(Console.ReadLine());

                index = studentIDs.IndexOf(searchId);

                if (index != -1)
                {
                    Console.Write("Enter new grade: ");
                    double newGrade = Convert.ToDouble(Console.ReadLine());

                    if (newGrade < 0 || newGrade > 100)
                    {
                        Console.WriteLine("Invalid grade.");
                        break;
                    }

                    studentGrades[index] = newGrade;

                    Console.WriteLine("Grade updated successfully.");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }

                break;

            case 6:

                Console.Write("Enter Student ID to delete: ");
                searchId = Convert.ToInt32(Console.ReadLine());

                index = studentIDs.IndexOf(searchId);

                if (index != -1)
                {
                    studentNames.RemoveAt(index);
                    studentIDs.RemoveAt(index);
                    studentGrades.RemoveAt(index);
                    enrollmentStatus.RemoveAt(index);

                    Console.WriteLine("Student deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }

                break;

            case 7: // implement statistics functionalities

                if (studentGrades.Count == 0)
                {
                    Console.WriteLine("No data available.");
                    break;
                }

                double highest = studentGrades[0];
                double lowest = studentGrades[0];

                int pass = 0;
                int fail = 0;

                for (int i = 0; i < studentGrades.Count; i++)
                {
                    if (studentGrades[i] > highest)
                        highest = studentGrades[i];

                    if (studentGrades[i] < lowest)
                        lowest = studentGrades[i];

                    if (studentGrades[i] >= 60)
                        pass++;
                    else
                        fail++;
                }

                Console.WriteLine($"Highest Grade: {highest}");
                Console.WriteLine($"Lowest Grade: {lowest}");
                Console.WriteLine($"Passing Students: {pass}");
                Console.WriteLine($"Failing Students: {fail}");

                break;

            default:
                Console.WriteLine("Invalid option.");
                break;
        }
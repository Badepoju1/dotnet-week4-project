
// See https://aka.ms/new-console-template for more information

using System.Diagnostics.Metrics;
using System.Threading.Tasks.Dataflow;
using System.Collections.Generic;
using System;
using System.Linq;

int counter = 0;
string[] studentNames = new string[10];
int[] studentIDs = new int[10];
double[] studentGrades = new double[10];
bool[] enrollmentStatus = new bool[10];

while(true)
{   
    try // Implement a try-catch block to handle System.FormatException exceptions triggered by invalid user input, ensuring the application remains stable and provides a user-friendly error message.
    {
        Console.WriteLine("=== Student Management System ==="); // Display the Menu Option Page
        Console.WriteLine();
        Console.WriteLine("1. Add New Student");
        Console.WriteLine("2. View All Students");
        Console.WriteLine("3. Calculate Average Grade");
        Console.WriteLine("4. Find Student by ID");
        Console.WriteLine("5. Update Student Grade");
        Console.WriteLine("6. Delete Student");
        Console.WriteLine("7. Display Statistics");
        Console.WriteLine("8. Exit");
        Console.WriteLine();

        Console.WriteLine("Select An Option from the Menu Page");
        int option = Convert.ToInt32(Console.ReadLine()); // Input Preferred Menu Option

        if (option == 8) // to exit the menu page when the option selected is 4
        {
            Console.WriteLine("You Have Successfully Terminate SMS Operations, Thank you. ");
            Console.WriteLine();
            Console.WriteLine("Press Any Key to Continue. ");
            Console.ReadLine();
        }

        switch (option)
        {
            case 1:
                Console.Write("Enter Student Fullname: "); // Ask for student name
                string fullName = Console.ReadLine()!; // Store name

                Console.Write("Enter Student ID: "); // Ask for ID
                int id = Convert.ToInt32(Console.ReadLine()); // Convert input to integer

                // Check if ID is positive
                if (id <= 0)
                {
                    Console.WriteLine("ID must be positive Number.");
                    break;
                }

                Console.Write("Enter student grade (0-100): "); // Ask for grade
                double grade = Convert.ToDouble(Console.ReadLine()); // Convert to double

                // Validate grade range
                if (grade < 0 || grade > 100)
                {
                    Console.WriteLine("Grade must be between 0 and 100.");
                    break;
                }

                // Store student information in arrays
                studentNames[counter] = fullName;
                studentIDs[counter] = id;
                studentGrades[counter] = grade;
                enrollmentStatus[counter] = true;

                counter++; // Increase student count

                Console.WriteLine("Student added successfully.");
            break;

            case 2:
                if (counter == 0)
                {
                    Console.WriteLine("No students available.");
                    break;
                }

                for (int i = 0; i < counter; i++)
                {
                    string status = studentGrades[i] >= 60 ? "Pass" : "Fail";

                    Console.WriteLine("\nStudentName\tStudentID\tStudentGrade\tStatus");

                    Console.WriteLine($"{studentNames[i]}\t{studentIDs[i]}\t\t{studentGrades[i]}\t\t{status}");
                }
            break;

            case 3:
                if (counter == 0)
                {
                    Console.WriteLine("No students record to calculate average.");
                    break;
                }

                double total = 0;

                for (int i = 0; i < counter; i++)
                {
                    total += studentGrades[i];
                }

                double average = total / counter;

                Console.WriteLine($"Average Grade: {average:F2}");
            break;

            case 4:

                Console.Write("Enter Student ID: "); // Ask for ID
                int searchid = Convert.ToInt32(Console.ReadLine()); // Convert input to integer

                for (int i = 0; i < counter; i++)
                {
                    if (studentIDs[i] == searchid)
                    {
                        Console.WriteLine("\nStudent Name\tStudent ID\tStudent Grade");
                        Console.WriteLine($"{studentNames[i]}\t{studentIDs[i]}\t\t{studentGrades[i]}");
                    }

                    else
                    {
                        Console.WriteLine($"No Record Found For StudentID {searchid}");
                    }
                }
            break;
            
            case 5:
            
                for (int i = 0; i < counter; i++)
                {
                    Console.Write("Enter Student ID: "); // Ask for ID
                    searchid = Convert.ToInt32(Console.ReadLine()); // Convert input to integer
                    if (studentIDs[i] == searchid)
                    {
                        Console.Write("Enter New Grade: "); // Ask for ID
                        double newGrade = Convert.ToInt32(Console.ReadLine()); // Convert input to integer
                        if (newGrade < 0 || newGrade > 100)
                        {
                            Console.WriteLine("Invalid grade, Student grade should be between 0-100");
                            break;
                        }
                        studentGrades[i] = newGrade;
                        Console.WriteLine($"The new grade for student with ID {studentIDs[i]} has been succesfully updated");
                    }

                    else
                    {
                        Console.WriteLine($"The ID {searchid} not found");
                    }
                }
            break;
            case 6:
                Console.Write("Enter Student ID: "); // Ask for ID
                searchid = Convert.ToInt32(Console.ReadLine()); // Convert input to integer
                for (int i = 0; i < counter; i++)
                {
                    if (counter == 0 || studentIDs[i] != searchid)
                    {
                        Console.WriteLine("No students record to calculate average.");
                        break;
                    }

                    Console.Write($"Are you sure you want to delete {student.Name} (ID: {student.ID})? (yes/no): ");
                    string confirm = Console.ReadLine()!.Trim().ToLower();
                    
                    if (confirm == "yes" || confirm == "y")
                    {
                        searchid.(studentIDs[i]);
                        Console.WriteLine("Student deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Deletion cancelled.");
                    }
                }
            break;

            case 7:
                
                if (counter == 0)
                    {
                        Console.WriteLine("No data available.");
                        return;
                    }

                    double highest = studentGrades[0]; // Start with first grade
                    double lowest = studentGrades[0];

                    int pass = 0;
                    int fail = 0;

                    // Loop through all students
                    for (int i = 0; i < counter; i++)
                    {
                        if (studentGrades[i] > highest) // Check highest
                            highest = studentGrades[i];

                        if (studentGrades[i] < lowest) // Check lowest
                            lowest = studentGrades[i];

                        if (studentGrades[i] >= 60) // Count passing
                            pass++;
                        else
                            fail++;
                    }

                Console.WriteLine("Highest Grade: " + highest);
                Console.WriteLine("Lowest Grade: " + lowest);
                Console.WriteLine("Passing Students: " + pass);
                Console.WriteLine("Failing Students: " + fail);
            break;
            
        } 
    }
    catch (System.FormatException ex)
    {
        Console.WriteLine($"Error: In: {ex.Message}");
        Console.WriteLine();
    } 
    
}
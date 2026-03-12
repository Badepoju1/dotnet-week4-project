using System;                  // Provides basic system functionalities, including Console input/output
using System.Collections.Generic; // Provides generic collection classes like List<T>

// Lists to store student data
List<string> studentNames = new List<string>();    // Stores full names of students
List<int> studentIDs = new List<int>();            // Stores unique student IDs
List<double> studentGrades = new List<double>();  // Stores student grades
List<bool> enrollmentStatus = new List<bool>();    // Stores enrollment status (true = enrolled)

// Variables for searching and indexing
int searchId;   // Temporary variable to store user input for student ID searches
int index;      // Stores index of student in lists after search

// Main loop to keep the program running until user chooses to exit

// Display to get letter grade method
string GetLetterGrade(double grade)
{
    if (grade >= 90) return "A";
    else if (grade >= 80) return "B";
    else if (grade >= 70) return "C";
    else if (grade >= 60) return "D";
    else return "F";
}

void DisplayStudents() // Sorted by display method
{
    if (studentNames.Count == 0)
    {
        Console.WriteLine("No students available.");
        return;
    }

    Console.WriteLine("\nName\t\tID\tGrade\tLetter\tStatus");
    for (int i = 0; i < studentNames.Count; i++)
    {
        string status = studentGrades[i] >= 60 ? "Pass" : "Fail";
        string letter = GetLetterGrade(studentGrades[i]);
        Console.WriteLine($"{studentNames[i]}\t{studentIDs[i]}\t{studentGrades[i]}\t{letter}\t{status}");
    }
}

while (true)
{
    try
    {
        // Display main menu
        Console.WriteLine("\n=== Student Management System ===");
        Console.WriteLine("1. Add New Student");
        Console.WriteLine("2. View All Students");
        Console.WriteLine("3. Calculate Average Grade");
        Console.WriteLine("4. Find Student by ID");
        Console.WriteLine("5. Update Student Grade");
        Console.WriteLine("6. Delete Student");
        Console.WriteLine("7. Display Statistics");
        Console.WriteLine("8. Exit");
        Console.WriteLine("9. Find  Student by Name");
        Console.WriteLine("10. Sorting Option");

        Console.Write("\nSelect an option: ");
        int option = Convert.ToInt32(Console.ReadLine()); // Read user option and convert to integer

        // Exit option
        if (option == 8)
        {
            Console.WriteLine("Program is successfully terminated. Thank you."); // Friendly termination message
            break;              // Exit the while loop
        }

        // Handle user option
        switch (option)
        {
            case 1: // Add New Student
                Console.Write("Enter Student Fullname: ");
                string fullName = Console.ReadLine()!; // Get student's full name

                Console.Write("Enter Student ID: ");
                int id = Convert.ToInt32(Console.ReadLine()); // Get student ID

                // Validate ID
                if (id <= 0)
                {
                    Console.WriteLine("ID must be positive."); // ID must be greater than zero
                }
                else if (studentIDs.Contains(id))
                {
                    Console.WriteLine("A student with this ID already exists."); // Prevent duplicate IDs
                }
                else
                {
                    Console.Write("Enter student grade (0-100): ");
                    double grade = Convert.ToDouble(Console.ReadLine()); // Get student grade

                    // Validate grade
                    if (grade < 0 || grade > 100)
                    {
                        Console.WriteLine("Grade must be between 0 and 100."); // Ensure grade is in valid range
                    }
                    else
                    {
                        // Add student details to corresponding lists
                        studentNames.Add(fullName);
                        studentIDs.Add(id);
                        studentGrades.Add(grade);
                        enrollmentStatus.Add(true); // Set enrollment as active by default

                        Console.WriteLine("Student added successfully."); // Confirmation message
                    }
                }

                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
                Console.Clear(); // Clear screen before redisplaying menu
                break;

            case 2: // View All Students
                if (studentNames.Count == 0)
                {
                    Console.WriteLine("No students available."); // No students to display
                }
                else
                {
                    // Display table headers
                    Console.WriteLine("\nName\t\tID\tGrade\tStatus");
                    for (int i = 0; i < studentNames.Count; i++)
                    {
                        string status = studentGrades[i] >= 60 ? "Pass" : "Fail"; // Determine pass/fail
                        Console.WriteLine($"{studentNames[i]}\t{studentIDs[i]}\t{studentGrades[i]}\t{status}"); // Display student info
                    }
                }

                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
                Console.Clear();
                break;

            case 3: // Calculate Average Grade
                if (studentGrades.Count == 0)
                {
                    Console.WriteLine("No students to calculate average."); // No grades available
                }
                else
                {
                    double total = 0; // Initialize total sum of grades
                    for (int i = 0; i < studentGrades.Count; i++)
                        total += studentGrades[i]; // Sum all grades

                    double average = total / studentGrades.Count; // Compute average
                    Console.WriteLine($"Average Grade: {average:F2}"); // Display average rounded to 2 decimal places
                }

                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
                Console.Clear();
                break;

            case 4: // Find Student by ID
                Console.Write("Enter Student ID: ");
                searchId = Convert.ToInt32(Console.ReadLine()); // Get student ID to search

                index = studentIDs.IndexOf(searchId); // Find index of student in list

                if (index != -1)
                {
                    // Student found, display details
                    Console.WriteLine("\nStudent Record Found");
                    Console.WriteLine("\nName\t\tID\tGrade");
                    Console.WriteLine($"{studentNames[index]}\t{studentIDs[index]}\t{studentGrades[index]}"); // Corrected 'i' to 'index'
                }
                else
                {
                    Console.WriteLine("Student not found."); // Student ID does not exist
                }

                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
                Console.Clear();
                break;

            case 5: // Update Student Grade
                Console.Write("Enter Student ID: ");
                searchId = Convert.ToInt32(Console.ReadLine()); // Get ID to update

                index = studentIDs.IndexOf(searchId); // Find student index

                if (index != -1)
                {
                    Console.Write("Enter new grade: ");
                    double newGrade = Convert.ToDouble(Console.ReadLine()); // Get updated grade

                    if (newGrade < 0 || newGrade > 100)
                        Console.WriteLine("Invalid grade."); // Validate grade
                    else
                    {
                        studentGrades[index] = newGrade; // Update grade in list
                        Console.WriteLine("Grade updated successfully.");
                    }
                }
                else
                {
                    Console.WriteLine("Student not found."); // Student ID not found
                }

                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
                Console.Clear();
                break;

            case 6: // Delete Student
                Console.Write("Enter Student ID to delete: ");
                searchId = Convert.ToInt32(Console.ReadLine()); // Get ID to delete

                index = studentIDs.IndexOf(searchId); // Find student index

                if (index != -1)
                {
                    Console.WriteLine($"Student Found: {studentNames[index]}"); // Display student to delete
                    Console.Write("Are you sure you want to delete this student? (yes/no): ");
                    string confirm = Console.ReadLine()!.ToLower(); // Confirm deletion

                    if (confirm.StartsWith("y"))
                    {
                        // Remove student details from all lists
                        studentNames.RemoveAt(index);
                        studentIDs.RemoveAt(index);
                        studentGrades.RemoveAt(index);
                        enrollmentStatus.RemoveAt(index);

                        Console.WriteLine("Student deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Deletion cancelled."); // Cancel deletion
                    }
                }
                else
                {
                    Console.WriteLine("Student not found."); // ID does not exist
                }

                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
                Console.Clear();
                break;

            case 7: // Display Statistics
                if (studentGrades.Count == 0)
                {
                    Console.WriteLine("No data available."); // No students to compute stats
                }
                else
                {
                    double highest = studentGrades[0]; // Initialize highest grade
                    double lowest = studentGrades[0];  // Initialize lowest grade
                    int pass = 0;                      // Count of passing students
                    int fail = 0;                      // Count of failing students

                    for (int i = 0; i < studentGrades.Count; i++)
                    {
                        if (studentGrades[i] > highest) highest = studentGrades[i]; // Update highest grade
                        if (studentGrades[i] < lowest) lowest = studentGrades[i];   // Update lowest grade
                        if (studentGrades[i] >= 60) pass++;                          // Count passing
                        else fail++;                                                  // Count failing
                    }

                    // Display statistics
                    Console.WriteLine("Dtudent Grades Statistics");
                    Console.WriteLine($"Highest Grade: {highest}");
                    Console.WriteLine($"Lowest Grade: {lowest}");
                    Console.WriteLine($"No of Students Passed: {pass}");
                    Console.WriteLine($"No of Students Failed: {fail}");
                }

                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
                Console.Clear();
                break;
            case 9: // Search by Student Name
            
                Console.Write("Enter name to search (partial names allowed): ");
                string searchName = Console.ReadLine()!.ToLower(); // Read user input and convert to lowercase for case-insensitive search
                bool found = false; // Flag to track whether any matching student is found

                Console.WriteLine("\nName\t\tID\tGrade\tStatus");

                index = studentNames.IndexOf(searchName); // Attempt to find exact match index (not required for partial search but kept for reference)

                for (int i = 0; i < studentNames.Count; i++) // Loop through all student names
                {
                    // Check if the current student name contains the search text (partial match allowed)
                    if (studentNames[i].ToLower().Contains(searchName))
                    {
                        string status = studentGrades[i] >= 60 ? "Pass" : "Fail"; // Determine pass/fail based on grade
                        string letter = GetLetterGrade(studentGrades[i]); // Convert numeric grade to letter grade

                        // Display student information
                        Console.WriteLine($"{studentNames[i]}\t{studentIDs[i]}\t{studentGrades[i]}\t{letter}\t{status}");

                        found = true; // Mark that at least one student was found
                    }
                }

                // If no students matched the search criteria
                if (!found) 
                {
                    Console.WriteLine("No students found matching that name.");
                }

                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey(); // Wait for user input before returning to menu
                Console.Clear();
                break;

            case 10: // Sort Students (Bonus)

                Console.WriteLine("Sort by:\n1. Grade (High → Low)\n2. Name (A → Z)\n3. ID (Ascending)");
                Console.WriteLine("Select an Option for Sorting");

                int sortOption = Convert.ToInt32(Console.ReadLine()); // Read user sort option

                // Sort students by Grade (highest to lowest)
                if (sortOption == 1)
                {
                    List<double> sortedGrades = new List<double>(studentGrades); // Create copy of grades list
                    sortedGrades.Sort(); // Sort grades in ascending order
                    sortedGrades.Reverse(); // Reverse list to make it descending (high → low)

                    // Temporary lists to keep related student data aligned with sorted grades
                    List<string> tempNames = new List<string>();
                    List<int> tempIDs = new List<int>();
                    List<bool> tempStatus = new List<bool>();

                    foreach (double g in sortedGrades) // Loop through sorted grades
                    {
                        int idx = studentGrades.IndexOf(g); // Find original index of the grade

                        // Add corresponding student data to temporary lists
                        tempNames.Add(studentNames[idx]);
                        tempIDs.Add(studentIDs[idx]);
                        tempStatus.Add(enrollmentStatus[idx]);
                    }

                    // Replace original lists with sorted versions
                    studentGrades = sortedGrades;
                    studentNames = tempNames;
                    studentIDs = tempIDs;
                    enrollmentStatus = tempStatus;
                }

                // Sort students alphabetically by Name
                else if (sortOption == 2)
                {
                    List<string> sortedNames = new List<string>(studentNames); // Copy student names
                    sortedNames.Sort(); // Sort names alphabetically

                    // Temporary lists to maintain correct student information alignment
                    List<int> tempIDs = new List<int>();
                    List<double> tempGrades = new List<double>();
                    List<bool> tempStatus = new List<bool>();

                    foreach (string n in sortedNames)
                    {
                        int idx = studentNames.IndexOf(n); // Find original index of the name

                        // Add matching student data
                        tempIDs.Add(studentIDs[idx]);
                        tempGrades.Add(studentGrades[idx]);
                        tempStatus.Add(enrollmentStatus[idx]);
                    }

                    // Replace original lists with sorted data
                    studentNames = sortedNames;
                    studentIDs = tempIDs;
                    studentGrades = tempGrades;
                    enrollmentStatus = tempStatus;
                }

                // Sort students by ID in ascending order
                else if (sortOption == 3)
                {
                    List<int> sortedIDs = new List<int>(studentIDs); // Copy student IDs
                    sortedIDs.Sort(); // Sort IDs in ascending order

                    // Temporary lists to store corresponding student information
                    List<string> tempNames = new List<string>();
                    List<double> tempGrades = new List<double>();
                    List<bool> tempStatus = new List<bool>();

                    foreach (int idSort in sortedIDs)
                    {
                        int idx = studentIDs.IndexOf(idSort); // Find original index of the ID

                        // Add related student data
                        tempNames.Add(studentNames[idx]);
                        tempGrades.Add(studentGrades[idx]);
                        tempStatus.Add(enrollmentStatus[idx]);
                    }

                    // Update main lists with sorted values
                    studentIDs = sortedIDs;
                    studentNames = tempNames;
                    studentGrades = tempGrades;
                    enrollmentStatus = tempStatus;
                }

                else 
                    Console.WriteLine("Invalid sort option."); // Handle invalid input

                Console.WriteLine("Sorted Students:");
                DisplayStudents(); // Call method to display updated sorted student list

                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey(); // Pause before returning to menu
                Console.Clear();
                break;

            default: // Handle invalid menu option
                Console.WriteLine("Invalid option."); 
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();

                break;
        }
    }
    catch (FormatException ex) // Handle invalid input format
    {
        Console.WriteLine($"Invalid Input Format: {ex.Message}"); // Display error message
        Console.WriteLine("\nPress any key to return to the menu...");
        Console.ReadKey();
    }
}
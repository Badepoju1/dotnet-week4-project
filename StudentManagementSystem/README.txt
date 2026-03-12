Student Management System

Description: This is a console-based Student Management System built in C# that allows users to manage student records efficiently. The program supports adding, viewing, updating, and deleting student data, as well as calculating grades and generating statistics. 
It demonstrates basic programming concepts such as loops, conditionals, variables, lists, and error handling.

## Features
- **Add New Student:** Input student name, unique ID, and grade. Ensures ID uniqueness and valid grade range.
- **View All Students:** Display all student records with pass/fail status based on grade.
- **Calculate Average Grade:** Compute and display the average grade of all students.
- **Find Student by ID:** Search and display a student record using their ID.
- **Update Student Grade:** Modify an existing student's grade.
- **Delete Student:** Remove a student record after confirmation.
- **Display Statistics:** Show highest and lowest grades, and count of passing and failing students.
- **Exit Program:** Safely terminate the program with a confirmation message.

## Example Usage
=== Student Management System ===

1. Add New Student

2. View All Students

3. Calculate Average Grade

4. Find Student by ID

5. Update Student Grade

6. Delete Student

7. Display Statistics

8. Exit

Select an option: 1
Enter Student Fullname: John Doe
Enter Student ID: 101
Enter student grade (0-100): 85
Student added successfully.

Press any key to return to the menu...

## After adding multiple students, selecting option `2` will display:
Name     ID    Grade Status
John Doe 101    85    Pass
Jane Smith 102   55   Fail

## Option `7` displays statistics:
Highest Grade: 85
Lowest Grade: 55
Passing Students: 1
Failing Students: 1


## Concepts Demonstrated
- **Variables:** Storing student names, IDs, grades, and statuses.
- **Lists:** Dynamic storage of student information.
- **Loops:** `while` loop for the main menu; `for` loops for processing lists.
- **Conditionals:** `if`, `else if`, `else`, and `switch` statements for program logic.
- **Operators:** Arithmetic (`+`, `-`, `/`), comparison (`>`, `<`, `>=`, `<=`), and logical operators.
- **Error Handling:** `try-catch` blocks for invalid input handling.
- **Functions (Optional):** Modular structure can be extended with functions for cleaner code.

## Challenges Faced
- Ensuring **unique student IDs** and preventing duplicates.
- Validating **grades** to ensure they stay between 0 and 100.
- Handling **empty lists** when calculating averages or displaying statistics.
- Managing **input errors** gracefully without crashing the program.
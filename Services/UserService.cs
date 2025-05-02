using MyDotNetApp.Data;
using MyDotNetApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MyDotNetApp.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ Create User
        public (bool success, string message, User? user) AddUser(User user)
        {
            if (user == null) return (false, "Invalid user data!", null);

            _context.Users.Add(user);
            _context.SaveChanges();

            return (true, "User added successfully!", user);
        }

        // ✅ Get all users with pagination
        public (bool success, string message, object? data) GetUsers(int page, int pageSize)
        {
            var totalUsers = _context.Users.Count();
            var users = _context.Users
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();

            if (!users.Any()) return (false, "No users found!", null);

            return (true, "Users retrieved successfully!", new
            {
                totalUsers,
                page,
                pageSize,
                users
            });
        }

        // ✅ Get user by ID
        public (bool success, string message, User? user) GetUserById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return (false, "User not found!", null);

            return (true, "User found!", user);
        }

        // ✅ Update user details
        public (bool success, string message, User? user) UpdateUser(int id, User updatedUser)
        {
            var existingUser = _context.Users.Find(id);
            if (existingUser == null) return (false, "User not found!", null);

            existingUser.Name = updatedUser.Name;
            existingUser.Email = updatedUser.Email;

            _context.SaveChanges();
            return (true, "User updated successfully!", existingUser);
        }

        // ✅ Delete user
        public (bool success, string message) DeleteUser(int id)
        {
            var existingUser = _context.Users.Find(id);
            if (existingUser == null) return (false, "User not found!");

            _context.Users.Remove(existingUser);
            _context.SaveChanges();

            return (true, "User deleted successfully!");
        }
    }
}




Student Records Management - GET By Id
Description





Student Records Management - GET By Id

A school is looking to create a web service application using Web API in .NET Framework to manage student records. The application will provide endpoints to retrieve the student information.

Create a Service application using Web API .Net Framework.

 

Functionality  

1. In class  Student.cs the properties are already declared.

2. Below code snippet is already given with values predefined in StudentController,

public static List<Student> StudentRecords = new List<Student>()

  Id

  FirstName

  LastName

  GPA

  101

  John

  Doe

   3.6

  102

 Jane

  Smith

   3.9

  103

  Robert

  Johnson

  3.5

  104

  Emily

  Brown

   4.0

  105

  Michael

  Lee

   3.8

 
3. Create a GET method with attribute routing "~/api/get-student/{id}" that returns the student record as a student object.

The GetStudentById method retrieves the student detail from the StudentRecords and return the detail as an object. The ID should be passed as a parameter marked as [FromUri].





xsp4
Listening on address: 0.0.0.0
Root directory: /home/p14774/WebAPI_Framework/WebAPI_Framework
Listening on port: 14774 (non-secure)
NUnit Console Runner 3.10.0 (.NET 2.0)
Copyright (c) 2019 Charlie Poole, Rob Prouse
Friday, May 2, 2025 9:14:37 AM

Runtime Environment
   OS Version: Linux 4.4.0.1128 
  CLR Version: 4.0.30319.42000

Test Files
    /home/p14774/WebAPI_Framework/WebAPI_Framework/bin/WebAPI_Framework.dll


Errors, Failures and Warnings

1) Failed : WebAPI_Framework.TestCase.Test1_GetMethod_StatusCodeTest
'api/get-student/{id}' is not working properly.
  at WebAPI_Framework.TestCase.ExceptionCatch (System.String functionName, System.String catchMsg, System.String msg, System.String msg_name, System.String exceptionMsg) [0x00000] in <97a6e4c519054b51b96745e43744cfb7>:0 
  at WebAPI_Framework.TestCase.Test1_GetMethod_StatusCodeTest () [0x00000] in <97a6e4c519054b51b96745e43744cfb7>:0 

Run Settings
    DisposeRunners: True
    WorkDirectory: /home/p14774
    ImageRuntimeVersion: 4.0.30319
    ImageTargetFrameworkName: .NETFramework,Version=v4.7.2
    ImageRequiresX86: False
    ImageRequiresDefaultAppDomainAssemblyResolver: False
    NumberOfTestWorkers: 2

Test Run Summary
  Overall result: Failed
  Test Count: 2, Passed: 1, Failed: 1, Warnings: 0, Inconclusive: 0, Skipped: 0
    Failed Tests - Failures: 1, Errors: 0, Invalid: 0
  Start time: 2025-05-02 03:44:38Z
    End time: 2025-05-02 03:44:41Z
    Duration: 3.224 seconds

Results (nunit3) saved as TestResult.xml
<|--

>Fail 1 -- Test1_GetMethod_StatusCodeTest::
>
>'api/get-student/{id}' is not working properly.
>
--|>
MarksCalculation.cs(44,30): warning CS0168: The variable `e' is declared but never used
MarksCalculation.cs(65,20): warning CS0219: The variable `blockTotal' is assigned but its value is never used
MarksCalculation.cs(66,20): warning CS0219: The variable `blockActualTotal' is assigned but its value is never used
MarksCalculation.cs(103,24): warning CS0219: The variable `obtainedmark' is assigned but its value is never used
MarksCalculation.cs(245,31): warning CS0219: The variable `scored' is assigned but its value is never used
MarksCalculation.cs(246,36): warning CS0219: The variable `totmark' is assigned but its value is never used
MarksCalculation.cs(22,20): warning CS0414: The private field `MarksCalculation.ConsoleTemp' is assigned but its value is never used
MarksConfig.cs(27,24): warning CS0169: The private field `Functiontested.name' is never used
MarksConfig.cs(28,34): warning CS0169: The private field `Functiontested.expertises' is never used
MarksConfig.cs(45,24): warning CS0169: The private field `Expertise.name' is never used
MarksConfig.cs(46,23): warning CS0169: The private field `Expertise.grade' is never used
MarksConfig.cs(47,33): warning CS0169: The private field `Expertise.testcases' is never used
MarksConfig.cs(121,24): warning CS0169: The private field `Grade.complete' is never used
MarksConfig.cs(122,24): warning CS0169: The private field `Grade.partial' is never used
MarksConfig.cs(123,24): warning CS0169: The private field `Grade.incomplete' is never used
TestConsole.cs(15,20): warning CS0414: The private field `TestConsole.failCount' is assigned but its value is never used
Compilation succeeded - 16 warning(s)
Testcase Total 2
Comment :=>>- Grading and Feedback
Grade :=>> 60
<|--
>To Work With Web API - 60 / 100 (Partial Success)
--|>
<|--
>        Check whether the implementation of Get code status correctness                                               :    0/40
--|>
<|--
>        Check whether the implementation of Get service logic and return data correctness                             :    60/60
--|>
Comment :=>> Assessment Partially Implemented. Good. Try Again.


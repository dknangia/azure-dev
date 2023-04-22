using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.NewFeatures
{
    public class PositionalPatternSample
    {

        public void CallFunction()
        {
            List<Student> students = new List<Student>
            {
                new Student("Mark", "King", new Teacher("Linda", "Smith", "Math"), 7),
                new Student("Mark", "King", new Teacher("Martha", "Smith", "Math"), 4),
                new Student("Mark", "King", new Teacher("Linda", "Smith", "Math"), 11), 
                new Student("Mark", "King", new Teacher("Richeal", "Smith", "Math"), 6), 
                new Student("Mark", "King", new Teacher("Denise", "Smith", "Math"), 2), 

            };


            foreach (var student in students)
            {
                Console.WriteLine(IsInSeventhGradeMath(student));
            }
            
        }

        public static bool IsInSeventhGradeMath(Student s)
        {
            // #1
            // return s is (_, _, (_,_,"Math"), 7);

            //#2
            return s is {GradeLevel: >=7, HomeRoomTeacher: {FirstName: "Linda"}};
        }

    }

    public class Student
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Teacher HomeRoomTeacher { get; set; }

        public int GradeLevel { get; set; }

        public Student(string firstName, string lastName, Teacher homeRoomTeacher, int gradeLevel)
        {
            FirstName = firstName;
            LastName = lastName;
            HomeRoomTeacher = homeRoomTeacher;
            GradeLevel = gradeLevel;
        }

        public void Deconstruct(out string firstName, out string lastName, out Teacher homeRoomTeacher, out int gradeLevel)
        {
            firstName = FirstName;
            lastName = LastName;
            homeRoomTeacher = HomeRoomTeacher;
            gradeLevel = GradeLevel;
        }
    }

    public class Teacher
    {
        public Teacher(string firstName, string lastName, string subject)
        {
            FirstName = firstName;
            LastName = lastName;
            Subject = subject;
        }

        public void Deconstruct(out string firstName, out string lastName, out string subject)
        {
            firstName = FirstName;
            lastName = LastName;
            subject = Subject; 
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string  Subject { get; set; }
    }
}

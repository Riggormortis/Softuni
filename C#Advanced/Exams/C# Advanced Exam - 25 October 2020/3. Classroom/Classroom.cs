using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ClassroomProject
{
    public class Classroom
    {
        public Classroom(int capacity)
        {
            Capacity = capacity;
            Students = new List<Student>();
        }


        public List<Student> Students { get; set; } = new List<Student>();

        public int Capacity { get; set; }

        public int Count => Students.Count;
        
        public string RegisterStudent(Student student)
        {
            if (Students.Count == Capacity)
            {
                //no seats
               return "No seats in the classroom";
            }

            Students.Add(student);
            return $"Added student {student.FirstName} {student.LastName}";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = Students.FirstOrDefault(x=> x.FirstName == firstName && x.LastName == lastName);

            if (student is null)
            {
               return "Student not found";
            }

            Students.Remove(student);
            return $"Dismissed student {student.FirstName} {student.LastName}";
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> students = Students.Where(x => x.Subject == subject).ToList();

            if (students.Count == 0)
            {
                // no students
                return "No students enrolled for the subject";
            }

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Subject: {subject}");
            stringBuilder.AppendLine("Students:");
            foreach (var student in students)
            {
                stringBuilder.AppendLine($"{student.FirstName} {student.LastName}");
            }

            return stringBuilder
                .ToString()
                .TrimEnd();
        }

        public int GetStudentsCount()
        {
            return Students.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return Students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}

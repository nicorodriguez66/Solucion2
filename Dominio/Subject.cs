using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Subject
    {
        public string name { get; set; }
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int codeId { get; set; }
        public List<Student> students { get; set; }
        public List<Teacher> teachers { get; set; }
        public Subject()
        {
            students = new List<Student>();
            teachers = new List<Teacher>();
            name = "empty";
            codeId = 0;
        }
        public void EditSubjectName(string NewName)
        {
            name = NewName;
        }
        public void EditSubjectCode(int NewCode)
        {
            codeId = NewCode;
        }
        public void SubjectAddStudent(Student NewStudent)
        {
            if (!SubjectStudentExists(NewStudent))
                students.Add(NewStudent);
        }
        public bool SubjectStudentExists(Student NewStudent)
        {
            return students.Contains(NewStudent);
        }
        public void SubjectAddTeacher(Teacher NewTeacher)
        {
            if (!SubjectTeacherExists(NewTeacher))
                teachers.Add(NewTeacher);
        }
        public bool SubjectTeacherExists(Teacher NewTeacher)
        {
            return teachers.Contains(NewTeacher);
        }
        public void DeleteSubject()
        {
            students.Clear();
            teachers.Clear();
        }
        public override string ToString()
        {
            return codeId + " " + name;
        }
        public int GetCode()
        {
            return codeId;
        }
        public string GetName()
        {
            return name;
        }
        public List<Student> GetStudents()
        {
            return students;
        }
        public List<Teacher> GetTeachers()
        {
            return teachers;
        }
    }
}

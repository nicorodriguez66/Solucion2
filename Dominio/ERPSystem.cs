using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ERPsystem
    {
        public List<Teacher> allteachers { get; set; }
        public List<Student> allstudents { get; set; }
        public List<Subject> allsubjects { get; set; }
        public List<Van> allvans { get; set; }
        public List<Activity> allactivities { get; set; }
        public List<Exam> allexams { get; set; }

        public ERPsystem()
        {
            allteachers = new List<Teacher>();
            allsubjects = new List<Subject>();
            allstudents = new List<Student>();
            allvans = new List<Van>();
            allactivities = new List<Activity>();
            allexams = new List<Exam>(); 
        }
        public List<Teacher> showallteachers()
        {
            return allteachers;
        }
        public List<Student> showallstudents()
        {
            return allstudents;
        }
        public List<Subject> showallsubjects()
        {
            return allsubjects;
        }
        public List<Van> showallvans()
        {
            return allvans;
        }
        public List<Van> showAvailableVans()
        {
            List<Van> Availables = new List<Van>();
            foreach (Van element in allvans)
                if (element.GetAvailability())
                    Availables.Add(element);
            Availables = Availables.OrderByDescending(o => o.GetCapacity()).ToList();
            return Availables;
        }
        public List<Activity> showallactivities()
        {
            return allactivities;
        }
        public List<Exam> showallexams()
        {
            return allexams;
        }

        public Student searchStudent(int Number)
        {
            Student found = null;
            foreach (Student element in allstudents)
            {
                if (element.GetNumber().Equals(Number))
                    found = element;
            }
            return found;
        }
        public Subject searchSubject(int code)
        {
            Subject found = null;
            foreach (Subject element in allsubjects)
            {
                if (element.GetCode().Equals(code))
                    found = element;
            }
            return found;
        }
        public Teacher searchTeacher(string surname)
        {
            Teacher found = null;
            foreach (Teacher element in allteachers)
            {
                if (element.GetSurname().Equals(surname))
                    found = element;
            }
            return found;
        }
        public Van searchVan(int id)
        {
            Van found = null;
            foreach (Van element in allvans)
            {
                if (element.GetId().Equals(id))
                    found = element;
            }
            return found;
        }

        public Exam searchExam(int id)
        {
            Exam found = null;
            foreach (Exam item in allexams)
            {
                if (item.ExamId.Equals(id))
                    found = item;
            }
            return found;
        }

        public void DeleteStudent(Student StudentToDelete)
        {
            if (allstudents.Contains(StudentToDelete))
            {
                foreach(Subject element in StudentToDelete.GetSubjects())
                {
                    searchSubject(element.GetCode()).GetStudents().Remove(StudentToDelete);
                }
                allstudents.Remove(StudentToDelete);
            }
        }
        public void DeleteTeacher(Teacher TeacherToDelete)
        {
            if (allteachers.Contains(TeacherToDelete))
            {
                foreach(Subject element in TeacherToDelete.GetSubjects())
                {
                    searchSubject(element.GetCode()).GetTeachers().Remove(TeacherToDelete);
                }
                allteachers.Remove(TeacherToDelete);
            }
        }
        public void DeleteSubject(Subject SubjectToDelete)
        {
            if (allsubjects.Contains(SubjectToDelete))
            {
                allsubjects.Remove(SubjectToDelete);
            }
        }
        public void DeleteVan(Van VanToDelete)
        {
            if (allvans.Contains(VanToDelete))
            {
                allvans.Remove(VanToDelete);
            }
        }
        public void DeleteActivity(Activity ActivityToDelete)
        {
            if (allactivities.Contains(ActivityToDelete))
            {
                allactivities.Remove(ActivityToDelete);
            }
        }
        public void DeleteExam(Exam ExamToDelete)
        {
            if(allexams.Contains(ExamToDelete))
            {
                allexams.Remove(ExamToDelete);
            }
        }


        public float distance(Student student)
        {
            return student.GetX() + student.GetY();
        }
        public List<Student> routeVan(Van van)
        {
            List<Student> roadmap = new List<Student>();
            if (van.GetAvailability())
            {             
                List<Student> closer = allstudents.OrderByDescending(o => distance(o)).ToList();
                int actualCapacity = van.GetCapacity();
                while (actualCapacity > 0 && closer.Count>0)
                {
                    roadmap.Add(closer.First());
                    closer.Remove(closer.First());
                    actualCapacity--;
                }
            }
            return roadmap;
        }
        public List<List<Student>> routeAllVan()
        {
            List<List<Student>> allroadmaps = new List<List<Student>>();
            foreach (Van element in allvans)
                allroadmaps.Add(routeVan(element));
            return allroadmaps;
        }

        public Activity searchActivity(int id)
        {
            Activity found = null;
            foreach (Activity element in allactivities)
            {
                if (element.GetId().Equals(id))
                    found = element;
            }
            return found;
        }
        
        public ERPsystem LoadData()
        {
            ERPsystem mysystem = new ERPsystem();

            Student s1 = new Student(); s1.EditStudentName("s1"); s1.EditStudentSurname("s1"); s1.EditStudentNumber(1); s1.EditStudentidCard(1);
            Student s2 = new Student(); s2.EditStudentName("s2"); s2.EditStudentSurname("s2"); s2.EditStudentNumber(2); s2.EditStudentidCard(2);
            Student s3 = new Student(); s3.EditStudentName("s3"); s3.EditStudentSurname("s3"); s3.EditStudentNumber(3); s3.EditStudentidCard(3);
            Student s4 = new Student(); s4.EditStudentName("s4"); s4.EditStudentSurname("s4"); s4.EditStudentNumber(4); s4.EditStudentidCard(4);
            mysystem.showallstudents().Add(s1);
            mysystem.showallstudents().Add(s2);
            mysystem.showallstudents().Add(s3);
            mysystem.showallstudents().Add(s4);
            Teacher t1 = new Teacher(); t1.EditTeacherName("T1"); t1.EditTeacherSurname("T1");
            Teacher t2 = new Teacher(); t2.EditTeacherName("T2"); t2.EditTeacherSurname("T2");
            Teacher t3 = new Teacher(); t3.EditTeacherName("T3"); t3.EditTeacherSurname("T3");
            Teacher t4 = new Teacher(); t4.EditTeacherName("T4"); t4.EditTeacherSurname("T4");
            mysystem.showallteachers().Add(t1);
            mysystem.showallteachers().Add(t2);
            mysystem.showallteachers().Add(t3);
            mysystem.showallteachers().Add(t4);
            Subject sub1 = new Subject(); sub1.EditSubjectCode(1); sub1.EditSubjectName("subject1"); sub1.SubjectAddStudent(s1); s1.GetSubjects().Add(sub1); sub1.SubjectAddTeacher(t1); t1.GetSubjects().Add(sub1);
            Subject sub2 = new Subject(); sub2.EditSubjectCode(2); sub2.EditSubjectName("subject2"); sub2.SubjectAddStudent(s2); s2.GetSubjects().Add(sub2); sub2.SubjectAddTeacher(t2); t2.GetSubjects().Add(sub2);
            Subject sub3 = new Subject(); sub3.EditSubjectCode(3); sub3.EditSubjectName("subject3"); sub3.SubjectAddStudent(s3); s3.GetSubjects().Add(sub3); sub3.SubjectAddTeacher(t3); t3.GetSubjects().Add(sub3);
            mysystem.showallsubjects().Add(sub1);
            mysystem.showallsubjects().Add(sub2);
            mysystem.showallsubjects().Add(sub3);
            Activity a1 = new Activity(); a1.EditActivityCost(1); a1.EditActivityDate(System.DateTime.Now); a1.EditActivityId(1); a1.EditActivityName("1");
            Activity a2 = new Activity(); a2.EditActivityCost(2); a2.EditActivityDate(System.DateTime.Now); a2.EditActivityId(2); a2.EditActivityName("2");
            Activity a3 = new Activity(); a3.EditActivityCost(3); a3.EditActivityDate(System.DateTime.Now); a3.EditActivityId(3); a3.EditActivityName("3");
            a1.GetStudents().Add(s1);
            a2.GetStudents().Add(s2);
            a3.GetStudents().Add(s3);
            mysystem.showallactivities().Add(a1);
            mysystem.showallactivities().Add(a2);
            mysystem.showallactivities().Add(a3);
            Fee f1 = new Fee() { month = 1, year = 2017, paid = true };
            Fee f2 = new Fee() { month = 2, year = 2017, paid = true };
            Fee f3 = new Fee() { month = 3, year = 2017, paid = true };
            Fee f4 = new Fee() { month = 4, year = 2017, paid = true };
            Fee f5 = new Fee() { month = 5, year = 2017, paid = false };
            Fee f6 = new Fee() { month = 6, year = 2017, paid = false };
            Fee f7 = new Fee() { month = 7, year = 2017, paid = false };
            Fee f8 = new Fee() { month = 8, year = 2017, paid = false };
            s1.GetPayments().Add(f1);
            s1.GetPayments().Add(f2);
            s1.GetPayments().Add(f3);
            s1.GetPayments().Add(f4);
            s1.GetPayments().Add(f5);
            s1.GetPayments().Add(f6);
            s1.GetPayments().Add(f7);
            s1.GetPayments().Add(f8);
            Van v1 = new Van(); v1.EditVanAvailability(true); v1.EditVanCapacity(1); v1.EditVanId(1); v1.EditVanName("1");
            Van v2 = new Van(); v2.EditVanAvailability(true); v2.EditVanCapacity(2); v2.EditVanId(2); v2.EditVanName("2");
            Van v3 = new Van(); v3.EditVanAvailability(true); v3.EditVanCapacity(3); v3.EditVanId(3); v3.EditVanName("3");
            mysystem.showallvans().Add(v1);
            mysystem.showallvans().Add(v2);
            mysystem.showallvans().Add(v3);
            Exam e1 = new Exam() { ExamId = 1, approval = 3, subject = sub1, date = DateTime.MaxValue };
            Exam e2 = new Exam() { ExamId = 2, approval = 6, subject = sub2 };
            Exam e3 = new Exam() { ExamId = 3, approval = 9, subject = sub3 };
            //all students approved
            e1.ExamEnrollStudent(s1, 0); e1.qualify(s1, 12);
            e1.ExamEnrollStudent(s2, 0); e1.qualify(s2, 12);
            e1.ExamEnrollStudent(s3, 0); e1.qualify(s3, 12);
            //all students failed
            e2.ExamEnrollStudent(s1, 0); e2.qualify(s1, 0);
            e2.ExamEnrollStudent(s2, 0); e2.qualify(s2, 0);
            e2.ExamEnrollStudent(s3, 0); e2.qualify(s3, 0);
            //some students fail
            e3.ExamEnrollStudent(s1, 0); e3.qualify(s1, 3);
            e3.ExamEnrollStudent(s2, 0); e3.qualify(s2, 6);
            e3.ExamEnrollStudent(s3, 0); e3.qualify(s3, 9);
            mysystem.allexams.Add(e1);
            mysystem.allexams.Add(e2);
            mysystem.allexams.Add(e3);
            return mysystem;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Dominio
{
    public class Exam:IComparable<Exam>
    {
        [Key]
        public int ExamId { get; set; }
        public Subject subject { set; get; }
        public DateTime date { set; get; }
        public int approval { set; get; }
        public virtual List<Tuple<Student,int>> enrolled { set; get; }
        public Exam()
        {
            subject = null;
            date = System.DateTime.Now;
            approval = 0;
            enrolled = new List<Tuple<Student, int>>();
        }

        public void EditExamSubject(Subject OneSubject)
        {
            subject = OneSubject;
        }
        public void EditExamDate(DateTime OneDate)
        {
            date = OneDate;
        }
        public void EditExamApproval(int OneScore)
        {
            if ((OneScore<=12) && (OneScore >= 1))
                approval = OneScore;
        }
        public void ExamEnrollStudent(Student OneStudent, int qualification)
        {
            if (!enrolled.Any(s => s.Item1 == OneStudent))
            {
                Tuple<Student, int> StudentToAdd = new Tuple<Student,int>(OneStudent, qualification);
                enrolled.Add(StudentToAdd);
            }
        }
        public void ExamUnEnrollStudent(Student OneStudent)
        {
            if (enrolled.Any(s => s.Item1 == OneStudent))
            {
                enrolled.Remove(enrolled.Find(s => s.Item1 == OneStudent));
            }
        }

        public void qualify(Student OneStudent, int qualification)
        {
            if (enrolled.Any(s => s.Item1 == OneStudent))
            {
                ExamUnEnrollStudent(OneStudent);
                ExamEnrollStudent(OneStudent, qualification);
            }
        }

        public List<Student> ExamApproved()
        {
            List<Student> approved = new List<Student>();
            foreach(Tuple<Student,int> element in enrolled)
            {
                if (element.Item2 >= approval)
                    approved.Add(element.Item1);
            }
            return approved;
        }
        public List<Student> ExamNotApproved()
        {
            List<Student> notapproved = new List<Student>();
            foreach (Tuple<Student, int> element in enrolled)
            {
                if (element.Item2 < approval)
                    notapproved.Add(element.Item1);
            }
            return notapproved;
        }

        public Exam ExamSubject(Subject OneSubject)
        {
            Exam OneExam = null;
            if (this.subject.codeId == OneSubject.codeId)
                OneExam = this;
            return OneExam;
        }

        public override string ToString()
        {
            return ExamId + " " +subject + " " + date;
        }

        public int CompareTo(Exam other)
        {
            if (other.subject.codeId > this.subject.codeId)
                return 1;
            else
                return -1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Activity : Payment
    {
        public string name { get; set; }
        public int id { get; set; }
        public DateTime date { get; set; }
        public int cost { get; set; }
        public virtual List<Student> students { get; set; }


        public Activity()
        {
            name = "";
            id = -1;
            date = System.DateTime.Now;
            cost = 0;
            students = new List<Student>();
            paid = false;
        }

        public void EditActivityName(string NewName)
        {
            name = NewName;
        }
        public void EditActivityId(int NewId)
        {
            id = NewId;
        }
        public void EditActivityDate(DateTime NewDate)
        {
            date= NewDate;
        }
        public void EditActivityCost(int NewCost)
        {
            cost = NewCost;
        }
        public int GetId()
        {
            return id;
        }
        public List<Student> GetStudents()
        {
            return students;
        }
        public void DeleteActivity()
        {
            students.Clear();
        }
        public override string ToString()
        {
            return name + " " + id;
        }
        public override void pay()
        {
            paid = true;
        }
        public void ActivityEnrollStudent(Student OneStudent)
        {
            if (!students.Any(s => s== OneStudent))
            {
                students.Add(OneStudent);
            }
        }
        public void ActivityUnEnrollStudent(Student OneStudent)
        {
            if (students.Any(s => s== OneStudent))
            {
                students.Remove(students.Find(s => s== OneStudent));
            }
        }


    }
}

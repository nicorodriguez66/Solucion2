using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Student:Person
    {
        
        public int number { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public virtual List<Payment> payments { get; set; }
        
        public Student()
        {
            name = "";
            surname = "";            
            number = 0;
            cardId = 0;
            x = 0;
            y = 0;
            subjects = new List<Subject>();
            payments = new List<Payment>();
        }
        public List<Subject> GetSubjects()
        {
            return subjects;
        }


        public List<Payment> GetPayments()
        {
            return payments;
        }



        

        public string GetName()
        {
            return name;
        }

        public void EditStudentName(string newName)
        {
            name=newName;
        }

        public void EditStudentSurname(string newSurname)
        {
            surname = newSurname;
        }

        public string GetSurname()
        {
            return surname;
        }

        public void EditStudentNumber(int newNumber)
        {
            number=newNumber;
        }

        public int GetNumber()
        {
            return number;
        }

        public void EditStudentidCard(int newidCard)
        {
            cardId = newidCard;
        }

        public int GetidCard()
        {
            return cardId;
        }

        public void EditStudentXY(float newX, float newY)
        {
            x=newX;
            y = newY;
        }

        public float GetX()
        {
            return x;
        }

        public float GetY()
        {
            return y;
        }
        public override string ToString()
        {
            return name+ " " + surname + " " + number;
        }
    }
}

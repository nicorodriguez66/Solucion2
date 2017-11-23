using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Fee:Payment, IEquatable<Fee>

    {

        public int month { set; get; }
        public int year { set; get; }
        public Fee()
        {
            month = 0;
            year = 0;
        }
        public override void pay()
        {
            paid=true;
        }
        public void editfeeMonth(int OneMonth)
        {
            if ((1 <= OneMonth) && (OneMonth <= 12))
                month = OneMonth;
        }
        public void editfeeYear(int OneYear)
        {
            if (0 < OneYear) 
               year= OneYear;
        }

        public override string ToString()
        {
            return this.month + "/" + this.year;
        }

        public bool Equals(Fee other)
        {
            return ((this.month== other.month) && (this.year == other.year));
        }
    }
}

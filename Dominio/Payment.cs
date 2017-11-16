using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public abstract class Payment
    {
        [Key]
        public int payId { get; set; }
        public bool paid { get; set; }
        public abstract void pay();
        //public virtual  string ToString();

    }
}
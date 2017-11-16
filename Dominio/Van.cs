using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Van
    {

        [Key]
        public int VanId { get; set; }
        public int capacity { get; set; }
        public string name { get; set; }
        public bool available { get; set; }
        public int eficiency { get; set; }
        public Van()
        {
            capacity = -1;
            name = "";
            available = false;
            eficiency = 0;
        }

        public void EditVanName(string NewName)
        {
            name=NewName;
        }

        public void EditVanCapacity(int NewCapacity)
        {
            capacity = NewCapacity;
        }

        public void EditVanId(int NewId)
        {
            VanId = NewId;
        }

        public void EditVanAvailability(bool NewAvailable)
        {
            available = NewAvailable;
        }

        public void EditVanEficiency(int NewEficiency)
        {
            eficiency = NewEficiency;
        }

        public bool GetAvailability()
        {
            return available;
        }

        public int GetCapacity()
        {
            return capacity;
        }

        public int GetId()
        {
            return VanId;
        }
        public string GetName()
        {
            return name;
        }
        public override string ToString()
        {
            return name + " " + VanId + " " + capacity;
        }
        public void DeleteVan()
        {
            
        }
        public void CalcularRuta()
        {

        }
    }
}
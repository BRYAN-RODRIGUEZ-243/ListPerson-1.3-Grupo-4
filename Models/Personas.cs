using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListPerson_1._3_Grupo__4.Models
{
    public class Personas
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        public String? Name { get; set; }

        public  String? Apellido { get; set; }

        public  int Edad { get; set; }
        public  String? Correo { get; set; }

        public  String? Direccion { get; set; }
    }
}

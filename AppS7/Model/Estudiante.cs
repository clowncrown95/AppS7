using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppS7.Model
{
    public class Estudiante
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }
        [MaxLength(50)]

        public string nombre { get; set; }
        [MaxLength(25)]

        public string usuario { get; set; }
        [MaxLength(50)]

        public string password { get; set; }
       

    }
}

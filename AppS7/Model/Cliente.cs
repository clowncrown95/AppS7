using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppS7.Model
{
   public class Cliente
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [MaxLength(50)]

        public string nombres { get; set; }
        [MaxLength(25)]

        public string apellidos { get; set; }
        [MaxLength(50)]

        public string cedula { get; set; }
        [MaxLength(50)]

        public string direccion { get; set; }
        [MaxLength(50)]
        public string usuario { get; set; }
        [MaxLength(50)]

        public string password { get; set; }
    }
}

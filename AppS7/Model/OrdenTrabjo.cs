using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppS7.Model
{
  public  class OrdenTrabjo
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [MaxLength(50)]

        public string cliente { get; set; }
        [MaxLength(25)]

        public string equipo { get; set; }
        [MaxLength(25)]

        public string modelo { get; set; }
        [MaxLength(25)]

        public string serie { get; set; }
        [MaxLength(25)]

        public string fechaIngreso { get; set; }
        [MaxLength(25)]

        public string estado { get; set; }
        public string fechaEntrega { get; set; }
        
    }
}

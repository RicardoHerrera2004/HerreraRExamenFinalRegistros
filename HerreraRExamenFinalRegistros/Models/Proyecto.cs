using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace HerreraRExamenFinalRegistros.Models
{
    class Proyecto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string NombreProyecto { get; set; }
        public string Responsable { get; set; }
        public decimal Progreso { get; set; }
        public int DuracionDias { get; set; }
    }
}

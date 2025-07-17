using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservasHotelApp
{
    public class Reserva
    {
        public string Cliente { get; set; }
        public string TipoHabitacion { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }

        public override string ToString()
        {
            return $"{Cliente} - {TipoHabitacion} - {FechaEntrada.ToShortDateString()} a {FechaSalida.ToShortDateString()}";
        }
    }
}

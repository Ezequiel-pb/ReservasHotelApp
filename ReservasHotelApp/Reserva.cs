using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservasHotelApp
{
    // Clase que representa una reserva de hotel
    public class Reserva
    {
        public string Cliente { get; set; }
        public string TipoHabitacion { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }

        // Sobrescribe el método ToString para mostrar la reserva en formato legible
        public override string ToString()
        {
            // Formatea la cadena de salida con los detalles de la reserva
            return $"{Cliente} - {TipoHabitacion} - {FechaEntrada.ToShortDateString()} a {FechaSalida.ToShortDateString()}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservasHotelApp
{
    // Clase que gestiona la lógica de las reservas
    public class GestorReservas
    {
        // Lista que almacena todas las reservas realizadas
        private List<Reserva> reservas = new List<Reserva>();
        private readonly object locker = new object();

        // Método asíncrono para verificar disponibilidad y reservar una habitación
        public async Task<bool> VerificarYReservarAsync(Reserva nuevaReserva)
        {
            await Task.Delay(3000); // Simula una consulta o proceso pesado

            lock (locker) // Evita problemas de concurrencia en la lista de reservas
            {
                foreach (var reserva in reservas)
                {
                    // Verifica si el tipo de habitación es igual y las fechas se solapan
                    if (reserva.TipoHabitacion == nuevaReserva.TipoHabitacion &&
                        !(nuevaReserva.FechaSalida <= reserva.FechaEntrada || nuevaReserva.FechaEntrada >= reserva.FechaSalida))
                    {
                        // Si hay una coincidencia, la reserva no se puede realizar
                        return false;
                    }
                }

                // Si no hay solapamiento, se agrega la reserva
                reservas.Add(nuevaReserva);
                return true;
            }
        }

        public List<Reserva> ObtenerReservas()
        {
            lock (locker)
            {
                return new List<Reserva>(reservas); // Retorna una copia de la lista de reservas para evitar modificaciones externas
            }
        }

        internal bool EliminarReserva(Reserva reservaSeleccionada)
        {
            lock (locker)
            {
                if (reservas.Contains(reservaSeleccionada))
                {
                    reservas.Remove(reservaSeleccionada);
                    return true;
                }
                return false;
            }
        }
    }
}

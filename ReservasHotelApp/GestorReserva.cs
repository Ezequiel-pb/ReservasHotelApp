using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservasHotelApp
{
    public class GestorReservas
    {
        private List<Reserva> reservas = new List<Reserva>();
        private readonly object locker = new object();

        public async Task<bool> VerificarYReservarAsync(Reserva nuevaReserva)
        {
            await Task.Delay(10000); // Simula consulta a servidor 

            lock (locker)
            {
                foreach (var reserva in reservas)
                {
                    // Si se cruza con alguna existente
                    if (reserva.TipoHabitacion == nuevaReserva.TipoHabitacion &&
                        !(nuevaReserva.FechaSalida <= reserva.FechaEntrada || nuevaReserva.FechaEntrada >= reserva.FechaSalida))
                    {
                        return false;
                    }
                }

                reservas.Add(nuevaReserva);
                return true;
            }
        }

        public List<Reserva> ObtenerReservas()
        {
            lock (locker)
            {
                return new List<Reserva>(reservas);
            }
        }
    }
}

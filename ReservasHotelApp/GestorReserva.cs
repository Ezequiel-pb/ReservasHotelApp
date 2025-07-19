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

        public bool EliminarReserva(Reserva reservaSeleccionada)
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

        public bool ActualizarReserva(Reserva original, Reserva datosActualizados)
        {
            lock (locker) // Bloqueo para garantizar seguridad en concurrencia
            {
                // Verifica si los nuevos datos chocan con otra reserva (ignorando la original)
                if (HayChoque(datosActualizados, original))
                    return false;

                // Si no hay choque, actualiza los datos de la reserva original
                original.Cliente = datosActualizados.Cliente;
                original.TipoHabitacion = datosActualizados.TipoHabitacion;
                original.FechaEntrada = datosActualizados.FechaEntrada;
                original.FechaSalida = datosActualizados.FechaSalida;
                return true;
            }
        }

        private bool HayChoque(Reserva nueva, Reserva? ignorar)
        {
            foreach (var r in reservas)
            {
                // Ignora la misma reserva cuando se está editando
                if (ignorar != null && ReferenceEquals(r, ignorar)) continue;

                // Verifica si el tipo de habitación es igual y las fechas se cruzan
                if (r.TipoHabitacion == nueva.TipoHabitacion &&
                    !(nueva.FechaSalida <= r.FechaEntrada || nueva.FechaEntrada >= r.FechaSalida))
                {
                    return true; // Hay choque
                }
            }
            return false; // No hay conflicto
        }
    }
}

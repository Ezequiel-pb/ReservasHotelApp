using System;

namespace ReservasHotelApp
{

    // Clase principal del formulario de la aplicaci�n de reservas de hotel
    public partial class Form1 : Form
    {
        // Instancia del gestor de reservas que maneja la l�gica de negocio
        private GestorReservas gestor = new GestorReservas();

        // Constructor del formulario
        public Form1()
        {
            InitializeComponent();

            // Se agregan las opciones de tipo de habitaci�n al ComboBox al iniciar el formulario
            cmbTipoHabitacion.Items.AddRange(new string[] { "Est�ndar", "Doble", "Suite" });
            cmbTipoHabitacion.DropDownStyle = ComboBoxStyle.DropDownList;

            // Configuraci�n inicial de fechas
            dtpEntrada.Value = DateTime.Now;
            dtpSalida.Value = DateTime.Now.AddDays(1);

            // Configuraci�n inicial de la barra de progreso
            progressBarReserva.Visible = false;
            progressBarReserva.Style = ProgressBarStyle.Marquee;
            progressBarReserva.MarqueeAnimationSpeed = 30;
        }

        // Evento que se ejecuta al cargar el formulario
        private void Form1_Load(object sender, EventArgs e) { }

        // M�todo para limpiar los campos de entrada
        public void LimpiarCampos()
        {
            txtCliente.Clear();
            cmbTipoHabitacion.SelectedIndex = 0;
            dtpEntrada.Value = DateTime.Now;
            dtpSalida.Value = DateTime.Now.AddDays(1);
        }

        // Bot�n para realizar una reserva
        private async void btnReservar_Click(object sender, EventArgs e)
        {
            // Validaci�n de campos antes de proceder con la reserva
            string cliente = txtCliente.Text.Trim();
            string tipo = cmbTipoHabitacion.SelectedItem?.ToString();
            DateTime entrada = dtpEntrada.Value.Date;
            DateTime salida = dtpSalida.Value.Date;

            if (string.IsNullOrWhiteSpace(cliente) || tipo == null || entrada >= salida)
            {
                MessageBox.Show("Datos inv�lidos. Verifica la informaci�n.");
                return;
            }


            Reserva nuevaReserva = new Reserva
            {
                Cliente = cliente,
                TipoHabitacion = tipo,
                FechaEntrada = entrada,
                FechaSalida = salida
            };

            //Mostrar barra de progreso mientras se procesa
             progressBarReserva.Visible = true;
            //btnReservar.Enabled = false;

            bool reservada = await gestor.VerificarYReservarAsync(nuevaReserva);

            // Ocultar barra y reactivar bot�n
            progressBarReserva.Visible = false;
           // btnReservar.Enabled = true;

            if (reservada)
            {
                MessageBox.Show("�Reserva confirmada!");
                LimpiarCampos();
                RefrescarListaReservas();
            }
            else
            {
                MessageBox.Show("No hay disponibilidad para esa habitaci�n en esas fechas.");
            }
        }

        // Bot�n para eliminar una reserva
        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            // Verifica si hay una reserva seleccionada
            if (lstReservas.SelectedItem == null)
            {
                MessageBox.Show("Selecciona una reserva para eliminar.");
                return;
            }

            var reservaSeleccionada = lstReservas.SelectedItem as Reserva;
            if (reservaSeleccionada == null)
            {
                MessageBox.Show("Error al obtener la reserva seleccionada.");
                return;
            }

            // Llama al m�todo de eliminaci�n en el gestor de reservas
            bool eliminado = gestor.EliminarReserva(reservaSeleccionada);

            if (eliminado)
            {
                MessageBox.Show("Reserva eliminada correctamente.");
                RefrescarListaReservas();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar la reserva.");
            }
        }

        // Bot�n para editar una reserva
        private void btn_editar_Click(object sender, EventArgs e)
        {
            // Verifica si hay una reserva seleccionada para editar
            if (lstReservas.SelectedItem is not Reserva reservaSeleccionada)
            {
                MessageBox.Show("Selecciona una reserva para editar.");
                return;
            }

            // Validar campos
            string nuevoCliente = txtCliente.Text.Trim();
            string nuevoTipo = cmbTipoHabitacion.SelectedItem?.ToString();
            DateTime entrada = dtpEntrada.Value.Date;
            DateTime salida = dtpSalida.Value.Date;

            if (string.IsNullOrWhiteSpace(nuevoCliente) || nuevoTipo == null || entrada >= salida)
            {
                MessageBox.Show("Datos inv�lidos para editar la reserva.");
                return;
            }

            // Crear objeto con datos actualizados
            Reserva datosActualizados = new Reserva
            {
                Cliente = nuevoCliente,
                TipoHabitacion = nuevoTipo,
                FechaEntrada = entrada,
                FechaSalida = salida
            };

            // Intentar actualizar
            bool actualizado = gestor.ActualizarReserva(reservaSeleccionada, datosActualizados);
            if (actualizado)
            {
                MessageBox.Show("Reserva actualizada correctamente.");
                RefrescarListaReservas();
            }
            else
            {
                MessageBox.Show("Las nuevas fechas chocan con otra reserva.");
            }
        }

        // Refresca la lista de reservas en el ListBox
        private void RefrescarListaReservas()
        {
            lstReservas.Items.Clear();
            foreach (var reserva in gestor.ObtenerReservas())
            {
                lstReservas.Items.Add(reserva);
            }
        }
    }
}
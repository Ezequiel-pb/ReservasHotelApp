using System;

namespace ReservasHotelApp
{
    // Clase principal del formulario de la aplicación de reservas de hotel
    public partial class Form1 : Form
    {
        // Instancia del gestor de reservas que maneja la lógica de negocio
        GestorReservas gestor = new GestorReservas();
       
        // Constructor del formulario
        public Form1()
        {
            InitializeComponent();

            // Se agregan las opciones de tipo de habitación al ComboBox al iniciar el formulario
            cmbTipoHabitacion.Items.AddRange(new string[] { "Estándar", "Doble", "Suite" });
        }

        // Evento que se ejecuta al cargar el formulario (actualmente vacío)
        private void Form1_Load(object sender, EventArgs e){}

        public void LimpiarCampos()
        {
            txtCliente.Clear();
            cmbTipoHabitacion.SelectedIndex = -1; // Deselecciona cualquier opción
            dtpEntrada.Value = DateTime.Now;
            dtpSalida.Value = DateTime.Now.AddDays(1);  // Fecha de salida por defecto es mañana
        }

        private async void btnReservar_Click(object sender, EventArgs e)
        {
            // Validación de campos antes de proceder con la reserva
            string cliente = txtCliente.Text.Trim();
            string tipo = cmbTipoHabitacion.SelectedItem?.ToString();
            DateTime entrada = dtpEntrada.Value.Date;
            DateTime salida = dtpSalida.Value.Date;

            if (string.IsNullOrWhiteSpace(cliente) || tipo == null || entrada >= salida)
            {
                MessageBox.Show("Datos inválidos. Verifica la información.");
                return;
            }

            // Creación de una nueva reserva con los datos ingresados
            Reserva nuevaReserva = new Reserva
            {
                Cliente = cliente,
                TipoHabitacion = tipo,
                FechaEntrada = entrada,
                FechaSalida = salida
            };

            // Verifica disponibilidad y realiza la reserva de manera asíncrona
            LimpiarCampos();
            bool reservada = await gestor.VerificarYReservarAsync(nuevaReserva);
            btnReservar.Enabled = true;
            progressBarReserva.Value = 0;
            progressBarReserva.Visible = true;
            btnReservar.Enabled = false;

            // Simulamos un progreso gradual
            for (int i = 0; i <= 100; i += 20)
            {
                progressBarReserva.Value = i;
                await Task.Delay(300);  // Espera 300 ms por cada incremento
            }

            bool reserva = await gestor.VerificarYReservarAsync(nuevaReserva);

            progressBarReserva.Visible = false;
            btnReservar.Enabled = true;

            if (reservada)
            {
                MessageBox.Show("¡Reserva confirmada!");
                LimpiarCampos();
                RefrescarListaReservas();
            }
            else
            {
                MessageBox.Show("No hay disponibilidad para esa habitación en esas fechas.");
            }
        }

        private void lbl_FechaDeSalida_Click(object sender, EventArgs e)
        {
            // Este evento está definido pero no tiene funcionalidad implementada
        }

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

            // Llama al método de eliminación en el gestor de reservas
            bool eliminado = gestor.EliminarReserva(reservaSeleccionada);

            if (eliminado)
            {
                MessageBox.Show("Reserva eliminada correctamente.");
                lstReservas.Items.Remove(reservaSeleccionada);
            }
            else
            {
                MessageBox.Show("No se pudo eliminar la reserva.");
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            // Verifica si hay una reserva seleccionada para editar
            if (lstReservas.SelectedItem is not Reserva reservaSeleccionada)
            {
                MessageBox.Show("Selecciona una reserva para editar.");
                return;
            }

            string nuevoCliente = txtCliente.Text.Trim();
            string nuevoTipo = cmbTipoHabitacion.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(nuevoCliente) || string.IsNullOrWhiteSpace(nuevoTipo))
            {
                MessageBox.Show("Nombre del cliente o tipo de habitación no puede estar vacío.");
                return;
            }
            // Actualiza la información de la reserva seleccionada
            reservaSeleccionada.Cliente = nuevoCliente;
            reservaSeleccionada.TipoHabitacion = nuevoTipo;

            MessageBox.Show("Reserva actualizada correctamente.");

            RefrescarListaReservas();
        }
        private void RefrescarListaReservas()
        {
            // Limpia la lista de reservas y vuelve a cargarla desde el gestor
            lstReservas.Items.Clear();
            foreach (var reserva in gestor.ObtenerReservas())
            {
                lstReservas.Items.Add(reserva);
            }
        }

        private async void progressBarReserva_Click(object sender, EventArgs e)
        {
            string cliente = txtCliente.Text.Trim();
            string tipo = cmbTipoHabitacion.SelectedItem?.ToString();
            DateTime entrada = dtpEntrada.Value.Date;
            DateTime salida = dtpSalida.Value.Date;

            if (string.IsNullOrWhiteSpace(cliente) || tipo == null || entrada >= salida)
            {
                MessageBox.Show("Datos inválidos. Verifica la información.");
                return;
            }

            Reserva nuevaReserva = new Reserva
            {
                Cliente = cliente,
                TipoHabitacion = tipo,
                FechaEntrada = entrada,
                FechaSalida = salida
            };

            // Activamos la barra y desactivamos el botón
            progressBarReserva.Visible = true;
            btnReservar.Enabled = false;

            // Simular tiempo de proceso (aquí podría ser tu llamada real asíncrona)
            await Task.Delay(3000);  // Simulamos 3 segundos

            bool reservada = await gestor.VerificarYReservarAsync(nuevaReserva);

            // Ocultamos la barra y activamos el botón
            progressBarReserva.Visible = false;
            btnReservar.Enabled = true;

            if (reservada)
            {
                MessageBox.Show("¡Reserva confirmada!");
                LimpiarCampos();
                RefrescarListaReservas();
            }
            else
            {
                MessageBox.Show("No hay disponibilidad para esa habitación en esas fechas.");
            }

            // Configuración final de la barra de progreso en modo indeterminado (marquee)
            this.progressBarReserva = new System.Windows.Forms.ProgressBar();
            this.progressBarReserva.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarReserva.Visible = false;
        }
    }
}
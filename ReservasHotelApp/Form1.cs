namespace ReservasHotelApp
{
    public partial class Form1 : Form
    {

        GestorReservas gestor = new GestorReservas();

        public Form1()
        {
            InitializeComponent();
            cmbTipoHabitacion.Items.AddRange(new string[] { "Estándar", "Doble", "Suite" });


        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void btnReservar_Click(object sender, EventArgs e)
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

            btnReservar.Enabled = false;
            bool reservada = await gestor.VerificarYReservarAsync(nuevaReserva);
            btnReservar.Enabled = true;

            if (reservada)
            {
                MessageBox.Show("¡Reserva confirmada!");
                lstReservas.Items.Clear();
                foreach (var r in gestor.ObtenerReservas())
                {
                    lstReservas.Items.Add(r);
                }
            }
            else
            {
                MessageBox.Show("No hay disponibilidad para esa habitación en esas fechas.");
            }
        }
    }  }
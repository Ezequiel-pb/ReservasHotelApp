namespace ReservasHotelApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            dtpEntrada = new DateTimePicker();
            dtpSalida = new DateTimePicker();
            lbl_FechaDeEntrada = new Label();
            lbl_FechaDeSalida = new Label();
            lbl_ReservasHotel = new Label();
            cmbTipoHabitacion = new ComboBox();
            lstReservas = new ListBox();
            lbl_ReservasRealizadas = new Label();
            txtCliente = new TextBox();
            lbl_NombreYApellido = new Label();
            btnReservar = new Button();
            lbl_TipoDeHabitacion = new Label();
            btn_eliminar = new Button();
            btn_editar = new Button();
            progressBarReserva = new ProgressBar();
            SuspendLayout();
            // 
            // dtpEntrada
            // 
            dtpEntrada.CalendarForeColor = Color.Cyan;
            dtpEntrada.Location = new Point(21, 270);
            dtpEntrada.Name = "dtpEntrada";
            dtpEntrada.Size = new Size(270, 27);
            dtpEntrada.TabIndex = 0;
            // 
            // dtpSalida
            // 
            dtpSalida.Location = new Point(21, 324);
            dtpSalida.Name = "dtpSalida";
            dtpSalida.Size = new Size(270, 27);
            dtpSalida.TabIndex = 1;
            // 
            // lbl_FechaDeEntrada
            // 
            lbl_FechaDeEntrada.AutoSize = true;
            lbl_FechaDeEntrada.BackColor = SystemColors.ButtonHighlight;
            lbl_FechaDeEntrada.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_FechaDeEntrada.Location = new Point(21, 247);
            lbl_FechaDeEntrada.Name = "lbl_FechaDeEntrada";
            lbl_FechaDeEntrada.Size = new Size(130, 20);
            lbl_FechaDeEntrada.TabIndex = 2;
            lbl_FechaDeEntrada.Text = "Fecha de entrada";
            // 
            // lbl_FechaDeSalida
            // 
            lbl_FechaDeSalida.AutoSize = true;
            lbl_FechaDeSalida.BackColor = SystemColors.ButtonFace;
            lbl_FechaDeSalida.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_FechaDeSalida.Location = new Point(21, 300);
            lbl_FechaDeSalida.Name = "lbl_FechaDeSalida";
            lbl_FechaDeSalida.Size = new Size(117, 20);
            lbl_FechaDeSalida.TabIndex = 3;
            lbl_FechaDeSalida.Text = "Fecha de salida";
            // 
            // lbl_ReservasHotel
            // 
            lbl_ReservasHotel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_ReservasHotel.AutoSize = true;
            lbl_ReservasHotel.BackColor = SystemColors.ButtonHighlight;
            lbl_ReservasHotel.Font = new Font("Sylfaen", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_ReservasHotel.Location = new Point(312, 67);
            lbl_ReservasHotel.Name = "lbl_ReservasHotel";
            lbl_ReservasHotel.Size = new Size(284, 36);
            lbl_ReservasHotel.TabIndex = 4;
            lbl_ReservasHotel.Text = "Reservas Hotel E Y D";
            // 
            // cmbTipoHabitacion
            // 
            cmbTipoHabitacion.BackColor = Color.DeepSkyBlue;
            cmbTipoHabitacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoHabitacion.ForeColor = SystemColors.InactiveBorder;
            cmbTipoHabitacion.FormattingEnabled = true;
            cmbTipoHabitacion.Location = new Point(21, 216);
            cmbTipoHabitacion.Name = "cmbTipoHabitacion";
            cmbTipoHabitacion.Size = new Size(186, 28);
            cmbTipoHabitacion.TabIndex = 6;
            // 
            // lstReservas
            // 
            lstReservas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstReservas.BackColor = SystemColors.ButtonHighlight;
            lstReservas.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstReservas.FormattingEnabled = true;
            lstReservas.ItemHeight = 23;
            lstReservas.Location = new Point(345, 140);
            lstReservas.Name = "lstReservas";
            lstReservas.Size = new Size(536, 211);
            lstReservas.TabIndex = 7;
            // 
            // lbl_ReservasRealizadas
            // 
            lbl_ReservasRealizadas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_ReservasRealizadas.AutoSize = true;
            lbl_ReservasRealizadas.BackColor = SystemColors.ButtonHighlight;
            lbl_ReservasRealizadas.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_ReservasRealizadas.Location = new Point(701, 114);
            lbl_ReservasRealizadas.Name = "lbl_ReservasRealizadas";
            lbl_ReservasRealizadas.Size = new Size(180, 23);
            lbl_ReservasRealizadas.TabIndex = 8;
            lbl_ReservasRealizadas.Text = "Reservas realizadas";
            // 
            // txtCliente
            // 
            txtCliente.BackColor = SystemColors.ButtonHighlight;
            txtCliente.ForeColor = SystemColors.Desktop;
            txtCliente.Location = new Point(21, 163);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(186, 27);
            txtCliente.TabIndex = 9;
            // 
            // lbl_NombreYApellido
            // 
            lbl_NombreYApellido.AutoSize = true;
            lbl_NombreYApellido.BackColor = SystemColors.ButtonHighlight;
            lbl_NombreYApellido.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_NombreYApellido.Location = new Point(21, 140);
            lbl_NombreYApellido.Name = "lbl_NombreYApellido";
            lbl_NombreYApellido.Size = new Size(146, 20);
            lbl_NombreYApellido.TabIndex = 10;
            lbl_NombreYApellido.Text = "Nombre y Apellido";
            // 
            // btnReservar
            // 
            btnReservar.BackColor = Color.Lime;
            btnReservar.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReservar.Location = new Point(12, 460);
            btnReservar.Name = "btnReservar";
            btnReservar.Size = new Size(195, 38);
            btnReservar.TabIndex = 11;
            btnReservar.Text = "Reservar habitacion";
            btnReservar.UseVisualStyleBackColor = false;
            btnReservar.Click += btnReservar_Click;
            // 
            // lbl_TipoDeHabitacion
            // 
            lbl_TipoDeHabitacion.AutoSize = true;
            lbl_TipoDeHabitacion.BackColor = SystemColors.ButtonHighlight;
            lbl_TipoDeHabitacion.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_TipoDeHabitacion.Location = new Point(21, 193);
            lbl_TipoDeHabitacion.Name = "lbl_TipoDeHabitacion";
            lbl_TipoDeHabitacion.Size = new Size(143, 20);
            lbl_TipoDeHabitacion.TabIndex = 5;
            lbl_TipoDeHabitacion.Text = "Tipo de habitación";
            // 
            // btn_eliminar
            // 
            btn_eliminar.BackColor = Color.Red;
            btn_eliminar.Location = new Point(682, 460);
            btn_eliminar.Name = "btn_eliminar";
            btn_eliminar.Size = new Size(188, 38);
            btn_eliminar.TabIndex = 12;
            btn_eliminar.Text = "eliminar";
            btn_eliminar.UseVisualStyleBackColor = false;
            btn_eliminar.Click += btn_eliminar_Click;
            // 
            // btn_editar
            // 
            btn_editar.Location = new Point(345, 460);
            btn_editar.Name = "btn_editar";
            btn_editar.Size = new Size(201, 38);
            btn_editar.TabIndex = 13;
            btn_editar.Text = "editar";
            btn_editar.UseVisualStyleBackColor = true;
            btn_editar.Click += btn_editar_Click;
            // 
            // progressBarReserva
            // 
          
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(906, 514);
            Controls.Add(progressBarReserva);
            Controls.Add(btn_editar);
            Controls.Add(btn_eliminar);
            Controls.Add(lbl_ReservasHotel);
            Controls.Add(lbl_TipoDeHabitacion);
            Controls.Add(lbl_NombreYApellido);
            Controls.Add(txtCliente);
            Controls.Add(lbl_ReservasRealizadas);
            Controls.Add(btnReservar);
            Controls.Add(lstReservas);
            Controls.Add(cmbTipoHabitacion);
            Controls.Add(lbl_FechaDeSalida);
            Controls.Add(lbl_FechaDeEntrada);
            Controls.Add(dtpSalida);
            Controls.Add(dtpEntrada);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpEntrada;
        private DateTimePicker dtpSalida;
        private Label lbl_FechaDeEntrada;
        private Label lbl_FechaDeSalida;
        private Label lbl_ReservasHotel;
        private ComboBox cmbTipoHabitacion;
        private ListBox lstReservas;
        private Label lbl_ReservasRealizadas;
        private TextBox txtCliente;
        private Label lbl_NombreYApellido;
        private Button btnReservar;
        private Label lbl_TipoDeHabitacion;
        private Button btn_eliminar;
        public Button btn_editar;
        private ProgressBar progressBarReserva;
    }
}

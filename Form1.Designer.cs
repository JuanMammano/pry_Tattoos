namespace pry_Tattoos
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelDatos;
        private Panel panelAgenda;
        private Label lblTitulo;
        private Label lblCliente;
        private ComboBox cmbCliente;
        private Button btnNuevoCliente;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private Label lblHora;
        private DateTimePicker dtpHora;
        private Label lblDiseno;
        private TextBox txtDiseno;
        private Label lblZona;
        private TextBox txtZona;
        private Label lblEstilo;
        private TextBox txtEstilo;
        private Label lblPresupuesto;
        private NumericUpDown nudPresupuesto;
        private Button btnGuardar;
        private Button btnLimpiar;
        private Label lblVista;
        private ComboBox cmbVista;
        private DateTimePicker dtpVista;
        private Button btnHoy;
        private DataGridView dgvTurnos;
        private MonthCalendar calMes;
        private Label lblEstado;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panelDatos = new Panel();
            panelAgenda = new Panel();
            lblTitulo = new Label();
            lblCliente = new Label();
            cmbCliente = new ComboBox();
            btnNuevoCliente = new Button();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            lblHora = new Label();
            dtpHora = new DateTimePicker();
            lblDiseno = new Label();
            txtDiseno = new TextBox();
            lblZona = new Label();
            txtZona = new TextBox();
            lblEstilo = new Label();
            txtEstilo = new TextBox();
            lblPresupuesto = new Label();
            nudPresupuesto = new NumericUpDown();
            btnGuardar = new Button();
            btnLimpiar = new Button();
            lblVista = new Label();
            cmbVista = new ComboBox();
            dtpVista = new DateTimePicker();
            btnHoy = new Button();
            dgvTurnos = new DataGridView();
            calMes = new MonthCalendar();
            lblEstado = new Label();
            panelDatos.SuspendLayout();
            panelAgenda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPresupuesto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTurnos).BeginInit();
            SuspendLayout();
            // panelDatos
            panelDatos.BackColor = Color.FromArgb(245, 240, 235);
            panelDatos.Controls.Add(lblTitulo);
            panelDatos.Controls.Add(lblCliente);
            panelDatos.Controls.Add(cmbCliente);
            panelDatos.Controls.Add(btnNuevoCliente);
            panelDatos.Controls.Add(lblNombre);
            panelDatos.Controls.Add(txtNombre);
            panelDatos.Controls.Add(lblTelefono);
            panelDatos.Controls.Add(txtTelefono);
            panelDatos.Controls.Add(lblFecha);
            panelDatos.Controls.Add(dtpFecha);
            panelDatos.Controls.Add(lblHora);
            panelDatos.Controls.Add(dtpHora);
            panelDatos.Controls.Add(lblDiseno);
            panelDatos.Controls.Add(txtDiseno);
            panelDatos.Controls.Add(lblZona);
            panelDatos.Controls.Add(txtZona);
            panelDatos.Controls.Add(lblEstilo);
            panelDatos.Controls.Add(txtEstilo);
            panelDatos.Controls.Add(lblPresupuesto);
            panelDatos.Controls.Add(nudPresupuesto);
            panelDatos.Controls.Add(btnGuardar);
            panelDatos.Controls.Add(btnLimpiar);
            panelDatos.Dock = DockStyle.Left;
            panelDatos.Padding = new Padding(18);
            panelDatos.Size = new Size(365, 670);
            // panelAgenda
            panelAgenda.Controls.Add(lblVista);
            panelAgenda.Controls.Add(cmbVista);
            panelAgenda.Controls.Add(dtpVista);
            panelAgenda.Controls.Add(btnHoy);
            panelAgenda.Controls.Add(dgvTurnos);
            panelAgenda.Controls.Add(calMes);
            panelAgenda.Controls.Add(lblEstado);
            panelAgenda.Dock = DockStyle.Fill;
            panelAgenda.Padding = new Padding(18);
            // lblTitulo
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(84, 45, 50);
            lblTitulo.Location = new Point(18, 18);
            lblTitulo.Text = "Nuevo turno";
            // labels y campos
            lblCliente.AutoSize = true; lblCliente.Location = new Point(18, 70); lblCliente.Text = "Cliente";
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList; cmbCliente.Location = new Point(18, 91); cmbCliente.Size = new Size(218, 23);
            cmbCliente.SelectedIndexChanged += cmbCliente_SelectedIndexChanged;
            btnNuevoCliente.Location = new Point(242, 90); btnNuevoCliente.Size = new Size(93, 25); btnNuevoCliente.Text = "Nuevo"; btnNuevoCliente.Click += btnNuevoCliente_Click;
            lblNombre.AutoSize = true; lblNombre.Location = new Point(18, 128); lblNombre.Text = "Nombre y apellido";
            txtNombre.Location = new Point(18, 149); txtNombre.Size = new Size(317, 23);
            lblTelefono.AutoSize = true; lblTelefono.Location = new Point(18, 182); lblTelefono.Text = "Teléfono / WhatsApp";
            txtTelefono.Location = new Point(18, 203); txtTelefono.Size = new Size(317, 23);
            lblFecha.AutoSize = true; lblFecha.Location = new Point(18, 236); lblFecha.Text = "Fecha de sesión";
            dtpFecha.Format = DateTimePickerFormat.Short; dtpFecha.Location = new Point(18, 257); dtpFecha.Size = new Size(145, 23); dtpFecha.ValueChanged += datosAgenda_Changed;
            lblHora.AutoSize = true; lblHora.Location = new Point(185, 236); lblHora.Text = "Hora";
            dtpHora.Format = DateTimePickerFormat.Custom; dtpHora.CustomFormat = "HH:mm"; dtpHora.ShowUpDown = true; dtpHora.Location = new Point(185, 257); dtpHora.Size = new Size(150, 23); dtpHora.ValueChanged += datosAgenda_Changed;
            lblDiseno.AutoSize = true; lblDiseno.Location = new Point(18, 290); lblDiseno.Text = "Idea / detalles del diseño";
            txtDiseno.Location = new Point(18, 311); txtDiseno.Multiline = true; txtDiseno.ScrollBars = ScrollBars.Vertical; txtDiseno.Size = new Size(317, 58);
            lblZona.AutoSize = true; lblZona.Location = new Point(18, 382); lblZona.Text = "Zona del cuerpo";
            txtZona.Location = new Point(18, 403); txtZona.Size = new Size(150, 23);
            lblEstilo.AutoSize = true; lblEstilo.Location = new Point(185, 382); lblEstilo.Text = "Estilo artístico";
            txtEstilo.Location = new Point(185, 403); txtEstilo.Size = new Size(150, 23);
            lblPresupuesto.AutoSize = true; lblPresupuesto.Location = new Point(18, 436); lblPresupuesto.Text = "Presupuesto acordado ($)";
            nudPresupuesto.DecimalPlaces = 2; nudPresupuesto.Maximum = 100000000; nudPresupuesto.ThousandsSeparator = true; nudPresupuesto.Location = new Point(18, 457); nudPresupuesto.Size = new Size(150, 23);
            btnGuardar.BackColor = Color.FromArgb(84, 45, 50); btnGuardar.FlatStyle = FlatStyle.Flat; btnGuardar.ForeColor = Color.White; btnGuardar.Location = new Point(18, 510); btnGuardar.Size = new Size(155, 38); btnGuardar.Text = "Guardar turno"; btnGuardar.Click += btnGuardar_Click;
            btnLimpiar.Location = new Point(180, 510); btnLimpiar.Size = new Size(155, 38); btnLimpiar.Text = "Limpiar"; btnLimpiar.Click += btnLimpiar_Click;
            // agenda
            lblVista.AutoSize = true; lblVista.Font = new Font("Segoe UI", 10F, FontStyle.Bold); lblVista.Location = new Point(18, 18); lblVista.Text = "Vista de agenda";
            cmbVista.DropDownStyle = ComboBoxStyle.DropDownList; cmbVista.Items.AddRange(new object[] { "Diaria", "Semanal", "Mensual" }); cmbVista.SelectedIndex = 0; cmbVista.Location = new Point(125, 16); cmbVista.Size = new Size(115, 25); cmbVista.SelectedIndexChanged += cmbVista_SelectedIndexChanged;
            dtpVista.Format = DateTimePickerFormat.Short; dtpVista.Location = new Point(250, 16); dtpVista.Size = new Size(130, 25); dtpVista.ValueChanged += dtpVista_ValueChanged;
            btnHoy.Location = new Point(390, 16); btnHoy.Size = new Size(75, 25); btnHoy.Text = "Hoy"; btnHoy.Click += btnHoy_Click;
            dgvTurnos.AllowUserToAddRows = false; dgvTurnos.AllowUserToDeleteRows = false; dgvTurnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; dgvTurnos.ReadOnly = true; dgvTurnos.RowHeadersVisible = false; dgvTurnos.SelectionMode = DataGridViewSelectionMode.FullRowSelect; dgvTurnos.Location = new Point(18, 58); dgvTurnos.Size = new Size(690, 540);
            calMes.Location = new Point(18, 58); calMes.Visible = false; calMes.DateSelected += calMes_DateSelected;
            lblEstado.AutoSize = true; lblEstado.ForeColor = Color.FromArgb(84, 45, 50); lblEstado.Location = new Point(18, 610); lblEstado.Text = "Seleccione una vista para consultar los turnos.";
            // Form1
            AutoScaleMode = AutoScaleMode.Font; ClientSize = new Size(1100, 670); MinimumSize = new Size(900, 600); StartPosition = FormStartPosition.CenterScreen; Text = "Agenda de turnos - Estudio de tatuajes";
            Controls.Add(panelAgenda); Controls.Add(panelDatos);
            panelDatos.ResumeLayout(false); panelDatos.PerformLayout(); panelAgenda.ResumeLayout(false); panelAgenda.PerformLayout(); ((System.ComponentModel.ISupportInitialize)nudPresupuesto).EndInit(); ((System.ComponentModel.ISupportInitialize)dgvTurnos).EndInit(); ResumeLayout(false);
        }

        #endregion
    }
}
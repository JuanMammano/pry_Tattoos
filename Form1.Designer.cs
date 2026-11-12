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
        private Label lblObservaciones;
        private TextBox txtObservaciones;
        private Label lblPresupuesto;
        private TextBox txtPresupuestos;
        private Button btnGuardar;
        private Button btnHistorial;
        private Button btnLimpiar;
        private Label lblVista;
        private ComboBox cmbVista;
        private DateTimePicker dtpVista;
        private Button btnHoy;
        private DataGridView dgvTurnos;
        private DataGridViewTextBoxColumn columnaId;
        private DataGridViewTextBoxColumn columnaFecha;
        private DataGridViewTextBoxColumn columnaHorario;
        private DataGridViewTextBoxColumn columnaCliente;
        private DataGridViewTextBoxColumn columnaTatuajes;
        private DataGridViewTextBoxColumn columnaZona;
        private DataGridViewTextBoxColumn columnaObservaciones;
        private DataGridViewTextBoxColumn columnaPresupuesto;
        private DataGridViewComboBoxColumn columnaEstado;
        private DataGridViewButtonColumn btnEliminarTurno;
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
            panelDatos = new Panel();
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
            lblObservaciones = new Label();
            txtObservaciones = new TextBox();
            lblPresupuesto = new Label();
            txtPresupuestos = new TextBox();
            btnGuardar = new Button();
            btnHistorial = new Button();
            btnLimpiar = new Button();
            panelAgenda = new Panel();
            lblVista = new Label();
            cmbVista = new ComboBox();
            dtpVista = new DateTimePicker();
            btnHoy = new Button();
            dgvTurnos = new DataGridView();
            columnaId = new DataGridViewTextBoxColumn();
            columnaFecha = new DataGridViewTextBoxColumn();
            columnaHorario = new DataGridViewTextBoxColumn();
            columnaCliente = new DataGridViewTextBoxColumn();
            columnaTatuajes = new DataGridViewTextBoxColumn();
            columnaZona = new DataGridViewTextBoxColumn();
            columnaObservaciones = new DataGridViewTextBoxColumn();
            columnaPresupuesto = new DataGridViewTextBoxColumn();
            columnaEstado = new DataGridViewComboBoxColumn();
            btnEliminarTurno = new DataGridViewButtonColumn();
            calMes = new MonthCalendar();
            lblEstado = new Label();
            panelDatos.SuspendLayout();
            panelAgenda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTurnos).BeginInit();
            SuspendLayout();
            // 
            // panelDatos
            // 
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
            panelDatos.Controls.Add(lblObservaciones);
            panelDatos.Controls.Add(txtObservaciones);
            panelDatos.Controls.Add(lblPresupuesto);
            panelDatos.Controls.Add(txtPresupuestos);
            panelDatos.Controls.Add(btnGuardar);
            panelDatos.Controls.Add(btnHistorial);
            panelDatos.Controls.Add(btnLimpiar);
            panelDatos.Dock = DockStyle.Left;
            panelDatos.Location = new Point(0, 0);
            panelDatos.Name = "panelDatos";
            panelDatos.Padding = new Padding(18);
            panelDatos.Size = new Size(365, 720);
            panelDatos.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Palatino Linotype", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(84, 45, 50);
            lblTitulo.Location = new Point(18, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(176, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Nuevo turno";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Ink Free", 9.75F, FontStyle.Bold);
            lblCliente.Location = new Point(18, 70);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(51, 16);
            lblCliente.TabIndex = 1;
            lblCliente.Text = "Cliente";
            // 
            // cmbCliente
            // 
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.Location = new Point(18, 91);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(218, 23);
            cmbCliente.TabIndex = 2;
            cmbCliente.SelectedIndexChanged += cmbCliente_SelectedIndexChanged;
            // 
            // btnNuevoCliente
            // 
            btnNuevoCliente.Location = new Point(242, 90);
            btnNuevoCliente.Name = "btnNuevoCliente";
            btnNuevoCliente.Size = new Size(93, 25);
            btnNuevoCliente.TabIndex = 3;
            btnNuevoCliente.Text = "Nuevo";
            btnNuevoCliente.Click += btnNuevoCliente_Click;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Ink Free", 9.75F, FontStyle.Bold);
            lblNombre.Location = new Point(18, 128);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(122, 16);
            lblNombre.TabIndex = 4;
            lblNombre.Text = "Nombre y apellido";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(18, 149);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(317, 23);
            txtNombre.TabIndex = 5;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Ink Free", 9.75F, FontStyle.Bold);
            lblTelefono.Location = new Point(18, 182);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(143, 16);
            lblTelefono.TabIndex = 6;
            lblTelefono.Text = "Teléfono / WhatsApp";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(18, 203);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(317, 23);
            txtTelefono.TabIndex = 7;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Ink Free", 9.75F, FontStyle.Bold);
            lblFecha.Location = new Point(18, 236);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(108, 16);
            lblFecha.TabIndex = 8;
            lblFecha.Text = "Fecha de sesión";
            // 
            // dtpFecha
            // 
            dtpFecha.Font = new Font("Candara", 9.75F, FontStyle.Bold);
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(18, 257);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(145, 23);
            dtpFecha.TabIndex = 9;
            dtpFecha.ValueChanged += datosAgenda_Changed;
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Font = new Font("Ink Free", 9.75F, FontStyle.Bold);
            lblHora.Location = new Point(185, 236);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(38, 16);
            lblHora.TabIndex = 10;
            lblHora.Text = "Hora";
            // 
            // dtpHora
            // 
            dtpHora.CustomFormat = "HH:mm";
            dtpHora.Font = new Font("Candara", 9.75F, FontStyle.Bold);
            dtpHora.Format = DateTimePickerFormat.Custom;
            dtpHora.Location = new Point(185, 257);
            dtpHora.Name = "dtpHora";
            dtpHora.ShowUpDown = true;
            dtpHora.Size = new Size(150, 23);
            dtpHora.TabIndex = 11;
            dtpHora.ValueChanged += datosAgenda_Changed;
            // 
            // lblDiseno
            // 
            lblDiseno.AutoSize = true;
            lblDiseno.Font = new Font("Ink Free", 9.75F, FontStyle.Bold);
            lblDiseno.Location = new Point(18, 290);
            lblDiseno.Name = "lblDiseno";
            lblDiseno.Size = new Size(216, 16);
            lblDiseno.TabIndex = 12;
            lblDiseno.Text = "Ideas / tatuajes (uno por línea)";
            // 
            // txtDiseno
            // 
            txtDiseno.Location = new Point(18, 311);
            txtDiseno.Multiline = true;
            txtDiseno.Name = "txtDiseno";
            txtDiseno.PlaceholderText = "Ej.: dragón en el brazo\r\nRosa en el hombro";
            txtDiseno.ScrollBars = ScrollBars.Vertical;
            txtDiseno.Size = new Size(317, 58);
            txtDiseno.TabIndex = 13;
            // 
            // lblZona
            // 
            lblZona.AutoSize = true;
            lblZona.Font = new Font("Ink Free", 9.75F, FontStyle.Bold);
            lblZona.Location = new Point(18, 474);
            lblZona.Name = "lblZona";
            lblZona.Size = new Size(107, 16);
            lblZona.TabIndex = 16;
            lblZona.Text = "Zona del cuerpo (una por línea)";
            // 
            // txtZona
            // 
            txtZona.Location = new Point(18, 495);
            txtZona.Multiline = true;
            txtZona.Name = "txtZona";
            txtZona.PlaceholderText = "Ej.: brazo\r\nHombro";
            txtZona.ScrollBars = ScrollBars.Vertical;
            txtZona.Size = new Size(317, 40);
            txtZona.TabIndex = 17;
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Font = new Font("Ink Free", 9.75F, FontStyle.Bold);
            lblObservaciones.Location = new Point(18, 544);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(99, 16);
            lblObservaciones.TabIndex = 18;
            lblObservaciones.Text = "Observaciones";
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(18, 565);
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(317, 23);
            txtObservaciones.TabIndex = 19;
            // 
            // lblPresupuesto
            // 
            lblPresupuesto.AutoSize = true;
            lblPresupuesto.Font = new Font("Ink Free", 9.75F, FontStyle.Bold);
            lblPresupuesto.Location = new Point(18, 382);
            lblPresupuesto.Name = "lblPresupuesto";
            lblPresupuesto.Size = new Size(208, 16);
            lblPresupuesto.TabIndex = 14;
            lblPresupuesto.Text = "Presupuestos ($, uno por línea)";
            // 
            // txtPresupuestos
            // 
            txtPresupuestos.Font = new Font("Candara", 9.75F, FontStyle.Bold);
            txtPresupuestos.Location = new Point(18, 403);
            txtPresupuestos.Multiline = true;
            txtPresupuestos.Name = "txtPresupuestos";
            txtPresupuestos.PlaceholderText = "Ej.: 1500,00\r\n800,00";
            txtPresupuestos.ScrollBars = ScrollBars.Vertical;
            txtPresupuestos.Size = new Size(317, 58);
            txtPresupuestos.TabIndex = 15;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(84, 45, 50);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Book Antiqua", 12F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(18, 594);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(155, 49);
            btnGuardar.TabIndex = 20;
            btnGuardar.Text = "Guardar turno";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnHistorial
            // 
            btnHistorial.Font = new Font("Book Antiqua", 12F, FontStyle.Bold);
            btnHistorial.Location = new Point(12, 649);
            btnHistorial.Name = "btnHistorial";
            btnHistorial.Size = new Size(317, 40);
            btnHistorial.TabIndex = 22;
            btnHistorial.Text = "Consultar Historial";
            btnHistorial.Click += btnHistorial_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Font = new Font("Book Antiqua", 12F, FontStyle.Bold);
            btnLimpiar.Location = new Point(180, 594);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(155, 49);
            btnLimpiar.TabIndex = 21;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // panelAgenda
            // 
            panelAgenda.Controls.Add(lblVista);
            panelAgenda.Controls.Add(cmbVista);
            panelAgenda.Controls.Add(dtpVista);
            panelAgenda.Controls.Add(btnHoy);
            panelAgenda.Controls.Add(dgvTurnos);
            panelAgenda.Controls.Add(calMes);
            panelAgenda.Controls.Add(lblEstado);
            panelAgenda.Dock = DockStyle.Fill;
            panelAgenda.Location = new Point(365, 0);
            panelAgenda.Name = "panelAgenda";
            panelAgenda.Padding = new Padding(18);
            panelAgenda.Size = new Size(747, 720);
            panelAgenda.TabIndex = 1;
            // 
            // lblVista
            // 
            lblVista.AutoSize = true;
            lblVista.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblVista.Location = new Point(18, 18);
            lblVista.Name = "lblVista";
            lblVista.Size = new Size(116, 19);
            lblVista.TabIndex = 0;
            lblVista.Text = "Vista de agenda";
            // 
            // cmbVista
            // 
            cmbVista.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVista.Font = new Font("Candara", 9.75F, FontStyle.Bold);
            cmbVista.Items.AddRange(new object[] { "Diaria", "Semanal", "Mensual" });
            cmbVista.Location = new Point(140, 17);
            cmbVista.Name = "cmbVista";
            cmbVista.Size = new Size(115, 23);
            cmbVista.TabIndex = 1;
            cmbVista.SelectedIndexChanged += cmbVista_SelectedIndexChanged;
            // 
            // dtpVista
            // 
            dtpVista.Font = new Font("Candara", 9.75F, FontStyle.Bold);
            dtpVista.Format = DateTimePickerFormat.Short;
            dtpVista.Location = new Point(265, 17);
            dtpVista.Name = "dtpVista";
            dtpVista.Size = new Size(130, 23);
            dtpVista.TabIndex = 2;
            dtpVista.ValueChanged += dtpVista_ValueChanged;
            // 
            // btnHoy
            // 
            btnHoy.Location = new Point(405, 17);
            btnHoy.Name = "btnHoy";
            btnHoy.Size = new Size(75, 25);
            btnHoy.TabIndex = 3;
            btnHoy.Text = "Hoy";
            btnHoy.Click += btnHoy_Click;
            // 
            // dgvTurnos
            // 
            dgvTurnos.AllowUserToAddRows = false;
            dgvTurnos.AllowUserToDeleteRows = false;
            dgvTurnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTurnos.AutoGenerateColumns = false;
            dgvTurnos.Columns.AddRange(new DataGridViewColumn[] { columnaId, columnaFecha, columnaHorario, columnaCliente, columnaTatuajes, columnaZona, columnaObservaciones, columnaPresupuesto, columnaEstado, btnEliminarTurno });
            dgvTurnos.Location = new Point(18, 58);
            dgvTurnos.Name = "dgvTurnos";
            dgvTurnos.ReadOnly = false;
            dgvTurnos.RowHeadersVisible = false;
            dgvTurnos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTurnos.Size = new Size(690, 540);
            dgvTurnos.TabIndex = 4;
            dgvTurnos.CellContentClick += dgvTurnos_CellContentClick;
            dgvTurnos.CellFormatting += dgvTurnos_CellFormatting;
            dgvTurnos.CellValueChanged += dgvTurnos_CellValueChanged;
            dgvTurnos.CurrentCellDirtyStateChanged += dgvTurnos_CurrentCellDirtyStateChanged;
            // 
            // columnaId
            // 
            columnaId.DataPropertyName = "Id";
            columnaId.HeaderText = "Id";
            columnaId.Name = "Id";
            columnaId.ReadOnly = true;
            columnaId.Visible = false;
            // 
            // columnaFecha
            // 
            columnaFecha.DataPropertyName = "Fecha";
            columnaFecha.HeaderText = "Fecha";
            columnaFecha.Name = "Fecha";
            columnaFecha.ReadOnly = true;
            // 
            // columnaHorario
            // 
            columnaHorario.DataPropertyName = "Horario";
            columnaHorario.HeaderText = "Horario";
            columnaHorario.Name = "Horario";
            columnaHorario.ReadOnly = true;
            // 
            // columnaCliente
            // 
            columnaCliente.DataPropertyName = "Cliente";
            columnaCliente.HeaderText = "Cliente";
            columnaCliente.Name = "Cliente";
            columnaCliente.ReadOnly = true;
            // 
            // columnaTatuajes
            // 
            columnaTatuajes.DataPropertyName = "Tatuajes";
            columnaTatuajes.HeaderText = "Tatuajes";
            columnaTatuajes.Name = "Tatuajes";
            columnaTatuajes.ReadOnly = true;
            // 
            // columnaZona
            // 
            columnaZona.DataPropertyName = "Zona";
            columnaZona.HeaderText = "Zona";
            columnaZona.Name = "Zona";
            columnaZona.ReadOnly = true;
            // 
            // columnaObservaciones
            // 
            columnaObservaciones.DataPropertyName = "Observaciones";
            columnaObservaciones.HeaderText = "Observaciones";
            columnaObservaciones.Name = "Observaciones";
            columnaObservaciones.ReadOnly = true;
            // 
            // columnaPresupuesto
            // 
            columnaPresupuesto.DataPropertyName = "Presupuesto";
            columnaPresupuesto.HeaderText = "Presupuesto";
            columnaPresupuesto.Name = "Presupuesto";
            columnaPresupuesto.ReadOnly = true;
            // 
            // columnaEstado
            // 
            columnaEstado.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            columnaEstado.DisplayStyleForCurrentCellOnly = true;
            columnaEstado.HeaderText = "Estado";
            columnaEstado.Items.AddRange(new object[] { "Agendado", "Incompleto", "Postergado", "Finalizado" });
            columnaEstado.Name = "Estado";
            columnaEstado.ReadOnly = false;
            columnaEstado.Width = 105;
            // 
            // btnEliminarTurno
            // 
            btnEliminarTurno.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            btnEliminarTurno.HeaderText = "Acción";
            btnEliminarTurno.Name = "btnEliminarTurno";
            btnEliminarTurno.ReadOnly = true;
            btnEliminarTurno.Text = "Eliminar";
            btnEliminarTurno.UseColumnTextForButtonValue = true;
            btnEliminarTurno.Width = 75;
            // 
            // calMes
            // 
            calMes.Location = new Point(18, 58);
            calMes.Name = "calMes";
            calMes.TabIndex = 5;
            calMes.Visible = false;
            calMes.DateSelected += calMes_DateSelected;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.ForeColor = Color.FromArgb(84, 45, 50);
            lblEstado.Location = new Point(18, 610);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(249, 15);
            lblEstado.TabIndex = 5;
            lblEstado.Text = "Seleccione una vista para consultar los turnos.";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1112, 720);
            Controls.Add(panelAgenda);
            Controls.Add(panelDatos);
            MinimumSize = new Size(900, 600);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agenda de turnos - Bona Ink Tattos";
            Load += Form1_Load;
            panelDatos.ResumeLayout(false);
            panelDatos.PerformLayout();
            panelAgenda.ResumeLayout(false);
            panelAgenda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTurnos).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}
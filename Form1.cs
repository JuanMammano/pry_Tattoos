using System.Text.Json;

namespace pry_Tattoos
{
    public partial class Form1 : Form
    {
        private readonly string archivoDatos = Path.Combine(AppContext.BaseDirectory, "agenda-tatuajes.json");
        private static readonly string[] EstadosTurno = { "Agendado", "Incompleto", "Postergado", "Finalizado" };
        private DatosAgenda datos = new();
        private bool actualizandoCliente;
        private bool actualizandoEstados;

        public Form1()
        {
            InitializeComponent();
            dtpFecha.MinDate = DateTime.Today;
            dtpFecha.Value = DateTime.Today;
            dtpHora.Value = DateTime.Today.AddHours(10);
            dtpVista.Value = DateTime.Today;
            CargarDatos();
            CargarClientes();
            ActualizarAgenda();
        }

        private void CargarDatos()
        {
            try
            {
                if (File.Exists(archivoDatos))
                {
                    datos = JsonSerializer.Deserialize<DatosAgenda>(File.ReadAllText(archivoDatos)) ?? new DatosAgenda();
                }
            }
            catch (JsonException)
            {
                datos = new DatosAgenda();
                lblEstado.Text = "No se pudo leer la agenda guardada. Se inició una agenda nueva.";
            }
        }

        private void GuardarDatos()
        {
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(archivoDatos, JsonSerializer.Serialize(datos, opciones));
        }

        private void CargarClientes()
        {
            actualizandoCliente = true;
            cmbCliente.DataSource = null;
            cmbCliente.DataSource = datos.Clientes.OrderBy(c => c.Nombre).ToList();
            cmbCliente.DisplayMember = nameof(Cliente.Nombre);
            cmbCliente.ValueMember = nameof(Cliente.Id);
            cmbCliente.SelectedIndex = -1;
            actualizandoCliente = false;
        }

        private void cmbCliente_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (actualizandoCliente || cmbCliente.SelectedItem is not Cliente cliente)
                return;

            txtNombre.Text = cliente.Nombre;
            txtTelefono.Text = cliente.Telefono;
        }

        private void btnNuevoCliente_Click(object? sender, EventArgs e)
        {
            actualizandoCliente = true;
            cmbCliente.SelectedIndex = -1;
            actualizandoCliente = false;
            txtNombre.Clear();
            txtTelefono.Clear();
            txtNombre.Focus();
            lblEstado.Text = "Ingrese los datos del nuevo cliente para asociarlo al turno.";
        }

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            List<string> lineasDiseno = txtDiseno.Lines
                .Select(linea => linea.Trim())
                .Where(linea => linea.Length > 0)
                .ToList();
            string disenos = string.Join(Environment.NewLine, lineasDiseno);
            List<string> lineasZona = txtZona.Lines
                .Select(linea => linea.Trim())
                .Where(linea => linea.Length > 0)
                .ToList();
            List<string> lineasPresupuesto = txtPresupuestos.Lines
                .Select(linea => linea.Trim())
                .Where(linea => linea.Length > 0)
                .ToList();
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(telefono))
            {
                MessageBox.Show("Ingrese el nombre y el teléfono del cliente.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lineasDiseno.Count != lineasPresupuesto.Count)
            {
                MessageBox.Show("Ingrese un presupuesto por cada tatuaje, respetando el mismo orden.", "Presupuestos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lineasDiseno.Count != lineasZona.Count)
            {
                MessageBox.Show("Ingrese una zona del cuerpo por cada tatuaje, respetando el mismo orden.", "Zonas incompletas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<decimal> presupuestos = new();
            foreach (string linea in lineasPresupuesto)
            {
                if (!decimal.TryParse(linea, out decimal presupuesto) || presupuesto < 0)
                {
                    MessageBox.Show($"El presupuesto «{linea}» no es válido.", "Presupuesto inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                presupuestos.Add(presupuesto);
            }

            if (lineasDiseno.Count == 0 || lineasZona.Count == 0)
            {
                MessageBox.Show("Complete la idea del diseño y la zona del cuerpo.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime inicio = dtpFecha.Value.Date + dtpHora.Value.TimeOfDay;
            DateTime fin = inicio.AddHours(1);
            bool ocupado = datos.Turnos.Any(t => inicio < t.FechaHoraFin && fin > t.FechaHoraInicio);
            if (ocupado)
            {
                MessageBox.Show("El horario seleccionado se superpone con otro turno. Elija otra fecha u hora.", "Horario ocupado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cliente? cliente = cmbCliente.SelectedItem as Cliente;
            if (cliente == null)
            {
                cliente = new Cliente { Id = Guid.NewGuid(), Nombre = nombre, Telefono = telefono };
                datos.Clientes.Add(cliente);
            }
            else
            {
                cliente.Nombre = nombre;
                cliente.Telefono = telefono;
            }

            datos.Turnos.Add(new Turno
            {
                Id = Guid.NewGuid(),
                ClienteId = cliente.Id,
                FechaHoraInicio = inicio,
                FechaHoraFin = fin,
                Diseno = disenos,
                Zona = string.Join(Environment.NewLine, lineasZona),
                Observaciones = txtObservaciones.Text.Trim(),
                Estado = "Agendado",
                Presupuesto = presupuestos.Sum(),
                Presupuestos = presupuestos
            });
            GuardarDatos();
            CargarClientes();
            LimpiarFormulario();
            dtpVista.Value = inicio.Date;
            ActualizarAgenda();
            MessageBox.Show($"Turno confirmado para {cliente.Nombre} el {inicio:dd/MM/yyyy} a las {inicio:HH:mm}.", "Turno guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLimpiar_Click(object? sender, EventArgs e) => LimpiarFormulario();

        private void btnHistorial_Click(object? sender, EventArgs e)
        {
            if (datos.Clientes.Count == 0)
            {
                MessageBox.Show("Todavía no hay clientes registrados.", "Historial de clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using HistorialForm historial = new(datos);
            historial.ShowDialog(this);
        }

        private void LimpiarFormulario()
        {
            actualizandoCliente = true;
            cmbCliente.SelectedIndex = -1;
            actualizandoCliente = false;
            txtNombre.Clear();
            txtTelefono.Clear();
            txtDiseno.Clear();
            txtPresupuestos.Clear();
            txtZona.Clear();
            txtObservaciones.Clear();
            dtpFecha.Value = DateTime.Today;
            dtpHora.Value = DateTime.Today.AddHours(10);
            lblEstado.Text = "Formulario listo para registrar un nuevo turno.";
        }

        private void cmbVista_SelectedIndexChanged(object? sender, EventArgs e) => ActualizarAgenda();
        private void dtpVista_ValueChanged(object? sender, EventArgs e) => ActualizarAgenda();
        private void datosAgenda_Changed(object? sender, EventArgs e) { }

        private void btnHoy_Click(object? sender, EventArgs e)
        {
            dtpVista.Value = DateTime.Today;
            if (cmbVista.SelectedIndex == 2)
                calMes.SetDate(DateTime.Today);
        }

        private void calMes_DateSelected(object? sender, DateRangeEventArgs e)
        {
            dtpVista.Value = e.Start;
            cmbVista.SelectedIndex = 0;
        }

        private void ActualizarAgenda()
        {
            if (cmbVista.SelectedIndex == 2)
            {
                dgvTurnos.Visible = false;
                calMes.Visible = true;
                calMes.SetDate(dtpVista.Value);
                calMes.RemoveAllBoldedDates();
                calMes.BoldedDates = datos.Turnos.Select(t => t.FechaHoraInicio.Date).Distinct().ToArray();
                calMes.UpdateBoldedDates();
                lblEstado.Text = $"Vista mensual: {dtpVista.Value:MMMM yyyy}. Los días en negrita tienen turnos.";
                return;
            }

            dgvTurnos.Visible = true;
            calMes.Visible = false;
            DateTime desde = dtpVista.Value.Date;
            DateTime hasta = cmbVista.SelectedIndex == 1 ? desde.AddDays(7) : desde.AddDays(1);
            var turnos = datos.Turnos.Where(t => t.FechaHoraInicio >= desde && t.FechaHoraInicio < hasta).OrderBy(t => t.FechaHoraInicio).ToList();
            dgvTurnos.DataSource = turnos.Select(t => new
            {
                Id = t.Id,
                Fecha = t.FechaHoraInicio.ToString("dd/MM/yyyy"),
                Horario = $"{t.FechaHoraInicio:HH:mm} - {t.FechaHoraFin:HH:mm}",
                Cliente = datos.Clientes.FirstOrDefault(c => c.Id == t.ClienteId)?.Nombre ?? "Sin cliente",
                Zona = t.Zona,
                Observaciones = t.Observaciones,
                Tatuajes = FormatearTatuajes(t),
                Presupuesto = t.Presupuesto.ToString("C")
            }).ToList();
            dgvTurnos.Columns["Zona"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvTurnos.Columns["Observaciones"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvTurnos.Columns["Tatuajes"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvTurnos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            actualizandoEstados = true;
            for (int indice = 0; indice < turnos.Count; indice++)
            {
                string estado = NormalizarEstado(turnos[indice].Estado);
                turnos[indice].Estado = estado;
                dgvTurnos.Rows[indice].Cells[columnaEstado.Name].Value = estado;
                AplicarColorEstado(dgvTurnos.Rows[indice].Cells[columnaEstado.Name], estado);
            }

            actualizandoEstados = false;
            lblEstado.Text = $"{turnos.Count} turno(s) encontrado(s) entre {desde:dd/MM/yyyy} y {hasta.AddDays(-1):dd/MM/yyyy}.";
        }

        private void dgvTurnos_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            if (dgvTurnos.IsCurrentCellDirty && dgvTurnos.CurrentCell is DataGridViewComboBoxCell)
                dgvTurnos.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvTurnos_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (actualizandoEstados || e.RowIndex < 0 || e.ColumnIndex < 0 ||
                dgvTurnos.Columns[e.ColumnIndex].Name != columnaEstado.Name ||
                dgvTurnos.Rows[e.RowIndex].Cells[nameof(Turno.Id)].Value is not Guid turnoId)
                return;

            string estado = NormalizarEstado(dgvTurnos.Rows[e.RowIndex].Cells[columnaEstado.Name].Value?.ToString());
            Turno? turno = datos.Turnos.FirstOrDefault(t => t.Id == turnoId);
            if (turno == null)
                return;

            turno.Estado = estado;
            AplicarColorEstado(dgvTurnos.Rows[e.RowIndex].Cells[columnaEstado.Name], estado);
            GuardarDatos();
        }

        private void dgvTurnos_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 &&
                dgvTurnos.Columns[e.ColumnIndex].Name == columnaEstado.Name)
            {
                AplicarColorEstado(e.CellStyle, e.Value?.ToString());
            }
        }

        private static string NormalizarEstado(string? estado) =>
            EstadosTurno.Contains(estado) ? estado : EstadosTurno[0];

        private static void AplicarColorEstado(DataGridViewCell celda, string estado)
        {
            AplicarColorEstado(celda.Style, estado);
        }

        private static void AplicarColorEstado(DataGridViewCellStyle estilo, string? estado)
        {
            (Color fondo, Color texto) = NormalizarEstado(estado) switch
            {
                "Incompleto" => (Color.LightCoral, Color.DarkRed),
                "Postergado" => (Color.Khaki, Color.Black),
                "Finalizado" => (Color.LightGreen, Color.DarkGreen),
                _ => (Color.LightBlue, Color.DarkBlue)
            };

            estilo.BackColor = fondo;
            estilo.ForeColor = texto;
            estilo.SelectionBackColor = fondo;
            estilo.SelectionForeColor = texto;
        }

        private void dgvTurnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || dgvTurnos.Columns[e.ColumnIndex].Name != btnEliminarTurno.Name)
                return;

            DataGridViewRow fila = dgvTurnos.Rows[e.RowIndex];
            if (fila.Cells[nameof(Turno.Id)].Value is not Guid turnoId)
                return;

            Turno? turno = datos.Turnos.FirstOrDefault(t => t.Id == turnoId);
            if (turno == null)
                return;

            string nombreCliente = datos.Clientes.FirstOrDefault(c => c.Id == turno.ClienteId)?.Nombre ?? "Sin cliente";
            DialogResult respuesta = MessageBox.Show(
                $"¿Está seguro de eliminar el turno de {nombreCliente} del {turno.FechaHoraInicio:dd/MM/yyyy} a las {turno.FechaHoraInicio:HH:mm}?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (respuesta != DialogResult.Yes)
                return;

            datos.Turnos.Remove(turno);
            GuardarDatos();
            ActualizarAgenda();
            lblEstado.Text = "Turno eliminado correctamente.";
        }

        private static string FormatearTatuajes(Turno turno)
        {
            string[] disenos = turno.Diseno.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            if (turno.Presupuestos.Count != disenos.Length)
                return turno.Diseno;

            return string.Join(Environment.NewLine, disenos.Select((diseno, indice) =>
                $"{diseno} - {turno.Presupuestos[indice]:C}"));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    internal sealed class DatosAgenda
    {
        public List<Cliente> Clientes { get; set; } = new();
        public List<Turno> Turnos { get; set; } = new();
    }

    internal sealed class Cliente
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public override string ToString() => Nombre;
    }

    internal sealed class Turno
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
        public string Diseno { get; set; } = string.Empty;
        public string Zona { get; set; } = string.Empty;
        public string Observaciones { get; set; } = string.Empty;
        public string Estilo { get; set; } = string.Empty;
        public string Estado { get; set; } = "Agendado";
        public decimal Presupuesto { get; set; }
        public List<decimal> Presupuestos { get; set; } = new();
    }

    internal sealed class HistorialForm : Form
    {
        private readonly DatosAgenda datos;
        private readonly ComboBox cmbCliente = new();
        private readonly Label lblTelefono = new();
        private readonly Label lblEstado = new();
        private readonly DataGridView dgvTurnos = new();

        public HistorialForm(DatosAgenda datos)
        {
            this.datos = datos;
            ConfigurarFormulario();
            CargarClientes();
        }

        private void ConfigurarFormulario()
        {
            Text = "Historial de turnos";
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(1050, 500);
            MinimumSize = new Size(800, 400);

            Label lblCliente = new()
            {
                AutoSize = true,
                Location = new Point(18, 18),
                Text = "Seleccione un cliente:",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };

            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.Location = new Point(175, 16);
            cmbCliente.Size = new Size(300, 25);
            cmbCliente.SelectedIndexChanged += cmbCliente_SelectedIndexChanged;

            lblTelefono.AutoSize = true;
            lblTelefono.ForeColor = Color.FromArgb(84, 45, 50);
            lblTelefono.Location = new Point(500, 20);

            lblEstado.AutoSize = true;
            lblEstado.ForeColor = Color.FromArgb(84, 45, 50);
            lblEstado.Location = new Point(18, 52);

            dgvTurnos.AllowUserToAddRows = false;
            dgvTurnos.AllowUserToDeleteRows = false;
            dgvTurnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTurnos.Location = new Point(18, 82);
            dgvTurnos.ReadOnly = true;
            dgvTurnos.RowHeadersVisible = false;
            dgvTurnos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTurnos.Size = new Size(1014, 390);
            dgvTurnos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dgvTurnos.Columns.Add("Fecha", "Fecha");
            dgvTurnos.Columns.Add("Horario", "Horario");
            dgvTurnos.Columns.Add("Diseno", "Diseño / tatuajes");
            dgvTurnos.Columns.Add("Zona", "Zona del cuerpo");
            dgvTurnos.Columns.Add("Observaciones", "Observaciones");
            dgvTurnos.Columns.Add("Presupuestos", "Presupuestos");
            dgvTurnos.Columns.Add("Total", "Presupuesto total");
            dgvTurnos.Columns["Diseno"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvTurnos.Columns["Observaciones"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvTurnos.Columns["Presupuestos"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            Controls.Add(lblCliente);
            Controls.Add(cmbCliente);
            Controls.Add(lblTelefono);
            Controls.Add(lblEstado);
            Controls.Add(dgvTurnos);
        }

        private void CargarClientes()
        {
            cmbCliente.DataSource = datos.Clientes.OrderBy(c => c.Nombre).ToList();
            cmbCliente.DisplayMember = nameof(Cliente.Nombre);
            cmbCliente.ValueMember = nameof(Cliente.Id);
            cmbCliente.SelectedIndex = -1;
        }

        private void cmbCliente_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbCliente.SelectedItem is Cliente cliente)
                MostrarHistorial(cliente);
        }

        private void MostrarHistorial(Cliente cliente)
        {
            lblTelefono.Text = $"Teléfono / WhatsApp: {cliente.Telefono}";
            dgvTurnos.Rows.Clear();

            List<Turno> turnos = datos.Turnos
                .Where(t => t.ClienteId == cliente.Id)
                .OrderBy(t => t.FechaHoraInicio)
                .ToList();

            foreach (Turno turno in turnos)
            {
                string[] disenos = turno.Diseno.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
                string detallesPresupuesto = turno.Presupuestos.Count == disenos.Length
                    ? string.Join(Environment.NewLine, disenos.Select((diseno, indice) => $"{diseno}: {turno.Presupuestos[indice]:C}"))
                    : turno.Diseno;

                dgvTurnos.Rows.Add(
                    turno.FechaHoraInicio.ToString("dd/MM/yyyy"),
                    $"{turno.FechaHoraInicio:HH:mm} - {turno.FechaHoraFin:HH:mm}",
                    turno.Diseno,
                    turno.Zona,
                    ObtenerObservaciones(turno),
                    detallesPresupuesto,
                    turno.Presupuesto.ToString("C"));
            }

            lblEstado.Text = turnos.Count == 0
                ? "Este cliente todavía no tiene turnos registrados."
                : $"{turnos.Count} turno(s) registrado(s) para {cliente.Nombre}.";
        }

        private static string ObtenerObservaciones(Turno turno)
        {
            if (!string.IsNullOrWhiteSpace(turno.Observaciones))
                return turno.Observaciones;

            return string.IsNullOrWhiteSpace(turno.Estilo) ? "Sin observaciones" : turno.Estilo;
        }
    }
}
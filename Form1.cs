using System.Text.Json;

namespace pry_Tattoos
{
    public partial class Form1 : Form
    {
        private readonly string archivoDatos = Path.Combine(AppContext.BaseDirectory, "agenda-tatuajes.json");
        private DatosAgenda datos = new();
        private bool actualizandoCliente;

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
            string disenos = string.Join(Environment.NewLine, txtDiseno.Lines
                .Select(linea => linea.Trim())
                .Where(linea => linea.Length > 0));
            List<string> lineasDiseno = disenos.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();
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

            if (string.IsNullOrWhiteSpace(disenos) || string.IsNullOrWhiteSpace(txtZona.Text))
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
                Zona = txtZona.Text.Trim(),
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
                Observaciones = FormatearObservaciones(t),
                Presupuesto = t.Presupuesto.ToString("C")
            }).ToList();
            dgvTurnos.Columns[nameof(Turno.Id)].Visible = false;
            dgvTurnos.Columns["Observaciones"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvTurnos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            lblEstado.Text = $"{turnos.Count} turno(s) encontrado(s) entre {desde:dd/MM/yyyy} y {hasta.AddDays(-1):dd/MM/yyyy}.";
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

        private static string FormatearObservaciones(Turno turno)
        {
            string[] disenos = turno.Diseno.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            if (turno.Presupuestos.Count != disenos.Length)
                return turno.Diseno;

            return string.Join(Environment.NewLine, disenos.Select((diseno, indice) =>
                $"{diseno} - {turno.Presupuestos[indice]:C}"));
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
        public string Estilo { get; set; } = string.Empty;
        public decimal Presupuesto { get; set; }
        public List<decimal> Presupuestos { get; set; } = new();
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_EC2
{
    public partial class alumnos : Form
    {
        public alumnos()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 250)
            {
                MenuVertical.Width = 34;
            }
            else
            {
                MenuVertical.Width = 250;

            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            UsuariosSistema usuario = new UsuariosSistema();
            usuario.Show();
            this.Hide();
        }

        private void btnMaestros_Click(object sender, EventArgs e)
        {
            maestros ma = new maestros();
            ma.Show();
            this.Hide();
        }

        private void btnCarrera_Click(object sender, EventArgs e)
        {
            Carrera c = new Carrera();
            c.Show();
            this.Hide();
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            materia m = new materia();
            m.Show();
            this.Hide();
        }

        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            alumnos a = new alumnos();
            a.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            menu.Show();
            this.Hide();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            txtNombre.Enabled = true;
            txtNombre.Text = "";
            cbCarrera.Enabled = true;
            cbCarrera.Text = "";

            txtNombre.Focus();

            btnCancelar.Enabled = true;
            btnGuardar.Enabled = true;
            btnAgregar.Enabled = false;
            dgAlumno.DataSource = null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnAgregar.Enabled = true;
            btnActualizar.Enabled = false;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;

            txtNombre.Text = "";
            txtNombre.Enabled = false;

            dgAlumno.DataSource = null;
        }

        private void cbCarrera_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Carreras a = cbCarrera.SelectedItem as Carreras;

        }

        private void alumnos_Load(object sender, EventArgs e)
        {
            using (conexDataContext bdEsuela = new conexDataContext())
            {
                cbCarrera.DataSource = bdEsuela.Carreras.ToList();
                cbCarrera.DisplayMember = "Nombre";
                cbCarrera.ValueMember = "ID_Carrera";
                Carreras a = cbCarrera.SelectedItem as Carreras;

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string name = txtNombre.Text;
            cbCarrera.ValueMember = "ID_Carrera";
            int carr = Convert.ToInt32(cbCarrera.SelectedValue);

            try
            {
                alumnos_Query a = new alumnos_Query();
                a.GuardarAlumno(name, carr);

                txtNombre.Text = "";
                txtNombre.Enabled = false;
                cbCarrera.Text = "";
                cbCarrera.Enabled = false;

                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
                btnAgregar.Enabled = true;
                dgAlumno.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgAlumno_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombre.Text = dgAlumno.CurrentRow.Cells[1].Value.ToString();
            cbCarrera.Text = dgAlumno.CurrentRow.Cells[2].Value.ToString();

            if (txtNombre.Text == dgAlumno.CurrentRow.Cells[1].Value.ToString() && cbCarrera.Text == dgAlumno.CurrentRow.Cells[2].Value.ToString())
            {
                txtNombre.Enabled = true;
                cbCarrera.Enabled = true;

                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
                btnCancelar.Enabled = true;
                btnAgregar.Enabled = false;
            }
        }
    

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgAlumno.CurrentRow.Cells[0].Value);
            string name = txtNombre.Text;
            cbCarrera.ValueMember = "ID_Carrera";
            int carr = Convert.ToInt32(cbCarrera.SelectedValue);

            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;
            btnAgregar.Enabled = true;

            txtNombre.Enabled = false;
            cbCarrera.Enabled = false;


            if (MessageBox.Show("¿Desea cambiar los datos " + dgAlumno.CurrentRow.Cells[1].Value.ToString() + "?", "Cambio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    alumnos_Query a = new alumnos_Query();
                    a.Actualizar(id, name, carr);
                    dgAlumno.DataSource = null;

                    txtNombre.Text = "";
                    cbCarrera.Text = "";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                conexDataContext bdEscuela = new conexDataContext();
                dgAlumno.DataSource = bdEscuela.MostrarAlumnos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;
            btnAgregar.Enabled = true;

            txtNombre.Enabled = false;
            cbCarrera.Enabled = false;
            cbCarrera.Text = "";
            txtNombre.Text = "";

            if (MessageBox.Show("¿Desea Eliminar al alumno " + dgAlumno.CurrentRow.Cells[1].Value.ToString() + "?", "Eliminar alumno", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgAlumno.CurrentRow.Cells[0].Value);
                try
                {
                    alumnos_Query a = new alumnos_Query();
                    a.Eliminar(id);
                    dgAlumno.DataSource = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar == (char)Keys.Back) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("No se aceptan caracteres especiales o numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargas_Docente ca = new cargas_Docente();
            ca.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cargas_Alumnos ca = new cargas_Alumnos();
            ca.Show();
            this.Hide();
        }

        private void cbCarrera_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("No se acepta ninguna forma de texto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}


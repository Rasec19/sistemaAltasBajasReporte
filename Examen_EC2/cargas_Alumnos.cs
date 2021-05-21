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
    public partial class cargas_Alumnos : Form
    {
        public cargas_Alumnos()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            cbNombre.Enabled = true;
            cbNombre.Text = "";
            cbCarrera.Text = "";
            cbMateria.Enabled = true;
            cbMateria.Text = "";
            cbProfesor.Enabled = true;
            cbProfesor.Text = "";
            cbCarrera.Enabled = true;
            cbNombre.Focus();

            btnCancelar.Enabled = true;
            btnGuardar.Enabled = true;
            btnAgregar.Enabled = false;
            dgCargaAlumnos.DataSource = null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnAgregar.Enabled = true;
            btnActualizar.Enabled = false;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;

            cbNombre.Text = "";
            cbMateria.Text = "";
            cbCarrera.Text = "";
            cbProfesor.Text = "";
            cbCarrera.Enabled = false;
            cbMateria.Enabled = false;
            cbNombre.Enabled = false;
            cbProfesor.Enabled = false;

            dgCargaAlumnos.DataSource = null;
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                conexDataContext bdEscuela = new conexDataContext();
                dgCargaAlumnos.DataSource = bdEscuela.MostrarCargasAlumnos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            cbCarrera.ValueMember = "ID_Carrera";
            int carr = Convert.ToInt32(cbCarrera.SelectedValue);
            cbMateria.ValueMember = "ID_Materia";
            int mat = Convert.ToInt32(cbMateria.SelectedValue);
            cbNombre.ValueMember = "ID_Alumno";
            int name = Convert.ToInt32(cbNombre.SelectedValue);
            cbProfesor.ValueMember = "ID_Maestros";
            int prof = Convert.ToInt32(cbProfesor.SelectedValue);

            try
            {
                cargasAlumnos_Querys ca = new cargasAlumnos_Querys();
                ca.GuardarCargaAlumno(name, carr, mat, prof);

                cbNombre.Text = "";
                cbNombre.Enabled = false;
                cbCarrera.Text = "";
                cbCarrera.Enabled = false;
                cbMateria.Text = "";
                cbMateria.Enabled = false;
                cbProfesor.Text = "";
                cbProfesor.Enabled = false;

                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
                btnAgregar.Enabled = true;
                dgCargaAlumnos.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cargas_Alumnos ca = new cargas_Alumnos();
            ca.Show();
            this.Hide();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            UsuariosSistema usuario = new UsuariosSistema();
            usuario.Show();
            this.Hide();
        }

        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            alumnos a = new alumnos();
            a.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
            cargas_Docente ca = new cargas_Docente();
            ca.Show();
            this.Hide();
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

        private void label1_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            menu.Show();
            this.Hide();
        }

        private void cargas_Alumnos_Load(object sender, EventArgs e)
        {
            using (conexDataContext bdEsuela = new conexDataContext())
            {
                cbCarrera.DataSource = bdEsuela.Carreras.ToList();
                cbCarrera.DisplayMember = "Nombre";
                cbCarrera.ValueMember = "ID_Carrera";
                Carreras c = cbCarrera.SelectedItem as Carreras;

                cbMateria.DataSource = bdEsuela.Materias.ToList();
                cbMateria.DisplayMember = "Nombre";
                cbMateria.ValueMember = "ID_Materia";
                Materias ma = cbMateria.SelectedItem as Materias;

                cbProfesor.DataSource = bdEsuela.Maestros.ToList();
                cbProfesor.DisplayMember = "Nombre";
                cbProfesor.ValueMember = "ID_Maestros";
                Maestros mas = cbNombre.SelectedItem as Maestros;

                cbNombre.DataSource = bdEsuela.Alumnos.ToList();
                cbNombre.DisplayMember = "Nombre";
                cbNombre.ValueMember = "ID_Alumno";
                Alumnos a = cbNombre.SelectedItem as Alumnos;
            }
        }

        private void cbProfesor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Maestros mas = cbProfesor.SelectedItem as Maestros;
        }

        private void cbCarrera_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            Alumnos  c = cbCarrera.SelectedItem as Alumnos;
        }

        private void cbMateria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Materias ma = cbMateria.SelectedItem as Materias;
        }

        private void cbNombre_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Alumnos a = cbNombre.SelectedItem as Alumnos;
        }

        private void dgCargaAlumnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cbNombre.Text = dgCargaAlumnos.CurrentRow.Cells[1].Value.ToString();
            cbCarrera.Text = dgCargaAlumnos.CurrentRow.Cells[2].Value.ToString();
            cbMateria.Text = dgCargaAlumnos.CurrentRow.Cells[3].Value.ToString();
            cbProfesor.Text = dgCargaAlumnos.CurrentRow.Cells[4].Value.ToString();

            if (cbNombre.Text == dgCargaAlumnos.CurrentRow.Cells[1].Value.ToString() && cbCarrera.Text == dgCargaAlumnos.CurrentRow.Cells[2].Value.ToString() && cbMateria.Text == dgCargaAlumnos.CurrentRow.Cells[3].Value.ToString() && cbProfesor.Text == dgCargaAlumnos.CurrentRow.Cells[4].Value.ToString())
            {
                cbNombre.Enabled = true;
                cbCarrera.Enabled = true;
                cbMateria.Enabled = true;
                cbProfesor.Enabled = true;

                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
                btnCancelar.Enabled = true;
                btnAgregar.Enabled = false;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgCargaAlumnos.CurrentRow.Cells[0].Value);
            cbMateria.ValueMember = "ID_Materia";
            int mat = Convert.ToInt32(cbMateria.SelectedValue);
            cbCarrera.ValueMember = "ID_Carrera";
            int carr = Convert.ToInt32(cbCarrera.SelectedValue);
            cbNombre.ValueMember = "ID_Alumno";
            int name = Convert.ToInt32(cbNombre.SelectedValue);
            cbProfesor.ValueMember = "ID_Maestros";
            int prof = Convert.ToInt32(cbProfesor.SelectedValue);

            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;
            btnAgregar.Enabled = true;

            cbNombre.Enabled = false;
            cbCarrera.Enabled = false;
            cbMateria.Enabled = false;
            cbProfesor.Enabled = false;

            if (MessageBox.Show("¿Desea cambiar la carga de " + dgCargaAlumnos.CurrentRow.Cells[1].Value.ToString() + "?", "Cambio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    cargasAlumnos_Querys ca = new cargasAlumnos_Querys();
                    ca.Actualizar(id, name, carr, mat, prof);
                    dgCargaAlumnos.DataSource = null;

                    cbMateria.Text = "";
                    cbCarrera.Text = "";
                    cbNombre.Text = "";
                    cbProfesor.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;
            btnAgregar.Enabled = true;

            cbNombre.Enabled = false;
            cbCarrera.Enabled = false;
            cbMateria.Enabled = false;
            cbProfesor.Enabled = false;
            cbCarrera.Text = "";
            cbNombre.Text = "";
            cbMateria.Text = "";
            cbProfesor.Text = "";

            if (MessageBox.Show("¿Desea Eliminar la carga de " + dgCargaAlumnos.CurrentRow.Cells[1].Value.ToString() + "?", "Eliminar carga", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgCargaAlumnos.CurrentRow.Cells[0].Value);
                try
                {
                    cargasAlumnos_Querys ca = new cargasAlumnos_Querys();
                    ca.Eliminar(id);
                    dgCargaAlumnos.DataSource = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cbNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("No se acepta ninguna forma de texto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
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

        private void cbMateria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("No se acepta ninguna forma de texto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void cbProfesor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("No se acepta ninguna forma de texto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            login l = new login();
            l.Show();
            this.Hide();
        }
    }
}

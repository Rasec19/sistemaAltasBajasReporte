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
    public partial class materia : Form
    {
        public materia()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            menu.Show();
            this.Hide();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            UsuariosSistema usuario = new UsuariosSistema();
            usuario.Show();
            this.Hide();
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            materia m = new materia();
            m.Show();
            this.Hide();
        }

        private void btnAgregarMateria_Click(object sender, EventArgs e)
        {
            txtMateria.Enabled = true;
            txtMateria.Text = "";
            txtMateria.Focus();

            btnCancelarMateria.Enabled = true;
            btnGuardarMateria.Enabled = true;
            btnAgregarMateria.Enabled = false;
            dgMateria.DataSource = null;
        }

        private void btnCancelarMateria_Click(object sender, EventArgs e)
        {
            btnAgregarMateria.Enabled = true;
            btnActualizarMateria.Enabled = false;
            btnGuardarMateria.Enabled = false;
            btnEliminarMateria.Enabled = false;
            btnCancelarMateria.Enabled = false;

            txtMateria.Text = "";
            txtMateria.Enabled = false;

            dgMateria.DataSource = null;
        }

        private void btnGuardarMateria_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtMateria.Text;

                materia_Query m = new materia_Query();
                m.GuardarMateria(name);

                txtMateria.Text = "";
                txtMateria.Enabled = false;

                btnGuardarMateria.Enabled = false;
                btnCancelarMateria.Enabled = false;
                btnAgregarMateria.Enabled = true;
                dgMateria.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMostrarMateria_Click(object sender, EventArgs e)
        {
            try
            {
                materia_Query m = new materia_Query();
                m.Mostrar(dgMateria);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBoxMateria_Click(object sender, EventArgs e)
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

        private void btnActualizarMateria_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgMateria.CurrentRow.Cells[0].Value);
            string name = txtMateria.Text;

            btnActualizarMateria.Enabled = false;
            btnEliminarMateria.Enabled = false;
            btnCancelarMateria.Enabled = false;
            btnAgregarMateria.Enabled = true;

            txtMateria.Enabled = false;


            if (MessageBox.Show("¿Desea cambiar la materia " + dgMateria.CurrentRow.Cells[1].Value.ToString() + "?", "Cambio de nombre de materia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    materia_Query m = new materia_Query();
                    m.Actualizar(id, name);
                    dgMateria.DataSource = null;

                    txtMateria.Text = "";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dgMateria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMateria.Text = dgMateria.CurrentRow.Cells[1].Value.ToString();

            if (txtMateria.Text == dgMateria.CurrentRow.Cells[1].Value.ToString())
            {
                txtMateria.Enabled = true;

                btnActualizarMateria.Enabled = true;
                btnEliminarMateria.Enabled = true;
                btnCancelarMateria.Enabled = true;
                btnAgregarMateria.Enabled = false;
            }
        }

        private void btnEliminarMateria_Click(object sender, EventArgs e)
        {
            btnActualizarMateria.Enabled = false;
            btnEliminarMateria.Enabled = false;
            btnCancelarMateria.Enabled = false;
            btnAgregarMateria.Enabled = true;

            txtMateria.Enabled = false;
            txtMateria.Text = "";

            if (MessageBox.Show("¿Desea Eliminar la materia " + dgMateria.CurrentRow.Cells[1].Value.ToString() + "?", "Eliminar Materia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgMateria.CurrentRow.Cells[0].Value);
                try
                {
                    materia_Query m = new materia_Query();
                    m.Eliminar(id);
                    dgMateria.DataSource = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtMateria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar  == (char)Keys.Back) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se aceptan letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
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

        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            alumnos a = new alumnos();
            a.Show();
            this.Hide();
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

        private void button3_Click(object sender, EventArgs e)
        {
            login l = new login();
            l.Show();
            this.Hide();
        }
    }
}

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
    public partial class Carrera : Form
    {
        public Carrera()
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

        private void label1_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            menu.Show();
            this.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnAgregarCarrera.Enabled = true;
            btnActualizarCarrera.Enabled = false;
            btnGuardarCarrera.Enabled = false;
            btnEliminarCarrera.Enabled = false;
            btnCancelarCarrera.Enabled = false;

            txtCarrera.Text = "";
            txtCarrera.Enabled = false;

            dgCarrera.DataSource = null;
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            carreras_Query c = new carreras_Query();
            c.Mostrar(dgCarrera);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            txtCarrera.Enabled = true;
            txtCarrera.Text = "";
            txtCarrera.Focus();

            btnCancelarCarrera.Enabled = true;
            btnGuardarCarrera.Enabled = true;
            btnAgregarCarrera.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string carrera = txtCarrera.Text;

            carreras_Query c = new carreras_Query();
            c.GuardarCarrera(carrera);

            txtCarrera.Text = "";
            txtCarrera.Enabled = false;

            btnGuardarCarrera.Enabled = false;
            btnCancelarCarrera.Enabled = false;
            btnAgregarCarrera.Enabled = true;
            dgCarrera.DataSource = null;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgCarrera.CurrentRow.Cells[0].Value);
            string name = txtCarrera.Text;

            btnActualizarCarrera.Enabled = false;
            btnEliminarCarrera.Enabled = false;
            btnCancelarCarrera.Enabled = false;
            btnAgregarCarrera.Enabled = true;

            txtCarrera.Enabled = false;


            if (MessageBox.Show("¿Desea cambiar la carrera " + dgCarrera.CurrentRow.Cells[1].Value.ToString() + "?", "Cambio de nombre de carrera", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    carreras_Query c = new carreras_Query();
                    c.Actualizar(id, name);
                    dgCarrera.DataSource = null;

                    txtCarrera.Text = "";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else 
            {
                txtCarrera.Text = "";
            }
        }

        private void txtCarrera_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) )
            {
                MessageBox.Show("Solo se aceptan letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void dgCarrera_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCarrera.Text = dgCarrera.CurrentRow.Cells[1].Value.ToString();

            if (txtCarrera.Text == dgCarrera.CurrentRow.Cells[1].Value.ToString())
            {
                txtCarrera.Enabled = true;

                btnActualizarCarrera.Enabled = true;
                btnEliminarCarrera.Enabled = true;
                btnCancelarCarrera.Enabled = true;
                btnAgregarCarrera.Enabled = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            btnActualizarCarrera.Enabled = false;
            btnEliminarCarrera.Enabled = false;
            btnCancelarCarrera.Enabled = false;
            btnAgregarCarrera.Enabled = true;

            txtCarrera.Enabled = false;
            txtCarrera.Text = "";

            if (MessageBox.Show("¿Desea Eliminar la carrera " + dgCarrera.CurrentRow.Cells[1].Value.ToString() + "?", "Eliminar Carrera", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgCarrera.CurrentRow.Cells[0].Value);
                try
                {
                    carreras_Query c = new carreras_Query();
                    c.Eliminar(id);
                    dgCarrera.DataSource = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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

        private void btnMaestros_Click(object sender, EventArgs e)
        {
            maestros ma = new maestros();
            ma.Show();
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

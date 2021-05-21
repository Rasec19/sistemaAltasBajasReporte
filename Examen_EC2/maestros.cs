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
    public partial class maestros : Form
    {
        public maestros()
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

        private void label1_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            menu.Show();
            this.Hide();
        }

        private void btnMaestros_Click(object sender, EventArgs e)
        {
            maestros ma = new maestros();
            ma.Show();
            this.Hide();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            UsuariosSistema usuario = new UsuariosSistema();
            usuario.Show();
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            txtDireccion.Enabled = true;
            txtNombre.Enabled = true;
            txtDireccion.Text = "";
            txtNombre.Text = "";

            txtNombre.Focus();

            btnCancelar.Enabled = true;
            btnGuardar.Enabled = true;
            btnAgregar.Enabled = false;
            dgMaestro.DataSource = null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnAgregar.Enabled = true;
            btnActualizar.Enabled = false;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;

            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtNombre.Enabled = false;
            txtDireccion.Enabled = false;

            dgMaestro.DataSource = null;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string name = txtNombre.Text;
            string dir = txtDireccion.Text;
            try
            {
                maestros_Query ma = new maestros_Query();
                ma.GuardarMaestro(name, dir);

                txtNombre.Text = "";
                txtDireccion.Text = "";
                txtNombre.Enabled = false;
                txtDireccion.Enabled = false;

                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
                btnAgregar.Enabled = true;
                dgMaestro.DataSource = null;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                maestros_Query ma = new maestros_Query();
                ma.Mostrar(dgMaestro);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
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

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar == (char)Keys.Back) && (e.KeyChar != (char)Keys.Back) && !char.IsPunctuation(e.KeyChar))
            {
                MessageBox.Show("No se aceptan caracteres especiales o numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgMaestro.CurrentRow.Cells[0].Value);
            string name = txtNombre.Text;
            string dir = txtDireccion.Text;

            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;
            btnAgregar.Enabled = true;

            txtNombre.Enabled = false;
            txtDireccion.Enabled = false;


            if (MessageBox.Show("¿Desea cambiar los datos " + dgMaestro.CurrentRow.Cells[1].Value.ToString() + "?", "Cambio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    maestros_Query ma = new maestros_Query();
                    ma.Actualizar(id, name, dir);
                    dgMaestro.DataSource = null;

                    txtNombre.Text = "";
                    txtDireccion.Text = "";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dgMaestro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombre.Text = dgMaestro.CurrentRow.Cells[1].Value.ToString();
            txtDireccion.Text = dgMaestro.CurrentRow.Cells[2].Value.ToString();

            if (txtNombre.Text == dgMaestro.CurrentRow.Cells[1].Value.ToString() && txtDireccion.Text == dgMaestro.CurrentRow.Cells[2].Value.ToString())
            {
                txtNombre.Enabled = true;
                txtDireccion.Enabled = true;

                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
                btnCancelar.Enabled = true;
                btnAgregar.Enabled = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;
            btnAgregar.Enabled = true;

            txtNombre.Enabled = false;
            txtDireccion.Enabled = false;
            txtDireccion.Text = "";
            txtNombre.Text = "";

            if (MessageBox.Show("¿Desea Eliminar al maestro " + dgMaestro.CurrentRow.Cells[1].Value.ToString() + "?", "Eliminar Maestro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgMaestro.CurrentRow.Cells[0].Value);
                try
                {
                    maestros_Query ma = new maestros_Query();
                    ma.Eliminar(id);
                    dgMaestro.DataSource = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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

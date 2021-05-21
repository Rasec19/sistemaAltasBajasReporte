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
    public partial class UsuariosSistema : Form
    {
        public UsuariosSistema()
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

        private void pictureBox1_Click_1(object sender, EventArgs e)
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            txtUsuario.Enabled = true;
            txtPassword.Enabled = true;
            txtConfirmPass.Enabled = true;

            txtUsuario.Text = "";
            txtPassword.Text = "";
            txtConfirmPass.Text = "";

            btnCancelar.Enabled = true;
            btnGuardar.Enabled = true;
            btnAgregar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtUsuario.Text;
            string pass = txtPassword.Text;
            string confirmPass = txtConfirmPass.Text;


            if (pass.Equals(confirmPass))
            {
                usuarios_Query objUsuario = new usuarios_Query();
                objUsuario.GuardarUsuario(nombre, pass);


                txtUsuario.Enabled = false;
                txtPassword.Enabled = false;
                txtConfirmPass.Enabled = false;

                txtUsuario.Text = "";
                txtPassword.Text = "";
                txtConfirmPass.Text = "";

                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
                btnAgregar.Enabled = true;
                dgUsuarios.DataSource = null;
            }
            else 
            {
                MessageBox.Show("La contraseña no coincide", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
            }

        }

        private void cbViewPass_CheckedChanged(object sender, EventArgs e)
        {
            if (cbViewPass.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
                txtConfirmPass.UseSystemPasswordChar = false;

                txtPassword.Focus();
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                txtConfirmPass.UseSystemPasswordChar = true;

                txtPassword.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnAgregar.Enabled = true;
            btnActualizar.Enabled = false;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;
            dgUsuarios.DataSource = null;

            txtUsuario.Text = "";
            txtPassword.Text = "";
            txtConfirmPass.Text = "";

            txtUsuario.Enabled = false;
            txtPassword.Enabled = false;
            txtConfirmPass.Enabled = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                usuarios_Query usu = new usuarios_Query();
                usu.Mostrar(dgUsuarios);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dgUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUsuario.Text = dgUsuarios.CurrentRow.Cells[1].Value.ToString();
            txtPassword.Text = dgUsuarios.CurrentRow.Cells[2].Value.ToString();


            
            if (txtUsuario.Text == dgUsuarios.CurrentRow.Cells[1].Value.ToString() && txtPassword.Text == dgUsuarios.CurrentRow.Cells[2].Value.ToString()) 
            {
                txtUsuario.Enabled = true;
                txtPassword.Enabled = true;
                txtConfirmPass.Enabled = true;

                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
                btnCancelar.Enabled = true;
                btnAgregar.Enabled = false;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgUsuarios.CurrentRow.Cells[0].Value);
            string nombre = txtUsuario.Text;
            string pass = txtPassword.Text;

            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;
            btnAgregar.Enabled = true;

            txtUsuario.Enabled = false;
            txtPassword.Enabled = false;
            txtConfirmPass.Enabled = false;

            if (MessageBox.Show("¿Desea cambiar el usuario y la contraseña de " + dgUsuarios.CurrentRow.Cells[1].Value.ToString() + "?", "Cambio de usuario y contraseña", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txtPassword.Text.Equals(txtConfirmPass.Text))
                {
                    try
                    {
                        usuarios_Query objUsuario = new usuarios_Query();
                        objUsuario.Actualizar(id, nombre, pass);
                        dgUsuarios.DataSource = null;

                        txtUsuario.Text = "";
                        txtPassword.Text = "";
                        txtConfirmPass.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("La contraseña no coincide", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuario.Enabled = true;
                    txtPassword.Enabled = true;
                    txtConfirmPass.Enabled = true;
                    txtPassword.Focus();

                    btnActualizar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnCancelar.Enabled = true;
                    btnAgregar.Enabled = false;
                }
            }
            else 
            {
                txtUsuario.Text = "";
                txtPassword.Text = "";
                txtConfirmPass.Text = "";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;
            btnAgregar.Enabled = true;

            txtUsuario.Enabled = false;
            txtPassword.Enabled = false;
            txtConfirmPass.Enabled = false;

            txtUsuario.Text = "";
            txtPassword.Text = "";
            txtConfirmPass.Text = "";


                if (MessageBox.Show("¿Desea Eliminar al usuario " + dgUsuarios.CurrentRow.Cells[1].Value.ToString() + "?", "Eliminar usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                int id = Convert.ToInt32(dgUsuarios.CurrentRow.Cells[0].Value);
                try
                    {
                    usuarios_Query usu = new usuarios_Query();
                    usu.Eliminar(id);
                    dgUsuarios.DataSource = null;
                }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar == (char)Keys.Back) && (e.KeyChar != (char)Keys.Back) && !char.IsNumber(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                MessageBox.Show("No se aceptan caracteres especiales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar == (char)Keys.Back) && (e.KeyChar != (char)Keys.Back) && !char.IsNumber(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                MessageBox.Show("No se aceptan caracteres especiales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
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

        private void txtConfirmPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar == (char)Keys.Back) && (e.KeyChar != (char)Keys.Back) && !char.IsNumber(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                MessageBox.Show("No se aceptan caracteres especiales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

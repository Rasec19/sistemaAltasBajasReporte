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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void cbViewPass_CheckedChanged(object sender, EventArgs e)
        {
            if (cbViewPass.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;

                txtPassword.Focus();
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;

                txtPassword.Focus();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (conexDataContext bdEscuela = new conexDataContext()) 
            {
                try
                {
                    string name = txtUsuario.Text;
                   string pass = Encrypt.GetSHA256(txtPassword.Text);

                    var registros = from valor in bdEscuela.Usuarios_del_sistema
                                    where valor.Nombre == name && valor.Contraseña == pass
                                    select valor;

                    if (registros.Any())
                    {
                        menu m = new menu();
                        m.Show();
                        this.Hide();
                    }
                    else 
                    {
                        MessageBox.Show("El usuario o contraseña proporcionados son incorrectos","Advertencia", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar == (char)Keys.Back) && !char.IsNumber(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                MessageBox.Show("No se aceptan caracteres especiales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !char.IsNumber(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                MessageBox.Show("No se aceptan caracteres especiales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}

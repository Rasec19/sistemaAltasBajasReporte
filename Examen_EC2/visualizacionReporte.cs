using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Examen_EC2
{
    public partial class visualizacionReporte : Form
    {
        public visualizacionReporte()
        {
            InitializeComponent();
        }

        private void visualizacionReporte_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'ConjuntoExamen.MostrarCargasDocentes' Puede moverla o quitarla según sea necesario.
            this.MostrarCargasDocentesTableAdapter.Fill(this.ConjuntoExamen.MostrarCargasDocentes);

            this.reportViewer1.RefreshReport();
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

        private void label1_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            menu.Show();
            this.Hide();
        }
    }
}

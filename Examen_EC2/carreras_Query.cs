using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_EC2
{
    class carreras_Query
    {
        conexDataContext bdEscuela = new conexDataContext();

        public void GuardarCarrera(string name) 
        {
            Carreras c = new Carreras();
            c.Nombre = name;

            bdEscuela.Carreras.InsertOnSubmit(c);

            try
            {
                bdEscuela.SubmitChanges();
                MessageBox.Show("Registro de carrera exitoso");
            }
            catch (Exception e) 
            {
                MessageBox.Show(e.Message);
            }
        }

        public void Actualizar(int id, string name) 
        {
            var registros = from valor in bdEscuela.Carreras
                            where valor.ID_Carrera == id
                            select valor;
            foreach (var valor in registros)
            {
                valor.Nombre = name;
            }

            try
            {
                bdEscuela.SubmitChanges();
                MessageBox.Show("Cambio exitoso");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void Mostrar(DataGridView data) 
        {
            var registros = from valor in bdEscuela.Carreras
                            select valor;
            data.DataSource = registros;
        }

        public void Eliminar(int id)
        {
            var registros = from valor in bdEscuela.Carreras
                            where valor.ID_Carrera == id
                            select valor;

            foreach (var valor in registros)
            {
                bdEscuela.Carreras.DeleteOnSubmit(valor);
            }

            try
            {
                bdEscuela.SubmitChanges();
                MessageBox.Show("Carrera eliminada exitosamente");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}

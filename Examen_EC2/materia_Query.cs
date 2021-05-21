using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_EC2
{
    class materia_Query
    {
        conexDataContext bdEscuela = new conexDataContext();
        public void GuardarMateria(string name)
        {
            Materias m = new Materias();
            m.Nombre = name;

            bdEscuela.Materias.InsertOnSubmit(m);

            try
            {
                bdEscuela.SubmitChanges();
                MessageBox.Show("Registro de Materia exitoso");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void Mostrar(DataGridView data)
        {
            var registros = from valor in bdEscuela.Materias
                            select valor;
            data.DataSource = registros;
        }

        public void Actualizar(int id, string name)
        {
            var registros = from valor in bdEscuela.Materias
                            where valor.ID_Materia == id
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

        public void Eliminar(int id)
        {
            var registros = from valor in bdEscuela.Materias
                            where valor.ID_Materia == id
                            select valor;

            foreach (var valor in registros)
            {
                bdEscuela.Materias.DeleteOnSubmit(valor);
            }

            try
            {
                bdEscuela.SubmitChanges();
                MessageBox.Show("Materia eliminada exitosamente");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_EC2
{
    class cargasDocente_Query
    {
        conexDataContext bdEscuela = new conexDataContext();
        public void GuardarCargaDocente(int name, int car, int mat)
        {
            Cargas_Docentes cd = new Cargas_Docentes();
            cd.Nombre = name;
            cd.Carrera = car;
            cd.Materia = mat;

            bdEscuela.Cargas_Docentes.InsertOnSubmit(cd);

            try
            {
                bdEscuela.SubmitChanges();
                MessageBox.Show("Registro de Carga exitosa");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        public void Actualizar(int id, int name, int car, int mat)
        {
            var registros = from valor in bdEscuela.Cargas_Docentes
                            where valor.ID_Docente == id
                            select valor;
            foreach (var valor in registros)
            {
                valor.Nombre = name;
                valor.Carrera = car;
                valor.Materia = mat;
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
            var registros = from valor in bdEscuela.Cargas_Docentes
                            where valor.ID_Docente == id
                            select valor;

            foreach (var valor in registros)
            {
                bdEscuela.Cargas_Docentes.DeleteOnSubmit(valor);
            }

            try
            {
                bdEscuela.SubmitChanges();
                MessageBox.Show("Carga eliminada exitosamente");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}

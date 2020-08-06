using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;

namespace Capa_Negocio
{
   public class Crud_Empleados

    {

        public static Surtex_BddDataContext dc = new Surtex_BddDataContext();
        //creamos la instancia de la base de datos para poder capaturar las tablas

        public static void Insert_empleado(Empleado tp)
        {
            //insertar Empleado
            try
            {
                var insert = dc.Insert_empleado(tp.Nombre_empleado, tp.Apellido_empleado, tp.Cedula_empleado, tp.id_car, tp.id_dep);
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException("los datos no han sido guardados <br/>" + ex.Message);
            }


        }

        public static List<Buscar_empleadoResult> Buscar_empleado(string Cedula_empleado)
        {
            var per = dc.Buscar_empleado(Cedula_empleado);
            return per.ToList();
        }

        public static void delete(string pac)
        {
            try
            {


                dc.Eliminar_empleado(pac);
                dc.SubmitChanges();



            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al Borrar <br/>" + ex.Message);
            }
        }
    }
}

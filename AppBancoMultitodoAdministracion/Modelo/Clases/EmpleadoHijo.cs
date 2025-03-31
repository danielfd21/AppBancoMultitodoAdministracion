using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using AppBancoMultitodoAdministracion.Recursos.Base_de_datos.Repositorio;

namespace AppBancoMultitodoAdministracion.Modelo.Clases
{
    internal class EmpleadoHijo : PersonaPadre
    {


       public  EmpleadosRepositorio repo_emp = new EmpleadosRepositorio();


        public String dep { get; internal set; }
        public int edad { get; set; }


        public EmpleadoHijo()
        {


        }

        public EmpleadoHijo(string cedula, string nombres, string apellidos, string correo, string fecha_nacimiento, String departamento) : base(cedula, nombres, apellidos, correo, fecha_nacimiento)
        {
            this.dep = departamento;


        }

        public Boolean Crear_Empleado()
        {

            Boolean estado = false;

            if (string.IsNullOrEmpty(base.ced) || string.IsNullOrEmpty(base.nom) || string.IsNullOrEmpty(base.ape) || string.IsNullOrEmpty(base.cor) || string.IsNullOrEmpty(base.fec_nac))
            {

                MessageBox.Show("Por favor llene todos los campos");


            }
            else
            {

                Boolean ver_ced = repo_emp.Consulta_Verificar_Un_Campo_Tabla_Empleados("cedula",base.ced);
                if (ver_ced == false)
                {
                    Boolean ver_cor = repo_emp.Consulta_Verificar_Un_Campo_Tabla_Empleados("correo", base.cor);

                    if (ver_cor == false)
                    {

                       Boolean insertar = repo_emp.Insert_Tabla_Empleados(base.ced,base.nom,base.ape,base.cor,base.fec_nac,dep);

                        if(insertar == true)
                        {
                            MessageBox.Show("Empleado registrado con exito");
                            estado = true;
                        }
                        


                    }
                    else
                    {
                        MessageBox.Show("No se puede crear porque el correo del empleado ya esta en uso");
                    }

                }
                else
                {
                    MessageBox.Show("No se puede crear porque la cedula del empleado ya existe");
                   


                }

               

            }


            return estado;


        }


        public void Eliminar_Empleado(String cedula)
        {
            if (String.IsNullOrEmpty(cedula))
            {
                MessageBox.Show("Se requiere su cedula");
            }
            else
            {
                Boolean eliminar = repo_emp.Delete_Empleados("cedula",cedula);

                if (eliminar == true)
                {
                    MessageBox.Show("Empleado Eliminado con exito");
                }
            }
        }


        public Tuple<String,String> Actualizar_Empleado(String cedula, String correo)
        {
            Tuple<String, String> tupla_emp = new Tuple<String, String>(cedula,correo);

            if (String.IsNullOrEmpty(cedula))
            {
                MessageBox.Show("Se requiere su cedula ");
            }
            else if(String.IsNullOrEmpty(base.ced) || String.IsNullOrEmpty(base.nom) || String.IsNullOrEmpty(base.ape) || String.IsNullOrEmpty(base.cor) || String.IsNullOrEmpty(base.fec_nac) || String.IsNullOrEmpty(dep))
            {

                MessageBox.Show("Por favor llene todos los campos");

            }
            else
            {

                Boolean ver_ced;


                ver_ced =  base.ced != cedula ?repo_emp.Consulta_Verificar_Un_Campo_Tabla_Empleados("cedula",base.ced):false;




                if (ver_ced == false)
                {
                    Boolean ver_cor;

                    ver_cor = base.cor != correo ?repo_emp.Consulta_Verificar_Un_Campo_Tabla_Empleados("correo", base.cor):false;

                    if(ver_cor == false)
                    {

                        Boolean act_ced = repo_emp.Update_Empleado("cedula", base.ced, cedula);
                        cedula = base.ced;
                        Boolean act_nom = repo_emp.Update_Empleado("nombre", base.nom, cedula);
                        Boolean act_ape = repo_emp.Update_Empleado("apellidos", base.ape, cedula);
                        Boolean act_cor = repo_emp.Update_Empleado("correo", base.cor, cedula);
                        correo = base.ced;
                        Boolean act_fec = repo_emp.Update_Empleado("fecha_de_nacimiento", base.fec_nac, cedula);


                        int id = repo_emp.Get_ID_Departamento(dep);

                        string ids = id.ToString();

                        Boolean act_dep = repo_emp.Update_Empleado("Id_departamento", ids, cedula);


                        
                       
                        tupla_emp = new Tuple<String, String>(cedula, correo);

                        if (act_ced == true && act_nom == true && act_ape == true && act_cor == true && act_fec == true && act_dep == true)
                        {
                            MessageBox.Show("Se ha actualizado los datos correctamente");
                        }





                    }
                    else
                    {
                        MessageBox.Show("Error: el correo ya se encuentra en uso");
                    }
                }
                else
                {
                    MessageBox.Show("Error: la cedula ya se encuentra en uso");
                }

               


            }

            return tupla_emp;


        }

        


    }
}

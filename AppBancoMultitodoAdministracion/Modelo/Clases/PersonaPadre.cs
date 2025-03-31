using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AppBancoMultitodoAdministracion.Recursos.Base_de_datos.Repositorio;
using MySql.Data.MySqlClient;


namespace AppBancoMultitodoAdministracion.Modelo.Clases
{
    internal class PersonaPadre



    {


        public String ced { get; internal set; }

        public String nom { get; internal set; }

        public String ape { get; internal set; }
        public String cor { get; internal set; } 

        public String fec_nac { get; internal set; }
        
        public PersonaPadre(String cedula, String nombres, String apellidos, String correo, String fecha_nacimiento)
        {

            this.ced = cedula;
            this.nom = nombres;
            this.ape = apellidos;
            this.cor = correo;
            this.fec_nac = fecha_nacimiento;

            

        }

        
        public PersonaPadre()
        {

        }



       public EmpleadosRepositorio repo_emp = new EmpleadosRepositorio();


        public void Loguear(String usu, String cla)
        {

            if (String.IsNullOrEmpty(usu) || String.IsNullOrEmpty(cla))
            {
                MessageBox.Show("Por favor ingrese todas las credenciales");
            }
            else
            {


               Boolean ver_usu = repo_emp.Consulta_Verificar_Un_Campo_Tabla_Empleados("cedula",usu);

                if (ver_usu == true)
                {

                    Boolean ver_cla = repo_emp.Consulta_Verificar_Un_Campo_Tabla_Empleados("clave",cla);

                    if(ver_cla == true)
                    {

                        int id = repo_emp.Get_ID_Departamento_Empleado(usu);

                        String Nombre_departamento = repo_emp.Get_Nombre_Departamento_Empleado(id);

                        if(Nombre_departamento == "Gerencia")
                        {


                            Vista.VistaGerencia.MenuGerencia menu_gerencia = new Vista.VistaGerencia.MenuGerencia();
                            menu_gerencia.Show();


                        } else if (Nombre_departamento == "Contabilidad")
                        {

                            Vista.VistaContabilidad.MenuContabilidad men_con = new Vista.VistaContabilidad.MenuContabilidad();
                            men_con.Show();

                        }
                        else
                        {
                            MessageBox.Show("Lo sentimos por el momento no existe una herramienta para su area de trabajo proximamente trabajaremos en ello...");
                        }

                    }
                    else
                    {
                        MessageBox.Show("La contraseña es incorrecta");
                    }


                }
                else
                {
                    MessageBox.Show("El usuario es incorrecto");
                }


            }



        }



    }
}

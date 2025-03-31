using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AppBancoMultitodoAdministracion.Recursos.Base_de_datos.Repositorio;

namespace AppBancoMultitodoAdministracion.Modelo.Clases
{
   


    internal class ClienteHijo : PersonaPadre
    {
        public int edad { get; set; }

        public ClienteHijo()
        {
        }

        public ClienteHijo(string cedula, string nombres, string apellidos, string correo, string fecha_nacimiento) : base(cedula, nombres, apellidos, correo, fecha_nacimiento)
        {


        }


        ClienteRepositorio repo_cli = new ClienteRepositorio();


        public Boolean Crear_CLiente()
        {
            Boolean estado = false;

            if (String.IsNullOrEmpty(base.ced) || String.IsNullOrEmpty(base.nom) || String.IsNullOrEmpty(base.ape) || String.IsNullOrEmpty(base.cor) || String.IsNullOrEmpty(base.fec_nac) )
            {

                MessageBox.Show("Por favor llene todos los campos");
            }
            else
            {
                Boolean ver_ced = repo_cli.Consulta_Verificar_Tabla_Cliente_Un_Campo("cedula",base.ced);

                if(ver_ced == false)
                {

                    Boolean ver_cor = repo_cli.Consulta_Verificar_Tabla_Cliente_Un_Campo("correo",base.cor);

                    if(ver_cor == false)
                    {

                        Boolean insertar_datos_cliente = repo_cli.Insert_Tabla_Cliente(base.ced,base.nom,base.ape,base.cor,base.fec_nac);

                        if(insertar_datos_cliente == true)
                        {
                            estado = true;
                            MessageBox.Show("Cliente registrado con exito");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Error: El correo del cliente ya esta registrado ");
                    }

                }
                else
                {
                    MessageBox.Show("Error: La cedula del cliente ya esta registrada");
                }

            }

                return estado;


        }


        public void Eliminar_Cliente(String cedula)
        {


            var Mensaje_Confirmacion = MessageBox.Show($"¿Estas seguro de eliminar el cliente con cedula \n {cedula}","Eliminar Cliente",MessageBoxButton.YesNo,MessageBoxImage.Warning);

            if(Mensaje_Confirmacion == MessageBoxResult.Yes)
            {
                repo_cli.Delete_Cliente(cedula);

                MessageBox.Show("Cliente Eliminado con exito");

            }

           






        }


        public Tuple<String,String> Actualizar_Cliente(String cedula,String correo)
        {
            Tuple<String, String> tupla_cliente = new Tuple<String, String>(cedula,correo);


            if (String.IsNullOrEmpty(base.ced) || String.IsNullOrEmpty(base.nom) || String.IsNullOrEmpty(base.ape) || String.IsNullOrEmpty(base.cor) || String.IsNullOrEmpty(base.fec_nac))
            {

                MessageBox.Show("Por favor llene todos los campos");
            }
            else
            {
                Boolean ver_ced;

               

                ver_ced = base.ced != cedula ? repo_cli.Consulta_Verificar_Tabla_Cliente_Un_Campo("Cedula", base.ced) : false;


                if (ver_ced == false)
                {

                    Boolean ver_cor;

                    ver_cor =  base.cor != correo? repo_cli.Consulta_Verificar_Tabla_Cliente_Un_Campo("Correo", base.cor): false;

                    if (ver_cor == false)
                    {

                        Boolean actualizar_ced = repo_cli.Update_CLientes("Cedula", base.ced, cedula);
                        cedula = base.ced;
                        Boolean actualizar_nom = repo_cli.Update_CLientes("Nombres", base.nom, cedula);
                        Boolean actualizar_ape = repo_cli.Update_CLientes("Apellidos", base.ape, cedula);
                        correo = base.cor;
                        Boolean actualizar_cor = repo_cli.Update_CLientes("Correo", base.cor, cedula);
                        Boolean actualizar_fec_nac = repo_cli.Update_CLientes("Fecha_nacimiento", base.fec_nac, cedula);

                        if (actualizar_ced == true && actualizar_nom == true && actualizar_ape == true && actualizar_cor == true && actualizar_fec_nac == true)
                        {

                           
                            
                            
                            tupla_cliente = new Tuple<String, String>(cedula, correo);
                            MessageBox.Show("Cliente actualizado con exito");

                        }


                    }
                    else
                    {
                        MessageBox.Show("El correo ya se encuentra en uso por favor digite otra");


                    }



                }
                else
                {
                    MessageBox.Show("La cedula del cliente ya se encuentra en uso por favor digite otra");
                }

            }




                return tupla_cliente;
        }

    }
}

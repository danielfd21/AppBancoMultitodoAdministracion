using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AppBancoMultitodoAdministracion.Recursos.Base_de_datos.Repositorio;

namespace AppBancoMultitodoAdministracion.Modelo.Clases
{
    internal class ContadorHijo_Empleado : EmpleadoHijo
    {

        CuentaRepositorio repo_cue = new CuentaRepositorio();

        public ContadorHijo_Empleado()
        {
        }

        public ContadorHijo_Empleado(string cedula, string nombres, string apellidos, string correo, string fecha_nacimiento, string departamento) : base(cedula, nombres, apellidos, correo, fecha_nacimiento, departamento)
        {




        }


        public void Depositar(String cuenta,double cantidad, double saldo)
        {
          

           
            

                repo_cue.Update_Saldo_Deposito(cuenta,cantidad);
                



        }



        public Boolean Retirar(String cuenta, double cantidad, double saldo)
        {

            Boolean estado = false;

            if (cantidad <= saldo)
            {

                repo_cue.Update_Saldo_Retiro(cuenta, cantidad);
                estado = true;

            }
            else
            {
                MessageBox.Show("La cantidad supera el saldo que tiene disponible");
            }








            return estado;





        }


        public void Transferir(String cuenta_dep, String cuenta_ben, double can, double sal)
        {
            Boolean ver_cue_ben = repo_cue.Verificar_Numero_Cuenta("Numero_cuenta",cuenta_ben);

            if(ver_cue_ben == true)
            {

                if(cuenta_dep != cuenta_ben)
                {

                    if(can <= sal)
                    {

                        repo_cue.Insert_Tabla_Transferencia(cuenta_dep,cuenta_ben,can);
                        repo_cue.Execute_Transferencia(cuenta_dep, cuenta_ben, can);

                        MessageBox.Show("Transferencia realizada con exito");


                    }
                    else
                    {
                        MessageBox.Show("La cantidad excede al saldo disponible");
                    }



                }
                else
                {
                    MessageBox.Show("El movimiento no se puede ejecutar porque la cuenta del depositante y beneficiario son las mismas");
                }



            }
            else
            {
                MessageBox.Show("El numero de cuenta del beneficiario no existe");
            }





        }

        


    }
}

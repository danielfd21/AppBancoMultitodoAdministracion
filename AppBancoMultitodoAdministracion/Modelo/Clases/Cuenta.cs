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
    class Cuenta
    {

   
       
        public String cue { get; set; }

        public Double sal { get; set; }

        public String ced{ get; set; }


        public String cla { set; get; }

        public Cuenta()
        {

        }

        public Cuenta(String cuenta, Double Saldo, String Cedula, String clave)
        {

            this.cue = cuenta;
            this.sal = Saldo;
            this.ced = Cedula;
            this.cla = clave;


            
            

            

        }


        public void Set_Clave(String clave)
        {
            this.cla = clave;
        }


        public String Get_Clave()
        {
            return cla;
        }
        


        CuentaRepositorio repo_cue = new CuentaRepositorio();


        public String Crear_Numero_de_Cuenta()
        {
            String cuenta = "";

            String numeros = "1234567890";

            Random aleatorio = new Random();

            Boolean bandera = false;

            while (bandera == false)
            {
                for (int i = 0; i < 10; i++)
                {
                    int pos = aleatorio.Next(numeros.Length);
                    char valor = numeros[pos];
                    cuenta += valor;


                }

                if (repo_cue.Verificar_Numero_Cuenta("Numero_cuenta", cuenta) == false)
                {

                    bandera = true;

                }
                else
                {
                    cuenta = "";
                }
            }

            return cuenta;
        }


        public String Crear_Clave_Cuenta()
        {
            String cla = "";



            String numeros = "1234567890";

            Random aleatorio = new Random();

            for(int i = 0; i < 4; i++)
            {
                int pos = aleatorio.Next(numeros.Length);
                char clave = numeros[pos];
                cla += clave;
            }



            return cla;
        }


        public void Crear_Cuenta()
        {
          

            


            if( sal == 0.0)
            {
                MessageBox.Show("Por favor Ingrese el saldo inicial de su cuenta");

            }else if(sal < 50)
            {
                MessageBox.Show("El saldo Inicial de la cuenta no debe ser menor que 50$");
            }
            else
            {








                Boolean insertar_cuenta = repo_cue.Insert_Tabla_Cuenta(cue, sal, ced, cla);

                if (insertar_cuenta == true) {

                    MessageBox.Show("Cuenta creada con exito,");
                }



            }





      

    }


       
        public Boolean Actualizar_Clave_Cuenta(String cuenta, String clave)
        {



            Boolean estado = false;

            if (String.IsNullOrEmpty(cuenta))
            {
                MessageBox.Show("Por favor ingrese su cuenta");
            }
            else
            {
                Boolean ver_cue = repo_cue.Verificar_Numero_Cuenta("Numero_Cuenta", cuenta);

                if (ver_cue == true)
                {

                    Boolean actualizar = repo_cue.UPDATE_Cuenta("Clave", clave, cuenta);

                    if (actualizar == true)
                    {

                        estado = true;

                        MessageBox.Show("La clave ha sido cambiada con exito");
                    }

                }
                else
                {
                    MessageBox.Show("El numero de cuenta proporcionado no existe");
                }

            }




            return estado;

        }

        


    }

     
}

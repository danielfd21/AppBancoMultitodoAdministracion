using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient; 


namespace AppBancoMultitodoAdministracion.Recursos.Base_de_datos.Conexion
{
    internal class ConexionInicioMultitodo
    {


        String Parametros = "Server=Localhost;Database=Inicio_multitodo;Uid=root;Pwd=";


        public MySqlConnection Conectar()
        {

            MySqlConnection con = new MySqlConnection(Parametros);


            try
            {

                con.Open();



            }catch(Exception e)
            {
                MessageBox.Show("Error en la conexion de InicioMultitodo" + e);
            }




            return con;

        }

    }
}

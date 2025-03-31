using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;


namespace AppBancoMultitodoAdministracion.Recursos.Base_de_datos.Conexion
{
    internal class ConexionBancoMultitodo
    {

        String Parametros = "Server=Localhost;Database=Banco_multitodo;Uid=root;Pwd=";


        public MySqlConnection Conectar()
        {

            MySqlConnection conexion = new MySqlConnection(Parametros);


            try
            {

                conexion.Open();


            }catch(Exception e)
            {
                MessageBox.Show("Error al contectar la base de datos" + e);
            }

            return conexion;


        }



    }
}

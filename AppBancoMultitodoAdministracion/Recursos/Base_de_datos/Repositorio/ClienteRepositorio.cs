using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AppBancoMultitodoAdministracion.Modelo.Clases;
using AppBancoMultitodoAdministracion.Recursos.Base_de_datos.Conexion;
using MySql.Data.MySqlClient;

namespace AppBancoMultitodoAdministracion.Recursos.Base_de_datos.Repositorio
{
    internal class ClienteRepositorio
    {

        ConexionBancoMultitodo con = new ConexionBancoMultitodo();

        public Boolean Consulta_Verificar_Tabla_Cliente_Un_Campo(String campo, String objeto)
        {

            Boolean estado = false;

            MySqlConnection conectar = con.Conectar();


            try
            {

                String consultar = $"SELECT * FROM cliente WHERE {campo} = @objeto";

                using(MySqlCommand cmd = new MySqlCommand(consultar,conectar))
                {

                    cmd.Parameters.AddWithValue("@objeto",objeto);

                    using (MySqlDataReader leer = cmd.ExecuteReader())
                    {

                        if (leer.Read())
                        {

                            estado = true;

                        }


                    }

                }



            }catch(MySqlException e)
            {
                MessageBox.Show("Error Consulta_Verificar_Tabla_Cliente_Un_Campo" + e);
            }catch(Exception e)
            {
                MessageBox.Show("Error Consulta_Verificar_Tabla_Cliente_Un_Campo" + e);
            }
            finally
            {
                conectar.Close();
            }


            return estado;

        }

        public Boolean Insert_Tabla_Cliente(String ced, String nom, String ape, String cor, String fec_nac)
        {
            Boolean estado = false;

            MySqlConnection conectar = con.Conectar();

            try
            {

                String insertar = "INSERT INTO cliente VALUES(@cedula,@nombres,@apellidos,@correo,@fec_nac)";

                using(MySqlCommand cmd = new MySqlCommand(insertar,conectar))
                {

                    cmd.Parameters.AddWithValue("@cedula", ced);
                    cmd.Parameters.AddWithValue("@nombres", nom);
                    cmd.Parameters.AddWithValue("@apellidos", ape);
                    cmd.Parameters.AddWithValue("@correo", cor);
                    cmd.Parameters.AddWithValue("@fec_nac", fec_nac);


                    int insertado = cmd.ExecuteNonQuery();

                    if(insertado > 0)
                    {
                        estado = true;

                    }



                }



            }catch(MySqlException e)
            {

                MessageBox.Show("Error Insert_Tabla_Cliente ");


            }catch(Exception e)
            {

                MessageBox.Show("Error Insert_Tabla_Cliente ");

            }
            finally
            {
                conectar.Close();
            }



            return estado;


        }

        public int Calcular_Edad(String fec_nac)
        {
            int edad = 0;


            try
            {

                MySqlConnection conectar = con.Conectar();

                String consultar = $"SELECT  YEAR(CURRENT_DATE) - YEAR({fec_nac}) AS Edad";

                using (MySqlCommand cmd = new MySqlCommand(consultar,conectar))

                {

                    using(MySqlDataReader leer = cmd.ExecuteReader())
                    {

                        if (leer.Read())
                        {

                            edad = Convert.ToInt32(leer["Edad"]);

                        }


                    }

                }



            }catch(MySqlException e)
            {



            }catch(Exception e)
            {

            }


            return edad;

        }

        public List<ClienteHijo> Mostrar_Lista_Cliente()
        {
            List<ClienteHijo> Lista_Clientes = new List<ClienteHijo>();

            MySqlConnection conectar = con.Conectar();


            try
            {
                String consultar = "SELECT * FROM CLiente";

                using(MySqlCommand cmd = new MySqlCommand(consultar,conectar))
                {
                   


                    using (MySqlDataReader leer = cmd.ExecuteReader())
                    {
                        while (leer.Read())
                        {
                            DateTime fecha_nac =  Convert.ToDateTime(leer["Fecha_nacimiento"].ToString());

                            int edad_calculada = DateTime.Today.Year - fecha_nac.Year;



                            ClienteHijo cliente = new ClienteHijo()
                            {
                                ced = leer["Cedula"].ToString(),
                                nom = leer["Nombres"].ToString(),
                                ape = leer["Apellidos"].ToString(),
                                cor = leer["Correo"].ToString(),
                                fec_nac = leer["Fecha_nacimiento"].ToString(),
                                edad = edad_calculada


                            };


                            Lista_Clientes.Add(cliente);
                        }
                      
                    }


                }

            }
            catch (MySqlException e)
            {

                MessageBox.Show("Error Mostrar_Lista_Cliente");


            }
            catch (Exception e)
            {

                MessageBox.Show("Error Mostrar_Lista_Cliente");

            }
            finally
            {
                conectar.Close();
            }



            return Lista_Clientes;

        }

        public List<ClienteHijo> Mostrar_Lista_Cliente_Filtrado(String campo, String objeto)
        {
            List<ClienteHijo> Lista_Clientes = new List<ClienteHijo>();

            MySqlConnection conectar = con.Conectar();


            try
            {
                String consultar = $"SELECT * FROM CLiente WHERE {campo} LIKE @objeto";

                using (MySqlCommand cmd = new MySqlCommand(consultar, conectar))
                {

                    cmd.Parameters.AddWithValue("@objeto","%" + objeto + "%");


                    using (MySqlDataReader leer = cmd.ExecuteReader())
                    {
                        while (leer.Read())
                        {
                            DateTime fecha_nac = Convert.ToDateTime(leer["Fecha_nacimiento"].ToString());

                            int edad_calculada = DateTime.Today.Year - fecha_nac.Year;



                            ClienteHijo cliente = new ClienteHijo()
                            {
                                ced = leer["Cedula"].ToString(),
                                nom = leer["Nombres"].ToString(),
                                ape = leer["Apellidos"].ToString(),
                                cor = leer["Correo"].ToString(),
                                fec_nac = leer["Fecha_nacimiento"].ToString(),
                                edad = edad_calculada


                            };


                            Lista_Clientes.Add(cliente);
                        }

                    }


                }

            }
            catch (MySqlException e)
            {

                MessageBox.Show("Error Mostrar_Lista_Cliente");


            }
            catch (Exception e)
            {

                MessageBox.Show("Error Mostrar_Lista_Cliente");

            }
            finally
            {
                conectar.Close();
            }



            return Lista_Clientes;

        }

        
        public Boolean Update_CLientes(String campo, String objeto, String cedula)
        {

            Boolean estado = false;


            MySqlConnection conectar = con.Conectar();


            try
            {
                String actualizar = $"UPDATE cliente SET {campo} = @objeto WHERE Cedula = @cedula";

                using(MySqlCommand cmd = new MySqlCommand(actualizar,conectar))
                {

                    cmd.Parameters.AddWithValue("@objeto",objeto);
                    cmd.Parameters.AddWithValue("@cedula", cedula);

                    int actualizado = cmd.ExecuteNonQuery();

                    if(actualizado > 0)
                    {

                        estado = true;

                    }






                }




            }catch(MySqlException e)
            {


                MessageBox.Show("Error Update_Cliente" + e);

            }catch(Exception e)
            {
                MessageBox.Show("Error Update_Cliente" + e);
            }

            return estado;

        }

        public void Delete_Cliente(String cedula)
        {
            MySqlConnection conectar = con.Conectar();

            try
            {

                String eliminar = "DELETE FROM cliente WHERE Cedula = @cedula";
                using(MySqlCommand cmd = new MySqlCommand(eliminar,conectar))
                {
                    cmd.Parameters.AddWithValue("@cedula",cedula);

                    cmd.ExecuteNonQuery();

                }

            }
            catch(MySqlException e)
            {

                MessageBox.Show("Error Delete_Cliente" + e);

            }
            catch(Exception e)
            {
                MessageBox.Show("Error Delete_Cliente" + e);

            }
            finally
            {
                conectar.Close();

            }

        }
       






    }





}

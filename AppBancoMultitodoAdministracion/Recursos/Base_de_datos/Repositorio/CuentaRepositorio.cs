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
    class CuentaRepositorio
    {

        ConexionBancoMultitodo con = new ConexionBancoMultitodo();
        ClienteRepositorio repo_cli = new ClienteRepositorio();

        public Boolean Verificar_Numero_Cuenta(String campo , String objeto)
        {
            Boolean estado = false;

            MySqlConnection conectar = con.Conectar();

            try
            {

                String consultar = $"SELECT * FROM cuenta WHERE {campo} = @objeto";

                using(MySqlCommand cmd = new MySqlCommand(consultar,conectar))
                {
                    cmd.Parameters.AddWithValue("@objeto",objeto);

                    using(MySqlDataReader leer = cmd.ExecuteReader())
                    {

                        if (leer.Read())
                        {
                            estado = true;
                        }
                    }

                }


            }catch(MySqlException e)
            {
                MessageBox.Show("Error: Verificar_Numero_Cuenta" + e);
            }catch(Exception e)
            {
                MessageBox.Show("Error: Verificar_Numero_Cuenta" + e);
            }
            finally
            {
                conectar.Close();
            }
            return estado;
        }

        public Boolean Insert_Tabla_Cuenta(String cue, Double sal, String ced, String cla)
        {
            Boolean estado = false;

            MySqlConnection conectar = con.Conectar();

            try
            {
                String insertar = "INSERT INTO cuenta VALUES(@cuenta,@estado,@saldo,@clave,@cedula)";

                String est = "Activo";
                String clav = cla;

                using (MySqlCommand cmd = new MySqlCommand(insertar,conectar))
                {
                    cmd.Parameters.AddWithValue("@cuenta",cue);
                    cmd.Parameters.AddWithValue("@estado", est);
                    cmd.Parameters.AddWithValue("@saldo", sal);
                    cmd.Parameters.AddWithValue("@clave", clav);
                    cmd.Parameters.AddWithValue("@cedula", ced);


                    int insertado = cmd.ExecuteNonQuery();

                    if(insertado > 0)
                    {
                        estado = true;
                    }

                }


            }catch(MySqlException e)
            {

                MessageBox.Show("Error Insert_Tabla_Cuenta" + e);

            }catch(Exception e)
            {
                MessageBox.Show("Error Insert_Tabla_Cuenta" + e);

            }
            finally
            {
                conectar.Close();
            }



            return estado;
        }

        public Boolean UPDATE_Cuenta(String campo, String objeto, String cuenta)
        {

            Boolean estado = false;

            MySqlConnection conectar = con.Conectar();

            try
            {
                String actualizar = $"UPDATE cuenta SET {campo} = @objeto WHERE Numero_Cuenta = @cuenta";

                using(MySqlCommand cmd = new MySqlCommand(actualizar,conectar))
                {

                    cmd.Parameters.AddWithValue("@objeto",objeto);
                    cmd.Parameters.AddWithValue("@cuenta", cuenta);

                    int actualizado = cmd.ExecuteNonQuery();

                    if (actualizado > 0)
                    {

                        estado = true;

                    }


                }




            }
            catch(MySqlException e)
            {

                MessageBox.Show("Erro: UPDATE_Cuenta" + e);

            }catch(Exception e)
            {

                MessageBox.Show("Erro: UPDATE_Cuenta" + e);

            }
            finally
            {
                conectar.Close();
            }


            return estado;

        }


        public List<object> Mostrar_Datos_Cuenta()
        {

            List<object> Lista_Cuenta = new List<object>();

            MySqlConnection conectar = con.Conectar();

            try
            {

                String consultar = "SELECT cliente.Cedula,cliente.Nombres,cliente.Apellidos,cliente.Correo,cliente.Fecha_nacimiento,cuenta.Numero_Cuenta, cuenta.Saldo FROM cliente INNER JOIN cuenta ON cliente.Cedula = cuenta.Cedula";

                using(MySqlCommand cmd = new MySqlCommand(consultar,conectar))
                {

                    using(MySqlDataReader leer = cmd.ExecuteReader())
                    {
                        while (leer.Read())
                        {

                            DateTime edad =  Convert.ToDateTime(leer["Fecha_nacimiento"].ToString());
                            int edad_calculada = DateTime.Today.Year - edad.Year;

                            object Cuenta_Cliente = new
                            {

                                ced = leer["Cedula"],
                                nom = leer["Nombres"],
                                ape = leer["Apellidos"],
                                cor = leer["Correo"],
                                eda = edad_calculada,
                                cue = leer["Numero_cuenta"],
                                sal = leer["Saldo"]




                            };


                            Lista_Cuenta.Add(Cuenta_Cliente);

                        }



                    }


                }


            }catch(MySqlException e)
            {

                MessageBox.Show("Error mostrar lista empleados_cuenta" + e);



            }catch(Exception e)
            {
                MessageBox.Show("Error mostrar lista empleados_cuenta" + e);

            }
            finally
            {
                conectar.Close();
            }



            return Lista_Cuenta;


        }

        public List<object> Mostrar_Datos_Cuenta_Filtro(String campo, String objeto)
        {

            List<object> Lista_Cuenta = new List<object>();

            MySqlConnection conectar = con.Conectar();

            try
            {

                String consultar = $"SELECT cliente.Cedula,cliente.Nombres,cliente.Apellidos,cliente.Correo,cliente.Fecha_nacimiento,cuenta.Numero_Cuenta, cuenta.Saldo FROM cliente INNER JOIN cuenta ON cliente.Cedula = cuenta.Cedula WHERE {campo} LIKE @objeto";

                using (MySqlCommand cmd = new MySqlCommand(consultar, conectar))
                {

                    cmd.Parameters.AddWithValue("@objeto", "%" + objeto + "%");


                    using (MySqlDataReader leer = cmd.ExecuteReader())
                    {


                        while (leer.Read())
                        {
                            DateTime edad = Convert.ToDateTime(leer["Fecha_nacimiento"].ToString());
                            int edad_calculada = DateTime.Today.Year - edad.Year;

                            object Cuenta_Cliente = new
                            {

                                ced = leer["Cedula"],
                                nom = leer["Nombres"],
                                ape = leer["Apellidos"],
                                cor = leer["Correo"],
                                eda = edad_calculada,
                                cue = leer["Numero_cuenta"],
                                sal = leer["Saldo"]




                            };


                            Lista_Cuenta.Add(Cuenta_Cliente);

                        }

                    }


                }


            }
            catch (MySqlException e)
            {

                MessageBox.Show("Error mostrar lista empleados_cuenta" + e);



            }
            catch (Exception e)
            {
                MessageBox.Show("Error mostrar lista empleados_cuenta" + e);

            }
            finally
            {
                conectar.Close();
            }



            return Lista_Cuenta;


        }


        public void Update_Saldo_Deposito(String cue, double can)
        {

            MySqlConnection conectar = con.Conectar();

            try
            {
                
                String actualizar =  "UPDATE cuenta SET Saldo = Saldo + @cantidad WHERE Numero_cuenta = @cuenta";

                using(MySqlCommand cmd = new MySqlCommand(actualizar,conectar))
                {

                    cmd.Parameters.AddWithValue("@cantidad",can);
                    cmd.Parameters.AddWithValue("@cuenta",cue);

                    cmd.ExecuteNonQuery();

                }




            }catch(MySqlException e)
            {

                MessageBox.Show("error UPDATE_Saldo_cueta_deposito" + e);

            }catch(Exception e)
            {
                MessageBox.Show("error UPDATE_Saldo_cueta_deposito" + e);
            }
            finally
            {
                conectar.Close();
            }



        }

        public void Update_Saldo_Retiro(String cue, double can)
        {

            MySqlConnection conectar = con.Conectar();

            try
            {

                String actualizar = "UPDATE cuenta SET Saldo = Saldo - @cantidad WHERE Numero_cuenta = @cuenta";

                using (MySqlCommand cmd = new MySqlCommand(actualizar, conectar))
                {

                    cmd.Parameters.AddWithValue("@cantidad", can);
                    cmd.Parameters.AddWithValue("@cuenta", cue);

                    cmd.ExecuteNonQuery();

                }




            }
            catch (MySqlException e)
            {

                MessageBox.Show("error UPDATE_Saldo_cueta_deposito" + e);

            }
            catch (Exception e)
            {
                MessageBox.Show("error UPDATE_Saldo_cueta_deposito" + e);
            }
            finally
            {
                conectar.Close();
            }



        }


        public Double Consultar_saldo(String cuenta)
        {

            Double saldo = 0.0; 


            MySqlConnection conectar = con.Conectar();
            try
            {

                String consultar = "SELECT Saldo FROM cuenta WHERE Numero_cuenta = @cuenta";

                using(MySqlCommand cmd = new MySqlCommand(consultar,conectar))
                {

                    cmd.Parameters.AddWithValue("@cuenta",cuenta);

                    using(MySqlDataReader leer = cmd.ExecuteReader())
                    {

                        if (leer.Read())
                        {


                            saldo = Convert.ToDouble(leer["Saldo"]);


                        }

                    }




                }




            }
            catch (MySqlException e)
            {

                MessageBox.Show("error Consultar Saldo" + e);

            }
            catch (Exception e)
            {

                MessageBox.Show("error Consultar Saldo" + e);

            }
            finally
            {
                conectar.Close();
            }

            return saldo;


        }


        public void Insert_Tabla_Transferencia(String cue_rem, String cue_ben, double can)
        {


            MySqlConnection conectar = con.Conectar();


            try
            {

                String insertar = "INSERT INTO transaccion(fecha_tra,Hora_tra,Cantidad,Cuenta_rem,Cuenta_ben) VALUES(CURRENT_DATE,CURRENT_TIME,@cantidad,@cuenta_rem,@cuenta_ben)";
                
                using(MySqlCommand cmd = new MySqlCommand(insertar,conectar))
                {

                    cmd.Parameters.AddWithValue("@cantidad", can);
                    cmd.Parameters.AddWithValue("@cuenta_rem",cue_rem);
                    cmd.Parameters.AddWithValue("@cuenta_ben",cue_ben);

                    cmd.ExecuteNonQuery();



                }




            }catch(MySqlException e)
            {

                MessageBox.Show("Error Insertar_transferencia" + e);


            }catch(Exception e)
            {
                MessageBox.Show("Error Insertar_transferencia" + e);
            }
            finally
            {
                conectar.Close();
            }


        }


        public void Execute_Transferencia(String cue_dep, String cue_ben, double can)
        {

            MySqlConnection conectar = con.Conectar();

            try
            {

                String ejecutar = "CALL Transferir(@cue_dep,@cue_ben,@can)";

                using(MySqlCommand cmd = new MySqlCommand(ejecutar,conectar))
                {

                    cmd.Parameters.AddWithValue("@cue_dep",cue_dep);
                    cmd.Parameters.AddWithValue("@cue_ben", cue_ben);
                    cmd.Parameters.AddWithValue("@can", can);

                    cmd.ExecuteNonQuery();

                }


            }catch(MySqlException e)
            {
                MessageBox.Show("Error execute_transferencia " + e);

            }catch(Exception e)
            {
                MessageBox.Show("Error execute_transferencia " + e);

            }
            finally
            {
                conectar.Close();
            }
        }






    }



}

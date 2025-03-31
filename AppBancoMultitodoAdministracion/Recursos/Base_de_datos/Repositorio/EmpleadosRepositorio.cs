using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AppBancoMultitodoAdministracion.Modelo.Clases;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace AppBancoMultitodoAdministracion.Recursos.Base_de_datos.Repositorio
{
    internal class EmpleadosRepositorio
    {

        Conexion.ConexionInicioMultitodo con = new Conexion.ConexionInicioMultitodo();

        public Boolean Consulta_Verificar_Un_Campo_Tabla_Empleados(String campo, String objeto)
        {
            Boolean Llave = false;

            MySqlConnection conectar = con.Conectar();
            try
            {
                String consulta = $"SELECT * FROM empleados WHERE {campo} = @objeto ";

                using (MySqlCommand cmd = new MySqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddWithValue("@objeto", objeto);

                    using (MySqlDataReader leer = cmd.ExecuteReader())
                    {

                        if (leer.Read())
                        {

                            Llave = true;
                        }


                    }

                }


            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error consulta_Verificar_Un_Campo_Tabla_Empleados" + e);
            }
            catch (Exception e)
            {

                MessageBox.Show("Error Consulta_Verificar_Un_Campo_Tabla_Empleados" + e);

            }
            finally
            {
                conectar.Close();
            }




            return Llave;

        }

        public int Get_ID_Departamento_Empleado(String cedula)
        {
            int id = 0;


            MySqlConnection conectar = con.Conectar();

            try
            {

                String obtener = "SELECT Id_departamento From empleados Where Cedula = @cedula";

                using (MySqlCommand cmd = new MySqlCommand(obtener, conectar))
                {
                    cmd.Parameters.AddWithValue("@cedula", cedula);

                    using (MySqlDataReader leer = cmd.ExecuteReader())
                    {

                        while (leer.Read())
                        {
                            id = Convert.ToInt32(leer["Id_departamento"]);

                        }

                    }


                }


            } catch (MySqlException e)
            {
                MessageBox.Show("error Obtenr_ID_Departamento_Empleados" + e);


            }
            catch (Exception e)
            {

                MessageBox.Show("Error Get_ID_Departamento_Empleado" + e);

            }
            finally
            {
                conectar.Close();
            }


            return id;
        }


        public int Get_ID_Departamento(String nombre)
        {
            int id = 0;


            MySqlConnection conectar = con.Conectar();

            try
            {

                String obtener = "SELECT Id_departamento From departamento Where Nombre = @nombre";

                using (MySqlCommand cmd = new MySqlCommand(obtener, conectar))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);

                    using (MySqlDataReader leer = cmd.ExecuteReader())
                    {

                        while (leer.Read())
                        {
                            id = Convert.ToInt32(leer["Id_departamento"]);

                        }

                    }


                }


            }
            catch (MySqlException e)
            {
                MessageBox.Show("error Obtener_ID_Departamento_Empleados" + e);


            }
            catch (Exception e)
            {

                MessageBox.Show("Error Obtenr_ID_Departamento_Empleados" + e);

            }
            finally
            {
                conectar.Close();
            }


            return id;
        }



        public String Get_Nombre_Departamento_Empleado(int id)
        {
            String nombre = "";


            MySqlConnection conectar = con.Conectar();

            try
            {

                String obtener = "SELECT Nombre From departamento Where Id_departamento = @id";

                using (MySqlCommand cmd = new MySqlCommand(obtener, conectar))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader leer = cmd.ExecuteReader())
                    {

                        while (leer.Read())
                        {
                            nombre = leer["Nombre"].ToString();

                        }

                    }


                }


            }
            catch (MySqlException e)
            {
                MessageBox.Show("error Obtener_Nombre_Departamento_Empleados" + e);


            }
            catch (Exception e)
            {

                MessageBox.Show("error Obtener_Nombre_Departamento_Empleados" + e);
            }
            finally
            {
                conectar.Close();
            }


            return nombre;
        }


        public Boolean Insert_Tabla_Empleados(String ced, String nom, String ape, String cor, String fec_nac, String dep)
        {
            Boolean afirmacion = false;
            MySqlConnection conectar = con.Conectar();

            try
            {


                String insertar = "INSERT INTO empleados VALUES(@ced,@nom,@ape,@cor,@fec_nac,@clave,@dep)";

                using (MySqlCommand cmd = new MySqlCommand(insertar, conectar))
                {

                    String clave_defecto = " ";

                    int id_dep = Get_ID_Departamento(dep);

                    cmd.Parameters.AddWithValue("@ced", ced);
                    cmd.Parameters.AddWithValue("@nom", nom);
                    cmd.Parameters.AddWithValue("@ape", ape);
                    cmd.Parameters.AddWithValue("@cor", cor);
                    cmd.Parameters.AddWithValue("@fec_nac", fec_nac);
                    cmd.Parameters.AddWithValue("@clave", clave_defecto);
                    cmd.Parameters.AddWithValue("@dep", id_dep);
                    int insertado = cmd.ExecuteNonQuery();

                    if (insertado > 0)
                    {
                        afirmacion = true;
                    }


                }




            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error en insertar_tabla_empleados" + e);
            }
            catch (Exception e)
            {

                MessageBox.Show("Error en insertar_tabla_empleados" + e);

            }
            finally
            {
                conectar.Close();
            }

            return afirmacion;




        }

        public List<String> Get_Columna_Departamentos(String columna)
        {

            List<String> fila = new List<String>();

            MySqlConnection conectar = con.Conectar();

            try
            {
                String obtener = "SELECT * FROM departamento";

                using (MySqlCommand cmd = new MySqlCommand(obtener, conectar))
                {

                    using (MySqlDataReader leer = cmd.ExecuteReader())
                    {

                        while (leer.Read())
                        {

                            fila.Add(leer[columna].ToString());

                        }


                    }



                }


            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error Get_Columna_departamentos" + e);
            }
            catch (Exception e)
            {

                MessageBox.Show("Error Get_Columna_departamentos" + e);

            }
            finally
            {
                conectar.Close();
            }

            return fila;

        }


        public Boolean Update_Clave_Empleado(String clave, String campo, String objeto)
        {

            Boolean estado = false;
            MySqlConnection conectar = con.Conectar();


            try
            {

                String actualizar = $"UPDATE empleados SET clave = @clave WHERE {campo} = @objeto";



                using (MySqlCommand cmd = new MySqlCommand(actualizar, conectar))
                {
                    cmd.Parameters.AddWithValue("@clave", clave);
                    cmd.Parameters.AddWithValue("@objeto", objeto);


                    int actualizado = cmd.ExecuteNonQuery();

                    if (actualizado > 0)
                    {
                        estado = true;
                    }


                }


            }
            catch(MySqlException e)
            {

                MessageBox.Show("Error update_clave" + e);

            }
            catch (Exception e)
            {

                MessageBox.Show("Error update_clave" + e);

            }
            finally
            {
                conectar.Close();
            }


            




            return estado;


        }

  

        


        public List<EmpleadoHijo> Get_Datos_Empleados()
        {

            List<EmpleadoHijo> Lista_empleados = new List<EmpleadoHijo>();

            MySqlConnection conectar = con.Conectar();

            try
            {


                String consultar = "SELECT * FROM empleados";

                using (MySqlCommand cmd = new MySqlCommand(consultar, conectar))
                {

                    using (MySqlDataReader leer = cmd.ExecuteReader())
                    {


                        Boolean bandera = false;

                        while (leer.Read())
                        {


                            DateTime fec = Convert.ToDateTime(leer["fecha_de_nacimiento"]);

                            int id_dep = Convert.ToInt32(leer["Id_departamento"]);

                            String nombre_dep = Get_Nombre_Departamento_Empleado(id_dep);


                            EmpleadoHijo emp = new EmpleadoHijo
                            {



                                ced = leer["cedula"].ToString(),
                                nom = leer["nombre"].ToString(),
                                ape = leer["apellidos"].ToString(),
                                cor = leer["correo"].ToString(),
                                fec_nac = fec.ToString("yyyy-MM-dd"),
                                dep = nombre_dep





                            };

                            bandera = true;

                            Lista_empleados.Add(emp);






                        }

                        if (bandera == false)
                        {
                            MessageBox.Show("No se han encontrado resultados");
                        }



                    }



                }


            }catch(MySqlException e)
            {
                MessageBox.Show("Error en Get_Datos_Empleados" + e);

            }
            catch (Exception e)
            {

                MessageBox.Show("Error en Get_Datos_Empleados" + e);

            }
            finally
            {
                conectar.Close();
            }



            return Lista_empleados;
        }

        public List<EmpleadoHijo> Get_Datos_Empleados_Campos(String campo, String objeto)
        {

            List<EmpleadoHijo> Lista_empleados = new List<EmpleadoHijo>();

            MySqlConnection conectar = con.Conectar();

            try
            {


                String consultar = $"SELECT * FROM empleados WHERE {campo} LIKE @objeto";

                using (MySqlCommand cmd = new MySqlCommand(consultar, conectar))
                {
                    cmd.Parameters.AddWithValue("@objeto", "%" + objeto + "%");

                    using (MySqlDataReader leer = cmd.ExecuteReader())
                    {


                        Boolean bandera = false;
                        

                        while (leer.Read())
                        {


                            DateTime fec = Convert.ToDateTime(leer["fecha_de_nacimiento"]);

                            int id_dep = Convert.ToInt32(leer["Id_departamento"]);

                            String nombre_dep = Get_Nombre_Departamento_Empleado(id_dep);




                            EmpleadoHijo emp = new EmpleadoHijo
                            {



                                ced = leer["cedula"].ToString(),
                                nom = leer["nombre"].ToString(),
                                ape = leer["apellidos"].ToString(),
                                cor = leer["correo"].ToString(),
                                fec_nac = fec.ToString("yyyy-MM-dd"),
                                dep = nombre_dep
                                






                            };


                            bandera = true;

                            Lista_empleados.Add(emp);






                        }

                        if(bandera == false)
                        {
                            MessageBox.Show("No se han encontrado resultados");
                        }

                    }



                }


            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error en Get_Datos_Empleados" + e);

            }
            catch (Exception e)
            {

                MessageBox.Show("Error en Get_Datos_Empleados" + e);

            }
            finally
            {
                conectar.Close();
            }



            return Lista_empleados;
        }


        public Boolean Delete_Empleados(String campo, String objeto)
        {
            Boolean estado = false;

            MySqlConnection conectar = con.Conectar();

            try
            {

                String eliminar = $"DELETE FROM empleados WHERE {campo} = @objeto";

                using (MySqlCommand cmd = new MySqlCommand(eliminar,conectar)) 
                {

                    cmd.Parameters.AddWithValue("@objeto",objeto);

                    int eliminado = cmd.ExecuteNonQuery();

                    if(eliminado > 0)
                    {

                        estado = true;

                    }


                    

                }


            }catch(MySqlException e)
            {
                MessageBox.Show("Error Delete_empleados" + e);
            }
            catch (Exception e)
            {

                MessageBox.Show("Error Delete_empleados" + e);

            }
            finally
            {
                conectar.Close();
            }


            return estado;
            


        }


        public Boolean Update_Empleado(String campo,String objeto, String cedula)
        {
            Boolean estado = false;

            MySqlConnection conectar = con.Conectar();

            try
            {
                String actualizar = $"UPDATE empleados SET {campo} = @objeto WHERE cedula = @cedula";

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


                MessageBox.Show("Error en Update_Empleado" + e);
            }
            catch (Exception e)
            {

                MessageBox.Show("Error en Update_Empleado" + e);

            }
            finally
            {
                conectar.Close();
            }


            return estado;
        }

        public int Get_Total_Departamentos_Empleados()
        {

            int total = 0;


            MySqlConnection conectar = con.Conectar();

            try
            {


                String obtener = "SELECT COUNT(DISTINCT Id_departamento) AS Departamentos FROM empleados";

                using (MySqlCommand cmd = new MySqlCommand(obtener, conectar))
                {

                    using(MySqlDataReader leer = cmd.ExecuteReader())
                    {

                        while (leer.Read())
                        {
                            total = Convert.ToInt32(leer["Departamentos"]);

                        }

                    }



                }

            }
            catch(MySqlException e)
            {
                MessageBox.Show("Error Get_Total_Departamento" + e);
            }
            catch (Exception e)
            {

                MessageBox.Show("Error Get_Total_Departamento" + e);

            }
            finally
            {
                conectar.Close();
            }

           

            




            return total;


        }

        public int Get_Total_Emplados_X_Departamento(int id)
        {
            int total = 0;

            MySqlConnection conectar = con.Conectar();

           

            try
            {
                String obtener = "SELECT count(cedula) AS cedula FROM empleados WHERE Id_departamento = @id";

                using (MySqlCommand cmd = new MySqlCommand(obtener, conectar))
                {

                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader leer = cmd.ExecuteReader())
                    {
                        if (leer.Read())
                        {
                            total = Convert.ToInt32(leer["cedula"]);
                        }

                        
                    }
                }

            }
            catch(MySqlException e)
            {
                MessageBox.Show("Error Get_Total_Emplados_X_Departamento" + e);
            }
            catch (Exception e)
            {

                MessageBox.Show("Error Get_Total_Emplados_X_Departamento" + e);

            }
            finally
            {
                conectar.Close();
            }

            return total;
        }

    }


}


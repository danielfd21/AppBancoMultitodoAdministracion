using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AppBancoMultitodoAdministracion.Modelo.Clases;
using AppBancoMultitodoAdministracion.Recursos.Base_de_datos.Repositorio;

namespace AppBancoMultitodoAdministracion.Vista.VistaGerencia
{
    /// <summary>
    /// Lógica de interacción para ActualizarEmpleados.xaml
    /// </summary>
    public partial class ActualizarEmpleados : Window
    {

        EmpleadosRepositorio repo_emp = new EmpleadosRepositorio();

        public String cedu { get; internal set; }
        public String corr { get; internal set; }

        public ActualizarEmpleados(String cedula, String correo)
        {
            InitializeComponent();

            this.cedu = cedula;
            this.corr = correo;

            List<EmpleadoHijo> Lista_empleados = repo_emp.Get_Datos_Empleados_Campos("Cedula",cedu);
            List<String> Lista_departamentos = repo_emp.Get_Columna_Departamentos("Nombre");
            cb_dep.ItemsSource = Lista_departamentos;

            EmpleadoHijo empleado = Lista_empleados[0];


            txt_ced.Text = empleado.ced;
            txt_nom.Text = empleado.nom;
            txt_ape.Text = empleado.ape;
            txt_cor.Text = empleado.cor;

            DateTime fec_nac_ini;

           if (DateTime.TryParseExact(empleado.fec_nac,"yyyy-MM-dd",CultureInfo.InvariantCulture, DateTimeStyles.None,out fec_nac_ini))
            {

                txt_fec_nac.SelectedDate = fec_nac_ini;



            }

            
            cb_dep.SelectedItem = empleado.dep;
        }

        private void Actualizar_Empleado(object sender, RoutedEventArgs e)
        {

            String ced = txt_ced.Text;
            String nom = txt_nom.Text;
            String ape = txt_ape.Text;
            String cor = txt_cor.Text;
            
            DateTime fec = txt_fec_nac.SelectedDate.Value;
            String fe_na = fec.ToString("yyyy-MM-dd");

            String dep = cb_dep.SelectedItem.ToString();

            


            EmpleadoHijo edi_emp = new EmpleadoHijo(ced,nom,ape,cor,fe_na,dep);
            (String ced_tem,String cor_temp) = edi_emp.Actualizar_Empleado(cedu,corr);


            if (!string.IsNullOrEmpty(ced_tem))
            {
                cedu = ced_tem;
                txt_ced.Text = edi_emp.ced;
                txt_nom.Text = edi_emp.nom;
                txt_ape.Text = edi_emp.ape;
                txt_cor.Text = edi_emp.cor;

                DateTime f_n;

                if (DateTime.TryParseExact(edi_emp.fec_nac, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out f_n))
                {
                    txt_fec_nac.SelectedDate = f_n;
                }
                else
                {
                    MessageBox.Show("Fecha no valida");
                }

                cb_dep.SelectedItem = edi_emp.dep;

            }

          

           


           



        }
    }
}

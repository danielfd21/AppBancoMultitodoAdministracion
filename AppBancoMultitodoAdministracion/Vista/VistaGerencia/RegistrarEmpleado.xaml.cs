using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AppBancoMultitodoAdministracion.Modelo.Clases;
using AppBancoMultitodoAdministracion.Recursos.Base_de_datos.Repositorio;

namespace AppBancoMultitodoAdministracion.Vista.VistaGerencia
{
    /// <summary>
    /// Lógica de interacción para RegistrarEmpleado.xaml
    /// </summary>
    public partial class RegistrarEmpleado : Window
    {
        EmpleadosRepositorio repo_emp = new EmpleadosRepositorio();

        public RegistrarEmpleado()
        {
            InitializeComponent();
            
            List<String> departamentos = repo_emp.Get_Columna_Departamentos("Nombre");

            departamentos.Insert(0,"SELECCIONE");
            cb_dep.ItemsSource = departamentos;

            cb_dep.SelectedIndex = 0;





        }


       




        private void Btn_registrar(object sender, RoutedEventArgs e)
        {


            String ced = txt_ced.Text;
            String nom = txt_nom.Text;
            String ape = txt_ape.Text;
            String cor = txt_cor.Text;
            DateTime fec = txt_fec_nac.SelectedDate.Value;
            String fec_nac = fec.ToString("yyyy-MM-dd");
            String dep = cb_dep.SelectedItem.ToString();

            EmpleadoHijo Nuevo_empleado = new EmpleadoHijo(ced, nom, ape, cor, fec_nac, dep);
            Boolean cre_emp = Nuevo_empleado.Crear_Empleado();


            if(cre_emp == true)
            {

                txt_ced.Text = "";
                txt_nom.Text = "";
                txt_ape.Text = "";
                txt_cor.Text = "";
                txt_fec_nac.SelectedDate = null;
                cb_dep.SelectedIndex = 0;

            }

        }
    }
}

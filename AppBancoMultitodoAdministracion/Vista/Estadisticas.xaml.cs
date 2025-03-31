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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AppBancoMultitodoAdministracion.Modelo.Clases;
using AppBancoMultitodoAdministracion.Recursos.Base_de_datos.Repositorio;
using LiveCharts;
using LiveCharts.Wpf;

namespace AppBancoMultitodoAdministracion.Vista
{
    /// <summary>
    /// Lógica de interacción para Estadisticas.xaml
    /// </summary>
    public partial class Estadisticas : Window
    {

        GerenteHijo_Empleado ger = new GerenteHijo_Empleado();
       



        public SeriesCollection PieSeries { get; set; }

        

        public Estadisticas()

        {





            InitializeComponent();

            PieSeries = new SeriesCollection();

            List<Tuple<String, Double>> Lista_Empleados_X_Departamento = ger.Generar_Lista_FULL_Departamentos();



            foreach (var Obtener_Departamento in Lista_Empleados_X_Departamento)
            {

              
                PieSeries.Add(new PieSeries { Title = Obtener_Departamento.Item1, Values = new ChartValues<double> {Obtener_Departamento.Item2}, DataLabels = true  , LabelPoint = chartPoint => $"{chartPoint.Y} empleados" });

            }


            DataContext = this;
        }

        private void Chart_OnDataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show($"Porcentaje: {chartPoint.Participation:P}");
        }
    }
}

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

namespace AppBancoMultitodoAdministracion.Vista.VistaContabilidad
{
    /// <summary>
    /// Lógica de interacción para EditarCliente.xaml
    /// </summary>
    public partial class EditarCliente : Window
    {
        ClienteHijo cli = new ClienteHijo();
        ClienteRepositorio repo_cli = new ClienteRepositorio();

        public String cedu { get; set; }
        public String corr { get; set; }
        

        public EditarCliente(String cedula,String correo)
        {
            InitializeComponent();

            List<ClienteHijo> cliente = repo_cli.Mostrar_Lista_Cliente_Filtrado("Cedula", cedula);

            this.cedu = cedula;
            this.corr = correo;

            ClienteHijo cli = cliente[0];
            txt_ced.Text = cli.ced;
            txt_nom.Text = cli.nom;
            txt_ape.Text = cli.ape;
            txt_cor.Text = cli.cor;
            txt_fec_nac.SelectedDate = Convert.ToDateTime(cli.fec_nac);




        }


        public void Actualizar_Cliente(object sender, RoutedEventArgs e)
        {


            String ced = txt_ced.Text;
            String nom = txt_nom.Text;
            String ape = txt_ape.Text;
            String cor = txt_cor.Text;
            DateTime? fec_nac = txt_fec_nac.SelectedDate;
            String fe_na = fec_nac.HasValue ? fec_nac.Value.ToString("yyyy-MM-dd") : null;



            ClienteHijo editar_cliente = new ClienteHijo(ced,nom,ape,cor,fe_na);

            

            (String ced_temp,String cor_temp) = editar_cliente.Actualizar_Cliente(cedu,corr);
            
            if(!string.IsNullOrEmpty(ced_temp) && !string.IsNullOrEmpty(cor_temp))
            {
                cedu = ced_temp;
                corr = cor_temp;

                txt_ced.Text = editar_cliente.ced;
                txt_nom.Text = editar_cliente.nom;
                txt_ape.Text = editar_cliente.ape;
                txt_cor.Text = editar_cliente.cor;
                txt_fec_nac.SelectedDate = Convert.ToDateTime(editar_cliente.fec_nac);



            }





        }

        
    }
}

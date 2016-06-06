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

namespace Visao
{
    /// <summary>
    /// Interaction logic for WindowVeiculo.xaml
    /// </summary>
    public partial class WindowVeiculo : Window
    {
        ServiceReference1.Service1Client sr = new ServiceReference1.Service1Client();
        public WindowVeiculo()
        {
            InitializeComponent();
            SelectFabricantes();
        }

        private void SelectFabricantes()
        {
            comboBox.ItemsSource = sr.SelectFabricante();
            comboBox.SelectedValuePath = "Id";
            comboBox.DisplayMemberPath = "Descricao";
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Modelo.Veiculo v = new Modelo.Veiculo { Id = int.Parse(txtId.Text), Modelo = txtModelo.Text, IdFabricante = (int)comboBox.SelectedValue, DataCompra = Convert.ToDateTime(data.SelectedDate), DataVenda = Convert.ToDateTime(data.SelectedDate) };
            sr.InsertVeiculo(v);
            sr.SelectVeiculo();
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            var veiculos = sr.SelectVeiculo();
            var fabricantes = sr.SelectFabricante();
            var vplusf = from v in veiculos
                         join fab in fabricantes on v.IdFabricante equals fab.Id
                         select new
                         {
                             id = v.Id,
                             modelo = v.Modelo,
                             ano = v.Ano,
                             dtCompra = v.DataCompra,
                             vCompra = v.ValorCompra,
                             desc = fab.Descricao,
                             idFab = fab.Id
                         };
            dataGrid.ItemsSource = vplusf.OrderBy(desc => desc.desc).ThenBy(mode => mode.modelo);
        }
    }
}

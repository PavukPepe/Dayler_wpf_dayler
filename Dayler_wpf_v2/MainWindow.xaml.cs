using Dayler_wpf;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dayler_wpf_v2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Tip> tips = new List<Tip>();
        public MainWindow()
        {
            InitializeComponent();
            tip_date.Text = DateTime.Now.ToString("d");
            reload();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (tip_name.Text != "" && tip_description.Text != "" && tip_date.Text != "")
            {
                Tip tip = new Tip(tip_name.Text, tip_description.Text, Convert.ToDateTime(tip_date.Text));
                tips.Add(tip);
                BimBim.Write(tips, Convert.ToDateTime(tip_date.Text).ToString("D"));
                reload();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = Convert.ToDateTime(tip_date.Text);
            Tip selected = tips_list.SelectedItem as Tip;
            selected.name = tip_name.Text;
            selected.content = tip_description.Text;
            tips = (List<Tip>)tips_list.ItemsSource;
            BimBim.Write(tips, date.ToString("D"));
            reload();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Tip selected = tips_list.SelectedItem as Tip;
            tips.Remove(selected);
            BimBim.Write(tips, Convert.ToDateTime(tip_date.Text).ToString("D"));
            reload();
        }
        private void tips_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Tip selected = tips_list.SelectedItem as Tip;
            if (selected != null)
            {
                tip_name.Text = selected.name;
                tip_description.Text = selected.content;
            }
            else
            {
                tip_name.Text = "";
                tip_description.Text = "";
            }          
        }

        private void tip_date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            reload();
        }

        private void reload()
        {
            try
            {
                tips = BimBim.Read<List<Tip>>(Convert.ToDateTime(tip_date.Text).ToString("D"));
            }
            catch 
            {
                tips = new List<Tip>();
            }
            tips_list.ItemsSource = tips;
        }
    }
}
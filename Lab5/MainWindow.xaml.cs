using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace Lab5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string connectionString = "server=localhost;database=superheros;uid=root;pwd=root";

        MySqlConnection conn = new MySqlConnection(connectionString);

        public MainWindow()
        {
            InitializeComponent();

            


        }

        

        private void displayPowers_Click(object sender, RoutedEventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("select * from powers", conn);
            conn.Open();

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            conn.Close();

            dtGrid.DataContext = dt;
        }

        private void displayHeroes_Click(object sender, RoutedEventArgs e)
        {
            
            MySqlCommand cmd = new MySqlCommand("select * from superheros", conn);

            conn.Open();

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            conn.Close();

            dtGrid.DataContext = dt;
        }

        
    }
}

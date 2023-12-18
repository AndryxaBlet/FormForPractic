using Microsoft.SqlServer.Server;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace FormForPractic
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        { 
            string connectionString= @"data source=REVISION-PC;initial catalog=practicir311;integrated security=True";
          
          
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                 SqlCommand command = new SqlCommand();
                command.CommandText="select * from users where login = @log and password = @pass";
                command.Connection = connection;
                command.Parameters.AddWithValue("@pass", passb.Password.ToString());
                command.Parameters.AddWithValue("@log", login.Text.ToString());
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {

                        GridWindow frm = new GridWindow();
                        frm.Show();
                        Close();
                    }
                    else
                    {
                        var result = MessageBox.Show("Данные не верны!\nПопробовать ещё раз?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (result == MessageBoxResult.No)
                        {
                            this.Close();
                        }
                    }
                }
            }

          
           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

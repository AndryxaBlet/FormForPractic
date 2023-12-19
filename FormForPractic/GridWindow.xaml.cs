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
using System.Data.SqlClient;
using System.Data;


namespace FormForPractic
{
    /// <summary>
    /// Логика взаимодействия для GridWindow.xaml
    /// </summary>
    public partial class GridWindow : Window
    {

        public GridWindow(string tmp)
        {
            InitializeComponent();
            LoadData(tmp);
            log = tmp;

        }
        public string log;
        private void plus_Click(object sender, RoutedEventArgs e)
        {
            AddForm form = new AddForm();
            form.Owner = this;
            form.ShowDialog();
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {

            LoadData(log);
            //var result = MessageBox.Show("Удалить запись под номером ... ?", "Подтверждение", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            //if (result == MessageBoxResult.OK)
            //{
            //    MessageBox.Show("Успешно!", "Запись удалена", MessageBoxButton.OK, MessageBoxImage.Information);
            //}

        }
        private void LoadData(string LOGIN)
        {
            string connectionString = @"data source=1-510-cls-10;initial catalog=Practic1101;user id=sa;password=123";

            string query = "SELECT products_users.id,products.product_name,count,price,sum,category.category_name FROM products_users inner join products on products_users.product_name=products.id inner join category on category.id_cat=products.category_name inner join users on users.id=products_users.user_id WHERE users.login=@LOGIN";

           
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                myConnection.Open();
                using (SqlCommand command = new SqlCommand(query, myConnection))
                {
                    command.Parameters.AddWithValue("@LOGIN", LOGIN);
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                    DGrid.ItemsSource = dt.DefaultView;
                }
                myConnection.Close();
            }
           
        }
    }
}

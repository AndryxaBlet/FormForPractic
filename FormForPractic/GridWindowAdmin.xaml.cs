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
    public partial class GridWindowAdmin : Window
    {

        public GridWindowAdmin()
        {
            InitializeComponent();
            LoadData();


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

            LoadData();
            //var result = MessageBox.Show("Удалить запись под номером ... ?", "Подтверждение", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            //if (result == MessageBoxResult.OK)
            //{
            //    MessageBox.Show("Успешно!", "Запись удалена", MessageBoxButton.OK, MessageBoxImage.Information);
            //}

        }
        string connectionString = @"data source=1-510-cls-10;initial catalog=Practic1101;user id=sa;password=123";
        private void LoadData()
        {
            

            string query = "SELECT  family_name+' '+first_name+' '+patronymic as ФИО,products_users.id,date,products.product_name,count,price,sum,category.category_name FROM products_users inner join products on products_users.product_name=products.id inner join category on category.id_cat=products.category_name inner join users on users.id=products_users.user_id";


            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                myConnection.Open();
                using (SqlCommand command = new SqlCommand(query, myConnection))
                {

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                    DGrid.ItemsSource = dt.DefaultView;
                }
                myConnection.Close();
            }

        }

        private void vibor_Click(object sender, RoutedEventArgs e)
        {
           
            if (date1.Text.Length != 0 && date2.Text.Length != 0)
            {
            
                    string query = "SELECT  family_name+' '+first_name+' '+patronymic as ФИО,products_users.id,date,products.product_name,count,price,sum,category.category_name FROM products_users inner join products on products_users.product_name=products.id inner join category on category.id_cat=products.category_name inner join users on users.id=products_users.user_id where date>=@do and date<=@posle";


                    using (SqlConnection myConnection = new SqlConnection(connectionString))
                    {
                        myConnection.Open();
                        using (SqlCommand command = new SqlCommand(query, myConnection))
                        {
                            command.Parameters.AddWithValue("@id", IDUSER.Text.ToString());
                            command.Parameters.AddWithValue("@do", date1.Text.ToString());
                            command.Parameters.AddWithValue("@posle", date2.Text.ToString());
                            DataTable dt = new DataTable();
                            SqlDataAdapter da = new SqlDataAdapter(command);
                            da.Fill(dt);
                            DGrid.ItemsSource = dt.DefaultView;
                        }
                        myConnection.Close();
                    }
               
            }
        }

        private void IDUSER_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IDUSER.Text.Length != 0)
            {
                string query = "SELECT family_name+' '+first_name+' '+patronymic as ФИО,products_users.id,date,products.product_name,count,price,sum,category.category_name FROM products_users inner join products on products_users.product_name=products.id inner join category on category.id_cat=products.category_name inner join users on users.id=products_users.user_id where family_name+' '+first_name+' '+patronymic like '%@fio%'";
                using (SqlConnection myConnection = new SqlConnection(connectionString))
                {
                    myConnection.Open();
                    using (SqlCommand command = new SqlCommand(query, myConnection))
                    {
                        command.Parameters.AddWithValue("@fio", IDUSER.Text);
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(dt);
                        DGrid.ItemsSource = dt.DefaultView;
                    }
                    myConnection.Close();
                }
            }
            else LoadData();
        }
    }
}

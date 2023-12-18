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


namespace FormForPractic
{
    /// <summary>
    /// Логика взаимодействия для GridWindow.xaml
    /// </summary>
    public partial class GridWindow : Window
    {
        public GridWindow()
        {
            InitializeComponent();
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            AddForm form = new AddForm();
            form.Owner = this;
            form.ShowDialog();
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Удалить запись под номером ... ?", "Подтверждение", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if(result == MessageBoxResult.OK) {
                MessageBox.Show("Успешно!", "Запись удалена", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        
        }
    }
}

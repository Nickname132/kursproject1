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

namespace termins
{
    /// <summary>
    /// Логика взаимодействия для TermsPage.xaml
    /// </summary>
    public partial class TermsPage : Page
    {
      
        public TermsPage()
        {
            InitializeComponent();
            var currentTerm = termsEntities1.GetContext().term.ToList();
            DGridterms.ItemsSource = termsEntities1.GetContext().term.ToList();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manage.MainFrame.Navigate(new AddEditPage(null));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manage.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as term));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manage.MainFrame.Navigate(new AddEditPage(null));
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var termsForRemoving = DGridterms.SelectedItems.Cast<term>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующее {termsForRemoving.Count()}  терминов?", "Внимание ",
            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            { 
                try
                {
                    termsEntities1.GetContext().term.RemoveRange(termsForRemoving);
                    termsEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные были удалены !");

                    DGridterms.ItemsSource = termsEntities1.GetContext().term.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
                

        private void DGridterms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
       
        {
                termsEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridterms.ItemsSource = termsEntities1.GetContext().term.ToList();

        }

        }
   
    }
}

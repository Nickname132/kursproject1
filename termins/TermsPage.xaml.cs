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

            var scienceTypes = termsEntities2.GetContext().sciences.ToList();
            scienceTypes.Insert(0, new science { name = "Все типы" }); 

            ComboType.ItemsSource = scienceTypes;
            ComboType.SelectedIndex = 0;

            var sourceTypes = termsEntities2.GetContext().sources.ToList();
            sourceTypes.Insert(0, new source { source1 = "Все ресурсы" });

            ComboSource.ItemsSource = sourceTypes;
            ComboSource.SelectedIndex = 0;


            Updateterms();
            

        }

        private void Updateterms()
        {
            List<term> currentTerms = termsEntities2.GetContext().terms.ToList();
            //TBoxSearch
            currentTerms = currentTerms.Where(p => p.name.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            if (ComboType.SelectedIndex > 0)
                currentTerms = currentTerms.Where(p => p.science == ComboType.SelectedItem as science).ToList();
            if (ComboSource.SelectedIndex > 0)
                currentTerms = currentTerms.Where(p => p.source == ComboSource.SelectedItem as source).ToList();

            DGridterms.ItemsSource = currentTerms;

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
                    termsEntities2.GetContext().terms.RemoveRange(termsForRemoving);
                    termsEntities2.GetContext().SaveChanges();
                    MessageBox.Show("Данные были удалены !");

                    DGridterms.ItemsSource = termsEntities2.GetContext().terms.ToList();
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
                termsEntities2.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridterms.ItemsSource = termsEntities2.GetContext().terms.ToList();

        }




        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Updateterms();


        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Updateterms();
        }
       
    }
}

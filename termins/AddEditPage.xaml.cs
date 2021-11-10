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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private term _currentTerm = new term();

        public AddEditPage(term selectedTerm)
        {
            InitializeComponent();

            if (selectedTerm != null)
                _currentTerm = selectedTerm;

            DataContext = _currentTerm;

            ComboScience.ItemsSource = termsEntities2.GetContext().sciences.ToList();
            ComboSec.ItemsSource = termsEntities2.GetContext().secs.ToList();
            ComboSource.ItemsSource = termsEntities2.GetContext().sources.ToList();
            ComboEra.ItemsSource = termsEntities2.GetContext().eras.ToList();
            ComboCen.ItemsSource = termsEntities2.GetContext().centuries.ToList();
        }

        private void BtnSave_Click(object sender,RoutedEventArgs e)
        {

            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentTerm.name))
                errors.AppendLine("Укажите название термина");

            if (string.IsNullOrWhiteSpace(_currentTerm.url))
                errors.AppendLine("Укажите определение ссылку");

            if (string.IsNullOrWhiteSpace(_currentTerm.meaning))
                errors.AppendLine("Укажите определение термина");

            if (_currentTerm.century == null)
                errors.AppendLine("Выберите век");
            if (_currentTerm.source == null)
                errors.AppendLine("Выберите ресурс");
            if (_currentTerm.era == null)
                errors.AppendLine("Выберите эру");
            if (_currentTerm.sec == null)
                errors.AppendLine("Выберите раздел");
            if (_currentTerm.science == null)
                errors.AppendLine("Выберите науку");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentTerm.id == 0)
                termsEntities2.GetContext().terms.Add(_currentTerm);
              
            try
            {
                termsEntities2.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
             private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
        }

      
    }
}

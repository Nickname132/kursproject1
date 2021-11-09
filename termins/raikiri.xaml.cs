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
    /// Логика взаимодействия для raikiri.xaml
    /// </summary>
    public partial class raikiri : Page
    {
        public raikiri()
        {
            InitializeComponent();
            var currentTerms = termsEntities1.GetContext().term.ToList();
            LViewTerm.ItemsSource = currentTerms;
        }
    }
}

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

namespace FrenchBookApp
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public int SelectedSpeechRate { get; set; }
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void okBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NormalRB.IsChecked == true)
            {
                this.SelectedSpeechRate = 0;
            }
            else if (SlowRB.IsChecked == true)
            {
                this.SelectedSpeechRate = -3;
            }
            else if (SlowerRB.IsChecked == true)
            {
                this.SelectedSpeechRate = -6;
            }
            this.DialogResult = true;
            Close();
        }
    }
}

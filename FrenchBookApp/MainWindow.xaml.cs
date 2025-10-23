using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FrenchBookApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new FrenchBookContext()) { 
                List<Topic> Topics = db.Topics.ToList<Topic>();
                foreach (var topic in Topics) {
                    Console.WriteLine(topic.TopicName);

                    Border card = new Border
                    {
                        Width = 250,
                        Height = 120,
                        CornerRadius = new CornerRadius(10),
                        Background = Brushes.White,
                        BorderBrush = Brushes.Gray,
                        BorderThickness = new Thickness(1),
                        Margin = new Thickness(10),
                        Padding = new Thickness(10) 
                    };

                    TextBlock title = new TextBlock
                    {
                        Text = topic.TopicName,
                        FontSize = 16,
                        FontWeight = FontWeights.Bold,
                        TextAlignment = TextAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };

                    // adding mouse hover changes
                    card.MouseEnter += (s, e) =>
                    {
                        card.Background = new SolidColorBrush(Color.FromRgb(230, 240, 255)); // light blue
                        card.BorderBrush = Brushes.SteelBlue;
                    };

                    card.MouseLeave += (s, e) =>
                    {
                        card.Background = Brushes.White;
                        card.BorderBrush = Brushes.Gray;
                    };

                    card.Child = title;
                    TopicsPanel.Children.Add(card);

                    // click event on each Topic card
                    card.MouseLeftButtonDown += (s, e) =>
                    {
                        MessageBox.Show("Opening " + topic.TopicName);
                    };
                }
            }
        }

        private void AddTopic_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
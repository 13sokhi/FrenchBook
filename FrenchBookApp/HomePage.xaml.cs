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

namespace FrenchBookApp
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        Frame? MainFrame;

        public HomePage(Frame MainFrame)
        {
            this.MainFrame = MainFrame;
            InitializeComponent();
        }

        private void AddTopic_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new FrenchBookContext())
            {
                Topic newTopic = new Topic();
                newTopic.TopicName = NewTopicTextBox.Text;
                db.Topics.Add(newTopic);
                db.SaveChanges();
                LoadTopics();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadTopics();
        }

        public void LoadTopics()
        {
            using (var db = new FrenchBookContext())
            {
                TopicsPanel.Children.Clear();

                List<Topic> topics = db.Topics.ToList<Topic>();

                foreach (var topic in topics)
                {
                    Console.WriteLine(topic.TopicName);

                    Border card = new Border();
                    card.Width = 250;
                    card.Height = 120;
                    card.CornerRadius = new CornerRadius(10);
                    card.Background = Brushes.White;
                    card.BorderBrush = Brushes.Gray;
                    card.BorderThickness = new Thickness(1);
                    card.Margin = new Thickness(10);
                    card.Padding = new Thickness(10);

                    TextBlock title = new TextBlock();
                    title.Text = topic.TopicName;
                    title.FontSize = 16;
                    title.FontWeight = FontWeights.Bold;
                    title.TextAlignment = TextAlignment.Center;
                    title.VerticalAlignment = VerticalAlignment.Center;


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
                        MainFrame.Navigate(new TopicPage(topic));
                    };
                }
            }
        }
    }
}

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
    /// Interaction logic for TopicPage.xaml
    /// </summary>
    public partial class TopicPage : Page
    {
        private Topic Topic { get; set; }

        public TopicPage(Topic Topic)
        {
            this.Topic = Topic;
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void DeleteTopic_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new FrenchBookContext())
            {
                db.Topics.Remove(this.Topic);
                int response = (int)MessageBox.Show("Are you sure you want to delete Topic - " + Topic.TopicName + " ?", "Caution!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                
                if (response == 6)
                {
                    var sentencesToDelete = db.Sentences.Where(s => s.TopicId == this.Topic.TopicId);
                    db.Sentences.RemoveRange(sentencesToDelete);

                    var paragraphsToDelete = db.Paragraphs.Where(p => p.TopicId == this.Topic.TopicId);
                    db.Paragraphs.RemoveRange(paragraphsToDelete);

                    db.Topics.Remove(this.Topic);

                    db.SaveChanges();
                    NavigationService.GoBack();
                }
            }
        }

        public void Delete_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            int sentenceId = (int)button.Tag;
            //Console.WriteLine("ID - " + sentenceId);
            using (var db = new FrenchBookContext())
            {
                var sentenceToDelete = db.Sentences.Where(s => s.SentenceId == sentenceId);
                db.Sentences.RemoveRange(sentenceToDelete);
                db.SaveChanges();
                LoadSentences();
                LoadParagraphs();
            }
        }

        private void PlayAudio_Click(object sender, RoutedEventArgs e)
        {
            var senderButton = sender as Button;
            SpeechTranslator.Speak(senderButton?.Tag.ToString());
        }

        private async void TranslateButton_Click(object sender, RoutedEventArgs e)
        {
            string translatedText = await Translator.Translate(EnglishInput.Text, "en", "fr");
            FrenchInput.Text = translatedText;
        }

        private void Save_Translation_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new FrenchBookContext())
            {
                Sentence newSentence = new Sentence();
                newSentence.EnglishText = EnglishInput.Text;
                newSentence.FrenchText = FrenchInput.Text;
                newSentence.TopicId = this.Topic.TopicId;

                db.Sentences.Add(newSentence);
                db.SaveChanges();
                LoadSentences();
                LoadParagraphs();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            TopicNameText.Text = Topic.TopicName;
            LoadSentences();
            LoadParagraphs();
        }

        public void LoadSentences()
        {
            using (var db = new FrenchBookContext())
            {
                SentencesPanel.Children.Clear();
                List<Sentence> sentences = db.Sentences.ToList<Sentence>();

                foreach (var sentence in sentences)
                {
                    if (sentence.TopicId == this.Topic.TopicId)
                    {
                        Console.WriteLine(sentence.EnglishText);

                        Border translationBlock = new Border();
                        translationBlock.Padding = new Thickness(15);
                        translationBlock.Background = Brushes.White;
                        translationBlock.BorderBrush = Brushes.LightGray;
                        translationBlock.BorderThickness = new Thickness(0, 0, 0, 1);

                        StackPanel translationContent = new StackPanel();

                        TextBlock englishText = new TextBlock();
                        englishText.Text = sentence.EnglishText;
                        englishText.FontSize = 16;
                        englishText.FontWeight = FontWeights.SemiBold;

                        TextBlock frenchText = new TextBlock();
                        frenchText.Text = sentence.FrenchText;
                        frenchText.FontSize = 16;
                        frenchText.Margin = new Thickness(0, 5, 0, 0);

                        StackPanel buttonPanel = new StackPanel();
                        buttonPanel.Orientation = Orientation.Horizontal;

                        Button listenButton = new Button();
                        listenButton.Content = "🔊 Listen";
                        listenButton.Width = 100;
                        listenButton.Height = 30;
                        listenButton.HorizontalAlignment = HorizontalAlignment.Left;
                        listenButton.Margin = new Thickness(0, 10, 20, 0);
                        listenButton.Tag = sentence.FrenchText;
                        listenButton.Click += PlayAudio_Click;

                        Button deleteButton = new Button();
                        deleteButton.Content = "Delete";
                        deleteButton.Width = 100;
                        deleteButton.Height = 30;
                        deleteButton.HorizontalAlignment = HorizontalAlignment.Left;
                        deleteButton.Margin = new Thickness(0, 10, 0, 0);
                        deleteButton.Tag = sentence.SentenceId;
                        deleteButton.Click += Delete_Click;


                        buttonPanel.Children.Add(listenButton);
                        buttonPanel.Children.Add(deleteButton);
                        translationContent.Children.Add(englishText);
                        translationContent.Children.Add(frenchText);
                        translationContent.Children.Add(buttonPanel);
                        translationBlock.Child = translationContent;

                        SentencesPanel.Children.Add(translationBlock);
                    }
                }
            }
        }

        public void LoadParagraphs()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

namespace Evernote_Clone.View
{
    /// <summary>
    /// Interaction logic for WNotes.xaml
    /// </summary>
    public partial class WNotes : Window
    {
        public WNotes()
        {
            InitializeComponent();
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private async void BtnSpeech_OnClick(object sender, RoutedEventArgs e)
        {
            string region = "westeurope";
            string key = "cdc0886a26494b6ea32cb41cc17165c5";
            var speechConfig = SpeechConfig.FromSubscription(key, region);


            using (var audioConfig = AudioConfig.FromDefaultMicrophoneInput())
            {
                using (var recognizer = new SpeechRecognizer(speechConfig, audioConfig))
                {
                    var result = await recognizer.RecognizeOnceAsync();
                    RichTextContent.Document.Blocks.Add(new Paragraph(new Run(result.Text)));
                }
            }
        }

        private void RichTextContent_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            int amountOfChars = (new TextRange(RichTextContent.Document.ContentStart, RichTextContent.Document.ContentEnd)).Text.Length;
            TxtStatus.Text = $"Document Length : {amountOfChars} characters";
        }

        private void BtnBold_OnClick(object sender, RoutedEventArgs e)
        {
            bool isButtonChecked = (sender as ToggleButton).IsChecked ?? false;
            if (isButtonChecked)
            {
                //var textToBold = new TextRange(RichTextContent.Selection.Start, RichTextContent.Selection.End);
                RichTextContent.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Bold);
            }
            else
            {
                RichTextContent.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Normal); 
            }
        }

        private void RichTextContent_OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            var selectedWeight = RichTextContent.Selection.GetPropertyValue(FontWeightProperty);
            var selectedStyle = RichTextContent.Selection.GetPropertyValue(FontStyleProperty);
            //TODO: Underlining process
            //var selectedStyle = RichTextContent.Selection.GetPropertyValue(DEC);
            BtnBold.IsChecked = (selectedWeight != DependencyProperty.UnsetValue) && (selectedWeight.Equals(FontWeights.Bold));
            BtnItalic.IsChecked = (selectedWeight != DependencyProperty.UnsetValue) && (selectedStyle.Equals(FontStyles.Italic));
            //TODO: Underlining Event Handler
        }

        private void BtnItalic_OnClick(object sender, RoutedEventArgs e)
        {
            bool isButtonChecked = (sender as ToggleButton).IsChecked ?? false;
            if (isButtonChecked)
            {
                RichTextContent.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Italic);
            }
            else
            {
                RichTextContent.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Normal); 
            }
        }

        private void BtnUnderline_OnClick(object sender, RoutedEventArgs e)
        {
            bool isButtonChecked = (sender as ToggleButton).IsChecked ?? false;
            if (isButtonChecked)
            {
                RichTextContent.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
            }
            else
            {
                RichTextContent.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Baseline); 
            }
        }
    }
}

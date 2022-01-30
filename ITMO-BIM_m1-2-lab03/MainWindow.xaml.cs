using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

//Доработать проект текстового редактора из задания 9, заменив выбор шрифта и размера привязками данных.

namespace ITMO_BIM_m1_2_lab03
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

        //private void FontNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    string fontName = (sender as ComboBox).SelectedValue.ToString();
        //    if (textBox != null)
        //        textBox.FontFamily = new FontFamily(fontName);
        //}

        //private void FontSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    string fontSize = (sender as ComboBox).SelectedValue.ToString();
        //    if (textBox != null)
        //        textBox.FontSize = Convert.ToInt32(fontSize);
        //}

        private void BoldButton_Click(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                if (textBox.FontWeight == FontWeights.Bold)
                    textBox.FontWeight = FontWeights.Normal;
                else
                    textBox.FontWeight = FontWeights.Bold;
            }
        }

        private void ItalicButton_Click(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                if (textBox.FontStyle == FontStyles.Italic)
                    textBox.FontStyle = FontStyles.Normal;
                else
                    textBox.FontStyle = FontStyles.Italic;
            }        
        }

        private void UnderlineButton_Click(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                if (textBox.TextDecorations == TextDecorations.Underline)
                {
                    textBox.TextDecorations = null;
                }
                else
                    textBox.TextDecorations = TextDecorations.Underline;
            }
        }

        private void BlackRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
                textBox.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void RedRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
                textBox.Foreground = new SolidColorBrush(Colors.Red);
        }

        private void FileOpenCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = ("Текстовые документы|*.txt|Все файлы|*.*");
            if (ofd.ShowDialog() == true)
                textBox.Text = File.ReadAllText(ofd.FileName);
        }

        private void FileSaveCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = ("Текстовые документы|*.txt|Все файлы|*.*");
            if (sfd.ShowDialog() == true)
                File.WriteAllText(sfd.FileName, textBox.Text);
        }

        private void ExitCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void DarkThemeCheckBox_Click(object sender, RoutedEventArgs e)
        {
            Uri uri;
            //bool isDark = (bool)(sender as CheckBox).IsChecked;
            if ((bool)(sender as CheckBox).IsChecked)
                uri = new Uri("DarkTheme.xaml", UriKind.Relative);
            else
                uri = new Uri("LightTheme.xaml",UriKind.Relative);
            ResourceDictionary themeRD = Application.LoadComponent(uri) as ResourceDictionary;
            //Application.Current.Resources.Clear(); // сбрасывает словари шрифтов ??
            Application.Current.Resources.MergedDictionaries.Add(themeRD);
        }
    }
}

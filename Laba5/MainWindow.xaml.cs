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
using System.IO;

namespace Laba5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> words = new List<string>();
        bool flag = true;
        string word = null;
        char[] cha;
        int death = 0;
        ImageSource[] image = new ImageSource[6];       
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Check_Click(object sender, RoutedEventArgs e)
        {
            //char[] c = Letters1.Text.ToCharArray;
            if (Input.Text.Count() != 0)
            {
                char[] c = new char[Letters1.Text.Count()];
                var s = Letters1.Text.ToCharArray();
                for (int i = 0; i < Letters1.Text.Count(); i++)
                {
                    c[i] = s[i];
                }
                char ch = char.Parse(Input.Text);
                string h = null;
                bool win = true;
                bool det = false;
                for (int i = 0; i < cha.Length; i++)
                {
                    if (cha[i] == ch)
                    {
                        c[i] = ch;

                        det = true;
                    }
                }
                foreach (var t in c)
                {
                    if (t == '_')
                        win = false;
                    h += t.ToString();
                }
                Letters1.Text = h;
                if (win)
                {
                    MessageBox.Show("You win!!!");
                }
                if (!det)
                {
                    death++;
                    Garbage.AppendText(" " + ch.ToString());
                    Image(death);
                    foreach (var t in image)
                    {
                        if (t != null)
                            OutputImage.Source = t;
                    }

                }
                if (death == 5)
                {
                    MessageBox.Show("Game over :(");                  
                }
                Input.Clear();
                
            }
        }      
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if(Letters1.Text!=null)
            {
                Letters1.Text = null;
            
            }
            if (Le.Text != null)
                Le.Text = null;
            if (Garbage.Text != null)
                Garbage.Text = null;
            OutputImage.Source = null;
            if (phonesList.Text == "Animals")
            {
                InputText("Animals.txt");
            }
            else if (phonesList.Text == "Names")
            {
                InputText("Names.txt");
            }
            else if (phonesList.Text == "Themes of LP")
            {
                InputText("Themes.txt");
            }
            else
            {
                MessageBox.Show("Choose theme");
                flag = false;
            }
            if (flag)
            {
                Random r = new Random();
                int n = r.Next(0, words.Count);
               
                word= words[n];
                Le.AppendText(word.Length.ToString());
                for (int i = 0; i < word.Length; i++)
                {
                    Letters1.AppendText("_");
                }
                cha = word.ToCharArray();
            }
            else MessageBox.Show("Choose theme");  
           
        }      
        private void Themes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }
        private void Input_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        public void InputText(string name)
        {
            string text;
            using (var sr = new StreamReader(name))
            {
                text = sr.ReadToEnd();
            }
            var separators = new char[] { ' ', '\r', '\n' };
            var word = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            words.Clear();
            for (int i = 0; i < word.Length; i++)
            {
                words.Add(word[i]);
            }
            flag = true;
        }
        public void Image(int a)
        {
            if(a==1)
            { 
                image[0] = new ImageSourceConverter().ConvertFromString("1.png") as ImageSource;
            }
            else if (a == 2)
            {
                image[1] = new ImageSourceConverter().ConvertFromString("2.png") as ImageSource;
            }
            else if (a == 3)
            {
                image[2] = new ImageSourceConverter().ConvertFromString("3.png") as ImageSource;
            }
            else if (a == 4)
            {
                image[3] = new ImageSourceConverter().ConvertFromString("4.png") as ImageSource;
            }
            else if (a == 5)
            {
                image[4] = new ImageSourceConverter().ConvertFromString("5.png") as ImageSource;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void reference_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вам нужно выбрать тему, для слов, и нажать старт. Далее вносить буквы, которые, как вам кажутся, есть в этом слове. У вас 5 попыток, прежде чем вас повесят :( Удачи!");
        }

        private void phonesList_SelectionChanged()
        {

        }
    }
}

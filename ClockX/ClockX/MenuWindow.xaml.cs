using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace ClockX
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {

        public static bool ok_pressed,changed = false;
        public static int mth, d, y, h, min, sec;

        private void comboBox_Copy1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox.SelectedItem.ToString() == "2")
            {
                int year;
                Int32.TryParse(comboBox_Copy1.SelectedValue.ToString(), out year);

                if (comboBox.SelectedItem.ToString() == "2" && year % 4 == 0)
                {
                    for (int i = 1; i <= 29; i++)
                    {
                        comboBox_Copy.Items.Add(i);
                    }
                }
                else
                {
                    for (int i = 1; i <= 28; i++)
                    {
                        comboBox_Copy.Items.Add(i);
                    }
                }

            }
        }

        public static string pp;

        public MenuWindow()
        {
            InitializeComponent();

            this.ShowInTaskbar = false;
            this.ShowActivated = true;

            DateTime dt = DateTime.Now;
            string s = dt.ToString("tt", CultureInfo.InvariantCulture);
            int hour;
            int mints;
            int secs;
            Int32.TryParse(dt.ToString("%h"),out hour);
            Int32.TryParse(dt.ToString("%m"), out mints);
            Int32.TryParse(dt.ToString("%s"), out secs);

            //za min i sat double
            comboBox.SelectedValue = dt.Month;
            comboBox_Copy.SelectedValue = dt.Day;
            comboBox_Copy1.SelectedValue = dt.Year;
            comboBox_Copy2.SelectedValue = hour;
            comboBox_Copy3.SelectedValue = mints;
            comboBox_Copy4.SelectedValue = secs;
            comboBox_Copy5.SelectedValue = s;

            for (int i = 1; i <= 12; i++)
            {
                
                comboBox.Items.Add(i);

            }

            if (comboBox.SelectedItem.ToString() == "2")
            {
                for (int i = 1; i <= 28; i++)
                {
                 
                    comboBox_Copy.Items.Add(i);
                }
            }
            else if(comboBox.SelectedItem.ToString() == "2" && dt.Year%4==0)
            {
                for (int i = 1; i <= 29; i++)
                {
                    comboBox_Copy.SelectedValue = dt.Day;
                    comboBox_Copy.Items.Add(i);
                }
            }
            else
            {
                for (int i = 1; i <= 31; i++)
                {
                    comboBox_Copy.SelectedValue = dt.Day;
                    comboBox_Copy.Items.Add(i);
                }
            }

         

            for (int i = 1970; i <= 2025; i++)
            {
               
                comboBox_Copy1.Items.Add(i);
            }

            for (int i = 1; i <= 12; i++)
            {
                comboBox_Copy2.Items.Add(i);
            }

            for (int i = 0; i <= 59; i++)
            {
                comboBox_Copy3.Items.Add(i);
            }

            for (int i = 0; i <= 59; i++)
            {
                comboBox_Copy4.Items.Add(i);
            }

            comboBox_Copy5.Items.Add("AM");
            comboBox_Copy5.Items.Add("PM");
        }

        

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox.SelectedItem.ToString() == "2")
            {
                int year;
                Int32.TryParse(comboBox_Copy1.SelectedValue.ToString(), out year);

                if (comboBox.SelectedItem.ToString() == "2" &&  year% 4 == 0)
                {
                    for (int i = 1; i <= 29; i++)
                    {
                        comboBox_Copy.Items.Add(i);
                    }
                }
                else
                {
                    for (int i = 1; i <= 28; i++)
                    {
                        comboBox_Copy.Items.Add(i);
                    }
                }
              
            }
            else
            {
                for (int i = 1; i <= 31; i++)
                {
                    comboBox_Copy.Items.Add(i);
                }
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            changed = true;
            ok_pressed = true;
            //sec = 00;
            Int32.TryParse(comboBox.SelectedValue.ToString(), out mth);
            Int32.TryParse(comboBox_Copy.SelectedValue.ToString(), out d);
            Int32.TryParse(comboBox_Copy1.SelectedValue.ToString(), out y);
            Int32.TryParse(comboBox_Copy2.SelectedValue.ToString(), out h);
            Int32.TryParse(comboBox_Copy3.SelectedValue.ToString(), out min);
            Int32.TryParse(comboBox_Copy4.SelectedValue.ToString(), out sec);
            pp = comboBox_Copy5.SelectedValue.ToString();  
            this.Close();

        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

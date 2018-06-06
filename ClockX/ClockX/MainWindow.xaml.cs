using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace ClockX
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NotifyIcon notifyIcon = new NotifyIcon();
        System.Timers.Timer timer = new System.Timers.Timer(1000);
        int i = 0;
        int j;
        int y = 2018;
        int k, d, m = 0;
        bool changed = false;
        bool check = false;
        DateTime current = new DateTime();
        DateTime curentTime = new DateTime();
        

        public MainWindow()
        {
            InitializeComponent();

            this.ShowInTaskbar = false;
           // this.ShowActivated = true;

            this.notifyIcon.Visible = true;

            this.notifyIcon.Icon = Properties.Resources.clock;
            string dateString = DateTime.Now.Date.ToString();
            DateTime dateValue = DateTime.Parse(dateString, CultureInfo.InvariantCulture);
            this.notifyIcon.Text = dateValue.ToString("dddd") + ", " + dateValue.ToString("MMMM") + " " + DateTime.Now.Day.ToString() +
                "," + DateTime.Now.Year + "\n" + DateTime.Now.ToString("%h") + ":" + DateTime.Now.Minute.ToString("d2") + " " + DateTime.Now.ToString("tt", CultureInfo.InvariantCulture);
            this.notifyIcon.MouseDown += NotifyIcon_Click;
          

            secondHand.Angle = DateTime.Now.Second * 6;
            minuteHand.Angle = DateTime.Now.Minute * 6;
            hourHand.Angle = (DateTime.Now.Hour * 30) + (DateTime.Now.Minute * 0.5);


            if (MenuWindow.ok_pressed == true)
            {
                label.Content = "";
                label.Content = MenuWindow.pp;

                christianityCalendar.Content = "";
                christianityCalendar.Content = DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year;

                timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
                timer.Enabled = true;
            }
            else
            {
                label.Content = "";
                label.Content = DateTime.Now.ToString("tt", CultureInfo.InvariantCulture);
                christianityCalendar.Content = "";
                christianityCalendar.Content = DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year;
                

                timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
                timer.Enabled = true;
            }
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            this.Activate();
            System.Windows.Controls.ContextMenu m = new System.Windows.Controls.ContextMenu();

            System.Windows.Controls.MenuItem item = new System.Windows.Controls.MenuItem();
            item.Header = "Configure...";
            m.IsOpen = true;
            m.Items.Add(item);
            System.Windows.Controls.MenuItem item1 = new System.Windows.Controls.MenuItem();
            item1.Header = "Exit";
            m.Items.Add(item1);
            item1.Click += Item1_Click;
            item.Click += Item_Click;

        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            
            if (MenuWindow.ok_pressed == true)
            {

                this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>
                {
                    if (check == false)
                    {
                       
                        i = MenuWindow.sec;
                        j = MenuWindow.min;
                        k = MenuWindow.h;
                        m = MenuWindow.mth;
                        d = MenuWindow.d;
                        y = MenuWindow.y;

                        i++;

                        if (i == 60)
                        {
                            j++;
                            i = 00;
                        }
                        if (j == 60)
                        {
                            k++;
                            j = 00;
                        }
                        if (k == 12)
                        {
                            d++;
                            k = 01;
                        }
                        if(d==31)
                        {
                            m++;
                            d = 01;
                        }
                        if(m==12)
                        {
                            y++;
                        }
                       

                        DateTime dateToUse = DateTime.Now;
                        DateTime timetUse = new DateTime(y, m, d, k, j, i);
                        DateTime datewith = dateToUse.Date.Add(timetUse.TimeOfDay);

                        DateTime currenct = datewith.AddSeconds(1);

                        current = new DateTime(currenct.Year, currenct.Month, currenct.Day, currenct.Hour, currenct.Minute, currenct.Second);


                        secondHand.Angle = currenct.Second * 6;
                        minuteHand.Angle = currenct.Minute * 6;
                        hourHand.Angle = (currenct.Hour * 30) + (currenct.Minute * 0.5);
                        christianityCalendar.Content = "";
                        christianityCalendar.Content = MenuWindow.mth + "/" + MenuWindow.d + "/" + MenuWindow.y;
                        label.Content = "";
                        label.Content = MenuWindow.pp;
                        check = true;
                        changed = true;

                    }
                    else
                    {
                        i = current.Second;
                        j = current.Minute;
                        k = current.Hour;
                        d = current.Day;
                        m = current.Month;

                        DateTime dateToUse = DateTime.Now;
                        DateTime datewith = dateToUse.Date.Add(current.TimeOfDay);

                        DateTime currenct = datewith.AddSeconds(1);
                        current = new DateTime(currenct.Year, currenct.Month, currenct.Day, currenct.Hour, currenct.Minute, currenct.Second);

                        curentTime =current;
                       

                        secondHand.Angle = currenct.Second * 6;
                        minuteHand.Angle = currenct.Minute * 6;
                        hourHand.Angle = (currenct.Hour * 30) + (currenct.Minute * 0.5);
                        christianityCalendar.Content = "";
                        christianityCalendar.Content = MenuWindow.mth + "/" + MenuWindow.d + "/" + MenuWindow.y;
                        label.Content = "";
                        label.Content = MenuWindow.pp;

                        i++;

                        if (i == 60)
                        {
                            j++;
                            i = 00;
                        }
                        if (j == 60)
                        {
                            k++;
                            j = 00;
                        }
                        if (k == 12)
                        {
                            k = 01;
                        }
                        if (d == 31)
                        {
                            m++;
                            d = 01;
                        }
                        if (m == 12)
                        {
                            y++;
                        }

                    }

                }));
            }   
            else
            {
            this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>
                {
                    secondHand.Angle = DateTime.Now.Second * 6;
                    minuteHand.Angle = DateTime.Now.Minute * 6;
                    hourHand.Angle = (DateTime.Now.Hour * 30) + (DateTime.Now.Minute * 0.5);
                  
                }));
            }


        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Grid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

            System.Windows.Controls.ContextMenu m = new System.Windows.Controls.ContextMenu();

            System.Windows.Controls.MenuItem item = new System.Windows.Controls.MenuItem();
            item.Header = "Configure...";
            m.IsOpen = true;
            m.Items.Add(item);
            System.Windows.Controls.MenuItem item1 = new System.Windows.Controls.MenuItem();
            item1.Header = "Exit";
            m.Items.Add(item1);
            item1.Click += Item1_Click;
            item.Click += Item_Click;
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            

            if (this.WindowState == WindowState.Normal)
            {

                if (changed == true)
                {
                    DateTime dt = curentTime;
                    this.notifyIcon.Text = dt.ToString("dddd") + ", " + dt.ToString("MMMM") + " " + dt.Day.ToString() +
                       "," + dt.Year + "\n" + dt.ToString("%h") + ":" + dt.Minute.ToString("d2") + " " + dt.ToString("tt", CultureInfo.InvariantCulture);
                }
                else
                {
                  
                   
                }
            }

        }

        private void Item1_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Item_Click(object sender, RoutedEventArgs e)
        {
            if (System.Windows.Application.Current.Windows.OfType<MenuWindow>().Any())
            {
                System.Windows.Application.Current.Windows.OfType<MenuWindow>().First().Activate();
            }
            else
            {
                new MenuWindow().Show();
            }

            
        }

    }
}

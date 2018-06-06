using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockX
{
    class CustomClock
    {
        private int hour;
        private int minute;
        private int second;


        public CustomClock(int hh,int mm, int ss)
        {
            this.hour = hh;
            this.minute = mm;
            this.second = ss;
        }

        public void Tick()
        {
            this.second++;
            if(this.second == 60)
            {
                this.minute++;
                this.second = 00;
            }
            if (this.minute == 60)
            {
                this.hour++;
                this.minute = 00;
            }
            if (this.hour == 12)
            {  
                this.hour = 01;
            }
        }

        public string displayTime()
        {
            return this.hour.ToString("D2") + ":" + this.minute.ToString("D2") + ":" + this.second.ToString("D2");
        }
    
        public int Second
        {
            get { return second; }
            set { second = value; }
        }

        public int Minute
        {
            get { return minute; }
            set { minute = value; }
        }


        public int Hour
        {
            get { return hour; }
            set { hour = value; }
        }

    }
}

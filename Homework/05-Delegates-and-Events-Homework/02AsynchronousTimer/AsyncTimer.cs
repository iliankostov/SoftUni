namespace AsynchronousTimer
{
    using System;
    using System.Timers;

    internal class AsyncTimer
    {
        private Action<string> action;
        private int interval;
        private int time;

        public AsyncTimer(Action<string> method, int interval, int ticks)
        {
            this.Interval = interval;
            this.Ticks = ticks;
            this.action = method;
        }

        public int Interval
        {
            get
            {
                return this.interval;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Interval cant be negative!");
                }

                this.interval = value;
            }
        }

        public int Ticks
        {
            get
            {
                return this.time;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Time  cant be negative!");
                }

                this.time = value;
            }
        }

        public void Run()
        {
            System.Timers.Timer t = new System.Timers.Timer(this.Interval);
            t.Elapsed += this.OnTimedEvent;
            t.Start();
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            this.action(e.SignalTime.ToString());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RandomRouletteLibrary
{
    public class ThreadRoulette
    {
        private static Stopwatch watch = new Stopwatch();
        public Thread Thrd;

        #region Properties
        public DataRoulette RoulutteData { get; set; }
        public string ThreadName { get; set; }
        public int Id { get; set; }
        public static int TimeElapsed { get; set; }
        #endregion

        #region Constructor
        public ThreadRoulette(string name)
        {
            this.ThreadName = name;

            // Initialize thread
            Thrd = new Thread(this.Run);            
            Thrd.Name = this.ThreadName;
            Thrd.Start();
            Thread.Sleep(250);
        }
        #endregion

        #region Methods

        /// <summary>
        /// The method work in thread. 
        /// Initialize random.
        /// Set random results.
        /// </summary>
        private void Run()
        {
            Thread.Sleep(250);

            DataRoulette data = new DataRoulette();
            data.InitializeRandom();
            this.RoulutteData = data;
        }

        /// <summary>
        /// Start timer
        /// </summary>
        public static void StartTimer()
        {
            watch.Start();
        }

        /// <summary>
        /// Stop timer
        /// </summary>
        public static void StopTimer()
        {
            watch.Stop();
            TimeElapsed = watch.Elapsed.Seconds;
            watch.Restart();
        }
        #endregion
    }
}

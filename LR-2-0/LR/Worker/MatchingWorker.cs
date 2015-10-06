// --------------------------------
// <copyright file="ActionModel.cs" company="freiesradikal.it">
//     Copyright (c) Jonathan Günz. The code is published under MIT License.
// </copyright>
// <author>Jonathan Günz</author>
// --------------------------------

namespace LR.Worker
{
    using log4net;
    using System;
    using System.Threading;

    public sealed class MatchingWorker
    {
        #region Singleton
        private static volatile MatchingWorker instance;
        private static object syncRoot = new Object();


        public static MatchingWorker Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new MatchingWorker();
                    }
                }

                return instance;
            }
        }
        #endregion

        private static readonly ILog log = LogManager.GetLogger(typeof(MatchingWorker));
        private Thread MatchingThread { get; set; }
        private bool StopThread { get; set; }

        // ToDo: In Web.config aufnehmen
        private int Intervall { get { return 30; } } // hier kann der Ausführungszyclus des Workers gesetzt werden

        private MatchingWorker() {
            MatchingThread = new Thread(new ThreadStart(Match));
            MatchingThread.Start();
        }

        public void StopMatching()
        {
            StopThread = true;
            // ToDo: Event implementieren
        }

        private void Match()
        {
            log.Debug("Start matching");

            // ToDo: Matchlogik implementieren

            Thread.Sleep(Intervall * 1000);

            if (!StopThread)
                Match();

            StopThread = false;
            log.Debug("end matching");
        }
    }
}

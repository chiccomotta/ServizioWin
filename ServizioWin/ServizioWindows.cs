using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.ServiceProcess;
using System.Timers;
using System.IO;
using log4net.Core;
using NotificationManager;
using ServizioWin.Infrastructure;
using System.Linq;

namespace ServizioWin
{
    public partial class ServizioWindows : ServiceBase
    {
        //private EventLog eventLog1;
        private List<string> _notificationTimeList;
        private readonly string _serviceDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private readonly string _appDataDirectory = null;
        protected Infrastructure.ILogger Logger = new Logger();


        public ServizioWindows()
        {
            InitializeComponent();
            _appDataDirectory = Path.Combine(_serviceDirectory, "App_Data");

            //// creo un log nel registro eventi di windows
            //eventLog1 = new EventLog();
            //if (!EventLog.SourceExists("MySource"))
            //{
            //    EventLog.CreateEventSource("MySource", "MyNewLog");
            //}
            //eventLog1.Source = "MySource";
            //eventLog1.Log = "MyNewLog";
        }

        // Evento OnStart eseguito all'avvio del servizio
        protected override void OnStart(string[] args)
        {
            try
            {
                // tempo per permettere l'attach al processo per debug
                // System.Threading.Thread.Sleep(25000);

                // Log service start
                Logger.WriteLog("SERVICE STARTED", Level.Info);

                var section = (MultipleValuesSection)ConfigurationManager.GetSection("NotificationTime");
                _notificationTimeList = (from object value in section.Values
                            select ((ValueElement)value).Time)
                            .ToList();

                foreach (string t in _notificationTimeList)
                {
                    Logger.WriteLog("TIME: " + t, Level.Info);
                }

                // Leggo l'ora di invio dall' App.config
                //notificationTimeList = ConfigurationManager.AppSettings["notificationTimeList"].Split(';').ToList();

                //Logger.WriteLog("APP_DATA DIRECTORY: " + AppDataDirectory, Level.Info);
                //using (var context = new RegulatoryDbContext())
                //{
                //    Logger.WriteLog("CONNSTRING: " + context.Database.Connection.ConnectionString, Level.Info);
                //}

                //var text = File.ReadAllText(Path.Combine(AppDataDirectory, "mail.txt"));
                //Logger.WriteLog(text, Level.Info);
                //NotificationManger nm = new NotificationManger();
                //Logger.WriteLog("BaseDirectory del NotificationManager.dll: " + nm.Foo(), Level.Alert);

                // Set up a timer to trigger every minute
                Timer timer = new Timer
                {
                    Interval = 1000 * 60
                };

                timer.Elapsed += TimerOnElapsed;
                timer.Start();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex.ToString(), Level.Error);
            }
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            //********** TODO: Insert main activities here.   **************                                 
            if (_notificationTimeList.Contains(DateTime.Now.ToString("HH:mm")))
            {
                Logger.WriteLog("SENDING EMAIL.......OK", Level.Info);
                NotificationManger nm = new NotificationManger();
            }
        }        

        // Evento OnStop eseguito allo stop del servizio
        protected override void OnStop()
        {
            Debug.WriteLine("OnStop event");
            Logger.WriteLog("SERVICE STOPPED", Level.Info);
        }

        // Evento OnContinue
        protected override void OnContinue()
        {
            Debug.WriteLine("OnContinue event");
            //eventLog1.WriteEntry("In OnContinue.");
        }
    }
}

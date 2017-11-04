using System;
using System.Diagnostics;

namespace NotificationManager
{
    public class NotificationManger
    {
        public string Foo()
        {
            string serviceDirectory = AppDomain.CurrentDomain.BaseDirectory;    // directory di ServizioWin.exe         
            return serviceDirectory;
        }
    }
}

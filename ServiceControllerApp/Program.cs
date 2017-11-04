using NotificationManager.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using NotificationManager.Models;

namespace ServiceControllerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {                
                //var s = Templating();
                //return;
                //AddCustomer();

                // Display properties for Service                 
                ServiceController sc = new ServiceController("SERVIZIO WINDOWS CHICCO");    // Può essere il nome o il DisplayName
                Console.WriteLine("Status = " + sc.Status);
                Console.WriteLine("Can Pause and Continue = " + sc.CanPauseAndContinue);
                Console.WriteLine("Can ShutDown = " + sc.CanShutdown);
                Console.WriteLine("Can Stop = " + sc.CanStop);
                Console.WriteLine(sc.DisplayName);

                // avvia il servizio
                sc.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }


        public static string Templating()
        {
            // Parse the template:
            var sourceTemplate =
                "Dear {{name}}, this is definitely a personalized note to you. \n\tVery truly yours, {{sender}} \n CIAO {{XXX}}";
            var template = Mustachio.Parser.Parse(sourceTemplate);

            // Create the values for the template model:
            var model = new Dictionary<string, object>
            {
                {"name", "Chiccone"},
                {"sender", "GINO!!!"},
                {"XXX", "Chiccone"}
            };

            // Combine the model with the template to get content:
            var content = template(model);
            return content;
        }


        public static void AddCustomer()
        {
            // https://stackoverflow.com/questions/3600175/the-model-backing-the-database-context-has-changed-since-the-database-was-crea
            Database.SetInitializer<RegulatoryDbContext>(null);

            var context = new RegulatoryDbContext();
            Debug.WriteLine(context.Database.Connection.ConnectionString);
            Debug.WriteLine(context.Customers.Count());

            var newCust = new Customer()
            {
                Nome = "Giovanni",
                Cognome = "Rossi",
                Matricola = 102488,
                Status = 1
            };

            context.Customers.Add(newCust);
            context.SaveChanges();
        }


        public static void testXML()
        {
            var codes = new List<string> { "004536273", "334536273", "884536273", "544536292", "775434473" };
            //var xml = items.Aggregate("", (current, x) => current + ("<Codice>" + x + "</Codice>"));

            XmlDocument xmlDom = new XmlDocument();
            xmlDom.LoadXml("<?xml version='1.0' ?><Grossisti></Grossisti>");

            foreach (var code in codes)
            {
                var nodeGrossista = xmlDom.CreateNode(XmlNodeType.Element, "Grossista", "");
                var nodeCodice = xmlDom.CreateNode(XmlNodeType.Element, "Codice", "");
                nodeCodice.InnerText = code;

                nodeGrossista.AppendChild(nodeCodice);
                xmlDom.DocumentElement.AppendChild(nodeGrossista);
            }

            Debug.WriteLine(xmlDom.OuterXml);
        }
    }
}

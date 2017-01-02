using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using MassDefect.Data;
using MassDefect.Models;

namespace MassDefect.XMLImport
{
    class Program
    {
        private static string AnomaliesPath = "../../../datasets/new-anomalies.xml";
        static void Main()
        {
            MassDefectContext context=new MassDefectContext();
            ImportAnomalies(context);
        }

        private static void ImportAnomalies(MassDefectContext context)
        {
            XDocument document=XDocument.Load(AnomaliesPath);
            var anomalies = document.XPathSelectElements("anomalies/anomaly");
            foreach (XElement anomaly in anomalies)
            {
                var originPlanetAt = anomaly.Attribute("origin-planet");
                var teleportPlanetAt = anomaly.Attribute("teleport-planet");
                if (originPlanetAt==null||teleportPlanetAt==null)
                {
                    Console.WriteLine("Invalid data.");
                    continue;
                }
                Planet originPlanet = context.Planets.FirstOrDefault(p => p.Name == originPlanetAt.Value);
                Planet teleportPlanet = context.Planets.FirstOrDefault(p => p.Name == teleportPlanetAt.Value);
                if (originPlanet==null||teleportPlanet==null)
                {
                    Console.WriteLine("Invalid Data.");
                    continue;
                }
                var victimsXml = anomaly.XPathSelectElements("victims/victim");
                var victims=new List<Person>();
                foreach (var victim in victimsXml)
                {
                    XAttribute victimAtt = victim.Attribute("name");
                    if (victimAtt==null)
                    {
                        Console.WriteLine("Invalid Data.");
                        continue;
                    }
                    Person victimAnomaly = context.People.FirstOrDefault(p => p.Name == victimAtt.Value);
                    if (victimAnomaly==null)
                    {
                        Console.WriteLine("Invalid Data.");
                        continue;
                    }
                    victims.Add(victimAnomaly);
                }

                Anomaly anomalyImport=new Anomaly()
                {
                    OriginPlanet = originPlanet,
                    TeleportPlanet = teleportPlanet,
                    Victims = victims
                };
                context.Anomalies.Add(anomalyImport);
                context.SaveChanges();
                Console.WriteLine($"Successfully imported anomaly with Origin Planet {anomalyImport.OriginPlanet.Name}");
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MassDefect.Data;

namespace ExportToXML
{
    class Program
    {
        static void Main()
        {
            MassDefectContext context=new MassDefectContext();
            var anomalies = context.Anomalies
                .Select(a => new
                {
                    id=a.Id,
                    originPlanet = a.OriginPlanet.Name,
                    teleportPlanet = a.TeleportPlanet.Name,
                    persons = a.Victims.Select(v =>v.Name)
                });
            XElement root=new XElement("anomailies");
            foreach (var anomaly in anomalies)
            {
                XElement anomalyEl=new XElement("anomaly");
                anomalyEl.Add(new XAttribute("id",anomaly.id));
                anomalyEl.Add(new XAttribute("origin-planet",anomaly.originPlanet));
                anomalyEl.Add(new XAttribute("teleport-planet",anomaly.teleportPlanet));
                XElement victimsEl=new XElement("victims");
                foreach (var victim in anomaly.persons)
                {
                    XElement victimEl=new XElement("victim");
                    victimEl.Add(new XAttribute("name",victim));
                    victimsEl.Add(victimEl);
                    
                }
                anomalyEl.Add(victimsEl);
                root.Add(anomalyEl);
            }
           
           root.Save("../../../exportXml/anomalies.xml");





        }
    }
}

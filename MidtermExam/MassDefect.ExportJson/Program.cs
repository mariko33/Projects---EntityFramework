using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassDefect.Data;
using Newtonsoft.Json;

namespace MassDefect.ExportJson
{
    class Program
    {
        static void Main()
        {
            MassDefectContext context=new MassDefectContext();
            ExportPlantWichAreNotAnomalyOrigins(context);
            ExportPeopleWichHaveNotBeenVictims(context);
            ExportTopAnomaly(context);



        }

        private static void ExportTopAnomaly(MassDefectContext context)
        {
            var anomaly = context.Anomalies
                .OrderByDescending(a => a.Victims.Count)
                .Select(a => new
                {
                    id = a.Id,
                    originPlanet = new
                    {
                        name = a.OriginPlanet.Name
                    },
                    teleportPlanet = new
                    {
                        name = a.TeleportPlanet.Name

                    },
                    victims = a.Victims.Count
                }).Take(1);
            string json = JsonConvert.SerializeObject(anomaly, Formatting.Indented);
            File.WriteAllText("../../../importJson/anomaly.json",json);
        }

        private static void ExportPeopleWichHaveNotBeenVictims(MassDefectContext context)
        {
            var people = context.People
                .Where(p => p.Anomalies.Count == 0)
                .Select(p => new
                {
                    p.Name,
                    homePlanet = new
                    {
                        p.HomePlanet.Name

                    }
                });
            string json = JsonConvert.SerializeObject(people,Formatting.Indented);
            File.WriteAllText("../../../importJson/persons.json",json);
        }

        private static void ExportPlantWichAreNotAnomalyOrigins(MassDefectContext context)
        {
            var planets = context.Planets
                .Where(p => p.OriginAnomalies.Count == 0)
                .Select(p => p.Name);
            string planetsJSON = JsonConvert.SerializeObject(planets, Formatting.Indented);
            File.WriteAllText("../../../importJson/importPlanets.json",planetsJSON);
        }
    }
}

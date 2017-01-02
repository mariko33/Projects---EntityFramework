using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dtos;
using MassDefect.Data;
using MassDefect.Models;
using Newtonsoft.Json;

namespace MassDefect.ExportData
{
    class Program
    {
        static void Main()
        {
            MassDefectContext context=new MassDefectContext();
            

            // ExportAnomaliesWichAreNotAnomalyOrigin(context);
            // ExportPeopleWichArenotBeenVictims(context);
           ExportTopAnomaly(context);
            


        }

       

        private static void ExportTopAnomaly(MassDefectContext context)
        {
            Mapper.Initialize(config=>
            {
                config.CreateMap<SolarSystem, SolarSystemDto>();
                
            });

            
            var anomalyTopVictim = context.Anomalies
                .OrderByDescending(a => a.Victims.Count)
                .Select(a => new
                {
                    Id = a.Id,
                    OriginPlanet = new
                    {
                       Name= a.OriginPlanet.Name

                    },
                    TeleportPlanet = new
                    {
                       Name= a.TeleportPlanet.Name
                    },
                    victimsCount = a.Victims.Count
                }).Take(1);
            
            string anolmalyTopVictims = JsonConvert.SerializeObject(anomalyTopVictim, Formatting.Indented);
            File.WriteAllText("../../../results/anomalyRopVictims.json",anolmalyTopVictims);

            SolarSystem solarSystem = context.SolarSystems.First();
            SolarSystemDto solarSystemDto = Mapper.Map<SolarSystemDto>(solarSystem);
            string jsonSolarSystem = JsonConvert.SerializeObject(solarSystemDto, Formatting.Indented);
            Console.WriteLine(jsonSolarSystem);
            IEnumerable<SolarSystem> solarSystems = context.SolarSystems;
            IEnumerable<SolarSystemDto> solarSystemDtos = Mapper.Map<IEnumerable<SolarSystemDto>>(solarSystems);
            string json = JsonConvert.SerializeObject(solarSystemDtos, Formatting.Indented);
            Console.WriteLine(json);

            


        }

        private static void ExportPeopleWichArenotBeenVictims(MassDefectContext context)
        {
            var persons = context.Persons
                .Where(p => p.Anomalies.Count == 0)
                .Select(p => new
                {
                    p.Name,
                    homePlanet = new
                    {
                        name = p.HomePlanet.Name
                    }
                });
            string jsonPersons = JsonConvert.SerializeObject(persons, Formatting.Indented);
            File.WriteAllText("../../../results/personsNotVictims.json",jsonPersons);
            Console.WriteLine(jsonPersons);
        }

        private static void ExportAnomaliesWichAreNotAnomalyOrigin(MassDefectContext context)
        {
            var planets = context.Planets
                .Where(pl => pl.OriginAnomalies.Count == 0)
                .Select(pl => pl.Name);
            string jsonPlanets = JsonConvert.SerializeObject(planets, Formatting.Indented);
            File.WriteAllText("../../../results/planetsNotAnomalyOrigin.json",jsonPlanets);
            Console.WriteLine(jsonPlanets);
        }
    }
}

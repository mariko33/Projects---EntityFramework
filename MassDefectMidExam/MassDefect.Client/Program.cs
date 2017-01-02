using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using AutoMapper;
using Dtos;
using MassDefect.Data;
using MassDefect.Models;
using Newtonsoft.Json;

namespace MassDefect.Client
{
    class Program
    {
        private static string SolarSystemsPath = "../../../datasets/solar-systems.json";
        private static string StarsPath = "../../../datasets/stars.json";
        private static string PlanetsPath = "../../../datasets/planets.json";
        private static string PersonsPath = "../../../datasets/persons.json";
        private static string AnomaliesPath = "../../../datasets/anomalies.json";
        private static string AnomalyVictimsPath = "../../../datasets/anomaly-victims.json";
        private static string NewAnomaliesPath = "../../../datasets/new-anomalies.xml";
        private static string Error = "Inavalid Data.";
        static void Main()
        {
            MassDefectContext context=new MassDefectContext();
            //context.Database.Initialize(true);
            ConfigureMapping(context);
            //ImportSolarSystems(context);
            //ImportStars(context);
            //ImportPlanets(context);
            //ImportPersons(context);
            //ImportAnomalies(context);
           // ImportAnomalyVictims(context);


            //XDocument doc=XDocument.Load("../../../datasets/new-anomalies.xml");
            //var anomalies = doc.XPathSelectElements("anomalies/anomaly");
            //foreach (var anomaly in anomalies)
            //{
            //    if (anomaly.Attribute("origin-planet")==null ||anomaly.Attribute("teleport-planet")==null)
            //    {
            //        Console.WriteLine(Error);
            //        continue;
            //    }
            //    string nameOriginPlanet = anomaly.Attribute("origin-planet").Value;
            //    string nameTeleportPlanet = anomaly.Attribute("teleport-planet").Value;

                
            //    var originPlanet =
            //        context.Planets.FirstOrDefault(pl => pl.Name == nameOriginPlanet);
            //    var teleportPlanet = context.Planets.FirstOrDefault(pl => pl.Name == nameTeleportPlanet);

            //    if (originPlanet==null||teleportPlanet==null)
            //    {
            //        Console.WriteLine(Error);
            //        continue;
            //    }

            //    Anomaly anomalyNew = new Anomaly()
            //    {
            //        OriginPlanet = originPlanet,
            //        TeleportPlanet = teleportPlanet
            //    };

            //    var victimsEl = anomaly.XPathSelectElements("victims/victim");
            //    foreach (var victimEl in victimsEl)
            //    {
            //        var victimAt = victimEl.Attribute("name");
            //        if (victimAt==null)
            //        {
            //            Console.WriteLine(Error);
            //            continue;
            //        }
            //        string victimName = victimAt.Value;
            //        Person victim = context.Persons.FirstOrDefault(p => p.Name == victimName);
            //        if (victim==null)
            //        {
            //            Console.WriteLine(Error);
            //            continue;
            //        }
            //        anomalyNew.Victims.Add(victim);
            //        context.Anomalies.Add(anomalyNew);
            //        context.SaveChanges();
            //        Console.WriteLine("Successfully imported anomaly");
            //    }
            //}





        }

        private static void ConfigureMapping(MassDefectContext context)
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<SolarSystemDto, SolarSystem>();
                config.CreateMap<StarDto, Star>()
                    .ForMember(star => star.SolarSystem,
                        expression =>
                            expression.MapFrom(
                                dto => context.SolarSystems.FirstOrDefault(s => s.Name == dto.SolarSystem)));
                config.CreateMap<PlanetDto, Planet>()
                    .ForMember(planet => planet.SolarSystem,
                        expression =>
                                expression.MapFrom(dto => context.SolarSystems.FirstOrDefault(s => s.Name == dto.SolarSystem)))
                    .ForMember(planet => planet.Sun,
                        expression => expression.MapFrom(dto => context.Stars.FirstOrDefault(st => st.Name == dto.Sun)));
                config.CreateMap<PersonDto, Person>()
                    .ForMember(person => person.HomePlanet,
                        expression =>
                                expression.MapFrom(dto => context.Planets.FirstOrDefault(p => p.Name == dto.HomePlanet)));
                config.CreateMap<AnomalyDto, Anomaly>()
                    .ForMember(anomaly => anomaly.OriginPlanet,
                        expression =>
                            expression.MapFrom(
                                dto => context.Planets.FirstOrDefault(p => p.Name == dto.OriginPlanet)))
                    .ForMember(anomaly => anomaly.TeleportPlanet,
                        expression =>
                            expression.MapFrom(
                                dto => context.Planets.FirstOrDefault(p => p.Name == dto.TeleportPlanet)));

            });
        }

        private static void ImportAnomalyVictims(MassDefectContext context)
        {
            var json = File.ReadAllText(AnomalyVictimsPath);
            IEnumerable<AnomalyVictimsDto> anomalyVictimsDtos =
                JsonConvert.DeserializeObject<IEnumerable<AnomalyVictimsDto>>(json);
            foreach (var anomalyVictimDto in anomalyVictimsDtos)
            {
                if (anomalyVictimDto.Id==null||anomalyVictimDto.Person==null)
                {
                    Console.WriteLine(Error);
                    continue;
                }
                var anomalyEntity = context.Anomalies.FirstOrDefault(a => a.Id == anomalyVictimDto.Id);
                var victimEntity = context.Persons.FirstOrDefault(v => v.Name == anomalyVictimDto.Person);
                if (anomalyEntity==null||victimEntity==null)
                {
                    Console.WriteLine(Error);
                    continue;
                }
                anomalyEntity.Victims.Add(victimEntity);
                context.Anomalies.Add(anomalyEntity);
                context.SaveChanges();
                Console.WriteLine("Successfully imported anomalys-victims.");
            }
        }

        private static void ImportAnomalies(MassDefectContext context)
        {
            string json = File.ReadAllText(AnomaliesPath);
            IEnumerable<AnomalyDto> anomalyDtos = JsonConvert.DeserializeObject<IEnumerable<AnomalyDto>>(json);
            foreach (var anomalyDto in anomalyDtos)
            {
                if (anomalyDto.OriginPlanet==null||anomalyDto.TeleportPlanet==null)
                {
                    Console.WriteLine(Error);
                    continue;
                }
                var anomaly = Mapper.Map<Anomaly>(anomalyDto);
                if (anomaly.OriginPlanet==null||anomaly.TeleportPlanet==null)
                {
                    Console.WriteLine(Error);
                    continue;
                }
                context.Anomalies.Add(anomaly);
                context.SaveChanges();
                Console.WriteLine($"Successfully imported Anomaly.");

            }
        }

        private static void ImportPersons(MassDefectContext context)
        {
            string json = File.ReadAllText(PersonsPath);
            IEnumerable<PersonDto> personsDtos = JsonConvert.DeserializeObject<IEnumerable<PersonDto>>(json);
            foreach (var personDto in personsDtos)
            {
                if (personDto.Name==null||personDto.HomePlanet==null)
                {
                    Console.WriteLine(Error);
                    continue;
                    
                }
                var person = Mapper.Map<Person>(personDto);
                if (person.Name==null||person.HomePlanet==null)
                {
                    Console.WriteLine(Error);
                    continue;
                }
                context.Persons.Add(person);
                context.SaveChanges();
                Console.WriteLine($"Successfully imported Person {person.Name}");
            }
        }

        private static void ImportPlanets(MassDefectContext context)
        {
            string json = File.ReadAllText(PlanetsPath);
            IEnumerable<PlanetDto> planetsDtos = JsonConvert.DeserializeObject<IEnumerable<PlanetDto>>(json);
            foreach (var planetDto in planetsDtos)
            {
                if (planetDto.Name==null||planetDto.Sun==null||planetDto.SolarSystem==null)
                {
                    Console.WriteLine(Error);
                    continue;
                }
                var planet = Mapper.Map<Planet>(planetDto);

                if (planet.Name==null||planet.Sun==null||planet.SolarSystem==null)
                {
                    Console.WriteLine(Error);
                    continue;
                }
                context.Planets.Add(planet);
                context.SaveChanges();
                Console.WriteLine($"Succssfully imported Planet {planet.Name}");
            }
        }

        private static void ImportStars(MassDefectContext context)
        {
            string json = File.ReadAllText(StarsPath);
            IEnumerable<StarDto> starsDtos = JsonConvert.DeserializeObject<IEnumerable<StarDto>>(json);
            foreach (var starDto in starsDtos)
            {
                if (starDto.Name==null||starDto.SolarSystem==null)
                {
                    Console.WriteLine(Error);
                    continue;
                }
                var star = Mapper.Map<Star>(starDto);
                if (star.Name==null||star.SolarSystem==null)
                {
                    Console.WriteLine(Error);
                    continue;
                }
                context.Stars.Add(star);
                context.SaveChanges();
                Console.WriteLine($"Successfully imported Star {star.Name}.");
            }

        }

        private static void ImportSolarSystems(MassDefectContext context)
        {
            var json = File.ReadAllText(SolarSystemsPath);
            IEnumerable<SolarSystemDto> solarSystemsDtos =
                JsonConvert.DeserializeObject<IEnumerable<SolarSystemDto>>(json);
            foreach (var solarSystemsDto in solarSystemsDtos)
            {
                if (solarSystemsDto.Name==null)
                {
                    Console.WriteLine(Error);
                    continue;
                }
                var solarSystem = Mapper.Map<SolarSystem>(solarSystemsDto);
                if (solarSystem.Name==null)
                {
                    Console.WriteLine(Error);
                    continue;
                }
                context.SolarSystems.Add(solarSystem);
                context.SaveChanges();
                Console.WriteLine($"Successfully imported SolarSystem {solarSystem.Name}");


            }
        }
    }
}

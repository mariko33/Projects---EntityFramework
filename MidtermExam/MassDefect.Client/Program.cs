

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using AutoMapper;
using MassDefect.Data;
using MassDefect.DTOs;
using MassDefect.Models;
using Newtonsoft.Json;

namespace MassDefect.Client
{
    class Program
    {
        private static string SoarSystemPath = "../../../datasets/solar-systems.json";
        private static string StarsPath = "../../../datasets/stars.json";
        private static string PlanetsPath = "../../../datasets/planets.json";
        private static string PersonsPath = "../../../datasets/persons.json";
        private static string AnomaliesPath = "../../../datasets/anomalies.json";
        private static string AnomaliesVictimsPath = "../../../datasets/anomaly-victims.json";
        private static string Error = "Error: Invalid data.";
        static void Main()
        {
            MassDefectContext context=new MassDefectContext();
            //context.Database.Initialize(true);
            ConfigureMapping(context);
           // ImportSolarSystems(context);
           // ImportStars(context);
           // ImportPlanets(context);
           // ImportPersons(context);
           // ImportAnomalies(context);
           // ImportAnomalyVictims(context);


        }

        private static void ConfigureMapping(MassDefectContext context)
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<SolarSystemDto, SolarSystem>();

                config.CreateMap<StarDto, Star>()
                    .ForMember(star => star.SolarSystem,
                        expretion =>
                                expretion.MapFrom(dto => context.SolarSystems.FirstOrDefault(s => s.Name == dto.SolarSystem)));


                config.CreateMap<PlanetDto, Planet>()
                    .ForMember(planet => planet.SolarSystem,
                        expression =>
                            expression.MapFrom(
                                dto => context.SolarSystems.FirstOrDefault(s => s.Name == dto.SolarSystem)))
                    .ForMember(planet => planet.Sun,
                        expression => expression.MapFrom(dto => context.Stars.FirstOrDefault(s => s.Name == dto.Sun)));


                config.CreateMap<PersonDto, Person>()
                    .ForMember(person => person.HomePlanet,
                        expression =>
                                expression.MapFrom(dto => context.Planets.FirstOrDefault(p => p.Name == dto.HomePlanet)));

                config.CreateMap<AnomaliesDto, Anomaly>()
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
            string json = File.ReadAllText(AnomaliesVictimsPath);
            IEnumerable<AnomalyVictimsDto> anomalyVictimsDtos =
                JsonConvert.DeserializeObject<IEnumerable<AnomalyVictimsDto>>(json);
            foreach (AnomalyVictimsDto anomalyVictimsDto in anomalyVictimsDtos)
            {
                if (anomalyVictimsDto.Person==null||anomalyVictimsDto.Id<=0)
                {
                    Console.WriteLine(Error);
                    continue;
                }

                Anomaly anomaly = context.Anomalies.FirstOrDefault(a => a.Id == anomalyVictimsDto.Id);
                Person victim = context.People.FirstOrDefault(p => p.Name == anomalyVictimsDto.Person);
                if (anomaly==null||victim==null)
                {
                    Console.WriteLine(Error);
                    continue;
                }
                anomaly.Victims.Add(victim);
                context.SaveChanges();
                Console.WriteLine($"Successfully imporeted victims to anomaly.");

            }
        }

        private static void ImportAnomalies(MassDefectContext context)
        {
            string json = File.ReadAllText(AnomaliesPath);
            IEnumerable<AnomaliesDto> anomaliesDtos = JsonConvert.DeserializeObject<IEnumerable<AnomaliesDto>>(json);
            foreach (var anomalyDto in anomaliesDtos)
            {
                if (anomalyDto.OriginPlanet==null||anomalyDto.TeleportPlanet==null)
                {
                    Console.WriteLine(Error);
                    continue;
                }
                Anomaly anomaly = Mapper.Map<Anomaly>(anomalyDto);
                if (anomaly.OriginPlanet==null||anomaly.TeleportPlanet==null)
                {
                    Console.WriteLine(Error);
                    continue;
                }
                context.Anomalies.Add(anomaly);
                context.SaveChanges();
                Console.WriteLine($"Succeffully imported Anomaly with Origin Planet:{anomaly.OriginPlanet.Name}");
            }
        }

        private static void ImportPersons(MassDefectContext context)
        {
            string json = File.ReadAllText(PersonsPath);
            IEnumerable<PersonDto> personDtos = JsonConvert.DeserializeObject<IEnumerable<PersonDto>>(json);
           
            foreach (var personDto in personDtos)
            {

                if (personDto.Name==null||personDto.HomePlanet==null)
                {
                    Console.WriteLine(Error);
                    continue;  
                }
                Person person = Mapper.Map<Person>(personDto);
                if (person.Name==null||person.HomePlanet==null)
                {
                    Console.WriteLine(Error);
                    continue;
                }
                context.People.Add(person);
                context.SaveChanges();
                Console.WriteLine($"Successfully imported Person {person.Name}");

            }
        }

        private static void ImportPlanets(MassDefectContext context)
        {
            string json = File.ReadAllText(PlanetsPath);
            IEnumerable<PlanetDto> planetDtos = JsonConvert.DeserializeObject<IEnumerable<PlanetDto>>(json);
            foreach (var planetDto in planetDtos)
            {
                if (planetDto.Name==null||planetDto.Sun==null||planetDto.SolarSystem==null)
                {
                    Console.WriteLine(Error);
                    continue;
                }
                Planet planet = Mapper.Map<Planet>(planetDto);

                //Check data from Database
                if (planet.Name == null || planet.Sun == null || planet.SolarSystem == null)
                {
                    Console.WriteLine(Error);
                    continue;
                }
                context.Planets.Add(planet);
                context.SaveChanges();
                Console.WriteLine($"Succeffully imported planet {planet.Name}");
            }
        }

        private static void ImportStars(MassDefectContext context)
        {
            var json = File.ReadAllText(StarsPath);
            IEnumerable<StarDto> starsDtos = JsonConvert.DeserializeObject<IEnumerable<StarDto>>(json);
            foreach (var starDto in starsDtos)
            {
                if (starDto.Name==null || starDto.SolarSystem==null)
                {
                    Console.WriteLine(Error);
                    continue;
                }
                Star star = Mapper.Map<Star>(starDto);
                if (star.SolarSystem==null)
                {
                    Console.WriteLine(Error);
                    continue;
                }
                context.Stars.Add(star);
                context.SaveChanges();
                Console.WriteLine($"Succeffully imported Star {star.Name}");

            }

        }

        private static void ImportSolarSystems(MassDefectContext context)
        {
            string json = File.ReadAllText(SoarSystemPath);
            IEnumerable<SolarSystemDto> solarSystemsDto = 
                JsonConvert.DeserializeObject<IEnumerable<SolarSystemDto>>(json);
            foreach (var solarSystemDto in solarSystemsDto)
            {
                if (solarSystemDto.Name==null)
                {
                    Console.WriteLine(Error);
                    continue;
                }
                SolarSystem solarSystem = Mapper.Map<SolarSystem>(solarSystemDto);
                context.SolarSystems.Add(solarSystem);
                context.SaveChanges();
                Console.WriteLine($"Successfully imported Solar System {solarSystem.Name}");
            }
        }
    }
}

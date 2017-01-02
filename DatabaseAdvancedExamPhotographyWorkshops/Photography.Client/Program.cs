using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;
using Photography.Data;
using Photography.Dtos;
using Photography.Models;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Photography.Client
{
    public class Program
    {
        private static string CamerasPath = "../../../datasets/cameras.json";
        private static string LensesPath = "../../../datasets/lenses.json";
        private static string PhotographersPath = "../../../datasets/photographers.json";
        private static string Error = "Error. Invalid data provided";

        static void Main()
        {
            PhotographyContext context = new PhotographyContext();
            //context.Database.Initialize(true);
            ConfigureMapping(context);


            // ImportLenses(context);
            //ImportCameras(context);
            //ImportPhotographers(context);
            ImportAccessoaries(context);

        }

        private static void ImportAccessoaries(PhotographyContext context)
        {
            XDocument doc=XDocument.Load("../../../datasets/accessories.xml");
            var accessories = doc.XPathSelectElements("accessories/accessory");
            foreach (var acc in accessories)
            {
                if (acc.Attribute("name")==null)
                {
                    Console.WriteLine(Error);
                    continue;
                    
                }
                 Accessory accessory=new Accessory()
                {
                    Name =acc.Attribute("name").Value
                };
                context.Accessories.Add(accessory);
                context.SaveChanges();
                Console.WriteLine($"Successfully imported {accessory.Name}");
            }

        }

        private static void ConfigureMapping(PhotographyContext context)
        {
            //Mapper.Initialize(config =>
            //{
            //    config.CreateMap<SolarSystemDto, SolarSystem>();

            //    config.CreateMap<StarDto, Star>()
            //        .ForMember(star => star.SolarSystem,
            //            expretion =>
            //                    expretion.MapFrom(dto => context.SolarSystems.FirstOrDefault(s => s.Name == dto.SolarSystem)));

            Mapper.Initialize(config =>
            {
                config.CreateMap<LenDto, Len>();

                //config.CreateMap<CameraDto, Camera>();

            });



        }

        private static void ImportPhotographers(PhotographyContext context)
        {
            string json = File.ReadAllText(PhotographersPath);
            IEnumerable<PhotographerDto> photographersDtos =
                JsonConvert.DeserializeObject<IEnumerable<PhotographerDto>>(json);
            IEnumerable<Len> lens = context.Lens;
            IEnumerable<Camera> cameras = context.Cameras;

            Random rnd=new Random();
            foreach (var photographerDto in photographersDtos)
            {
                Photographer photographer=new Photographer();
                for (int i = 0; i < cameras.Count(); i++)
                {
                    photographer.PrimaryCamera = cameras.FirstOrDefault(c=>c.Id==rnd.Next(1, 10));
                    photographer.SecondaryCamera = cameras.FirstOrDefault(c => c.Id == rnd.Next(1, 10));

                }
                for (int i = 0; i < photographerDto.Lenses.Length; i++)
                {
                    int id = photographerDto.Lenses[i];
                    var len = context.Lens.FirstOrDefault(l => l.Id == id);
                    if (len == null || len.CompatibleWith != photographer.PrimaryCamera.Make)
                    {
                        Console.WriteLine(Error);
                        continue;
                    }
                    photographer.Lens.Add(len);
                }

                string regExpressionString = @"(/\+\[0-9]{1,3}\/[0-9]{8,10}/)";
                Regex regex = new Regex(regExpressionString);
                if (!regex.IsMatch(photographerDto.Phone))
                {
                    Console.WriteLine(Error);
                    continue;

                }
                if (photographerDto.FirstName==null||photographerDto.LastName==null)
                {
                    Console.WriteLine(Error);
                    continue;
                }
                photographer.FirstName = photographerDto.FirstName;
                photographer.LastName = photographerDto.LastName;
                photographer.Phone = photographerDto.Phone;
                context.Photographers.Add(photographer);
                context.SaveChanges();
                Console.WriteLine($"Successfully imported {photographer.FirstName} {photographer.LastName} Lenses: {photographer.Lens.Count}");


            }
        }

        private static void ImportCameras(PhotographyContext context)
        {
            string json = File.ReadAllText(CamerasPath);
            IEnumerable<CameraDto> camerasDtos = JsonConvert.DeserializeObject<IEnumerable<CameraDto>>(json);

            foreach (var cameraDto in camerasDtos)
            {
                if (cameraDto.Type == null || cameraDto.Make == null || cameraDto.Model == null ||
                    cameraDto.MinISO == null)
                {
                    Console.WriteLine(Error);
                    continue;
                }
                if (cameraDto.Type == "DSLR")
                {
                    DSLRCamera camera=new DSLRCamera()
                    {
                        Make = cameraDto.Make,
                        Model =cameraDto.Model,
                        MinISO = cameraDto.MinISO,
                        IsFullFrameOrNot =cameraDto.IsFullFrameOrNot,
                        MaxISO =cameraDto.MaxISO

                    };

                    if (camera.Make==null||camera.Model==null||camera.MinISO<100)
                    {
                        Console.WriteLine(Error);
                        continue;
                    }
                    context.Cameras.Add(camera);
                    context.SaveChanges();
                    Console.WriteLine($"Successfully imported {cameraDto.Type} {camera.Make} {camera.Model}");

                }
                if (cameraDto.Type == "Mirrorless")
                {
                    MirrorlessCamera camera = new MirrorlessCamera()
                    {
                        Make = cameraDto.Make,
                        Model = cameraDto.Model,
                        MinISO = cameraDto.MinISO,
                        IsFullFrameOrNot = cameraDto.IsFullFrameOrNot,
                        MaxISO = cameraDto.MaxISO

                    };

                    if (camera.Make == null || camera.Model == null || camera.MinISO < 100)
                    {
                        Console.WriteLine(Error);
                        continue;
                    }
                    context.Cameras.Add(camera);
                    context.SaveChanges();
                    Console.WriteLine($"Successfully imported {cameraDto.Type} {camera.Make} {camera.Model}");

                }



            }
            //foreach (var cameraDto in camerasDtos)
            //{
            //    if (cameraDto.Type == null || cameraDto.Make == null || cameraDto.Model == null ||
            //        cameraDto.MinISO == null)
            //    {
            //        Console.WriteLine(Error);
            //        continue;
            //    }

            //    if (cameraDto.Type == "DSLR")
            //    {
            //        DSLRCamera camera = Mapper.Map<DSLRCamera>(cameraDto);
            //        if (camera.MinISO<100|| cameraDto.Make == null || cameraDto.Model == null ||
            //        cameraDto.MinISO == 0)
            //        {
            //            Console.WriteLine(Error);
            //            continue;
            //        }
            //        context.Cameras.Add(camera);
            //        context.SaveChanges();
            //        Console.WriteLine($"Successfully imported {cameraDto.Type} {camera.Make} {camera.Model}");

            //    }
            //    if (cameraDto.Type== "Mirrorless")
            //    {
            //        MirrorlessCamera camera = Mapper.Map<MirrorlessCamera>(cameraDto);
            //        if (camera.MinISO < 100 || cameraDto.Make == null || cameraDto.Model == null ||
            //            cameraDto.MinISO == 0)
            //        {
            //            Console.WriteLine(Error);
            //            continue;
            //        }
            //        context.Cameras.Add(camera);
            //        context.SaveChanges();
            //        Console.WriteLine($"Successfully imported {cameraDto.Type} {camera.Make} {camera.Model}");
            //    }

            //}



        }

        private static void ImportLenses(PhotographyContext context)
        {
            string json = File.ReadAllText(LensesPath);
            IEnumerable<LenDto> lensesDtos = JsonConvert.DeserializeObject<IEnumerable<LenDto>>(json);
            foreach (var lenseDto in lensesDtos)
            {
                if (lenseDto.Make==null||lenseDto.FocalLength==null||lenseDto.MaxAperture==null||lenseDto.CompatibleWith==null)
                {
                    Console.WriteLine(Error);
                    continue;
                }
                Len len = Mapper.Map<Len>(lenseDto);
                if (len.Make==null||len.FocalLength==null||len.MaxAperture==null||len.CompatibleWith==null)
                {
                    Console.WriteLine(Error);
                    continue;
                }
                context.Lens.Add(len);
                context.SaveChanges();
                Console.WriteLine($"Successfully imported {len.Make} {len.FocalLength}mm f{len.MaxAperture}");
            }
        }
  }
}

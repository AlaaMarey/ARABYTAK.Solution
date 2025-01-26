using Arabytak.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Arabytak.Repository.Data
{
    public class ArabytakContextSeed
    {
        public async static Task SeedAsync(ArabytakContext _dbContext)
        {
            var brandData = File.ReadAllText("../Arabytak.Repository/Data/DataSeeding/Brand.json");
            var brands=JsonSerializer.Deserialize<List<Brand>>(brandData);
            if (brands.Count()>0)
            {
                if (_dbContext.Brands.Count() == 0)
                {
                    foreach (var brand in brands)
                    {
                        _dbContext.Set<Brand>().Add(brand);
                    }
                    await _dbContext.SaveChangesAsync();
                }
            }
         


            var modelData = File.ReadAllText("../Arabytak.Repository/Data/DataSeeding/Model.json");
            var models= JsonSerializer.Deserialize<List<Model>>(modelData);
            if(models.Count()>0)
            {
                if (_dbContext.models.Count() == 0)
                {
                    foreach (var model in models)
                    {
                        _dbContext.Set<Model>().Add(model);
                    }
                    await _dbContext.SaveChangesAsync();
                }
            }

            var CarData = File.ReadAllText("../Arabytak.Repository/Data/DataSeeding/Car.json");
            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() }
            };
            var cars = JsonSerializer.Deserialize<List<Car>>(CarData, options);
            if (cars.Count() > 0)
            {
               if (_dbContext.cars.Count() == 0)
               {
                 foreach (var car in cars)
                 {
                      _dbContext.Set<Car>().Add(car);
                  }
                   await _dbContext.SaveChangesAsync();
              }
            }
            //var CarData = File.ReadAllText("../Arabytak.Repository/Data/DataSeeding/Car.json");
            //var options = new JsonSerializerOptions
            //{
            //    Converters = { new JsonStringEnumConverter() }
            //};
            //var cars = JsonSerializer.Deserialize<List<Car>>(CarData, options);

            //if (cars.Count() > 0)
            //{
            //    if (_dbContext.cars.Count() == 0)
            //    {
            //        foreach (var car in cars)
            //        {
            //            // تحقق مما إذا كان الكائن موجودًا بالفعل قبل إضافته
            //            if (!_dbContext.cars.Any(c => c.Id == car.Id))
            //            {
            //                _dbContext.Set<Car>().Add(car);
            //            }
            //        }
            //        await _dbContext.SaveChangesAsync();
            //    }
            //}

            var SpecUsedData = File.ReadAllText("../Arabytak.Repository/Data/DataSeeding/Specification_Used.json");
            var specUseds=JsonSerializer.Deserialize<List<SpecUsedCar>>(SpecUsedData);
            if(specUseds.Count() > 0)
            {
                if (_dbContext.specUsedCars.Count() == 0)
                {
                    foreach (var specUsedCar in specUseds)
                    {
                        _dbContext.Set<SpecUsedCar>().Add(specUsedCar);
                    }
                    await _dbContext.SaveChangesAsync();
                }

            }


            var SpecNewData = File.ReadAllText("../Arabytak.Repository/Data/DataSeeding/Specification_New.json");
            var specNews = JsonSerializer.Deserialize<List<SpecNewCar>>(SpecNewData);
            if (specNews.Count() > 0)
            {
                if (_dbContext.specNewCars.Count() == 0)
                {
                    foreach (var specNewCar in specNews)
                    {
                        _dbContext.Set<SpecNewCar>().Add(specNewCar);
                    }
                    await _dbContext.SaveChangesAsync();
                }
            }



            var DealershipData = File.ReadAllText("../Arabytak.Repository/Data/DataSeeding/Dealership.json");
            var Dealers = JsonSerializer.Deserialize<List<Dealership>>(DealershipData);
            if (Dealers.Count() > 0)
            {
                if (_dbContext.deals.Count()==0)
                {
                   foreach(var dealer in Dealers)
                    {
                        _dbContext.Set<Dealership>().Add(dealer);
                    }
                   await _dbContext.SaveChangesAsync();
                }
            }


            var RescueData = File.ReadAllText("../Arabytak.Repository/Data/DataSeeding/RescueCompanies.json");
            var Rescues = JsonSerializer.Deserialize<List<RescueCompany>>(RescueData);
            if (Rescues.Count() > 0)
            {
                if (_dbContext.rescueCompanys.Count() == 0)
                {
                    foreach (var rescue in Rescues)
                    {
                        _dbContext.Set<RescueCompany>().Add(rescue);
                    }
                    await _dbContext.SaveChangesAsync();
                }
            }

            var UrlData = File.ReadAllText("../Arabytak.Repository/Data/DataSeeding/PictureUrl.json");
            var Urls = JsonSerializer.Deserialize<List<CarPictureUrl>>(UrlData);
            if (Urls.Count() > 0)
            {
                if (_dbContext.carsPictureUrls.Count()==0)
                {
                  foreach (var Url in Urls)
                  {
                      _dbContext.Set<CarPictureUrl>().Add(Url);
                  }
                  await _dbContext.SaveChangesAsync();
              }
            }
            //var UrlData = File.ReadAllText("../Arabytak.Repository/Data/DataSeeding/PictureUrl.json");
            //var Urls = JsonSerializer.Deserialize<List<CarPictureUrl>>(UrlData);

            //if (Urls.Count() > 0)
            //{
            //    if (_dbContext.carsPictureUrls.Count() == 0)
            //    {
            //        foreach (var Url in Urls)
            //        {
            //            // التأكد من أن PictureUrl ليس فارغًا أو null
            //            if (!string.IsNullOrEmpty(Url.PictureUrl))
            //            {
            //                _dbContext.Set<CarPictureUrl>().Add(Url);
            //            }
            //            else
            //            {
            //                Url.PictureUrl = "default_image_url";
            //            }
            //        }
            //        await _dbContext.SaveChangesAsync();
            //    }
            //}

        }
    }
}

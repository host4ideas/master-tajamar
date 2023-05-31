﻿using MvcCoreElastiCacheAWS.Helpers;
using MvcCoreElastiCacheAWS.Models;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace MvcCoreElastiCacheAWS.Services
{
    public class ServiceAWSCache
    {
        private readonly IDatabase cache;

        public ServiceAWSCache()
        {
            this.cache = HelperCacheRedis.Connection.GetDatabase();
        }

        public async Task<List<Coche>?> GetCochesFavoritosAsync()
        {
            string jsonCoches = await this.cache.StringGetAsync("cochesfavoritos");
            if (jsonCoches == null)
            {
                return default;
            }
            else
            {
                return JsonConvert.DeserializeObject<List<Coche>>(jsonCoches);
            }
        }

        public async Task AddCocheAsync(Coche car)
        {
            List<Coche> coches = await this.GetCochesFavoritosAsync() ?? new();
            coches.Add(car);
            string jsonCoches = JsonConvert.SerializeObject(coches);
            await this.cache.StringSetAsync("cochesfavoritos", jsonCoches, TimeSpan.FromMinutes(30));
        }

        public async Task DeleteCocheFavoritoAsync(int idcoche)
        {
            List<Coche>? cars = await this.GetCochesFavoritosAsync();
            if (cars != null)
            {
                Coche? carEliminar = cars.FirstOrDefault(x => x.IdCoche == idcoche);

                if (carEliminar != null)
                {
                    cars.Remove(carEliminar);
                }

                if (!cars.Any())
                {
                    await this.cache.KeyDeleteAsync("cochesfavoritos");
                }
                else
                {
                    string jsonCoches = JsonConvert.SerializeObject(cars);
                    await this.cache.StringSetAsync("cochesfavoritos", jsonCoches, TimeSpan.FromMinutes(30));
                }
            }
        }
    }
}

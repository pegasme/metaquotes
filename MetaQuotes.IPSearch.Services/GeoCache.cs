using MetaQuotes.IPSearch.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace MetaQuotes.IPSearch.Services
{
    public class GeoCache : IGeoCache
    {
        private readonly IMemoryCache _cache;

        private const string IpKey = "ip";
        private const string CityKey = "city";
        public GeoCache(IMemoryCache cache) {
            _cache = cache;
        }

        public string getLocationByCity(string city)
        {
            var result = _cache.Get(city);
            return "ip";
        }

        public string getLocationByIp(string ip)
        {
            throw new NotImplementedException();
        }
    }
}

using MetaQuotes.IPSearch.Models;
using MetaQuotes.IPSearch.Services.Extensions;
using MetaQuotes.IPSearch.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System.Text;

namespace MetaQuotes.IPSearch.Services
{
    public class LoadService : ILoadService
    {
        private readonly ILogger _logger;
        private readonly List<IPRange> _ranges;
        private readonly List<GeoInfo> _cities;
        private readonly List<int> _sortedIndexes;
        public LoadService(ILogger logger)
        {
            _logger = logger;

            _ranges = new List<IPRange>();
            _cities = new List<GeoInfo>();
            _sortedIndexes = new List<int>();
        }

           
        public void LoadFromFile(IMemoryCache cache)
        {
            using (var trace = new Trace(_logger))
            {
                // create stream in memory

                MemoryStream ms = new MemoryStream();

                using (var stream = new MemoryStream(File.Open("./Data/geobase.dat", FileMode.Open))
                {
                    using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                    {
                        int version = reader.ReadInt32();         // версия база данных
                        sbyte[] name = reader.ReadSBytes(32);       // название/префикс для базы данных
                        ulong timestamp = reader.ReadUInt64();         // время создания базы данных
                        int records = reader.ReadInt32();           // общее количество записей
                        uint offset_ranges = reader.ReadUInt32();     // смещение относительно начала файла до начала списка записей с геоинформацией
                        uint offset_cities = reader.ReadUInt32(); ;     // смещение относительно начала файла до начала индекса с сортировкой по названию городов
                        uint offset_locations = reader.ReadUInt32();

                        for (int i = 0; i < records; i++)
                        {
                            var _rangeRow = new IPRange();
                            _rangeRow.ip_from = reader.ReadUInt32();
                            _rangeRow.ip_to = reader.ReadUInt32();
                            _rangeRow.location_index = reader.ReadUInt32();
                            _ranges.Add(_rangeRow);
                        }

                        for (int i = 0; i < records; i++)
                        {
                            var _geoRow = new GeoInfo();
                            _geoRow.country = reader.ReadSBytes(8);
                            _geoRow.region = reader.ReadSBytes(12);
                            _geoRow.postal = reader.ReadSBytes(12);
                            _geoRow.city = reader.ReadSBytes(24);
                            _geoRow.organization = reader.ReadSBytes(32);
                            _geoRow.latitude = System.BitConverter.ToSingle(reader.ReadBytes(4));
                            _geoRow.longitude = System.BitConverter.ToSingle(reader.ReadBytes(4));
                            _cities.Add(_geoRow);
                        }

                        for (int i = 0; i < records; i++)
                        {
                            var index = reader.ReadInt32();
                            _sortedIndexes.Add(index);
                        }
                    }
                }
            }
        }
    }
}
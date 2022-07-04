namespace MetaQuotes.IPSearch.Models
{
    public class Header
    {
        public int version;
        public sbyte name;
        public ulong timestamp;
        public int records;
        public uint offset_ranges;
        public uint offset_cities;
        public uint offset_locations;
    }
}
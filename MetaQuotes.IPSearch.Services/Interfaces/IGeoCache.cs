namespace MetaQuotes.IPSearch.Services.Interfaces
{
    public interface IGeoCache
    {
        string getLocationByIp(string ip);
        string getLocationByCity(string city);
    }
}

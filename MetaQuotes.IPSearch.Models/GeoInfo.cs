namespace MetaQuotes.IPSearch.Models;

public class GeoInfo
{
    public sbyte[] country { get; set; }
    public sbyte[] region { get; set; }
    public sbyte[] postal { get; set; }
    public sbyte[] city { get; set; }
    public sbyte[] organization { get; set; }
    public float latitude { get; set; }
    public float longitude { get; set; }
}

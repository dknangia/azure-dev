namespace Level4._3_Party_Deployment;

public class RunProgram
{
    private readonly LegacyMediaGroup _mediaGroup;

    public RunProgram(IMediaGroup mediaGroup)
    {
        _mediaGroup = mediaGroup.CreateMediaGroup();
        _mediaGroup.Medias.Add(new LegacyMedia());
    }
}

public interface IMediaGroup
{
    LegacyMediaGroup CreateMediaGroup();
}

public class MediaGroup : IMediaGroup
{
    public LegacyMediaGroup CreateMediaGroup()
    {
        return new LegacyMediaGroup();
    }
}

public class LegacyMediaGroup
{
    public List<LegacyMedia> Medias { get; set; } = new();
    public int MediaGroup1 { get; set; }
}

public class LegacyMedia
{
    public string Media1 { get; set; } = string.Empty;
    public string Media2 { get; set; } = string.Empty;
    public string Media3 { get; set; } = string.Empty;
}

public class Wine
{
    public Wine(decimal price)
    {
        Price = price;
    }

    public Wine(decimal price, int year) : this(price)
    {
        Year = year;
    }

    public Wine(decimal price, DateTime year) : this(price, year.Year)
    {
    }

    public decimal Price { get; set; }
    public int Year { get; set; }
}
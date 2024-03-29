using System.Globalization;

namespace Chapter02;

public class Location
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public static bool TryParse(string? value, IFormatProvider? provider, out Location? location)
    {
        if (!string.IsNullOrEmpty(value))
        {
            var values = value.Split(",", StringSplitOptions.RemoveEmptyEntries);
            if (values.Length == 2
                && double.TryParse(values[0], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var latitude)
                && double.TryParse(values[1], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var longitude))
            {
                location = new Location
                {
                    Latitude = latitude,
                    Longitude = longitude
                };

                return true;
            }
        }
        location = null;
        return false;
    }
}
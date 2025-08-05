namespace WeatherApp.Models
{
    public class WeatherApiResponse
    {
        public Location Location { get; set; }
        public Current Current { get; set; }
    }

    public class Location
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }

    public class Current
    {
        public float Temp_c { get; set; }
        public Condition Condition { get; set; }
        public int Humidity { get; set; }
        public float Wind_kph { get; set; }
    }

    public class Condition
    {
        public string Text { get; set; }
        public string Icon { get; set; }
    }
}
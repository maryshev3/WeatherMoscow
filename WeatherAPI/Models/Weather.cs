using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherAPI.Models
{
    public class Weather
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public double Temperature { get; set; }
        public int Humidity { get; set; }
        public double DewPoint { get; set; }
        public int Presure { get; set; }
        public string WindDirection { get; set; }
        public int WindSpeed { get; set; }
        public int? Cloudy { get; set; }
        public int HighBorderCloudy { get; set; }
        public int? HorizontalVisibility { get; set; }
        public string? WeatherСonditions { get; set; }
    }
}

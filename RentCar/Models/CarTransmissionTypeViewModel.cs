using Microsoft.AspNetCore.Mvc.Rendering;

namespace RentCar.Models
{
    public class CarTransmissionTypeViewModel
    {
        public List<Car>? Cars { get; set; }
        public SelectList? Type { get; set; }
        public string? CarType { get; set; }
        public string? SearchString { get; set; }
    }
}

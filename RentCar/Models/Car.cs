using RentCar.Models;
using System.ComponentModel.DataAnnotations;

namespace RentCar.Models
{
    public class Car
    {
        [Display(Name = "Идентификатор")]
        public int Id { get; set; }
        [Display(Name = "Модель автомобиля")]
        public string? CarModel { get; set; }

        [Display(Name = "Дата выпуска")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Тип трансмиссии")]
        public string? TransmissionType { get; set; }
        [Display(Name = "Цена аренды")]
        public decimal RentalPrice { get; set; }
     
        public ICollection<LeaseAgreement> LeaseAgreements { get; set; } = new List<LeaseAgreement>();
    }
}

using RentCar.Models;
using System.ComponentModel.DataAnnotations;

namespace RentCar.Models
{
    public class LeaseAgreement
    {
        [Display(Name = "Идентификатор")]
        public int Id { get; set; }
        [Display(Name = "Дата")]
        public DateTime DataTime { get; set; }
        [Display(Name = "Стоимость")]
        public decimal Price { get; set; }
        [Display(Name = "Идентификатор арендадатора")]
        public int? TenantId { get; set; }
        [Display(Name = "Арендадатор")]
        public Tenant? Tenant { get; set; }
        [Display(Name = "Индентификатор автомобиля")]
        public int? CarId { get; set; }
        [Display(Name = "Автомобиль")]
        public Car? Car { get; set; }
      
    }
}

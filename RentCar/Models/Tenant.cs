using RentCar.Models;
using System.ComponentModel.DataAnnotations;

namespace RentCar.Models
{
    public class Tenant
    {
        [Display(Name = "Идентификатор")]
        public int Id { get; set; }
        [Display(Name = "Фамилия")]
        public string? Surname { get; set; }
        [Display(Name = "Начало аренды")]
        public DateTime StartOfLease { get; set; }
        [Display(Name = "Конец аренды")]
        public DateTime EndOfLease { get; set; }
        [Display(Name = "Данные паспорта")]
        public int PassportDetails { get; set; }
        

        public ICollection<LeaseAgreement> LeaseAgreements { get; set; } = new List<LeaseAgreement>();

    }
}
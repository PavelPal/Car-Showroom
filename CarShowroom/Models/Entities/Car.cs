using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShowroom.Models.Entities
{
    public class Car
    {
        public Car()
        {
            CarImages = new List<CarImage>();
            Reviews = new List<Review>();
        }

        [Key,
         DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Неверно заполнено поле")]
        [Display(Name = "Название автомобиля")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Неверно заполнено поле")]
        [Display(Name = "Цена")]
        public decimal Cost { get; set; }

        [Display(Name = "Скидка")]
        public int Discount { get; set; }

        [Display(Name = "Количество")]
        public int Count { get; set; }

        [Required(ErrorMessage = "Неверно заполнено поле")]
        [Display(Name = "Дата создания")]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "Неверно заполнено поле")]
        [Display(Name = "Дата добавления")]
        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "Неверно заполнено поле")]
        [Display(Name = "Ширина")]
        public double Width { get; set; }

        [Required(ErrorMessage = "Неверно заполнено поле")]
        [Display(Name = "Высота")]
        public double Height { get; set; }

        [Required(ErrorMessage = "Неверно заполнено поле")]
        [Display(Name = "Длина")]
        public double Length { get; set; }

        [Required(ErrorMessage = "Неверно заполнено поле")]
        [Display(Name = "Колесная база")]
        public double Wheelbase { get; set; }

        [Required(ErrorMessage = "Неверно заполнено поле")]
        [Display(Name = "Дорожный просвет")]
        public double Clearance { get; set; }

        [Required(ErrorMessage = "Неверно заполнено поле")]
        [Display(Name = "Объем багажника")]
        public double TrunkVolume { get; set; }

        [Required(ErrorMessage = "Неверно заполнено поле")]
        [Display(Name = "Объем топливного бака")]
        public double FuelTankVolume { get; set; }

        [Required(ErrorMessage = "Неверно заполнено поле")]
        [Display(Name = "Вес")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Неверно заполнено поле")]
        [Display(Name = "Количество дверей")]
        public int DoorCount { get; set; }

        [Required(ErrorMessage = "Неверно заполнено поле")]
        [Display(Name = "Объем двигателя")]
        public double EngineVolume { get; set; }

        [Required(ErrorMessage = "Неверно заполнено поле")]
        [Display(Name = "Количество цилиндров")]
        public int CylindersCount { get; set; }

        [Required(ErrorMessage = "Неверно заполнено поле")]
        [Display(Name = "Нагнетатель")]
        public bool Supercharger { get; set; }

        [Required(ErrorMessage = "Неверно заполнено поле")]
        [Display(Name = "Мощность двигателя")]
        public int EnginePower { get; set; }

        [Required(ErrorMessage = "Неверно заполнено поле")]
        [Display(Name = "Максимальная скорость")]
        public int MaxSpeed { get; set; }

        [Required(ErrorMessage = "Неверно заполнено поле")]
        [Display(Name = "Максимальная передача")]
        public int TopGear { get; set; }

        [Required(ErrorMessage = "Неверно заполнено поле")]
        [Display(Name = "Разгон")]
        public double Acceleration { get; set; }

        [Required(ErrorMessage = "Неверно заполнено поле")]
        [Display(Name = "Расход топлива")]
        public double FuelConsumption { get; set; }

        [Required(ErrorMessage = "Неверно заполнено поле")]
        [Display(Name = "Отделка сидений")]
        public string SeatFinish { get; set; }

        [Required(ErrorMessage = "Неверно заполнено поле")]
        [Display(Name = "Кондиционер")]
        public bool ConditioningSystem { get; set; }

        [Required(ErrorMessage = "Неверно заполнено поле")]
        [Display(Name = "Регулировка рулевой колонки")]
        public bool AdjustableSteeringColumn { get; set; }

        [Required(ErrorMessage = "Неверно заполнено поле")]
        [Display(Name = "Обогреватель")]
        public bool Heating { get; set; }

        [Required(ErrorMessage = "Неверно заполнено поле")]
        [Display(Name = "Навигация")]
        public bool Navigation { get; set; }

        [Required(ErrorMessage = "Неверно заполнено поле")]
        [Display(Name = "Сигнализация")]
        public bool Signaling { get; set; }

        [Required(ErrorMessage = "Неверно заполнено поле")]
        [Display(Name = "Круизконтроль")]
        public bool CruiseControl { get; set; }

        public int BodyTypeId { get; set; }
        public BodyType BodyType { get; set; }
        public int EngineId { get; set; }
        public Engine Engine { get; set; }
        public int TransmissionId { get; set; }
        public Transmission Transmission { get; set; }
        public int DriveUnitId { get; set; }
        public DriveUnit DriveUnit { get; set; }
        public int CarTypeId { get; set; }
        public CarType CarType { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int HeadlightId { get; set; }
        public Headlight Headlight { get; set; }
        public List<CarImage> CarImages { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
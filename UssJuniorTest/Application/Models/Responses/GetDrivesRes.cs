using System.ComponentModel.DataAnnotations;

namespace UssJuniorTest.Application.Models.Responses
{
    public class GetDrivesRes
    {
        [Required]
        /// <summary>
        /// Имя.
        /// </summary>
        public required string Name { get; set; }

        [Required]
        /// <summary>
        /// Возраст.
        /// </summary>
        public required int Age { get; set; }

        [Required]
        /// <summary>
        /// Производитель.
        /// </summary>
        public required string Manufacturer { get; set; }

        [Required]
        /// <summary>
        /// Модель автомобиля.
        /// </summary>
        public required string Model { get; set; }

        [Required]
        /// <summary>
        /// Сколько времени провел
        /// </summary>
        public required int Days { get; set; }
        [Required]
        public required int Hours { get; set; }
        [Required]
        public required int Minutes { get; set; }
    }
}

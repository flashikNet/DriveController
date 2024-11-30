using System.ComponentModel.DataAnnotations;

namespace UssJuniorTest.Application.Models.Requests
{
    public class GetDrivesReq
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Start {  get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime End { get; set; }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ModelsDTO
{
    public class BookingDTO :DTO
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal Cost { get; set; }
        public int? ClientId { get; set; }
        public int? RoomId { get; set; }
    }
    public class BookingDTOValidator : AbstractValidator<BookingDTO>
    {
        public BookingDTOValidator()
        {
            RuleFor(a => a.RoomId).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(a => a.ClientId).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(a => a.Cost).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(a => a.CheckIn).NotNull().NotEmpty().GreaterThan(DateTime.Now);
            RuleFor(a => a.CheckOut).NotNull().NotEmpty().GreaterThan(a=>a.CheckIn);
        }
    }
}

using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebjarTask.Application.Settings.Commands.ChangeDollarPrice
{
    public class ChangeDollarPriceVM : IRequest<ErrorOr<bool>>
    {
        public decimal DollarPrice { get; set; }
    }
}

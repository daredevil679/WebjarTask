using ErrorOr;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebjarTask.Application.Product.Commands.AddPriceForProduct;
using WebjarTask.Domain.Errors;

namespace WebjarTask.Application.Settings.Commands.ChangeDollarPrice
{
    public class ChangeDollarPriceH : IRequestHandler<ChangeDollarPriceVM, ErrorOr<bool>>
    {
        private IConfiguration _config;

        public ChangeDollarPriceH(IConfiguration config)
        {
            _config = config;
        }

        public async Task<ErrorOr<bool>> Handle(ChangeDollarPriceVM request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            try
            {
                _config["PriceValuation:DOLLAR"] = request.DollarPrice.ToString();
                return true;
            }
            catch (Exception)
            {
                return VErrors.CRUD.Update;
            }
        }
    }
}

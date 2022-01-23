using Serilog;
using Spotzer.Dto;
using Spotzer.Helpers;
using Spotzer.Helpers.Constants;
using Spotzer.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Spotzer.Services.Partners
{
    public class PartnerD : OrderDto, IPartnerService
    {
        public List<string> Validate()
        {
            var exceptionList = new List<string>();

            if (this.LineItems.Any(x => x.ProductType == ProductConstants.Website))
            {
                exceptionList.Add(ProductConstants.Website + " product is not supported");
            }

            return exceptionList;
        }

        public ResponseDto Process()
        {
            //Create a DB layer and make a call to repository. Inject the repository object using DI pattern similar to ILogger.
            var response = new ResponseDto();
            try
            {
                response.ErrorList = Validate();

                if (response.ErrorList.Count > 0)
                {
                    response.IsSuccess = false;
                }
                else
                {
                    response.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                throw new CustomException("Error occured. Contact administrator!");
            }
            return response;
        }
    }
}

using Serilog;
using Spotzer.Dto;
using Spotzer.Services.Contracts;
using System;
using System.Collections.Generic;

namespace Spotzer.Services.Partners
{
    public class PartnerB : OrderDto, IPartnerService
    {
        public List<string> Validate()
        {
            throw new NotImplementedException();
        }

        public ResponseDto Process()
        {
            //Create a DB layer and make a call to repository. Inject the repository object using DI pattern similar to ILogger.
            
            var response = new ResponseDto();
            response.IsSuccess = true;
            return response;
        }
    }
}

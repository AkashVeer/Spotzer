using Serilog;
using Spotzer.Dto;
using Spotzer.Helpers;
using Spotzer.Services.Contracts;
using System;
using System.Collections.Generic;

namespace Spotzer.Services.Partners
{
    public class PartnerC : OrderDto, IPartnerService
    {
        public string ExposureID { get; set; }
        public string UDAC { get; set; }
        public string RelatedOrder { get; set; }

        public List<string> Validate()
        {
            try
            {
                var errorList = new List<string>();
                if (String.IsNullOrEmpty(this.ExposureID))
                    errorList.Add("ExposureID cannot be null");
                if (String.IsNullOrEmpty(this.UDAC))
                    errorList.Add("UDAC cannot be null");
                if (String.IsNullOrEmpty(this.RelatedOrder))
                    errorList.Add("RelatedOrder cannot be null");

                return errorList;
            }
            catch(Exception ex)
            {
                throw new CustomException("Error occured. Contact administrator!");
            }
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

using Serilog;
using Spotzer.Dto;
using Spotzer.Helpers;
using Spotzer.Helpers.Constants;
using Spotzer.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotzer.Services.Partners
{
    public class PartnerA:OrderDto, IPartnerService
    {
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactTitle { get; set; }
        public string ContactPhone { get; set; }
        public string ContactMobile { get; set; }
        public string ContactEmail { get; set; }

        public List<string> Validate()
        {
            try
            {
                var exceptionList = new List<string>();

                if (this.LineItems.Any(x => x.ProductType == ProductConstants.PaidSearch))
                {
                    exceptionList.Add(ProductConstants.PaidSearch + " product is not supported");
                }

                if (String.IsNullOrEmpty(this.ContactFirstName))
                    exceptionList.Add("ContactFirstName cannot be null");
                if (String.IsNullOrEmpty(this.ContactLastName))
                    exceptionList.Add("ContactLastName cannot be null");
                if (String.IsNullOrEmpty(this.ContactTitle))
                    exceptionList.Add("ContactTitle cannot be null");
                if (String.IsNullOrEmpty(this.ContactPhone))
                    exceptionList.Add("ContactPhone cannot be null");
                if (String.IsNullOrEmpty(this.ContactMobile))
                    exceptionList.Add("ContactMobile cannot be null");
                if (String.IsNullOrEmpty(this.ContactEmail))
                    exceptionList.Add("ContactEmail cannot be null");

                return exceptionList;
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

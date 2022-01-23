using Newtonsoft.Json.Linq;
using Spotzer.Helpers.Constants;
using Spotzer.Services.Contracts;
using Spotzer.Services.Partners;
using System;

namespace Spotzer.Helpers
{
    public class PartnerFactory
    {
        public IPartnerService GetInstance(JObject request)
        {
            string partnerCode = request.GetValue("Partner", StringComparison.InvariantCultureIgnoreCase).Value<string>();

            switch(partnerCode)
            {
                case PartnerConstants.PartnerA: return request.ToObject<PartnerA>();
                case PartnerConstants.PartnerB: return request.ToObject<PartnerB>();
                case PartnerConstants.PartnerC: return request.ToObject<PartnerC>();
                case PartnerConstants.PartnerD: return request.ToObject<PartnerD>();
                default: throw new CustomException("Partner not supported currently!");
            }
        }
    }
}

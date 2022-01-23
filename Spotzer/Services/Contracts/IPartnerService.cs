using Spotzer.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spotzer.Services.Contracts
{
    public interface IPartnerService
    {
        List<string> Validate();
        ResponseDto Process();
    }
}

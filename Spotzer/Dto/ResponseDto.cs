using System.Collections.Generic;

namespace Spotzer.Dto
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; }
        public List<string> ErrorList { get; set; }
    }
}

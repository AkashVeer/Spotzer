using System.Collections.Generic;

namespace Spotzer.Dto
{
    public class OrderDto
    {
        public string Partner { get; set; }
        public string OrderID { get; set; }
        public string TypeOfOrder { get; set; }
        public string SubmittedBy { get; set; }
        public string CompanyID { get; set; }
        public string CompanyName { get; set; }
        public List<ProductDto> LineItems { get; set; }
    }
}

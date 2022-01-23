namespace Spotzer.Dto
{
    public class ProductDto
    {
        public int ID { get; set; }
        public string ProductID { get; set; }
        public string ProductType { get; set; }
        public string Notes { get; set; }
        public string Category { get; set; }
        public WebsiteDto WebsiteDetails { get; set; }
        public PaidSearchDto AdWordCampaign { get; set; }
    }
}

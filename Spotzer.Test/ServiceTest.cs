using NUnit.Framework;
using Spotzer.Controllers;
using Spotzer.Dto;
using Spotzer.Services.Contracts;
using Spotzer.Services.Partners;
using System.Collections.Generic;
using System.Linq;

namespace Spotzer.Test
{
    [TestFixture]
    public class ServiceTest
    {
        OrderDto orderDto = new OrderDto();
        PaidSearchDto paidSearchDto = new PaidSearchDto();
        ProductDto websiteProductDto = new ProductDto();
        ProductDto paidSearchProductDto = new ProductDto();
        WebsiteDto websiteDto = new WebsiteDto();
        PartnerA partnerA = new PartnerA();
        PartnerB partnerB = new PartnerB();
        PartnerC partnerC = new PartnerC();
        PartnerD partnerD = new PartnerD();

        [SetUp]
        public void Setup()
        {
            websiteDto.TemplateId = "Sample";
            websiteDto.WebsiteBusinessName = "Sample";
            websiteDto.WebsiteAddressLine1 = "Sample";
            websiteDto.WebsiteAddressLine2 = "Sample";
            websiteDto.WebsiteCity = "Sample";
            websiteDto.WebsiteState = "Sample";
            websiteDto.WebsitePostCode = "Sample";
            websiteDto.WebsitePhone = "Sample";
            websiteDto.WebsiteEmail = "Sample";
            websiteDto.WebsiteMobile = "Sample";

            paidSearchDto.CampaignName = "Sample";
            paidSearchDto.CampaignAddressLine1 = "Sample";
            paidSearchDto.CampaignPostCode = "Sample";
            paidSearchDto.CampaignRadius = "Sample";
            paidSearchDto.LeadPhoneNumber = "Sample";
            paidSearchDto.SMSPhoneNumber = "Sample";
            paidSearchDto.UniqueSellingPoint1 = "Sample";
            paidSearchDto.UniqueSellingPoint2 = "Sample";
            paidSearchDto.UniqueSellingPoint3 = "Sample";
            paidSearchDto.Offer = "Sample";
            paidSearchDto.DestinationURL = "Sample";

            websiteProductDto.ID = 1;
            websiteProductDto.ProductID = "Sample";
            websiteProductDto.ProductType = "Website";
            websiteProductDto.Notes = "Sample";
            websiteProductDto.Category = "Sample";
            websiteProductDto.WebsiteDetails = websiteDto;

            paidSearchProductDto.ID = 1;
            paidSearchProductDto.ProductID = "Sample";
            paidSearchProductDto.ProductType = "Paid Search";
            paidSearchProductDto.Notes = "Sample";
            paidSearchProductDto.Category = "Sample";
            paidSearchProductDto.AdWordCampaign = paidSearchDto;

            orderDto.Partner = "Sample";
            orderDto.OrderID = "Sample";
            orderDto.TypeOfOrder = "Sample";
            orderDto.SubmittedBy = "Sample";
            orderDto.CompanyID = "Sample";
            orderDto.CompanyName = "Sample";
            orderDto.LineItems = new List<ProductDto>();
        }

        [Test]
        public void PartnerA_WithValidData_ReturnSuccessTrue()
        {
            //Arrange
            partnerA.Partner = orderDto.Partner;
            partnerA.OrderID = orderDto.OrderID;
            partnerA.TypeOfOrder = orderDto.TypeOfOrder;
            partnerA.SubmittedBy = orderDto.SubmittedBy;
            partnerA.CompanyID = orderDto.CompanyID;
            partnerA.CompanyName = orderDto.CompanyName;
            partnerA.LineItems = orderDto.LineItems;
            partnerA.LineItems.Add(websiteProductDto);
            partnerA.ContactFirstName = "Sample";
            partnerA.ContactLastName = "Sample";
            partnerA.ContactTitle = "Sample";
            partnerA.ContactPhone = "Sample";
            partnerA.ContactMobile = "Sample";
            partnerA.ContactEmail = "Sample";

            //Act
            var response = partnerA.Process();

            //Assert
            Assert.IsTrue(response.IsSuccess);
        }

        [Test]
        public void PartnerA_WithNullData_ReturnSuccessFalse()
        {
            //Arrange
            partnerA.Partner = orderDto.Partner;
            partnerA.OrderID = orderDto.OrderID;
            partnerA.TypeOfOrder = orderDto.TypeOfOrder;
            partnerA.SubmittedBy = orderDto.SubmittedBy;
            partnerA.CompanyID = orderDto.CompanyID;
            partnerA.CompanyName = orderDto.CompanyName;
            partnerA.LineItems = orderDto.LineItems;
            partnerA.ContactFirstName = "";
            partnerA.ContactLastName = "";
            partnerA.ContactTitle = "";
            partnerA.ContactPhone = "";
            partnerA.ContactMobile = "";
            partnerA.ContactEmail = "";

            //Act
            var response = partnerA.Process();

            //Assert
            Assert.IsFalse(response.IsSuccess);
        }

        [Test]
        public void PartnerA_WithInvalidData_ReturnSuccessFalse()
        {
            //Arrange
            partnerA.Partner = orderDto.Partner;
            partnerA.OrderID = orderDto.OrderID;
            partnerA.TypeOfOrder = orderDto.TypeOfOrder;
            partnerA.SubmittedBy = orderDto.SubmittedBy;
            partnerA.CompanyID = orderDto.CompanyID;
            partnerA.CompanyName = orderDto.CompanyName;
            partnerA.LineItems = orderDto.LineItems;
            partnerA.LineItems.Add(paidSearchProductDto);
            partnerA.ContactFirstName = "Sample";
            partnerA.ContactLastName = "Sample";
            partnerA.ContactTitle = "Sample";
            partnerA.ContactPhone = "Sample";
            partnerA.ContactMobile = "Sample";
            partnerA.ContactEmail = "Sample";

            //Act
            var response = partnerA.Process();

            //Assert
            Assert.IsFalse(response.IsSuccess);
        }

        [Test]
        public void PartnerB_WithValidData_ReturnSuccessTrue()
        {
            //Arrange
            partnerB.Partner = orderDto.Partner;
            partnerB.OrderID = orderDto.OrderID;
            partnerB.TypeOfOrder = orderDto.TypeOfOrder;
            partnerB.SubmittedBy = orderDto.SubmittedBy;
            partnerB.CompanyID = orderDto.CompanyID;
            partnerB.CompanyName = orderDto.CompanyName;
            partnerB.LineItems = orderDto.LineItems;
            partnerB.LineItems.Add(paidSearchProductDto);
            partnerB.LineItems.Add(websiteProductDto);

            //Act
            var response = partnerB.Process();

            //Assert
            Assert.IsTrue(response.IsSuccess);
        }

        [Test]
        public void PartnerC_WithValidData_ReturnSuccessTrue()
        {
            //Arrange
            partnerC.Partner = orderDto.Partner;
            partnerC.OrderID = orderDto.OrderID;
            partnerC.TypeOfOrder = orderDto.TypeOfOrder;
            partnerC.SubmittedBy = orderDto.SubmittedBy;
            partnerC.CompanyID = orderDto.CompanyID;
            partnerC.CompanyName = orderDto.CompanyName;
            partnerC.LineItems = orderDto.LineItems;
            partnerC.LineItems.Add(paidSearchProductDto);
            partnerC.LineItems.Add(websiteProductDto);
            partnerC.ExposureID = "Sample";
            partnerC.UDAC = "Sample";
            partnerC.RelatedOrder = "Sample";

            //Act
            var response = partnerC.Process();

            //Assert
            Assert.IsTrue(response.IsSuccess);
        }

        [Test]
        public void PartnerC_WithNullData_ReturnSuccessFalse()
        {
            //Arrange
            partnerC.Partner = orderDto.Partner;
            partnerC.OrderID = orderDto.OrderID;
            partnerC.TypeOfOrder = orderDto.TypeOfOrder;
            partnerC.SubmittedBy = orderDto.SubmittedBy;
            partnerC.CompanyID = orderDto.CompanyID;
            partnerC.CompanyName = orderDto.CompanyName;
            partnerC.LineItems = orderDto.LineItems;
            partnerC.LineItems.Add(paidSearchProductDto);
            partnerC.LineItems.Add(websiteProductDto);
            partnerC.ExposureID = "";
            partnerC.UDAC = "";
            partnerC.RelatedOrder = "";

            //Act
            var response = partnerC.Process();

            //Assert
            Assert.IsFalse(response.IsSuccess);
        }

        [Test]
        public void PartnerD_WithValidData_ReturnSuccessTrue()
        {
            //Arrange
            partnerD.Partner = orderDto.Partner;
            partnerD.OrderID = orderDto.OrderID;
            partnerD.TypeOfOrder = orderDto.TypeOfOrder;
            partnerD.SubmittedBy = orderDto.SubmittedBy;
            partnerD.CompanyID = orderDto.CompanyID;
            partnerD.CompanyName = orderDto.CompanyName;
            partnerD.LineItems = orderDto.LineItems;
            partnerD.LineItems.Add(paidSearchProductDto);
            //partnerD.LineItems.Add(websiteProductDto);

            //Act
            var response = partnerD.Process();

            //Assert
            Assert.IsTrue(response.IsSuccess);
        }

        [Test]
        public void PartnerD_WithInvalidData_ReturnSuccessFalse()
        {
            //Arrange
            partnerD.Partner = orderDto.Partner;
            partnerD.OrderID = orderDto.OrderID;
            partnerD.TypeOfOrder = orderDto.TypeOfOrder;
            partnerD.SubmittedBy = orderDto.SubmittedBy;
            partnerD.CompanyID = orderDto.CompanyID;
            partnerD.CompanyName = orderDto.CompanyName;
            partnerD.LineItems = orderDto.LineItems;
            partnerD.LineItems.Add(paidSearchProductDto);
            partnerD.LineItems.Add(websiteProductDto);

            //Act
            var response = partnerD.Process();

            //Assert
            Assert.IsFalse(response.IsSuccess);
        }

    }
}
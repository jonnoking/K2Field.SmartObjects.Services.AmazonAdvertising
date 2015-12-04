using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SourceCode.SmartObjects.Services.ServiceSDK.Objects;
using Attributes = SourceCode.SmartObjects.Services.ServiceSDK.Attributes;
using SourceCode.SmartObjects.Services.ServiceSDK.Types;
using System.Net;
using Microsoft.Win32;
using System.Xml.Serialization;
using AmazonProductAdvtApi;
using System.IO;

namespace K2Field.SmartObjects.Services.AmazonAdvertising
{
    [Attributes.ServiceObject("AmazonItemLookup", "Amazon Item Lookup", "Amazon Item Lookup")]
    public class AmazonItemLookup
    {
        //http://docs.aws.amazon.com/AWSECommerceService/latest/DG/ItemLookup.html
        //http://docs.aws.amazon.com/AWSECommerceService/latest/DG/RG_ItemAttributes.html


        //const string _decimalFormat = "#.##";

        public ServiceConfiguration ServiceConfiguration { get; set; }

        [Attributes.Property("ItemId", SoType.Text, "Item Id", "Item Id")]
        public string ItemId { get; set; }

        [Attributes.Property("IdType", SoType.Text, "Id Type", "Id Type")]
        public string IdType { get; set; }

        [Attributes.Property("SearchIndex", SoType.Text, "Search Index", "Search Index")]
        public string SearchIndex { get; set; }


        // Standard Returns
        [Attributes.Property("ASIN", SoType.Text, "ASIN", "ASIN")]
        public string ASIN { get; set; }

        [Attributes.Property("ParentASIN", SoType.Text, "ParentASIN", "ParentASIN")]
        public string ParentASIN { get; set; }

        [Attributes.Property("Manufacturer", SoType.Text, "Manufacturer", "Manufacturer")]
        public string Manufacturer { get; set; }

        [Attributes.Property("ProductGroup", SoType.Text, "ProductGroup", "ProductGroup")]
        public string ProductGroup { get; set; }

        [Attributes.Property("Title", SoType.Text, "Title", "Title")]
        public string Title { get; set; }

        [Attributes.Property("DetailPageURL", SoType.Memo, "Detail Page URL", "Detail Page URL")]
        public string DetailPageURL { get; set; }


        [Attributes.Property("SmallImageUrl", SoType.Memo, "Small Image Url", "Small Image Url")]
        public string SmallImageUrl { get; set; }

        [Attributes.Property("MediumImageUrl", SoType.Memo, "Medium Image Url", "Medium Image Url")]
        public string MediumImageUrl { get; set; }

        [Attributes.Property("LargeImageUrl", SoType.Memo, "Large Image Url", "Large Image Url")]
        public string LargeImageUrl { get; set; }

        [Attributes.Property("ResultXML", SoType.Memo, "Result XML", "Result XML")]
        public string ResultXML { get; set; }

        [Attributes.Property("ErrorCode", SoType.Text, "Error Code", "Error Code")]
        public string ErrorCode { get; set; }

        [Attributes.Property("ErrorMessage", SoType.Memo, "Error Message", "Error Message")]
        public string ErrorMessage { get; set; }




        [Attributes.Property("ResultStatus", SoType.Text, "Result Status", "Result Status")]
        public string ResultStatus { get; set; }

        [Attributes.Property("ResultMessage", SoType.Text, "Result Message", "Result Message")]
        public string ResultMessage { get; set; }



        [Attributes.Method("ItemLookupByUPC", SourceCode.SmartObjects.Services.ServiceSDK.Types.MethodType.Read, "Item Lookup By UPC", "Item Lookup By UPC",
        new string[] { "ItemId" }, //required property array (no required properties for this sample)
        new string[] { "ItemId" }, //input property array (no optional input properties for this sample)
        new string[] { "ItemId", "IdType", "SearchIndex", "ASIN", "ParentASIN", "Manufacturer", "ProductGroup", "Title", "DetailPageUrl", "SmallImageUrl", "MediumImageUrl", "LargeImageUrl", "ResultXML",  "ErrorCode", "ErrorMessage", "ResultStatus", "ResultMessage" })]
        public AmazonItemLookup ItemLookupByUPC()
        {
            var settings = new Settings(ServiceConfiguration);

            try
            {
                IDictionary<string, string> query = new Dictionary<string, String>();
                query["Service"] = "AWSECommerceService";
                query["AssociateTag"] = settings.AssoicateTag;
                query["Operation"] = "ItemLookup";
                query["ItemId"] = this.ItemId;
                query["IdType"] = "UPC";
                query["ResponseGroup"] = "Images,ItemAttributes";
                query["SearchIndex"] = "All"; // needed for UPC

                var item = ExecuteItemLookup(query, settings.AWSAccessKeyId, settings.AWSSecretKey, settings.Marketplace);


                var returnItem = MapProperties(item);
                returnItem.ItemId = this.ItemId;
                returnItem.IdType = "UPC";
                returnItem.SearchIndex = "All"; //this.SearchIndex; // should come from response                

                returnItem.ResultStatus = "OK";

                return returnItem;
            }
            catch (Exception ex)
            {
                this.ResultStatus = "Exception";
                this.ResultMessage = ex.GetBaseException().Message;
                return this;
            }
        }

        private AmazonItemLookup MapProperties(ItemLookupResponse response)
        {
            AmazonItemLookup item = new AmazonItemLookup();

            if (response.Items != null && response.Items.Item != null)
            {
                item.ASIN = response.Items.Item.ASIN;
                item.ParentASIN = response.Items.Item.ParentASIN != null ? response.Items.Item.ParentASIN : "";
                item.DetailPageURL = response.Items.Item.DetailPageURL != null ? response.Items.Item.DetailPageURL : "";

                if (response.Items.Item.SmallImage != null)
                    item.SmallImageUrl = response.Items.Item.SmallImage.URL != null ? response.Items.Item.SmallImage.URL : "";
                
                if (response.Items.Item.MediumImage != null)
                    item.MediumImageUrl = response.Items.Item.MediumImage.URL != null ? response.Items.Item.MediumImage.URL : "";

                if (response.Items.Item.MediumImage != null)
                    item.LargeImageUrl = response.Items.Item.LargeImage.URL != null ? response.Items.Item.LargeImage.URL : "";

                if(response.Items.Item.ItemAttributes != null)
                {
                    item.Manufacturer = response.Items.Item.ItemAttributes.Manufacturer != null ? response.Items.Item.ItemAttributes.Manufacturer : "";
                    item.ProductGroup = response.Items.Item.ItemAttributes.ProductGroup != null ? response.Items.Item.ItemAttributes.ProductGroup : "";
                    item.Title = response.Items.Item.ItemAttributes.Title != null ? response.Items.Item.ItemAttributes.Title : "";
                }

            }

            if (response.Items != null && response.Items.Request != null && response.Items.Request.Errors != null)
            {
                item.ErrorCode = response.Items.Request.Errors.Error.Code != null ? response.Items.Request.Errors.Error.Code : "";
                item.ErrorMessage = response.Items.Request.Errors.Error.Message != null ? response.Items.Request.Errors.Error.Message : "";
            }

            // inefficient - change FetchItem
            item.ResultXML = SerializeObject(response);

            return item;
        }

        private ItemLookupResponse ExecuteItemLookup(IDictionary<string, string> query, string AWSAccessKeyId, string AWSSecretKey, string AWSMarketPlace)
        {
            String requestUrl;
            SignedRequestHelper helper = new SignedRequestHelper(AWSAccessKeyId, AWSSecretKey, AWSMarketPlace);

            requestUrl = helper.Sign(query);
            var item = FetchItem(requestUrl);

            return item;
        }


        private string SerializeObject(ItemLookupResponse toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }

        private ItemLookupResponse FetchItem(string url)
        {
            try
            {
                WebRequest request = HttpWebRequest.Create(url);
                WebResponse response = request.GetResponse();

                ItemLookupResponse item;

                XmlSerializer xs = new XmlSerializer(typeof(ItemLookupResponse));
                item = (ItemLookupResponse)xs.Deserialize(response.GetResponseStream());

                return item;

            }
            catch (Exception e)
            {
                throw e;
            }
            return null;
        }

    }
}

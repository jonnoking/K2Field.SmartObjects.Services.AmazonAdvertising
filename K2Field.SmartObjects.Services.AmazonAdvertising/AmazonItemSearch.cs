using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SourceCode.SmartObjects.Services.ServiceSDK.Objects;
using Attributes = SourceCode.SmartObjects.Services.ServiceSDK.Attributes;
using SourceCode.SmartObjects.Services.ServiceSDK.Types;
using System.Net;
using System.Xml.Serialization;
using AmazonProductAdvtApi;
using System.IO;
using System.Xml;

namespace K2Field.SmartObjects.Services.AmazonAdvertising
{
    [Attributes.ServiceObject("AmazonItemLookup", "Amazon Item Lookup", "Amazon Item Lookup")]
    public class AmazonItemSearch
    {
        public ServiceConfiguration ServiceConfiguration { get; set; }

        [Attributes.Property("ItemId", SoType.Text, "Item Id", "Item Id")]
        public string ItemId { get; set; }

        [Attributes.Property("IdType", SoType.Text, "Id Type", "Id Type")]
        public string IdType { get; set; }

        [Attributes.Property("SearchIndex", SoType.Text, "Search Index", "Search Index")]
        public string SearchIndex { get; set; }

        [Attributes.Property("Condition", SoType.Text, "Condition", "Condition")]
        public string Condition { get; set; } // All, New, Collectible, Refurbished

        [Attributes.Property("Sort", SoType.Text, "Sort", "Sort")]
        public string Sort { get; set; } // All, New, Collectible, Refurbished

        [Attributes.Property("ItemPage", SoType.Text, "Item Page", "Item Page")]
        public string ItemPage { get; set; } 

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

        [Attributes.Property("AttributeName", SoType.Text, "Attribute Name", "Attribute Name")]
        public string AttributeName { get; set; }

        [Attributes.Property("AttributeValue", SoType.Text, "Attribute Value", "Attribute Value")]
        public string AttributeValue { get; set; }



        [Attributes.Property("ErrorCode", SoType.Text, "Error Code", "Error Code")]
        public string ErrorCode { get; set; }

        [Attributes.Property("ErrorMessage", SoType.Memo, "Error Message", "Error Message")]
        public string ErrorMessage { get; set; }


        [Attributes.Property("ResultStatus", SoType.Text, "Result Status", "Result Status")]
        public string ResultStatus { get; set; }

        [Attributes.Property("ResultMessage", SoType.Text, "Result Message", "Result Message")]
        public string ResultMessage { get; set; }


        [Attributes.Method("Search", SourceCode.SmartObjects.Services.ServiceSDK.Types.MethodType.List, "Search", "Search",
        new string[] { "" }, //required property array (no required properties for this sample)
        new string[] { "" }, //input property array (no optional input properties for this sample)
        new string[] { "AttributeName", "AttributeValue" })]
        public List<AmazonItemSearch> ItemSearch()
        {
            return GetResult();
        }


        private List<AmazonItemSearch> GetResult()
        {
            var settings = new Settings(ServiceConfiguration);

            try
            {
                string searchindex = "All";
                if (!string.IsNullOrWhiteSpace(this.SearchIndex))
                {
                    searchindex = this.SearchIndex;
                }

                string condition = "All";
                if (!string.IsNullOrWhiteSpace(this.Condition))
                {
                    condition = this.Condition;
                }

                IDictionary<string, string> query = new Dictionary<string, String>();
                query["Service"] = "AWSECommerceService";
                query["AssociateTag"] = settings.AssoicateTag;
                query["Operation"] = "ItemLookup";
                query["ItemId"] = this.ItemId;
                query["IdType"] = this.IdType;
                query["ResponseGroup"] = "Images,ItemAttributes";

                if (!this.IdType.Equals("ASIN", StringComparison.OrdinalIgnoreCase))
                {
                    query["SearchIndex"] = searchindex;
                }

                query["Condition"] = condition;

                var item = ExecuteItemLookup(query, settings.AWSAccessKeyId, settings.AWSSecretKey, settings.Marketplace);

                var returnItem = MapProperties(item);
                returnItem.ItemId = this.ItemId;
                returnItem.IdType = this.IdType;
                returnItem.SearchIndex = searchindex;
                returnItem.Condition = condition;

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

        private List<AmazonItemSearch> MapProperties(ItemSearchResponse response)
        {
            List<AmazonItemSearch> items = new List<AmazonItemSearch>();

            if (response.Items != null && response.Items.Request != null && response.Items.Request.Errors != null)
            {
                throw new Exception(response.Items.Request.Errors.Error.Code + " - " + response.Items.Request.Errors.Error.Message);

                //item.ErrorCode = response.Items.Request.Errors.Error.Code != null ? response.Items.Request.Errors.Error.Code : "";
                //item.ErrorMessage = response.Items.Request.Errors.Error.Message != null ? response.Items.Request.Errors.Error.Message : "";
            }


            if (response.Items != null && response.Items.Item != null)
            {

                foreach (var resultItem in response.Items.Item)
                {
                    AmazonItemSearch item = new AmazonItemSearch();

                    item.ASIN = resultItem.ASIN;
                    item.ParentASIN = resultItem.ParentASIN != null ? resultItem.ParentASIN : "";
                    item.DetailPageURL = resultItem.DetailPageURL != null ? resultItem.DetailPageURL : "";

                    if (resultItem.SmallImage != null)
                        item.SmallImageUrl = resultItem.SmallImage.URL != null ? resultItem.SmallImage.URL : "";

                    if (resultItem.MediumImage != null)
                        item.MediumImageUrl = resultItem.MediumImage.URL != null ? resultItem.MediumImage.URL : "";

                    if (resultItem.MediumImage != null)
                        item.LargeImageUrl = resultItem.LargeImage.URL != null ? resultItem.LargeImage.URL : "";

                    if (resultItem.ItemAttributes != null)
                    {
                        item.Manufacturer = resultItem.ItemAttributes.Manufacturer != null ? resultItem.ItemAttributes.Manufacturer : "";
                        item.ProductGroup = resultItem.ItemAttributes.ProductGroup != null ? resultItem.ItemAttributes.ProductGroup : "";
                        item.Title = resultItem.ItemAttributes.Title != null ? resultItem.ItemAttributes.Title : "";
                    }
                  
                    // inefficient - change FetchItem
                    //item.ResultXML = SerializeObject(resultItem);

                    items.Add(item);
                }
            }

            return items;
        }

        private ItemSearchResponse ExecuteItemSearch(IDictionary<string, string> query, string AWSAccessKeyId, string AWSSecretKey, string AWSMarketPlace)
        {
            String requestUrl;
            SignedRequestHelper helper = new SignedRequestHelper(AWSAccessKeyId, AWSSecretKey, AWSMarketPlace);

            requestUrl = helper.Sign(query);
            var item = FetchSearchItem(requestUrl);

            return item;
        }


        private string SerializeSearchObject(ItemLookupResponse toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }

        private ItemSearchResponse FetchSearchItem(string url)
        {
            try
            {
                WebRequest request = HttpWebRequest.Create(url);
                WebResponse response = request.GetResponse();

                ItemSearchResponse item;

                XmlSerializer xs = new XmlSerializer(typeof(ItemSearchResponse));
                item = (ItemSearchResponse)xs.Deserialize(response.GetResponseStream());

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

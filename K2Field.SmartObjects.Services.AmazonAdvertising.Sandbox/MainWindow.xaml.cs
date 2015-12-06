using AmazonProductAdvtApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;

namespace K2Field.SmartObjects.Services.AmazonAdvertising.Sandbox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private const string AWSAssociateTag = "jonnoking-21";
        private const string AWSAccessKeyId = "AKIAIKFIJ445YDIFJITQ";
        private const string AWSSecretKey = "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";
        private const string AWSMarketPlace = "webservices.amazon.co.uk";

        private const string NAMESPACE = "http://webservices.amazon.com/AWSECommerceService/2011-08-01";

        private void btnLookupItem_Click(object sender, RoutedEventArgs e)
        {
        

            IDictionary<string, string> r1 = new Dictionary<string, String>();
            r1["Service"] = "AWSECommerceService";
            //r1["Version"] = "2009-03-31";
            r1["AssociateTag"] = AWSAssociateTag;
            r1["Operation"] = "ItemLookup";
            r1["ItemId"] = "B00NK3329A";
            r1["IdType"] = "ASIN";
            r1["ResponseGroup"] = "Images,ItemAttributes";
            //r1["SearchIndex"] = "All"; // UPC



            IDictionary<string, string> r2 = new Dictionary<string, String>();
            r2["Service"] = "AWSECommerceService";
            r2["AssociateTag"] = AWSAssociateTag;
            r2["Operation"] = "ItemLookup";
            r2["ItemId"] = "888462570039";
            r2["IdType"] = "UPC";
            r2["ResponseGroup"] = "Images,ItemAttributes";
            r2["SearchIndex"] = "All"; // UPC



            String requestUrl;
            SignedRequestHelper helper = new SignedRequestHelper(AWSAccessKeyId, AWSSecretKey, AWSMarketPlace);

            requestUrl = helper.Sign(r2);
            var item = FetchTitle(requestUrl);
        }

        private static ItemSearchResponse FetchSearch(string url)
        {
            try
            {
                WebRequest request = HttpWebRequest.Create(url);
                WebResponse response = request.GetResponse();
                XmlDocument doc = new XmlDocument();

                ItemSearchResponse item;

                XmlSerializer xs = new XmlSerializer(typeof(ItemSearchResponse));
                item = (ItemSearchResponse)xs.Deserialize(response.GetResponseStream());

                return item;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message);
            }
            return null;
        }

        private static ItemLookupResponse FetchTitle(string url)
        {
            try
            {
                WebRequest request = HttpWebRequest.Create(url);
                WebResponse response = request.GetResponse();
                XmlDocument doc = new XmlDocument();
                
                ItemLookupResponse item;

                XmlSerializer xs = new XmlSerializer(typeof(ItemLookupResponse));
                item = (ItemLookupResponse)xs.Deserialize(response.GetResponseStream());

                return item;
                
                //doc.Load(response.GetResponseStream());

                //XmlNodeList errorMessageNodes = doc.GetElementsByTagName("Message", NAMESPACE);
                //if (errorMessageNodes != null && errorMessageNodes.Count > 0)
                //{
                //    String message = errorMessageNodes.Item(0).InnerText;
                //    return "Error: " + message + " (but signature worked)";
                //}

                //XmlNode titleNode = doc.GetElementsByTagName("Title", NAMESPACE).Item(0);
                //string title = titleNode.InnerText;
                //return title;

                

                


            }
            catch (Exception e)
            {
                System.Console.WriteLine("Caught Exception: " + e.Message);
                System.Console.WriteLine("Stack Trace: " + e.StackTrace);
            }
            return null;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            IDictionary<string, string> r1 = new Dictionary<string, String>();
            r1["Service"] = "AWSECommerceService";
            //r1["Version"] = "2009-03-31";
            r1["AssociateTag"] = AWSAssociateTag;
            r1["Operation"] = "ItemSearch";
            r1["SearchIndex"] = "All";
            r1["Keywords"] = "iphone";
            r1["ResponseGroup"] = "Images,ItemAttributes";

            SignedRequestHelper helper = new SignedRequestHelper(AWSAccessKeyId, AWSSecretKey, AWSMarketPlace);

            String requestUrl;

            requestUrl = helper.Sign(r1);
            var item = FetchSearch(requestUrl);

            int i = 0;

        }
    }


    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01", IsNullable = false)]
    public partial class ItemLookupResponse
    {

        private ItemLookupResponseOperationRequest operationRequestField;

        private ItemLookupResponseItems itemsField;

        /// <remarks/>
        public ItemLookupResponseOperationRequest OperationRequest
        {
            get
            {
                return this.operationRequestField;
            }
            set
            {
                this.operationRequestField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItems Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseOperationRequest
    {

        private ItemLookupResponseOperationRequestHTTPHeaders hTTPHeadersField;

        private string requestIdField;

        private ItemLookupResponseOperationRequestArgument[] argumentsField;

        private decimal requestProcessingTimeField;

        /// <remarks/>
        public ItemLookupResponseOperationRequestHTTPHeaders HTTPHeaders
        {
            get
            {
                return this.hTTPHeadersField;
            }
            set
            {
                this.hTTPHeadersField = value;
            }
        }

        /// <remarks/>
        public string RequestId
        {
            get
            {
                return this.requestIdField;
            }
            set
            {
                this.requestIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Argument", IsNullable = false)]
        public ItemLookupResponseOperationRequestArgument[] Arguments
        {
            get
            {
                return this.argumentsField;
            }
            set
            {
                this.argumentsField = value;
            }
        }

        /// <remarks/>
        public decimal RequestProcessingTime
        {
            get
            {
                return this.requestProcessingTimeField;
            }
            set
            {
                this.requestProcessingTimeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseOperationRequestHTTPHeaders
    {

        private ItemLookupResponseOperationRequestHTTPHeadersHeader headerField;

        /// <remarks/>
        public ItemLookupResponseOperationRequestHTTPHeadersHeader Header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                this.headerField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseOperationRequestHTTPHeadersHeader
    {

        private string nameField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseOperationRequestArgument
    {

        private string nameField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItems
    {

        private ItemLookupResponseItemsRequest requestField;

        private ItemLookupResponseItemsItem itemField;

        /// <remarks/>
        public ItemLookupResponseItemsRequest Request
        {
            get
            {
                return this.requestField;
            }
            set
            {
                this.requestField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItem Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsRequest
    {

        private string isValidField;

        private ItemLookupResponseItemsRequestItemLookupRequest itemLookupRequestField;

        /// <remarks/>
        public string IsValid
        {
            get
            {
                return this.isValidField;
            }
            set
            {
                this.isValidField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsRequestItemLookupRequest ItemLookupRequest
        {
            get
            {
                return this.itemLookupRequestField;
            }
            set
            {
                this.itemLookupRequestField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsRequestItemLookupRequest
    {

        private string conditionField;

        private string idTypeField;

        private uint itemIdField;

        private string[] responseGroupField;

        private string searchIndexField;

        private string variationPageField;

        /// <remarks/>
        public string Condition
        {
            get
            {
                return this.conditionField;
            }
            set
            {
                this.conditionField = value;
            }
        }

        /// <remarks/>
        public string IdType
        {
            get
            {
                return this.idTypeField;
            }
            set
            {
                this.idTypeField = value;
            }
        }

        /// <remarks/>
        public uint ItemId
        {
            get
            {
                return this.itemIdField;
            }
            set
            {
                this.itemIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ResponseGroup")]
        public string[] ResponseGroup
        {
            get
            {
                return this.responseGroupField;
            }
            set
            {
                this.responseGroupField = value;
            }
        }

        /// <remarks/>
        public string SearchIndex
        {
            get
            {
                return this.searchIndexField;
            }
            set
            {
                this.searchIndexField = value;
            }
        }

        /// <remarks/>
        public string VariationPage
        {
            get
            {
                return this.variationPageField;
            }
            set
            {
                this.variationPageField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItem
    {

        private uint aSINField;

        private string detailPageURLField;

        private ItemLookupResponseItemsItemItemLink[] itemLinksField;

        private ItemLookupResponseItemsItemSmallImage smallImageField;

        private ItemLookupResponseItemsItemMediumImage mediumImageField;

        private ItemLookupResponseItemsItemLargeImage largeImageField;

        private ItemLookupResponseItemsItemImageSets imageSetsField;

        private ItemLookupResponseItemsItemItemAttributes itemAttributesField;

        private ItemLookupResponseItemsItemOfferSummary offerSummaryField;

        private ItemLookupResponseItemsItemOffers offersField;

        /// <remarks/>
        public uint ASIN
        {
            get
            {
                return this.aSINField;
            }
            set
            {
                this.aSINField = value;
            }
        }

        /// <remarks/>
        public string DetailPageURL
        {
            get
            {
                return this.detailPageURLField;
            }
            set
            {
                this.detailPageURLField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ItemLink", IsNullable = false)]
        public ItemLookupResponseItemsItemItemLink[] ItemLinks
        {
            get
            {
                return this.itemLinksField;
            }
            set
            {
                this.itemLinksField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemSmallImage SmallImage
        {
            get
            {
                return this.smallImageField;
            }
            set
            {
                this.smallImageField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemMediumImage MediumImage
        {
            get
            {
                return this.mediumImageField;
            }
            set
            {
                this.mediumImageField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemLargeImage LargeImage
        {
            get
            {
                return this.largeImageField;
            }
            set
            {
                this.largeImageField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemImageSets ImageSets
        {
            get
            {
                return this.imageSetsField;
            }
            set
            {
                this.imageSetsField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemItemAttributes ItemAttributes
        {
            get
            {
                return this.itemAttributesField;
            }
            set
            {
                this.itemAttributesField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemOfferSummary OfferSummary
        {
            get
            {
                return this.offerSummaryField;
            }
            set
            {
                this.offerSummaryField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemOffers Offers
        {
            get
            {
                return this.offersField;
            }
            set
            {
                this.offersField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemItemLink
    {

        private string descriptionField;

        private string uRLField;

        /// <remarks/>
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        public string URL
        {
            get
            {
                return this.uRLField;
            }
            set
            {
                this.uRLField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemSmallImage
    {

        private string uRLField;

        private ItemLookupResponseItemsItemSmallImageHeight heightField;

        private ItemLookupResponseItemsItemSmallImageWidth widthField;

        /// <remarks/>
        public string URL
        {
            get
            {
                return this.uRLField;
            }
            set
            {
                this.uRLField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemSmallImageHeight Height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemSmallImageWidth Width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemSmallImageHeight
    {

        private string unitsField;

        private byte valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public byte Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemSmallImageWidth
    {

        private string unitsField;

        private byte valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public byte Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemMediumImage
    {

        private string uRLField;

        private ItemLookupResponseItemsItemMediumImageHeight heightField;

        private ItemLookupResponseItemsItemMediumImageWidth widthField;

        /// <remarks/>
        public string URL
        {
            get
            {
                return this.uRLField;
            }
            set
            {
                this.uRLField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemMediumImageHeight Height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemMediumImageWidth Width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemMediumImageHeight
    {

        private string unitsField;

        private byte valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public byte Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemMediumImageWidth
    {

        private string unitsField;

        private byte valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public byte Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemLargeImage
    {

        private string uRLField;

        private ItemLookupResponseItemsItemLargeImageHeight heightField;

        private ItemLookupResponseItemsItemLargeImageWidth widthField;

        /// <remarks/>
        public string URL
        {
            get
            {
                return this.uRLField;
            }
            set
            {
                this.uRLField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemLargeImageHeight Height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemLargeImageWidth Width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemLargeImageHeight
    {

        private string unitsField;

        private ushort valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public ushort Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemLargeImageWidth
    {

        private string unitsField;

        private ushort valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public ushort Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemImageSets
    {

        private ItemLookupResponseItemsItemImageSetsImageSet imageSetField;

        /// <remarks/>
        public ItemLookupResponseItemsItemImageSetsImageSet ImageSet
        {
            get
            {
                return this.imageSetField;
            }
            set
            {
                this.imageSetField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemImageSetsImageSet
    {

        private ItemLookupResponseItemsItemImageSetsImageSetSwatchImage swatchImageField;

        private ItemLookupResponseItemsItemImageSetsImageSetSmallImage smallImageField;

        private ItemLookupResponseItemsItemImageSetsImageSetThumbnailImage thumbnailImageField;

        private ItemLookupResponseItemsItemImageSetsImageSetTinyImage tinyImageField;

        private ItemLookupResponseItemsItemImageSetsImageSetMediumImage mediumImageField;

        private ItemLookupResponseItemsItemImageSetsImageSetLargeImage largeImageField;

        private string categoryField;

        /// <remarks/>
        public ItemLookupResponseItemsItemImageSetsImageSetSwatchImage SwatchImage
        {
            get
            {
                return this.swatchImageField;
            }
            set
            {
                this.swatchImageField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemImageSetsImageSetSmallImage SmallImage
        {
            get
            {
                return this.smallImageField;
            }
            set
            {
                this.smallImageField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemImageSetsImageSetThumbnailImage ThumbnailImage
        {
            get
            {
                return this.thumbnailImageField;
            }
            set
            {
                this.thumbnailImageField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemImageSetsImageSetTinyImage TinyImage
        {
            get
            {
                return this.tinyImageField;
            }
            set
            {
                this.tinyImageField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemImageSetsImageSetMediumImage MediumImage
        {
            get
            {
                return this.mediumImageField;
            }
            set
            {
                this.mediumImageField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemImageSetsImageSetLargeImage LargeImage
        {
            get
            {
                return this.largeImageField;
            }
            set
            {
                this.largeImageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Category
        {
            get
            {
                return this.categoryField;
            }
            set
            {
                this.categoryField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemImageSetsImageSetSwatchImage
    {

        private string uRLField;

        private ItemLookupResponseItemsItemImageSetsImageSetSwatchImageHeight heightField;

        private ItemLookupResponseItemsItemImageSetsImageSetSwatchImageWidth widthField;

        /// <remarks/>
        public string URL
        {
            get
            {
                return this.uRLField;
            }
            set
            {
                this.uRLField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemImageSetsImageSetSwatchImageHeight Height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemImageSetsImageSetSwatchImageWidth Width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemImageSetsImageSetSwatchImageHeight
    {

        private string unitsField;

        private byte valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public byte Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemImageSetsImageSetSwatchImageWidth
    {

        private string unitsField;

        private byte valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public byte Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemImageSetsImageSetSmallImage
    {

        private string uRLField;

        private ItemLookupResponseItemsItemImageSetsImageSetSmallImageHeight heightField;

        private ItemLookupResponseItemsItemImageSetsImageSetSmallImageWidth widthField;

        /// <remarks/>
        public string URL
        {
            get
            {
                return this.uRLField;
            }
            set
            {
                this.uRLField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemImageSetsImageSetSmallImageHeight Height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemImageSetsImageSetSmallImageWidth Width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemImageSetsImageSetSmallImageHeight
    {

        private string unitsField;

        private byte valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public byte Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemImageSetsImageSetSmallImageWidth
    {

        private string unitsField;

        private byte valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public byte Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemImageSetsImageSetThumbnailImage
    {

        private string uRLField;

        private ItemLookupResponseItemsItemImageSetsImageSetThumbnailImageHeight heightField;

        private ItemLookupResponseItemsItemImageSetsImageSetThumbnailImageWidth widthField;

        /// <remarks/>
        public string URL
        {
            get
            {
                return this.uRLField;
            }
            set
            {
                this.uRLField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemImageSetsImageSetThumbnailImageHeight Height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemImageSetsImageSetThumbnailImageWidth Width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemImageSetsImageSetThumbnailImageHeight
    {

        private string unitsField;

        private byte valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public byte Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemImageSetsImageSetThumbnailImageWidth
    {

        private string unitsField;

        private byte valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public byte Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemImageSetsImageSetTinyImage
    {

        private string uRLField;

        private ItemLookupResponseItemsItemImageSetsImageSetTinyImageHeight heightField;

        private ItemLookupResponseItemsItemImageSetsImageSetTinyImageWidth widthField;

        /// <remarks/>
        public string URL
        {
            get
            {
                return this.uRLField;
            }
            set
            {
                this.uRLField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemImageSetsImageSetTinyImageHeight Height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemImageSetsImageSetTinyImageWidth Width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemImageSetsImageSetTinyImageHeight
    {

        private string unitsField;

        private byte valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public byte Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemImageSetsImageSetTinyImageWidth
    {

        private string unitsField;

        private byte valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public byte Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemImageSetsImageSetMediumImage
    {

        private string uRLField;

        private ItemLookupResponseItemsItemImageSetsImageSetMediumImageHeight heightField;

        private ItemLookupResponseItemsItemImageSetsImageSetMediumImageWidth widthField;

        /// <remarks/>
        public string URL
        {
            get
            {
                return this.uRLField;
            }
            set
            {
                this.uRLField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemImageSetsImageSetMediumImageHeight Height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemImageSetsImageSetMediumImageWidth Width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemImageSetsImageSetMediumImageHeight
    {

        private string unitsField;

        private byte valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public byte Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemImageSetsImageSetMediumImageWidth
    {

        private string unitsField;

        private byte valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public byte Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemImageSetsImageSetLargeImage
    {

        private string uRLField;

        private ItemLookupResponseItemsItemImageSetsImageSetLargeImageHeight heightField;

        private ItemLookupResponseItemsItemImageSetsImageSetLargeImageWidth widthField;

        /// <remarks/>
        public string URL
        {
            get
            {
                return this.uRLField;
            }
            set
            {
                this.uRLField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemImageSetsImageSetLargeImageHeight Height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemImageSetsImageSetLargeImageWidth Width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemImageSetsImageSetLargeImageHeight
    {

        private string unitsField;

        private ushort valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public ushort Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemImageSetsImageSetLargeImageWidth
    {

        private string unitsField;

        private ushort valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public ushort Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemItemAttributes
    {

        private string[] authorField;

        private string bindingField;

        private string brandField;

        private string[] catalogNumberListField;

        private ulong eANField;

        private ItemLookupResponseItemsItemItemAttributesEANList eANListField;

        private uint iSBNField;

        private ItemLookupResponseItemsItemItemAttributesItemDimensions itemDimensionsField;

        private string labelField;

        private ItemLookupResponseItemsItemItemAttributesLanguage[] languagesField;

        private ItemLookupResponseItemsItemItemAttributesListPrice listPriceField;

        private string manufacturerField;

        private byte numberOfPagesField;

        private ItemLookupResponseItemsItemItemAttributesPackageDimensions packageDimensionsField;

        private string productGroupField;

        private string productTypeNameField;

        private System.DateTime publicationDateField;

        private string publisherField;

        private System.DateTime releaseDateField;

        private string studioField;

        private string titleField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Author")]
        public string[] Author
        {
            get
            {
                return this.authorField;
            }
            set
            {
                this.authorField = value;
            }
        }

        /// <remarks/>
        public string Binding
        {
            get
            {
                return this.bindingField;
            }
            set
            {
                this.bindingField = value;
            }
        }

        /// <remarks/>
        public string Brand
        {
            get
            {
                return this.brandField;
            }
            set
            {
                this.brandField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("CatalogNumberListElement", IsNullable = false)]
        public string[] CatalogNumberList
        {
            get
            {
                return this.catalogNumberListField;
            }
            set
            {
                this.catalogNumberListField = value;
            }
        }

        /// <remarks/>
        public ulong EAN
        {
            get
            {
                return this.eANField;
            }
            set
            {
                this.eANField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemItemAttributesEANList EANList
        {
            get
            {
                return this.eANListField;
            }
            set
            {
                this.eANListField = value;
            }
        }

        /// <remarks/>
        public uint ISBN
        {
            get
            {
                return this.iSBNField;
            }
            set
            {
                this.iSBNField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemItemAttributesItemDimensions ItemDimensions
        {
            get
            {
                return this.itemDimensionsField;
            }
            set
            {
                this.itemDimensionsField = value;
            }
        }

        /// <remarks/>
        public string Label
        {
            get
            {
                return this.labelField;
            }
            set
            {
                this.labelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Language", IsNullable = false)]
        public ItemLookupResponseItemsItemItemAttributesLanguage[] Languages
        {
            get
            {
                return this.languagesField;
            }
            set
            {
                this.languagesField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemItemAttributesListPrice ListPrice
        {
            get
            {
                return this.listPriceField;
            }
            set
            {
                this.listPriceField = value;
            }
        }

        /// <remarks/>
        public string Manufacturer
        {
            get
            {
                return this.manufacturerField;
            }
            set
            {
                this.manufacturerField = value;
            }
        }

        /// <remarks/>
        public byte NumberOfPages
        {
            get
            {
                return this.numberOfPagesField;
            }
            set
            {
                this.numberOfPagesField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemItemAttributesPackageDimensions PackageDimensions
        {
            get
            {
                return this.packageDimensionsField;
            }
            set
            {
                this.packageDimensionsField = value;
            }
        }

        /// <remarks/>
        public string ProductGroup
        {
            get
            {
                return this.productGroupField;
            }
            set
            {
                this.productGroupField = value;
            }
        }

        /// <remarks/>
        public string ProductTypeName
        {
            get
            {
                return this.productTypeNameField;
            }
            set
            {
                this.productTypeNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime PublicationDate
        {
            get
            {
                return this.publicationDateField;
            }
            set
            {
                this.publicationDateField = value;
            }
        }

        /// <remarks/>
        public string Publisher
        {
            get
            {
                return this.publisherField;
            }
            set
            {
                this.publisherField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime ReleaseDate
        {
            get
            {
                return this.releaseDateField;
            }
            set
            {
                this.releaseDateField = value;
            }
        }

        /// <remarks/>
        public string Studio
        {
            get
            {
                return this.studioField;
            }
            set
            {
                this.studioField = value;
            }
        }

        /// <remarks/>
        public string Title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemItemAttributesEANList
    {

        private ulong eANListElementField;

        /// <remarks/>
        public ulong EANListElement
        {
            get
            {
                return this.eANListElementField;
            }
            set
            {
                this.eANListElementField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemItemAttributesItemDimensions
    {

        private ItemLookupResponseItemsItemItemAttributesItemDimensionsHeight heightField;

        private ItemLookupResponseItemsItemItemAttributesItemDimensionsLength lengthField;

        private ItemLookupResponseItemsItemItemAttributesItemDimensionsWeight weightField;

        private ItemLookupResponseItemsItemItemAttributesItemDimensionsWidth widthField;

        /// <remarks/>
        public ItemLookupResponseItemsItemItemAttributesItemDimensionsHeight Height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemItemAttributesItemDimensionsLength Length
        {
            get
            {
                return this.lengthField;
            }
            set
            {
                this.lengthField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemItemAttributesItemDimensionsWeight Weight
        {
            get
            {
                return this.weightField;
            }
            set
            {
                this.weightField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemItemAttributesItemDimensionsWidth Width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemItemAttributesItemDimensionsHeight
    {

        private string unitsField;

        private ushort valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public ushort Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemItemAttributesItemDimensionsLength
    {

        private string unitsField;

        private ushort valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public ushort Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemItemAttributesItemDimensionsWeight
    {

        private string unitsField;

        private byte valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public byte Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemItemAttributesItemDimensionsWidth
    {

        private string unitsField;

        private byte valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public byte Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemItemAttributesLanguage
    {

        private string nameField;

        private string typeField;

        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemItemAttributesListPrice
    {

        private ushort amountField;

        private string currencyCodeField;

        private string formattedPriceField;

        /// <remarks/>
        public ushort Amount
        {
            get
            {
                return this.amountField;
            }
            set
            {
                this.amountField = value;
            }
        }

        /// <remarks/>
        public string CurrencyCode
        {
            get
            {
                return this.currencyCodeField;
            }
            set
            {
                this.currencyCodeField = value;
            }
        }

        /// <remarks/>
        public string FormattedPrice
        {
            get
            {
                return this.formattedPriceField;
            }
            set
            {
                this.formattedPriceField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemItemAttributesPackageDimensions
    {

        private ItemLookupResponseItemsItemItemAttributesPackageDimensionsHeight heightField;

        private ItemLookupResponseItemsItemItemAttributesPackageDimensionsLength lengthField;

        private ItemLookupResponseItemsItemItemAttributesPackageDimensionsWeight weightField;

        private ItemLookupResponseItemsItemItemAttributesPackageDimensionsWidth widthField;

        /// <remarks/>
        public ItemLookupResponseItemsItemItemAttributesPackageDimensionsHeight Height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemItemAttributesPackageDimensionsLength Length
        {
            get
            {
                return this.lengthField;
            }
            set
            {
                this.lengthField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemItemAttributesPackageDimensionsWeight Weight
        {
            get
            {
                return this.weightField;
            }
            set
            {
                this.weightField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemItemAttributesPackageDimensionsWidth Width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemItemAttributesPackageDimensionsHeight
    {

        private string unitsField;

        private byte valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public byte Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemItemAttributesPackageDimensionsLength
    {

        private string unitsField;

        private ushort valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public ushort Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemItemAttributesPackageDimensionsWeight
    {

        private string unitsField;

        private byte valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public byte Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemItemAttributesPackageDimensionsWidth
    {

        private string unitsField;

        private ushort valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public ushort Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemOfferSummary
    {

        private ItemLookupResponseItemsItemOfferSummaryLowestNewPrice lowestNewPriceField;

        private ItemLookupResponseItemsItemOfferSummaryLowestUsedPrice lowestUsedPriceField;

        private byte totalNewField;

        private byte totalUsedField;

        private byte totalCollectibleField;

        private byte totalRefurbishedField;

        /// <remarks/>
        public ItemLookupResponseItemsItemOfferSummaryLowestNewPrice LowestNewPrice
        {
            get
            {
                return this.lowestNewPriceField;
            }
            set
            {
                this.lowestNewPriceField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemOfferSummaryLowestUsedPrice LowestUsedPrice
        {
            get
            {
                return this.lowestUsedPriceField;
            }
            set
            {
                this.lowestUsedPriceField = value;
            }
        }

        /// <remarks/>
        public byte TotalNew
        {
            get
            {
                return this.totalNewField;
            }
            set
            {
                this.totalNewField = value;
            }
        }

        /// <remarks/>
        public byte TotalUsed
        {
            get
            {
                return this.totalUsedField;
            }
            set
            {
                this.totalUsedField = value;
            }
        }

        /// <remarks/>
        public byte TotalCollectible
        {
            get
            {
                return this.totalCollectibleField;
            }
            set
            {
                this.totalCollectibleField = value;
            }
        }

        /// <remarks/>
        public byte TotalRefurbished
        {
            get
            {
                return this.totalRefurbishedField;
            }
            set
            {
                this.totalRefurbishedField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemOfferSummaryLowestNewPrice
    {

        private byte amountField;

        private string currencyCodeField;

        private string formattedPriceField;

        /// <remarks/>
        public byte Amount
        {
            get
            {
                return this.amountField;
            }
            set
            {
                this.amountField = value;
            }
        }

        /// <remarks/>
        public string CurrencyCode
        {
            get
            {
                return this.currencyCodeField;
            }
            set
            {
                this.currencyCodeField = value;
            }
        }

        /// <remarks/>
        public string FormattedPrice
        {
            get
            {
                return this.formattedPriceField;
            }
            set
            {
                this.formattedPriceField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemOfferSummaryLowestUsedPrice
    {

        private ushort amountField;

        private string currencyCodeField;

        private string formattedPriceField;

        /// <remarks/>
        public ushort Amount
        {
            get
            {
                return this.amountField;
            }
            set
            {
                this.amountField = value;
            }
        }

        /// <remarks/>
        public string CurrencyCode
        {
            get
            {
                return this.currencyCodeField;
            }
            set
            {
                this.currencyCodeField = value;
            }
        }

        /// <remarks/>
        public string FormattedPrice
        {
            get
            {
                return this.formattedPriceField;
            }
            set
            {
                this.formattedPriceField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemOffers
    {

        private byte totalOffersField;

        private byte totalOfferPagesField;

        private string moreOffersUrlField;

        private ItemLookupResponseItemsItemOffersOffer offerField;

        /// <remarks/>
        public byte TotalOffers
        {
            get
            {
                return this.totalOffersField;
            }
            set
            {
                this.totalOffersField = value;
            }
        }

        /// <remarks/>
        public byte TotalOfferPages
        {
            get
            {
                return this.totalOfferPagesField;
            }
            set
            {
                this.totalOfferPagesField = value;
            }
        }

        /// <remarks/>
        public string MoreOffersUrl
        {
            get
            {
                return this.moreOffersUrlField;
            }
            set
            {
                this.moreOffersUrlField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemOffersOffer Offer
        {
            get
            {
                return this.offerField;
            }
            set
            {
                this.offerField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemOffersOffer
    {

        private ItemLookupResponseItemsItemOffersOfferOfferAttributes offerAttributesField;

        private ItemLookupResponseItemsItemOffersOfferOfferListing offerListingField;

        /// <remarks/>
        public ItemLookupResponseItemsItemOffersOfferOfferAttributes OfferAttributes
        {
            get
            {
                return this.offerAttributesField;
            }
            set
            {
                this.offerAttributesField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemOffersOfferOfferListing OfferListing
        {
            get
            {
                return this.offerListingField;
            }
            set
            {
                this.offerListingField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemOffersOfferOfferAttributes
    {

        private string conditionField;

        /// <remarks/>
        public string Condition
        {
            get
            {
                return this.conditionField;
            }
            set
            {
                this.conditionField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemOffersOfferOfferListing
    {

        private string offerListingIdField;

        private ItemLookupResponseItemsItemOffersOfferOfferListingPrice priceField;

        private ItemLookupResponseItemsItemOffersOfferOfferListingAmountSaved amountSavedField;

        private byte percentageSavedField;

        private string availabilityField;

        private ItemLookupResponseItemsItemOffersOfferOfferListingAvailabilityAttributes availabilityAttributesField;

        private byte isEligibleForSuperSaverShippingField;

        private byte isEligibleForPrimeField;

        /// <remarks/>
        public string OfferListingId
        {
            get
            {
                return this.offerListingIdField;
            }
            set
            {
                this.offerListingIdField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemOffersOfferOfferListingPrice Price
        {
            get
            {
                return this.priceField;
            }
            set
            {
                this.priceField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemOffersOfferOfferListingAmountSaved AmountSaved
        {
            get
            {
                return this.amountSavedField;
            }
            set
            {
                this.amountSavedField = value;
            }
        }

        /// <remarks/>
        public byte PercentageSaved
        {
            get
            {
                return this.percentageSavedField;
            }
            set
            {
                this.percentageSavedField = value;
            }
        }

        /// <remarks/>
        public string Availability
        {
            get
            {
                return this.availabilityField;
            }
            set
            {
                this.availabilityField = value;
            }
        }

        /// <remarks/>
        public ItemLookupResponseItemsItemOffersOfferOfferListingAvailabilityAttributes AvailabilityAttributes
        {
            get
            {
                return this.availabilityAttributesField;
            }
            set
            {
                this.availabilityAttributesField = value;
            }
        }

        /// <remarks/>
        public byte IsEligibleForSuperSaverShipping
        {
            get
            {
                return this.isEligibleForSuperSaverShippingField;
            }
            set
            {
                this.isEligibleForSuperSaverShippingField = value;
            }
        }

        /// <remarks/>
        public byte IsEligibleForPrime
        {
            get
            {
                return this.isEligibleForPrimeField;
            }
            set
            {
                this.isEligibleForPrimeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemOffersOfferOfferListingPrice
    {

        private byte amountField;

        private string currencyCodeField;

        private string formattedPriceField;

        /// <remarks/>
        public byte Amount
        {
            get
            {
                return this.amountField;
            }
            set
            {
                this.amountField = value;
            }
        }

        /// <remarks/>
        public string CurrencyCode
        {
            get
            {
                return this.currencyCodeField;
            }
            set
            {
                this.currencyCodeField = value;
            }
        }

        /// <remarks/>
        public string FormattedPrice
        {
            get
            {
                return this.formattedPriceField;
            }
            set
            {
                this.formattedPriceField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemOffersOfferOfferListingAmountSaved
    {

        private ushort amountField;

        private string currencyCodeField;

        private string formattedPriceField;

        /// <remarks/>
        public ushort Amount
        {
            get
            {
                return this.amountField;
            }
            set
            {
                this.amountField = value;
            }
        }

        /// <remarks/>
        public string CurrencyCode
        {
            get
            {
                return this.currencyCodeField;
            }
            set
            {
                this.currencyCodeField = value;
            }
        }

        /// <remarks/>
        public string FormattedPrice
        {
            get
            {
                return this.formattedPriceField;
            }
            set
            {
                this.formattedPriceField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemLookupResponseItemsItemOffersOfferOfferListingAvailabilityAttributes
    {

        private string availabilityTypeField;

        private byte minimumHoursField;

        private byte maximumHoursField;

        /// <remarks/>
        public string AvailabilityType
        {
            get
            {
                return this.availabilityTypeField;
            }
            set
            {
                this.availabilityTypeField = value;
            }
        }

        /// <remarks/>
        public byte MinimumHours
        {
            get
            {
                return this.minimumHoursField;
            }
            set
            {
                this.minimumHoursField = value;
            }
        }

        /// <remarks/>
        public byte MaximumHours
        {
            get
            {
                return this.maximumHoursField;
            }
            set
            {
                this.maximumHoursField = value;
            }
        }
    }


}

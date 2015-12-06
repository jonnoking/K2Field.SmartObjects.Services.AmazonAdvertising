using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2Field.SmartObjects.Services.AmazonAdvertising
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01", IsNullable = false)]
    public partial class ItemSearchResponse
    {

        private ItemSearchResponseOperationRequest operationRequestField;

        private ItemSearchResponseItems itemsField;

        /// <remarks/>
        public ItemSearchResponseOperationRequest OperationRequest
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
        public ItemSearchResponseItems Items
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
    public partial class ItemSearchResponseOperationRequest
    {

        private ItemSearchResponseOperationRequestHTTPHeaders hTTPHeadersField;

        private string requestIdField;

        private ItemSearchResponseOperationRequestArgument[] argumentsField;

        private decimal requestProcessingTimeField;

        /// <remarks/>
        public ItemSearchResponseOperationRequestHTTPHeaders HTTPHeaders
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
        public ItemSearchResponseOperationRequestArgument[] Arguments
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
    public partial class ItemSearchResponseOperationRequestHTTPHeaders
    {

        private ItemSearchResponseOperationRequestHTTPHeadersHeader headerField;

        /// <remarks/>
        public ItemSearchResponseOperationRequestHTTPHeadersHeader Header
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
    public partial class ItemSearchResponseOperationRequestHTTPHeadersHeader
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
    public partial class ItemSearchResponseOperationRequestArgument
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
    public partial class ItemSearchResponseItems
    {

        private ItemSearchResponseItemsRequest requestField;

        private ulong totalResultsField;

        private ulong totalPagesField;

        private string moreSearchResultsUrlField;

        private ItemSearchResponseItemsItem[] itemField;


        /// <remarks/>
        public ItemSearchResponseItemsRequest Request
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
        public ulong TotalResults
        {
            get
            {
                return this.totalResultsField;
            }
            set
            {
                this.totalResultsField = value;
            }
        }

        /// <remarks/>
        public ulong TotalPages
        {
            get
            {
                return this.totalPagesField;
            }
            set
            {
                this.totalPagesField = value;
            }
        }

        /// <remarks/>
        public string MoreSearchResultsUrl
        {
            get
            {
                return this.moreSearchResultsUrlField;
            }
            set
            {
                this.moreSearchResultsUrlField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Item")]
        public ItemSearchResponseItemsItem[] Item
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
    public partial class ItemSearchResponseItemsRequestErrors
    {

        private ItemSearchResponseItemsRequestErrorsError errorField;

        /// <remarks/>
        public ItemSearchResponseItemsRequestErrorsError Error
        {
            get
            {
                return this.errorField;
            }
            set
            {
                this.errorField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsRequestErrorsError
    {

        private string codeField;

        private string messageField;

        /// <remarks/>
        public string Code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }

        /// <remarks/>
        public string Message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }
    }


    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsRequest
    {

        private string isValidField;

        private ItemSearchResponseItemsRequestErrors errorsField;

        private ItemSearchResponseItemsRequestItemSearchRequest itemSearchRequestField;

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

        public ItemSearchResponseItemsRequestErrors Errors
        {
            get
            {
                return this.errorsField;
            }
            set
            {
                this.errorsField = value;
            }
        }

        /// <remarks/>
        public ItemSearchResponseItemsRequestItemSearchRequest ItemSearchRequest
        {
            get
            {
                return this.itemSearchRequestField;
            }
            set
            {
                this.itemSearchRequestField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsRequestItemSearchRequest
    {

        private string keywordsField;

        private string[] responseGroupField;

        private string searchIndexField;

        private string sortField;

        /// <remarks/>
        public string Keywords
        {
            get
            {
                return this.keywordsField;
            }
            set
            {
                this.keywordsField = value;
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
        public string Sort
        {
            get
            {
                return this.sortField;
            }
            set
            {
                this.sortField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItem
    {

        private string aSINField;

        private string parentASINField;

        private string detailPageURLField;

        private ItemSearchResponseItemsItemItemLink[] itemLinksField;

        private ItemSearchResponseItemsItemSmallImage smallImageField;

        private ItemSearchResponseItemsItemMediumImage mediumImageField;

        private ItemSearchResponseItemsItemLargeImage largeImageField;

        private ItemSearchResponseItemsItemImageSet[] imageSetsField;

        private ItemSearchResponseItemsItemItemAttributes itemAttributesField;

        private ItemSearchResponseItemsItemOfferSummary offerSummaryField;

        private ItemSearchResponseItemsItemOffers offersField;

        /// <remarks/>
        public string ASIN
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
        public string ParentASIN
        {
            get
            {
                return this.parentASINField;
            }
            set
            {
                this.parentASINField = value;
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
        public ItemSearchResponseItemsItemItemLink[] ItemLinks
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
        public ItemSearchResponseItemsItemSmallImage SmallImage
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
        public ItemSearchResponseItemsItemMediumImage MediumImage
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
        public ItemSearchResponseItemsItemLargeImage LargeImage
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
        [System.Xml.Serialization.XmlArrayItemAttribute("ImageSet", IsNullable = false)]
        public ItemSearchResponseItemsItemImageSet[] ImageSets
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
        public ItemSearchResponseItemsItemItemAttributes ItemAttributes
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
        public ItemSearchResponseItemsItemOfferSummary OfferSummary
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
        public ItemSearchResponseItemsItemOffers Offers
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
    public partial class ItemSearchResponseItemsItemItemLink
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
    public partial class ItemSearchResponseItemsItemSmallImage
    {

        private string uRLField;

        private ItemSearchResponseItemsItemSmallImageHeight heightField;

        private ItemSearchResponseItemsItemSmallImageWidth widthField;

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
        public ItemSearchResponseItemsItemSmallImageHeight Height
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
        public ItemSearchResponseItemsItemSmallImageWidth Width
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
    public partial class ItemSearchResponseItemsItemSmallImageHeight
    {

        private string unitsField;

        private ulong valueField;

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
        public ulong Value
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
    public partial class ItemSearchResponseItemsItemSmallImageWidth
    {

        private string unitsField;

        private ulong valueField;

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
        public ulong Value
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
    public partial class ItemSearchResponseItemsItemMediumImage
    {

        private string uRLField;

        private ItemSearchResponseItemsItemMediumImageHeight heightField;

        private ItemSearchResponseItemsItemMediumImageWidth widthField;

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
        public ItemSearchResponseItemsItemMediumImageHeight Height
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
        public ItemSearchResponseItemsItemMediumImageWidth Width
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
    public partial class ItemSearchResponseItemsItemMediumImageHeight
    {

        private string unitsField;

        private ulong valueField;

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
        public ulong Value
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
    public partial class ItemSearchResponseItemsItemMediumImageWidth
    {

        private string unitsField;

        private ulong valueField;

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
        public ulong Value
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
    public partial class ItemSearchResponseItemsItemLargeImage
    {

        private string uRLField;

        private ItemSearchResponseItemsItemLargeImageHeight heightField;

        private ItemSearchResponseItemsItemLargeImageWidth widthField;

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
        public ItemSearchResponseItemsItemLargeImageHeight Height
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
        public ItemSearchResponseItemsItemLargeImageWidth Width
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
    public partial class ItemSearchResponseItemsItemLargeImageHeight
    {

        private string unitsField;

        private ulong valueField;

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
        public ulong Value
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
    public partial class ItemSearchResponseItemsItemLargeImageWidth
    {

        private string unitsField;

        private ulong valueField;

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
        public ulong Value
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
    public partial class ItemSearchResponseItemsItemImageSet
    {

        private ItemSearchResponseItemsItemImageSetSwatchImage swatchImageField;

        private ItemSearchResponseItemsItemImageSetSmallImage smallImageField;

        private ItemSearchResponseItemsItemImageSetThumbnailImage thumbnailImageField;

        private ItemSearchResponseItemsItemImageSetTinyImage tinyImageField;

        private ItemSearchResponseItemsItemImageSetMediumImage mediumImageField;

        private ItemSearchResponseItemsItemImageSetLargeImage largeImageField;

        private string categoryField;

        /// <remarks/>
        public ItemSearchResponseItemsItemImageSetSwatchImage SwatchImage
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
        public ItemSearchResponseItemsItemImageSetSmallImage SmallImage
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
        public ItemSearchResponseItemsItemImageSetThumbnailImage ThumbnailImage
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
        public ItemSearchResponseItemsItemImageSetTinyImage TinyImage
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
        public ItemSearchResponseItemsItemImageSetMediumImage MediumImage
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
        public ItemSearchResponseItemsItemImageSetLargeImage LargeImage
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
    public partial class ItemSearchResponseItemsItemImageSetSwatchImage
    {

        private string uRLField;

        private ItemSearchResponseItemsItemImageSetSwatchImageHeight heightField;

        private ItemSearchResponseItemsItemImageSetSwatchImageWidth widthField;

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
        public ItemSearchResponseItemsItemImageSetSwatchImageHeight Height
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
        public ItemSearchResponseItemsItemImageSetSwatchImageWidth Width
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
    public partial class ItemSearchResponseItemsItemImageSetSwatchImageHeight
    {

        private string unitsField;

        private ulong valueField;

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
        public ulong Value
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
    public partial class ItemSearchResponseItemsItemImageSetSwatchImageWidth
    {

        private string unitsField;

        private ulong valueField;

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
        public ulong Value
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
    public partial class ItemSearchResponseItemsItemImageSetSmallImage
    {

        private string uRLField;

        private ItemSearchResponseItemsItemImageSetSmallImageHeight heightField;

        private ItemSearchResponseItemsItemImageSetSmallImageWidth widthField;

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
        public ItemSearchResponseItemsItemImageSetSmallImageHeight Height
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
        public ItemSearchResponseItemsItemImageSetSmallImageWidth Width
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
    public partial class ItemSearchResponseItemsItemImageSetSmallImageHeight
    {

        private string unitsField;

        private ulong valueField;

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
        public ulong Value
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
    public partial class ItemSearchResponseItemsItemImageSetSmallImageWidth
    {

        private string unitsField;

        private ulong valueField;

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
        public ulong Value
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
    public partial class ItemSearchResponseItemsItemImageSetThumbnailImage
    {

        private string uRLField;

        private ItemSearchResponseItemsItemImageSetThumbnailImageHeight heightField;

        private ItemSearchResponseItemsItemImageSetThumbnailImageWidth widthField;

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
        public ItemSearchResponseItemsItemImageSetThumbnailImageHeight Height
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
        public ItemSearchResponseItemsItemImageSetThumbnailImageWidth Width
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
    public partial class ItemSearchResponseItemsItemImageSetThumbnailImageHeight
    {

        private string unitsField;

        private ulong valueField;

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
        public ulong Value
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
    public partial class ItemSearchResponseItemsItemImageSetThumbnailImageWidth
    {

        private string unitsField;

        private ulong valueField;

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
        public ulong Value
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
    public partial class ItemSearchResponseItemsItemImageSetTinyImage
    {

        private string uRLField;

        private ItemSearchResponseItemsItemImageSetTinyImageHeight heightField;

        private ItemSearchResponseItemsItemImageSetTinyImageWidth widthField;

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
        public ItemSearchResponseItemsItemImageSetTinyImageHeight Height
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
        public ItemSearchResponseItemsItemImageSetTinyImageWidth Width
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
    public partial class ItemSearchResponseItemsItemImageSetTinyImageHeight
    {

        private string unitsField;

        private ulong valueField;

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
        public ulong Value
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
    public partial class ItemSearchResponseItemsItemImageSetTinyImageWidth
    {

        private string unitsField;

        private ulong valueField;

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
        public ulong Value
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
    public partial class ItemSearchResponseItemsItemImageSetMediumImage
    {

        private string uRLField;

        private ItemSearchResponseItemsItemImageSetMediumImageHeight heightField;

        private ItemSearchResponseItemsItemImageSetMediumImageWidth widthField;

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
        public ItemSearchResponseItemsItemImageSetMediumImageHeight Height
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
        public ItemSearchResponseItemsItemImageSetMediumImageWidth Width
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
    public partial class ItemSearchResponseItemsItemImageSetMediumImageHeight
    {

        private string unitsField;

        private ulong valueField;

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
        public ulong Value
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
    public partial class ItemSearchResponseItemsItemImageSetMediumImageWidth
    {

        private string unitsField;

        private ulong valueField;

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
        public ulong Value
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
    public partial class ItemSearchResponseItemsItemImageSetLargeImage
    {

        private string uRLField;

        private ItemSearchResponseItemsItemImageSetLargeImageHeight heightField;

        private ItemSearchResponseItemsItemImageSetLargeImageWidth widthField;

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
        public ItemSearchResponseItemsItemImageSetLargeImageHeight Height
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
        public ItemSearchResponseItemsItemImageSetLargeImageWidth Width
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
    public partial class ItemSearchResponseItemsItemImageSetLargeImageHeight
    {

        private string unitsField;

        private ulong valueField;

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
        public ulong Value
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
    public partial class ItemSearchResponseItemsItemImageSetLargeImageWidth
    {

        private string unitsField;

        private ulong valueField;

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
        public ulong Value
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
    public partial class ItemSearchResponseItemsItemItemAttributes
    {

        private string bindingField;

        private string brandField;

        private string colorField;

        private ulong eANField;

        private ulong[] eANListField;

        private string[] featureField;

        private string labelField;

        private string legalDisclaimerField;

        private ItemSearchResponseItemsItemItemAttributesListPrice listPriceField;

        private string manufacturerField;

        private string modelField;

        private string mPNField;

        private string operatingSystemField;

        private ulong numberOfItemsField;

        private bool numberOfItemsFieldSpecified;

        private ItemSearchResponseItemsItemItemAttributesPackageDimensions packageDimensionsField;

        private ulong packageQuantityField;

        private string partNumberField;

        private string productGroupField;

        private string productTypeNameField;

        private string publisherField;

        private System.DateTime releaseDateField;

        private bool releaseDateFieldSpecified;

        private string sizeField;

        private string sKUField;

        private string studioField;

        private string titleField;

        private ulong uPCField;

        private bool uPCFieldSpecified;

        private ItemSearchResponseItemsItemItemAttributesUPCList uPCListField;

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
        public string Color
        {
            get
            {
                return this.colorField;
            }
            set
            {
                this.colorField = value;
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
        [System.Xml.Serialization.XmlArrayItemAttribute("EANListElement", IsNullable = false)]
        public ulong[] EANList
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
        [System.Xml.Serialization.XmlElementAttribute("Feature")]
        public string[] Feature
        {
            get
            {
                return this.featureField;
            }
            set
            {
                this.featureField = value;
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
        public string LegalDisclaimer
        {
            get
            {
                return this.legalDisclaimerField;
            }
            set
            {
                this.legalDisclaimerField = value;
            }
        }

        /// <remarks/>
        public ItemSearchResponseItemsItemItemAttributesListPrice ListPrice
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
        public string Model
        {
            get
            {
                return this.modelField;
            }
            set
            {
                this.modelField = value;
            }
        }

        /// <remarks/>
        public string MPN
        {
            get
            {
                return this.mPNField;
            }
            set
            {
                this.mPNField = value;
            }
        }

        /// <remarks/>
        public string OperatingSystem
        {
            get
            {
                return this.operatingSystemField;
            }
            set
            {
                this.operatingSystemField = value;
            }
        }

        /// <remarks/>
        public ulong NumberOfItems
        {
            get
            {
                return this.numberOfItemsField;
            }
            set
            {
                this.numberOfItemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumberOfItemsSpecified
        {
            get
            {
                return this.numberOfItemsFieldSpecified;
            }
            set
            {
                this.numberOfItemsFieldSpecified = value;
            }
        }

        /// <remarks/>
        public ItemSearchResponseItemsItemItemAttributesPackageDimensions PackageDimensions
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
        public ulong PackageQuantity
        {
            get
            {
                return this.packageQuantityField;
            }
            set
            {
                this.packageQuantityField = value;
            }
        }

        /// <remarks/>
        public string PartNumber
        {
            get
            {
                return this.partNumberField;
            }
            set
            {
                this.partNumberField = value;
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReleaseDateSpecified
        {
            get
            {
                return this.releaseDateFieldSpecified;
            }
            set
            {
                this.releaseDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string Size
        {
            get
            {
                return this.sizeField;
            }
            set
            {
                this.sizeField = value;
            }
        }

        /// <remarks/>
        public string SKU
        {
            get
            {
                return this.sKUField;
            }
            set
            {
                this.sKUField = value;
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

        /// <remarks/>
        public ulong UPC
        {
            get
            {
                return this.uPCField;
            }
            set
            {
                this.uPCField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool UPCSpecified
        {
            get
            {
                return this.uPCFieldSpecified;
            }
            set
            {
                this.uPCFieldSpecified = value;
            }
        }

        /// <remarks/>
        public ItemSearchResponseItemsItemItemAttributesUPCList UPCList
        {
            get
            {
                return this.uPCListField;
            }
            set
            {
                this.uPCListField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemItemAttributesListPrice
    {

        private ulong amountField;

        private string currencyCodeField;

        private string formattedPriceField;

        /// <remarks/>
        public ulong Amount
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
    public partial class ItemSearchResponseItemsItemItemAttributesPackageDimensions
    {

        private ItemSearchResponseItemsItemItemAttributesPackageDimensionsHeight heightField;

        private ItemSearchResponseItemsItemItemAttributesPackageDimensionsLength lengthField;

        private ItemSearchResponseItemsItemItemAttributesPackageDimensionsWeight weightField;

        private ItemSearchResponseItemsItemItemAttributesPackageDimensionsWidth widthField;

        /// <remarks/>
        public ItemSearchResponseItemsItemItemAttributesPackageDimensionsHeight Height
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
        public ItemSearchResponseItemsItemItemAttributesPackageDimensionsLength Length
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
        public ItemSearchResponseItemsItemItemAttributesPackageDimensionsWeight Weight
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
        public ItemSearchResponseItemsItemItemAttributesPackageDimensionsWidth Width
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
    public partial class ItemSearchResponseItemsItemItemAttributesPackageDimensionsHeight
    {

        private string unitsField;

        private ulong valueField;

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
        public ulong Value
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
    public partial class ItemSearchResponseItemsItemItemAttributesPackageDimensionsLength
    {

        private string unitsField;

        private ulong valueField;

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
        public ulong Value
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
    public partial class ItemSearchResponseItemsItemItemAttributesPackageDimensionsWeight
    {

        private string unitsField;

        private ulong valueField;

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
        public ulong Value
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
    public partial class ItemSearchResponseItemsItemItemAttributesPackageDimensionsWidth
    {

        private string unitsField;

        private ulong valueField;

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
        public ulong Value
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
    public partial class ItemSearchResponseItemsItemItemAttributesUPCList
    {

        private ulong uPCListElementField;

        /// <remarks/>
        public ulong UPCListElement
        {
            get
            {
                return this.uPCListElementField;
            }
            set
            {
                this.uPCListElementField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
    public partial class ItemSearchResponseItemsItemOfferSummary
    {

        private ItemSearchResponseItemsItemOfferSummaryLowestNewPrice lowestNewPriceField;

        private ItemSearchResponseItemsItemOfferSummaryLowestUsedPrice lowestUsedPriceField;

        private ulong totalNewField;

        private ulong totalUsedField;

        private ulong totalCollectibleField;

        private ulong totalRefurbishedField;

        /// <remarks/>
        public ItemSearchResponseItemsItemOfferSummaryLowestNewPrice LowestNewPrice
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
        public ItemSearchResponseItemsItemOfferSummaryLowestUsedPrice LowestUsedPrice
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
        public ulong TotalNew
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
        public ulong TotalUsed
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
        public ulong TotalCollectible
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
        public ulong TotalRefurbished
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
    public partial class ItemSearchResponseItemsItemOfferSummaryLowestNewPrice
    {

        private ulong amountField;

        private string currencyCodeField;

        private string formattedPriceField;

        /// <remarks/>
        public ulong Amount
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
    public partial class ItemSearchResponseItemsItemOfferSummaryLowestUsedPrice
    {

        private ulong amountField;

        private string currencyCodeField;

        private string formattedPriceField;

        /// <remarks/>
        public ulong Amount
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
    public partial class ItemSearchResponseItemsItemOffers
    {

        private ulong totalOffersField;

        private ulong totalOfferPagesField;

        private string moreOffersUrlField;

        private ItemSearchResponseItemsItemOffersOffer offerField;

        /// <remarks/>
        public ulong TotalOffers
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
        public ulong TotalOfferPages
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
        public ItemSearchResponseItemsItemOffersOffer Offer
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
    public partial class ItemSearchResponseItemsItemOffersOffer
    {

        private ItemSearchResponseItemsItemOffersOfferOfferAttributes offerAttributesField;

        private ItemSearchResponseItemsItemOffersOfferOfferListing offerListingField;

        /// <remarks/>
        public ItemSearchResponseItemsItemOffersOfferOfferAttributes OfferAttributes
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
        public ItemSearchResponseItemsItemOffersOfferOfferListing OfferListing
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
    public partial class ItemSearchResponseItemsItemOffersOfferOfferAttributes
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
    public partial class ItemSearchResponseItemsItemOffersOfferOfferListing
    {

        private string offerListingIdField;

        private ItemSearchResponseItemsItemOffersOfferOfferListingPrice priceField;

        private ItemSearchResponseItemsItemOffersOfferOfferListingSalePrice salePriceField;

        private ItemSearchResponseItemsItemOffersOfferOfferListingAmountSaved amountSavedField;

        private ulong percentageSavedField;

        private bool percentageSavedFieldSpecified;

        private string availabilityField;

        private ItemSearchResponseItemsItemOffersOfferOfferListingAvailabilityAttributes availabilityAttributesField;

        private ulong isEligibleForSuperSaverShippingField;

        private ulong isEligibleForPrimeField;

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
        public ItemSearchResponseItemsItemOffersOfferOfferListingPrice Price
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
        public ItemSearchResponseItemsItemOffersOfferOfferListingSalePrice SalePrice
        {
            get
            {
                return this.salePriceField;
            }
            set
            {
                this.salePriceField = value;
            }
        }

        /// <remarks/>
        public ItemSearchResponseItemsItemOffersOfferOfferListingAmountSaved AmountSaved
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
        public ulong PercentageSaved
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PercentageSavedSpecified
        {
            get
            {
                return this.percentageSavedFieldSpecified;
            }
            set
            {
                this.percentageSavedFieldSpecified = value;
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
        public ItemSearchResponseItemsItemOffersOfferOfferListingAvailabilityAttributes AvailabilityAttributes
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
        public ulong IsEligibleForSuperSaverShipping
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
        public ulong IsEligibleForPrime
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
    public partial class ItemSearchResponseItemsItemOffersOfferOfferListingPrice
    {

        private ulong amountField;

        private string currencyCodeField;

        private string formattedPriceField;

        /// <remarks/>
        public ulong Amount
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
    public partial class ItemSearchResponseItemsItemOffersOfferOfferListingSalePrice
    {

        private ulong amountField;

        private string currencyCodeField;

        private string formattedPriceField;

        /// <remarks/>
        public ulong Amount
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
    public partial class ItemSearchResponseItemsItemOffersOfferOfferListingAmountSaved
    {

        private ulong amountField;

        private string currencyCodeField;

        private string formattedPriceField;

        /// <remarks/>
        public ulong Amount
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
    public partial class ItemSearchResponseItemsItemOffersOfferOfferListingAvailabilityAttributes
    {

        private string availabilityTypeField;

        private ulong minimumHoursField;

        private ulong maximumHoursField;

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
        public ulong MinimumHours
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
        public ulong MaximumHours
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

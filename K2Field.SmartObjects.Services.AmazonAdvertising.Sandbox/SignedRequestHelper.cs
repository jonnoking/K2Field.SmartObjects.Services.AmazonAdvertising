/**********************************************************************************************
 * Copyright 2009 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License"). You may not use this file 
 * except in compliance with the License. A copy of the License is located at
 *
 *       http://aws.amazon.com/apache2.0/
 *
 * or in the "LICENSE.txt" file accompanying this file. This file is distributed on an "AS IS"
 * BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations under the License. 
 *
 * ********************************************************************************************
 *
 *  Amazon Product Advertising API
 *  Signed Requests Sample Code
 *
 *  API Version: 2009-03-31
 *
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Security.Cryptography;

namespace AmazonProductAdvtApi
{
    class SignedRequestHelper
    {
        private string endPoint;
        private string akid;
        private byte[] secret;
        private HMAC signer;

        private const string REQUEST_URI = "/onca/xml";
        private const string REQUEST_METHOD = "GET";

        /*
         * Use this constructor to create the object. The AWS credentials are available on
         * http://aws.amazon.com
         * 
         * The destination is the service end-point for your application:
         *  US: ecs.amazonaws.com
         *  JP: ecs.amazonaws.jp
         *  UK: ecs.amazonaws.co.uk
         *  DE: ecs.amazonaws.de
         *  FR: ecs.amazonaws.fr
         *  CA: ecs.amazonaws.ca
         */
        public SignedRequestHelper(string awsAccessKeyId, string awsSecretKey, string destination)
        {
            this.endPoint = destination.ToLower();
            this.akid = awsAccessKeyId;
            this.secret = Encoding.UTF8.GetBytes(awsSecretKey);
            this.signer = new HMACSHA256(this.secret);
        }

        /*
         * Sign a request in the form of a Dictionary of name-value pairs.
         * 
         * This method returns a complete URL to use. Modifying the returned URL
         * in any way invalidates the signature and Amazon will reject the requests.
         */
        public string Sign(IDictionary<string, string> request)
        {
            // Use a SortedDictionary to get the parameters in naturual byte order, as
            // required by AWS.
            ParamComparer pc = new ParamComparer();
            SortedDictionary<string, string> sortedMap = new SortedDictionary<string, string>(request, pc);

            // Add the AWSAccessKeyId and Timestamp to the requests.
            sortedMap["AWSAccessKeyId"] = this.akid;
            sortedMap["Timestamp"] = this.GetTimestamp();

            // Get the canonical query string
            string canonicalQS = this.ConstructCanonicalQueryString(sortedMap);

            // Derive the bytes needs to be signed.
            StringBuilder builder = new StringBuilder();
            builder.Append(REQUEST_METHOD)
                .Append("\n")
                .Append(this.endPoint)
                .Append("\n")
                .Append(REQUEST_URI)
                .Append("\n")
                .Append(canonicalQS);

            string stringToSign = builder.ToString();
            byte[] toSign = Encoding.UTF8.GetBytes(stringToSign);

            // Compute the signature and convert to Base64.
            byte[] sigBytes = signer.ComputeHash(toSign);
            string signature = Convert.ToBase64String(sigBytes);
            
            // now construct the complete URL and return to caller.
            StringBuilder qsBuilder = new StringBuilder();
            qsBuilder.Append("http://")
                .Append(this.endPoint)
                .Append(REQUEST_URI)
                .Append("?")
                .Append(canonicalQS)
                .Append("&Signature=")
                .Append(this.PercentEncodeRfc3986(signature));

            return qsBuilder.ToString();
        }

        /*
         * Sign a request in the form of a query string.
         * 
         * This method returns a complete URL to use. Modifying the returned URL
         * in any way invalidates the signature and Amazon will reject the requests.
         */
        public string Sign(string queryString)
        {
            IDictionary<string, string> request = this.CreateDictionary(queryString);
            return this.Sign(request);
        }

        /*
         * Current time in IS0 8601 format as required by Amazon
         */
        private string GetTimestamp()
        {
            DateTime currentTime = DateTime.UtcNow;
            string timestamp = currentTime.ToString("yyyy-MM-ddTHH:mm:ssZ");
            return timestamp;
        }

        /*
         * Percent-encode (URL Encode) according to RFC 3986 as required by Amazon.
         * 
         * This is necessary because .NET's HttpUtility.UrlEncode does not encode
         * according to the above standard. Also, .NET returns lower-case encoding
         * by default and Amazon requires upper-case encoding.
         */
        private string PercentEncodeRfc3986(string str)
        {
            str = HttpUtility.UrlEncode(str, System.Text.Encoding.UTF8);
            str = str.Replace("'", "%27").Replace("(", "%28").Replace(")", "%29").Replace("*", "%2A").Replace("!", "%21").Replace("%7e", "~").Replace("+", "%20");

            StringBuilder sbuilder = new StringBuilder(str);
            for (int i = 0; i < sbuilder.Length; i++)
            {
                if (sbuilder[i] == '%')
                {
                    if (Char.IsLetter(sbuilder[i + 1]) || Char.IsLetter(sbuilder[i + 2]))
                    {
                        sbuilder[i + 1] = Char.ToUpper(sbuilder[i + 1]);
                        sbuilder[i + 2] = Char.ToUpper(sbuilder[i + 2]);
                    }
                }
            }
            return sbuilder.ToString();
        }

        /*
         * Convert a query string to corresponding dictionary of name-value pairs.
         */
        private IDictionary<string, string> CreateDictionary(string queryString)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();

            string[] requestParams = queryString.Split('&');

            for (int i = 0; i < requestParams.Length; i++)
            {
                if (requestParams[i].Length < 1)
                {
                    continue;
                }

                char[] sep = { '=' };
                string[] param = requestParams[i].Split(sep, 2);
                for (int j = 0; j < param.Length; j++)
                {
                    param[j] = HttpUtility.UrlDecode(param[j], System.Text.Encoding.UTF8);
                }
                switch (param.Length)
                {
                    case 1:
                        {
                            if (requestParams[i].Length >= 1)
                            {
                                if (requestParams[i].ToCharArray()[0] == '=')
                                {
                                    map[""] = param[0];
                                }
                                else
                                {
                                    map[param[0]] = "";
                                }
                            }
                            break;
                        }
                    case 2:
                        {
                            if (!string.IsNullOrEmpty(param[0]))
                            {
                                map[param[0]] = param[1];
                            }
                        }
                        break;
                }
            }

            return map;
        }

        /*
         * Consttuct the canonical query string from the sorted parameter map.
         */
        private string ConstructCanonicalQueryString(SortedDictionary<string, string> sortedParamMap)
        {
            StringBuilder builder = new StringBuilder();

            if (sortedParamMap.Count == 0)
            {
                builder.Append("");
                return builder.ToString();
            }

            foreach (KeyValuePair<string, string> kvp in sortedParamMap)
            {
                builder.Append(this.PercentEncodeRfc3986(kvp.Key));
                builder.Append("=");
                builder.Append(this.PercentEncodeRfc3986(kvp.Value));
                builder.Append("&");
            }
            string canonicalString = builder.ToString();
            canonicalString = canonicalString.Substring(0, canonicalString.Length - 1);
            return canonicalString;
        }
    }

    /*
     * To help the SortedDictionary order the name-value pairs in the correct way.
     */     
    class ParamComparer : IComparer<string>
    {
        public int Compare(string p1, string p2)
        {
            return string.CompareOrdinal(p1, p2);
        }
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
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
public partial class ItemLookupResponseItemsRequest
{

    private string isValidField;

    private ItemLookupResponseItemsRequestItemLookupRequest itemLookupRequestField;

    private ItemLookupResponseItemsRequestErrors errorsField;

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

    /// <remarks/>
    public ItemLookupResponseItemsRequestErrors Errors
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
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webservices.amazon.com/AWSECommerceService/2011-08-01")]
public partial class ItemLookupResponseItemsRequestItemLookupRequest
{

    private string idTypeField;

    private ulong itemIdField;

    private string[] responseGroupField;

    private string searchIndexField;

    private string variationPageField;

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
    public ulong ItemId
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
public partial class ItemLookupResponseItemsRequestErrors
{

    private ItemLookupResponseItemsRequestErrorsError errorField;

    /// <remarks/>
    public ItemLookupResponseItemsRequestErrorsError Error
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
public partial class ItemLookupResponseItemsRequestErrorsError
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


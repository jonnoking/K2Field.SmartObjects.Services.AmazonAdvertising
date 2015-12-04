using SourceCode.SmartObjects.Services.ServiceSDK.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2Field.SmartObjects.Services.AmazonAdvertising
{
    public class Settings
    {
        public Settings(ServiceConfiguration ServiceConfiguration)
        {
            this.AssoicateTag = ServiceConfiguration["AssoicateTag"].ToString();
            this.AWSSecretKey = ServiceConfiguration["AWSSecretKey"].ToString();
            this.AWSAccessKeyId = ServiceConfiguration["AWSAccessKeyId"].ToString();
            this.Marketplace = ServiceConfiguration["Marketplace"].ToString();
        }

        public string AssoicateTag { get; set; }
        public string AWSAccessKeyId { get; set; }
        public string AWSSecretKey { get; set; }
        public string Marketplace { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherlockPlatform.Models
{ 
    public class RegistrationEvent
    {
        public int SiteID { get; set; }
        public int ExternalKey { get; set; }
        public string Handle { get; set; }
        public string EmailAddressHash { get; set; }
        public string EmailDomain { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime SignupDate { get; set; }
        public string GenderSelf { get; set; } //Male , female etc 
        public string GenderSeek { get; set; }
        public int LowerAgeSeek { get; set; }
        public int UpperAgeSeek { get; set; }
        public string PostalCode { get; set; }
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public string ChannelName { get; set; }
        public int RegPlatformID { get; set; }
        public long RegIPNumber { get; set; }
        public string RegIPAddress { get; set; }    
        public string UserAgent { get; set; }
        public int RegCountryID { get; set; }
        public string RegCountryCode { get; set; }
        public string RegCountryName { get; set; }
        public int RegStateID { get; set; }
        public string RegStateAbbreviation { get; set; }
        public string RegStateName { get; set; }
        public int RegCityID { get; set; }
        public string RegCityName { get; set; }
    }
}

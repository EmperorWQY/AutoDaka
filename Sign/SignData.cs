namespace Sign
{
    internal class SignData
    {
        public string longitude { get; set; }
        public string latitude { get; set; }
        public string areacode { get; set; }
        public string street { get; set; }
        public string township { get; set; }
        public string district { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string towncode { get; set; }
        public string citycode { get; set; }
        public string timestampHeader { get; set; }

        public SignData() { }

        public SignData(string longitude, string latitude, string areacode, string street, string township, 
            string district, string province, string city, string country, string towncode, string citycode, 
            string timestampHeader)
        {
            this.longitude = longitude;
            this.latitude = latitude;
            this.areacode = areacode;
            this.street = street;
            this.township = township;
            this.district = district;
            this.province = province;
            this.city = city;
            this.country = country;
            this.towncode = towncode;
            this.citycode = citycode;
            this.timestampHeader = timestampHeader;
        }

        public Dictionary<string,string> getData()
        {
            Dictionary<string,string> data = new();

            data.Add("longitude", longitude);
            data.Add("latitude", latitude);
            data.Add("areacode", areacode);
            data.Add("street", street);
            data.Add("township", township);
            data.Add("district", district);
            data.Add("province", province);
            data.Add("city", city);
            data.Add("country", country);
            data.Add("towncode", towncode);
            data.Add("citycode", citycode);
            data.Add("timestampHeader", timestampHeader);

            return data;
        }
    }
}

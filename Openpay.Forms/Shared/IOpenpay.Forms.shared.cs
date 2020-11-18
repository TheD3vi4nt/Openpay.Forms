using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Openpay.Forms.Shared
{
	public interface IOpenpay
    {

        void Initialize(string merchantId, string apiKey, bool isProductionMode);

        Task<string> CreateTokenWithCard(OPCard card);

        Task<string> GetTokenWithId(string tokenId);

        string CreateDeviceSessionId();
    }

    public class OPCard
    {

        public DateTime CreationDate { get; set; }

        public string Id { get; set; }

        public string BankName { get; set; }

        public bool AllowPayouts { get; set; }

        public string HolderName { get; set; }

        public string ExpirationMonth { get; set; }

        public string ExpirationYear { get; set; }

        public OPAddress Address { get; set; }

        public string Number { get; set; }

        public string Brand { get; set; }

        public bool AllowsCharges { get; set; }

        public string BankCode { get; set; }

        public string Cvv2 { get; set; }
    }

    public class OPAddress
    {
        public string PostalCode { get; set; }

        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string Line3 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string CountryCode { get; set; }
    }

    public class OPToken
    {

        public string Id { get; set; }

        public OPCard Card { get; set; }

    }
}

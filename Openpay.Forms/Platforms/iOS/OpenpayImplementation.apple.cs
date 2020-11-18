using Plugin.Openpay.Forms.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Openpay;

namespace Plugin.Openpay.Forms
{
	/// <summary>
	/// Interface for Openpay.Forms
	/// </summary>
	public class OpenpayImplementation : IOpenpay
	{
        Xamarin.Openpay.Openpay openpay = null;

        public string CreateDeviceSessionId()
        {
            return openpay.CreateDeviceSessionId();
        }

        public Task<string> CreateTokenWithCard(Shared.OPCard card)
        {
            TaskCompletionSource<string> taskCompletionSource = new TaskCompletionSource<string>();

            Xamarin.Openpay.OPCard oPCard = new Xamarin.Openpay.OPCard();
            oPCard.CreationDate = Foundation.NSDate.Now;
            oPCard.HolderName = "Rulin Rulazo";
            oPCard.ExpirationMonth = "02";
            oPCard.ExpirationYear = "21";
            oPCard.Number = "4222222222222220";
            oPCard.Cvv2 = "123";

            OpenpayTokenizeResponseBlock responseBlock = (token) =>
            {
                taskCompletionSource.SetResult(token.Id);
            };

            OpenpayErrorBlock errorBlock = (token) =>
            {
                taskCompletionSource.SetResult(string.Empty);
            };

            openpay.CreateTokenWithCard(oPCard, responseBlock, errorBlock);
            return taskCompletionSource.Task;
        }

        public Task<string> GetTokenWithId(string tokenId)
        {
            throw new NotImplementedException();
        }

        public void Initialize(string merchantId, string apiKey, bool isProductionMode)
        {
            openpay = new Xamarin.Openpay.Openpay("mqwwoo1nkej3imduzc2x", "pk_1b8216fe3dd14668a9f624487ee1b6b9", false);
        }
    }
}

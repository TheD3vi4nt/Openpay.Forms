using Plugin.Openpay.Forms.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Android;
using Android.App;
using Plugin.Openpay.Forms.Platforms.Android;

namespace Plugin.Openpay.Forms
{
	/// <summary>
	/// Interface for Openpay.Forms
	/// </summary>
	public class OpenpayImplementation : IOpenpay
	{
		internal static Activity Activity { get; set; }

		MX.Openpay.Android.Openpay openpay = null;

		CallbackActivityImplementation callback = new CallbackActivityImplementation();

		public string CreateDeviceSessionId()
		{
			if (null == Activity)
			{
				throw new InvalidOperationException("Activity has not been initialized.");
			}

			var id = openpay.DeviceCollectorDefaultImpl.Setup(Activity);
			if (string.IsNullOrWhiteSpace(id))
			{
				var error = openpay.DeviceCollectorDefaultImpl.ErrorMessage;
			}

			return id;
		}

		public Task<string> CreateTokenWithCard(Shared.OPCard card)
		{
			TaskCompletionSource<string> taskCompletionSource = new TaskCompletionSource<string>();

			MX.Openpay.Android.Model.Card oPCard = new MX.Openpay.Android.Model.Card();
			oPCard.HolderName = "Rulin Rulazo";
			oPCard.ExpirationMonth = "02";
			oPCard.ExpirationYear = "21";
			oPCard.CardNumber = "4222222222222220";
			oPCard.Cvv2 = "123";

			callback.Success = (s) => { taskCompletionSource.SetResult(s); };

			callback.Error = (s) => { taskCompletionSource.SetResult(string.Empty); };

			callback.CommunicationError = (s) => { taskCompletionSource.SetResult(string.Empty); };

			openpay.CreateToken(oPCard, callback);
			return taskCompletionSource.Task;
		}

		public Task<string> GetTokenWithId(string tokenId)
		{
			throw new NotImplementedException();
		}

		public void Initialize(string merchantId, string apiKey, bool isProductionMode)
		{
			openpay = new MX.Openpay.Android.Openpay(merchantId, apiKey, new Java.Lang.Boolean(isProductionMode));
		}
	}
}

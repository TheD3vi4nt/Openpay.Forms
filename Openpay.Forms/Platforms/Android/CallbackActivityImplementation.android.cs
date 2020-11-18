using System;
using System.Collections.Generic;
using System.Text;
using Android.App;
using Android.OS;

namespace Plugin.Openpay.Forms.Platforms.Android
{
	public class CallbackActivityImplementation : Activity, MX.Openpay.Android.IOperationCallBack
    {
        public delegate void OnCommunicationErrorDelegate(string errorMessage);

        public delegate void OnErrorDelegate(string errorMessage);

        public delegate void OnSuccessDelegate(string token);

        public OnCommunicationErrorDelegate CommunicationError { get; set; }

        public OnErrorDelegate Error { get; set; }

        public OnSuccessDelegate Success { get; set; }

        public void OnCommunicationError(MX.Openpay.Android.Exceptions.ServiceUnavailableException p0)
        {
            CommunicationError(p0.Message);
        }

        public void OnError(MX.Openpay.Android.Exceptions.OpenpayServiceException p0)
        {
            Error(p0.Message);
        }

        public void OnSuccess(MX.Openpay.Android.OperationResult p0)
        {
            var token = (MX.Openpay.Android.Model.Token)p0.Result;

            Success(token?.Id);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
    }
}

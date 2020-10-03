using System;
using System.ServiceModel.Configuration;

namespace M4Trader.ordenes.server.CQRSFramework.WcfExtensions
{
    public class NewtonsoftJsonExtension : BehaviorExtensionElement
    {
        const string MyPropertyName = "logFolder";

        public override Type BehaviorType
        {
            get { return typeof(NewtonsoftJsonBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new NewtonsoftJsonBehavior();
        }
    }
}
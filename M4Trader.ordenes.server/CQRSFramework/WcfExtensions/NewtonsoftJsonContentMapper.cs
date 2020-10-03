using System.ServiceModel.Channels;

namespace M4Trader.ordenes.server.CQRSFramework.WcfExtensions
{
    public class NewtonsoftJsonContentMapper : WebContentTypeMapper
    {
        public override WebContentFormat GetMessageFormatForContentType(string contentType)
        {
            return WebContentFormat.Raw;
        }
    }
}
using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace GatewayService
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "{deviceId}/command")]
        HttpResponseMessage PostCommand(string command, string deviceId);
        
        void PostIdentity();
    }
}
using System.ServiceModel;

namespace GatewayInterface
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebPost]
        void PostCommand();

        void PostIdentity();
        void PostData();
    }
}

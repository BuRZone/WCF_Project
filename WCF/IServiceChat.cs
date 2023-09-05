using System.ServiceModel;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceChat" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IServerChatCalback))]
    public interface IServiceChat
    {
        [OperationContract]
        int Connect(string name); //получение id
        [OperationContract]
        void Disconnect(int id); //клиент отключен, слать сообщения не надо
        [OperationContract(IsOneWay = true)] //отправить сообщение без ожидния ответа
        void SendMessage(string message, int id);
    }

    public interface IServerChatCalback
    {
        [OperationContract(IsOneWay = true)]
        void MessageCallback(string message);
    }
}

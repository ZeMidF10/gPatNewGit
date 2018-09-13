namespace Glintths.Apps.Base.Interfaces
{
    public interface IPushNotification
    {
        void InitPushNotifications();
        void PushNotificationSubscribeTopic(string topic);
        void PushNotificationSubscribeAllTopics();
        void PushNotificationUnSubscribeTopic(string topic);
        void PushNotificationUnSubscribeAllTopics();
    }
}

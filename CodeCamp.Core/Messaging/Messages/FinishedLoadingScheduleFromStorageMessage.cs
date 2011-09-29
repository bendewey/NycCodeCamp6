using TinyMessenger;

namespace CodeCamp.Core.Messaging.Messages
{
    public class FinishedLoadingScheduleFromStorageMessage : TinyMessageBase
    {
        public FinishedLoadingScheduleFromStorageMessage(object sender)
            : base(sender)
        {
        }
    }
}

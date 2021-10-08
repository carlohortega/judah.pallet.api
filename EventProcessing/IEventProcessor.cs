namespace Eis.Pallet.Api.EventProcessing
{
    public interface IEventProcessor
    {
        void ProcessEvent(string message);
    }
}
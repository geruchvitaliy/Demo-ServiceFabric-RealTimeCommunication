namespace SignalR
{
    public class Session
    {
        public int SentObjects { get; private set; }
        public int TotalObjects { get; private set; }

        public Session(int sentObjects, int totalObjects)
        {
            SentObjects = sentObjects;
            TotalObjects = totalObjects;
        }
    }
}
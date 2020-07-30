namespace XPTO.Core.Domain
{
    public class DomainNotifier
    {
        public DomainNotifier(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }
}
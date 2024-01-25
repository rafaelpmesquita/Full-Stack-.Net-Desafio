using System;

namespace TesteNetCore.Domain.Exceptions
{
    public class CustomLeadException : Exception
    {
        public string Title { get; }
        public string CustomMessage { get; }

        public CustomLeadException(string title, string customMessage) : base($"{title}: {customMessage}")
        {
            Title = title;
            CustomMessage = customMessage;
        }
    }
}

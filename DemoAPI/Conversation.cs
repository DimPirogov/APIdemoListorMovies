namespace DemoAPI
{
    public class Conversation
    {
        public int ConversationId { get; set; }
        public DateTime Date { get; set; }
        public List? List { get; set; }
        public string? ConversationName { get; set; }
        public string? Text { get; set; }
    }
}

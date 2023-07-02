namespace DemoAPI
{
    public class List
    {
        public int ListId { get; set; }
        public DateTime Date { get; set; }
        public string? ListName { get; set; }
        public ICollection<Conversation>? Conversations { get; set; } = new List<Conversation>();
    }
}

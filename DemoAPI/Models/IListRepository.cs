namespace DemoAPI.Models
{
    public interface IListRepository
    {
        Task<IEnumerable<List>> SearchList(string keyword);
        Task<List> GetList(int ListId);
        Task<IEnumerable<List>> GetLists();
        Task<List> AddList(List list);
        Task<List> UpdateList(List list);
        Task<List> DeleteList(int ListId);
        // Conversation block
        Task<IEnumerable<Conversation>> SearchConversation(string keyword);
        Task<Conversation> GetConversation(int ConversationId);
        Task<IEnumerable<Conversation>> GetConversations();
        Task<Conversation> AddConversation(Conversation conversation);
        Task<Conversation> UpdateConversation(Conversation conversation);
        Task<Conversation> DeleteConversation(int ConversationId);
    }
}

namespace ShoppingListAPI.Models
{
    public class ShoppingList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public int UserId { get; set; }
    }
}
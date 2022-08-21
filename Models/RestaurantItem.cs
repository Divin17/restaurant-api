namespace RestaurantApi.Models
{
    public class RestaurantItem
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public int? Rating { get; set; }
        public string? Address { get; set; }
        public int? OwnerId {get; set;}
    }
    public class Owner
{
    public int OwnerId { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Gender { get; set; }
    public string? Phonenumber { get; set; }
    public string? Nationality { get; set; }
    // public List<RestaurantItem> Restaurants { get;}
}
}
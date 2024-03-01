namespace encyclodepia.Models
{
    public class Encyclopedia
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Field_of_data { get; set; }
        
        public IList<Item> items { get; set; }
    }
}

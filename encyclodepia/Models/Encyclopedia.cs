namespace encyclodepia.Models
{
    public class Encyclopedia
    {
        private int _id;
        private string _name;
        private string _description;
        private string _field_of_data;
        private IList<Item> items;
    }
}

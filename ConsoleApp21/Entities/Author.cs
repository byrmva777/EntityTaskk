namespace ConsoleApp21.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AuthorBook> AuthorBooks { get; set; }

    }
}

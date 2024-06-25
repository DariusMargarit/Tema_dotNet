namespace Tema_dotNet.Database.Entities
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
namespace Tema_dotNet.Database.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Email { get; set; }
        public string Parola { get; set; }
        public int RolId { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
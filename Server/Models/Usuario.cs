namespace CellSystem.Server.Models;

public class Usuario
    {
        public int Id { get; set; }
        public int UsuarioRolId { get; set; }
        public virtual UsuarioRol UsuarioRol { get; set;} = null!;
        public string Name { get; set; } = null!;
        public string NickName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
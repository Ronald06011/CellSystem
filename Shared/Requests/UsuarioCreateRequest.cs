using System.ComponentModel.DataAnnotations;

namespace CellSystem.Shared.Requests;

public class UsuarioCreateRequest
{
    [Range(1,int.MaxValue, ErrorMessage = "El rol no es valido!.")]
    public int UsuarioRolId { get; set; }
    
    [Required(ErrorMessage = "Se debe proporcionar el nombre del usuario"),
    MinLength(5,ErrorMessage ="El nombre debe superar los 5 caracteres"),
    MaxLength(100,ErrorMessage ="El nombre no debe superar los 100 caracteres")
    ]
    public string Name { get; set; } = null!;
    
    [Required(ErrorMessage = "Se debe proporcionar el nickname del usuario"),
    MinLength(3,ErrorMessage ="El nickname debe superar los 5 caracteres"),
    MaxLength(100,ErrorMessage ="El nombre no debe superar los 100 caracteres")
    ]
    public string NickName { get; set; } = null!;
    [Required(ErrorMessage = "Se debe proporcionar el contraseña"),
    MinLength(3,ErrorMessage ="El contraseña debe superar los 2 caracteres"),
    MaxLength(50,ErrorMessage ="El contraseña debe no superar los 50 caracteres")
    ]
    public string Password { get; set; } = null!;
}
public class UsuarioUpdateRequest : UsuarioCreateRequest
{
     [Required(ErrorMessage = "Se debe proporcionar el Id del usuario a modificar")]
    public int Id { get; set; }

}
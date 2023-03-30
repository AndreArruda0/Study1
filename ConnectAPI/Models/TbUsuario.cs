using System;
using System.Collections.Generic;

namespace ConnectAPI.Models;

public partial class TbUsuario
{
    public int Codigo { get; set; }

    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool? Ativo { get; set; }

    public virtual ICollection<TbUsuarioPerfil> TbUsuarioPerfils { get; } = new List<TbUsuarioPerfil>();
}

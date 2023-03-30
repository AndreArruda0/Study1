using System;
using System.Collections.Generic;

namespace ConnectAPI.Models;

public partial class TbUsuarioPerfil
{
    public int CodigoUsuario { get; set; }

    public int CodigoPerfil { get; set; }

    public DateTime? DataLimite { get; set; }

    public virtual TbPerfil CodigoPerfilNavigation { get; set; } = null!;

    public virtual TbUsuario CodigoUsuarioNavigation { get; set; } = null!;
}

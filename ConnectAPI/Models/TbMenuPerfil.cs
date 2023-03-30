using System;
using System.Collections.Generic;

namespace ConnectAPI.Models;

public partial class TbMenuPerfil
{
    public int Codigo { get; set; }

    public int CodigoMenu { get; set; }

    public int CodigoPerfil { get; set; }

    public DateTime? DataCriacao { get; set; }

    public virtual TbMenu CodigoMenuNavigation { get; set; } = null!;

    public virtual TbPerfil CodigoPerfilNavigation { get; set; } = null!;
}

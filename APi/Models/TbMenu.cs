using System;
using System.Collections.Generic;

namespace APi.Models;

public partial class TbMenu
{
    public int Codigo { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descricao { get; set; }

    public bool? Ativo { get; set; }

    public DateTime? DataCriacao { get; set; }

    public virtual ICollection<TbMenuPerfil> TbMenuPerfils { get; } = new List<TbMenuPerfil>();
}

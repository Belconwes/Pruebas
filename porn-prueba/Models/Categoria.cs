using System;
using System.Collections.Generic;

namespace porn_prueba.Models;

public partial class Categoria
{
    public int CategoriaId { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<ProdCat> ProdCats { get; set; } = new List<ProdCat>();

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}

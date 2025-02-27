﻿using System;
using System.Collections.Generic;

namespace porn_prueba.Models;

public partial class Usuario
{
    public int IdUser { get; set; }

    public string? Rol { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Email { get; set; }

    public string? Contraseña { get; set; }

    public virtual ICollection<Favorito> Favoritos { get; set; } = new List<Favorito>();

    public virtual ICollection<HistorialVisita> HistorialVisita { get; set; } = new List<HistorialVisita>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}

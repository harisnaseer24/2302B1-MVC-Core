using System;
using System.Collections.Generic;

namespace _2302b1TempEmbedding.Models;

public partial class Category
{
    public int CatId { get; set; }

    public string CatName { get; set; } = null!;

    public string CatDescription { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}

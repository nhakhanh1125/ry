﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Bai1Lab8NET1051.Models
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}

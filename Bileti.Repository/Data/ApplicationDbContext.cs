using Bileti.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Bileti.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<BiletUser>
    {

        public virtual DbSet<Bilet> Bilets { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCards { get; set; }
        public virtual DbSet<BiletInShoppingCart> BiletInShoppingCarts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}

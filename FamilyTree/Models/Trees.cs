using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FamilyTree.Models
{
    public class Trees
    {
        public DbSet<Tree> read  { get; set; }
        public Tree add { get; set; }
    }
}
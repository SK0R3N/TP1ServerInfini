using Microsoft.EntityFrameworkCore;
using Moq;
using Super_Cartes_Infinies.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class MockApplicationDbContext : ApplicationDbContext
    {
        public MockApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}

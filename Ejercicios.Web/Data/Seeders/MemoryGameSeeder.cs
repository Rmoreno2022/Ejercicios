using Ejercicios.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ejercicios.Web.Data.Seeders
{
    public class MemoryGameSeeder
    {
        private readonly DataContext _context;

        public MemoryGameSeeder(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            if (!await _context.MemoryCards.AnyAsync())
            {
                var list = new List<MemoryCard>
                {
                    new MemoryCard { ImagePath = "/images/memory/1.png" },
                    new MemoryCard { ImagePath = "/images/memory/2.png" },
                    new MemoryCard { ImagePath = "/images/memory/3.png" },
                    new MemoryCard { ImagePath = "/images/memory/4.png" },
                    new MemoryCard { ImagePath = "/images/memory/5.png" },
                    new MemoryCard { ImagePath = "/images/memory/6.png" },
                    new MemoryCard { ImagePath = "/images/memory/7.png" },
                    new MemoryCard { ImagePath = "/images/memory/8.png" }
                };

                _context.MemoryCards.AddRange(list);
                await _context.SaveChangesAsync();
            }
        }
    }
}

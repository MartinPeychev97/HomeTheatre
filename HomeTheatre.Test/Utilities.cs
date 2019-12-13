using HomeTheatre.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeTheatre.Test
{
    public static class Utilities
    {
        public static DbContextOptions<TheatreContext> GetOptions(string dataBaseName)
        {
            return new DbContextOptionsBuilder<TheatreContext>()
                .UseInMemoryDatabase(dataBaseName)
                .Options;
                
        }
    }
}

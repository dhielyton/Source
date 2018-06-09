using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Mapping
{
    public class BemMapping : IEntityTypeConfiguration<Bem>
    {
        public void Configure(EntityTypeBuilder<Bem> builder)
        {
            
            
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Data.EF.Extensions;
using ShopApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Data.EF.Configurations
{
    public class AdvertistmentConfiguration : DbEntityConfiguration<Advertistment>
    {
        public override void Configure(EntityTypeBuilder<Advertistment> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).HasColumnType("varchar(128)");
        }
    }
}

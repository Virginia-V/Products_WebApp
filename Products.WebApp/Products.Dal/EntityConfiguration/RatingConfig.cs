using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain;

namespace Products.Dal.EntityConfiguration
{
    public class RatingConfig : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.Property(x => x.Rate)
                .IsRequired();

            builder.Property(x => x.Count)
               .IsRequired();

        }
    }
}

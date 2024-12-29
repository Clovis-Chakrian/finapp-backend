using Financa.Backend.Domain.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financa.Backend.Infra.EntitiesConfiguration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
  public void Configure(EntityTypeBuilder<Category> builder)
  {
    builder.ToTable("categories", "fin_app");

    builder.HasKey(p => p.Id);

    builder.Property(p => p.Name)
      .IsRequired();

    builder.Property(p => p.Color)
      .IsRequired()
      .HasDefaultValue("#D3D3D3");

    builder.Property(p => p.PrimaryCategoryId)
      .IsRequired(false);

    builder.HasOne(p => p.PrimaryCategory)
      .WithMany()
      .HasForeignKey(p => p.PrimaryCategoryId)
      .IsRequired(false);
  }
}
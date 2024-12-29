using Financa.Backend.Domain.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financa.Backend.Infra.EntitiesConfiguration;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
  public void Configure(EntityTypeBuilder<Transaction> builder)
  {
    builder.ToTable("transactions", "fin_app");

    builder.HasKey(p => p.Id);

    builder.Property(p => p.AccountId)
      .IsRequired();

    builder.Property(p => p.CategoryId)
      .IsRequired();

    builder.Property(p => p.Value)
      .IsRequired();

    builder.Property(p => p.Date)
      .IsRequired();

    builder.Property(p => p.Remark)
      .IsRequired(false)
      .HasMaxLength(400);

    builder.HasOne(p => p.Category)
      .WithMany()
      .HasForeignKey(p => p.CategoryId)
      .IsRequired();

    builder.HasOne(p => p.Account)
      .WithMany(p => p.Transactions)
      .HasForeignKey(p => p.AccountId)
      .IsRequired();
  }
}
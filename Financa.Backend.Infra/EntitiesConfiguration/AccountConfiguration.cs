using Financa.Backend.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financa.Backend.Infra.EntitiesConfiguration;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
  public void Configure(EntityTypeBuilder<Account> builder)
  {
    builder.ToTable("accounts", "fin_app");

    builder.HasKey(p => p.Id);

    builder.Property(p => p.Nickname)
      .IsRequired();

    builder.Property(p => p.Type)
      .IsRequired();

    builder.Property(p => p.Balance)
      .IsRequired();
  }
}
using AutoMapper;
using Financa.Backend.Domain.Accounts;

namespace Financa.Backend.Application.Accounts.Queries.GetAll;

[AutoMap(typeof(Account), ReverseMap = true)]
public class ListAccountDto
{
  public Guid Id { get; set; }
  public AccountType Type { get; set; }
  public string? Nickname { get; set; }
  public decimal Balance { get; set; }
}
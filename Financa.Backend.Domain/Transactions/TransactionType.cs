using System.ComponentModel;

namespace Financa.Backend.Domain.Transactions;

public enum TransactionType
{
  [Description("Incoming")]
  Incoming,

  [Description("Outcoming")]
  Outcoming
}
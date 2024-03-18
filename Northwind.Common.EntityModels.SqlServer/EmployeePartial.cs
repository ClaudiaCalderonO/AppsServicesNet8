using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.EntityModels;

public partial class Employee : IHasLastRefresed
{
    [NotMapped]
    public DateTimeOffset LastRefresed { get; set; }
}

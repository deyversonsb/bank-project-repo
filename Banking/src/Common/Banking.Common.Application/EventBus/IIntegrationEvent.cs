using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Common.Application.EventBus;
public interface IIntegrationEvent
{
    public Guid Id { get; }
    public DateTime OccurredOnUtc { get; }
}

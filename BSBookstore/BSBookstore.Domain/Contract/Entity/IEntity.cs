using System;
using System.Collections.Generic;
using System.Text;

namespace BSBookstore.Domain.Contract
{
    public interface IEntity<TId> where TId : struct
    {
        TId Id { get; set; }
    }

    public interface IEntity : IEntity<Guid>
    { }
}

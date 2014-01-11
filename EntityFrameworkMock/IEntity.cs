
using System;

namespace EntityFrameworkMock
{
    public interface IEntity
    {
        Int64 Id { get; set; }
        bool IsDelete { get; set; }
    }
}

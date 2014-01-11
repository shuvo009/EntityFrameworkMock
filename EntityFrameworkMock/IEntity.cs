
using System;

namespace TimeSketch.Core.Entity.Interface
{
    public interface IEntity
    {
        Int64 Id { get; set; }
        bool IsDelete { get; set; }
    }
}

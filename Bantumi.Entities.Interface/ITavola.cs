using System;
using System.Collections.Generic;

namespace Bantumi.Entities.Interface
{
    public interface ITavola
    {
        IList<IBuca> Buche { get; }
        ITavola Clone();
    }
}
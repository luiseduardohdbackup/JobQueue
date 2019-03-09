using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TestConsole
{
    interface IQueue<T> : IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, ICollection
    {
    }
}

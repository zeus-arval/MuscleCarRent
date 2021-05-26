using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public abstract class UniqueItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}

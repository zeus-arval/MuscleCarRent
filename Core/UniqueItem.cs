using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public abstract class UniqueItem
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();
    }
}

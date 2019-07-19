using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalStudyGuideCIS300
{
    public class LinkedListCell<T>
    {
        public T Data { get; set; }
        public LinkedListCell<T> Next { get; set; } = null;
        public LinkedListCell()
        {
            Data = default;
        }
    }
}

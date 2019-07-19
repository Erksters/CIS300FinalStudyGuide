using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class UndirectedGraphNode<T>
    {
        public T Data { get; set; }
        public UndirectedGraphNode<T>[] Edges = new UndirectedGraphNode<T>[10];

    }
}

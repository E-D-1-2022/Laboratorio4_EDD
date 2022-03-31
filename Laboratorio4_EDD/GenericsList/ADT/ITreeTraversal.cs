using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsList.ADT
{
    public interface ITreeTraversal<V>
    {
        void Walk(V value);
    }
}

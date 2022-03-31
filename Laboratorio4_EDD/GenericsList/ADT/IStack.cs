using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsList.ADT
{
    interface IStack<T>
    {
        void Push(T value);

        T Pull();

        T Peek();

        int Count();

        bool IsEmpty();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsList
{
 interface IbinaryTree<T>
    {
        void add(T Value);

        object[] select(Func<T, T, bool> Parametro_busqueda, T ValueSearch);
    }
}

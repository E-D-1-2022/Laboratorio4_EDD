using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsList.TreeStructures
{
    public class BinaryTree<T> : IbinaryTree<T>
    {
        Func<T, T, int> Comparer;
        List<T> ArbolOrdenado = new List<T>();
        int i = 0;
        public BinaryTree(Func<T,T,int> Comparer) {
            this.Comparer = Comparer;
        }
        Node<T> Raiz=null;
        int contador = 0;
        int count = 0;
        public void add(T Value)
        {
            Insert(Value, null);
        }

        private T Insert(T Value, Node<T> Iterando) {
            if (Raiz == null)
            {
                Raiz = new Node<T>();
                Raiz.Value = Value;
                count++;
                return Raiz.Value;
            }
            else
            {
                if (Iterando == null)
                {
                    Iterando = new Node<T>();
                    if (contador == 0)
                    {
                        Iterando = Raiz;
                        contador++;
                    }
                    else
                    {
                        Iterando.Value = Value;
                        contador = 0;
                        return Value;
                    }
                }
            }

            if (Comparer(Iterando.Value,Value) < 0)
            {
                Iterando.Left.Value = Insert(Value, Iterando.Left);
            }
            if (Comparer(Iterando.Value, Value) >0)
            {
                Iterando.Right.Value = Insert(Value, Iterando.Right);
            }
            return Iterando.Value;

        }
        protected T GetMinimun() {
            Node<T> trabajo = Raiz;
            while (trabajo.Left != null) {
                trabajo = trabajo.Left;
            }
            return trabajo.Value;

        }
        protected T GetMaximun()
        {
            Node<T> trabajo = Raiz;
            while (trabajo.Right != null)
            {
                trabajo = trabajo.Right;
            }
            return trabajo.Value;

        }
        public List<T> inOrder(Node<T> Node) {
            if (Node == null) {
                return null;
            }
            if (Node.Left != null) {
                i++;
                ArbolOrdenado.Add(Node.Value);
                inOrder(Node.Left);
                i--;
            }
            if (Node.Right != null)
            {
                i++;
                ArbolOrdenado.Add(Node.Value);
                inOrder(Node.Right);
                i--;
            }
            return ArbolOrdenado;
        }
        public object[] select(Func<T, T, bool> Parametro_busqueda,T ValueSearch)
        {
            inOrder(Raiz);
            T valueReturn=default(T);
            object[] arr = new object[2];
            int contador_comp = 0;
            foreach (var item in ArbolOrdenado) {
                if (Parametro_busqueda(item,ValueSearch))
                {
                    valueReturn = item;
                    contador_comp++;
                }
            }
            arr[0] = (object)valueReturn;
            arr[1] = (object)contador_comp;
            return arr ;
        }


        
    }

}

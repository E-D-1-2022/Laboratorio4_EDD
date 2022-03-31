using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsList.LinearStructures;
namespace GenericsList.LinearStructures
{/// <summary>
/// This is a custom DoubleLinkedList
/// </summary>
/// <typeparam name="T"></typeparam>
  public class CustomDobleListLink<T> : IDobleListLink<T>,IEnumerable<T>

    {
        private int count;
        private Node<T> start;
        private Node<T> end;
        public int Count()
        {
            return count;
        }

        public void Delete(T Value)
        {
            if (IsEmpty())
            {
                return;
            }

            Node<T> Previous = FindPrevious(Value);
            int index = Indexof(Value);
            Node<T> Refernce = GetNode(index);
            if (Refernce == null)
            {
                return;
            }
            Previous.next = Refernce.next;
            Refernce.next = null;
            count--;
        }

        private Node<T> GetNode(int index) {

                var node = start;
                int i = 0;
                if (index > count || index < 0)
                {
                    throw (new Exception("Index out of range"));
                }
                else
                {
                    while (node.next != null && i < index)
                    {
                        node = node.next;
                        i++;
                    }
                    return node;
                }
            
        }
        public T Get(int index)
        {
            var node = start;
            int i =0 ;
            if (index > count || index<0)
            {
                throw (new Exception("Index out of range"));
            }
            else
            {
                while (node.next != null && i < index)
                {
                    node = node.next;
                    i++;
                }
                return node.value;
            }
        }

        public void Add(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (IsEmpty())
            {
                start = newNode;
                end = newNode;
            }
            else
            {
                end.next = newNode;
                end = newNode;
            }
            count++;
        }

        public void Insert(T value, int index)
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty()
        {
           return (count == 0);
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = start;
            while (node != null)
            {
                yield return node.value;
                node = node.next;
            }
            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Clear() {
            start = null;
            end = null;
        }
        public int Indexof(T Value) {

            var node = start;
            int Index = -1;
            while (node != null)
            {
                if (EqualityComparer<T>.Default.Equals(node.value,Value)) {
                    Index++;
                    return Index;
                }
                Index++;
                node = node.next;
            }
            return -1;

        }

        private Node<T> FindPrevious(T Value) {
            var node = start;
            while (node.next != null && !EqualityComparer<T>.Default.Equals(node.next.value, Value)) {
                node = node.next;
            }
            return node;

        }

        private T GetbyIndex(int Index) {
            Node<T> Reference = null;
            int index = -1;
            var node = start;
            while (node.next != null) {
                index++;
                if (index == Index) {
                    Reference = node;
                }
            }
            return Reference.value;
        }
        public T this[int index]
        {
            get {
                Node<T> Work = GetNode(index);
                return Work.value;
            }
            set {
                Node<T> Work = GetNode(index);
                if (Work != null) {
                    Work.value=value;
                }
            }
        }
    }
}

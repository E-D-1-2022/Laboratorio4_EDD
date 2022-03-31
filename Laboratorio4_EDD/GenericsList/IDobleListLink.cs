using System;
using System.Collections.Generic;
using System.Text;
namespace GenericsList
{
     interface IDobleListLink<T>
    {
        /// <summary>
        /// Insert an element into the list
        /// </summary>
        /// <param name="value">The data for insert</param>
        void Add(T value);
        /// <summary>
        /// Insert an element into the list in a specific position
        /// </summary>
        /// <param name="value">The data for insert</param>
        /// <param name="index">index where the element will be inserted</param>
        void Insert(T value, int index);

        /// <summary>
        /// Delete element in the list
        /// </summary>
        /// <param name="index">index the element for delet</param>
        void Delete(T Value);
        /// <summary>
        /// Return a element from the list
        /// </summary>
        /// <param name="index">index of the element</param>
        /// <returns>Element of the list</returns>
        T Get(int index);
        /// <summary>
        /// Get if the list is clear
        /// </summary>
        /// <returns>If the list is empty</returns>
        bool IsEmpty();
        /// <summary>
        /// Returns the number of the element into the list
        /// </summary>
        /// <returns>Length of the list</returns>
        int Count();
        /// <summary>
        /// Clear all elements in the list
        /// </summary>
        void Clear();
        /// <summary>
        /// Return the index the specific value
        /// </summary>
        /// <param name="value">Search Value</param>
        /// <returns>The index of the element</returns>
        int Indexof (T value);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
    }
}

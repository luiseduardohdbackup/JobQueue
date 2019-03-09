using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TestConsole
{
    class SqliteQueue<T> //: IQueue<T>
    {
        //public int Count => throw new NotImplementedException();

        //public bool IsSynchronized => throw new NotImplementedException();

        //public object SyncRoot => throw new NotImplementedException();

        //public void CopyTo(Array array, int index)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerator<T> GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}
        ////
        //// Summary:
        ////     Initializes a new instance of the System.Collections.Generic.Queue`1 class that
        ////     is empty and has the default initial capacity.
        //public Queue()
        //{
        //    throw new NotImplementedException();
        //}
        ////
        //// Summary:
        ////     Initializes a new instance of the System.Collections.Generic.Queue`1 class that
        ////     contains elements copied from the specified collection and has sufficient capacity
        ////     to accommodate the number of elements copied.
        ////
        //// Parameters:
        ////   collection:
        ////     The collection whose elements are copied to the new System.Collections.Generic.Queue`1.
        ////
        //// Exceptions:
        ////   T:System.ArgumentNullException:
        ////     collection is null.
        //public Queue(IEnumerable<T> collection)
        //{
        //    throw new NotImplementedException();
        //}
        ////
        //// Summary:
        ////     Initializes a new instance of the System.Collections.Generic.Queue`1 class that
        ////     is empty and has the specified initial capacity.
        ////
        //// Parameters:
        ////   capacity:
        ////     The initial number of elements that the System.Collections.Generic.Queue`1 can
        ////     contain.
        ////
        //// Exceptions:
        ////   T:System.ArgumentOutOfRangeException:
        ////     capacity is less than zero.
        //public Queue(int capacity)
        //{
        //    throw new NotImplementedException();
        //}

        ////
        //// Summary:
        ////     Gets the number of elements contained in the System.Collections.Generic.Queue`1.
        ////
        //// Returns:
        ////     The number of elements contained in the System.Collections.Generic.Queue`1.
        //public int Count { get; }

        ////
        //// Summary:
        ////     Removes all objects from the System.Collections.Generic.Queue`1.
        //public void Clear()
        //{
        //    throw new NotImplementedException();
        //}
        ////
        //// Summary:
        ////     Determines whether an element is in the System.Collections.Generic.Queue`1.
        ////
        //// Parameters:
        ////   item:
        ////     The object to locate in the System.Collections.Generic.Queue`1. The value can
        ////     be null for reference types.
        ////
        //// Returns:
        ////     true if item is found in the System.Collections.Generic.Queue`1; otherwise, false.
        //public bool Contains(T item)
        //{
        //    throw new NotImplementedException();
        //}
        ////
        //// Summary:
        ////     Copies the System.Collections.Generic.Queue`1 elements to an existing one-dimensional
        ////     System.Array, starting at the specified array index.
        ////
        //// Parameters:
        ////   array:
        ////     The one-dimensional System.Array that is the destination of the elements copied
        ////     from System.Collections.Generic.Queue`1. The System.Array must have zero-based
        ////     indexing.
        ////
        ////   arrayIndex:
        ////     The zero-based index in array at which copying begins.
        ////
        //// Exceptions:
        ////   T:System.ArgumentNullException:
        ////     array is null.
        ////
        ////   T:System.ArgumentOutOfRangeException:
        ////     arrayIndex is less than zero.
        ////
        ////   T:System.ArgumentException:
        ////     The number of elements in the source System.Collections.Generic.Queue`1 is greater
        ////     than the available space from arrayIndex to the end of the destination array.
        //public void CopyTo(T[] array, int arrayIndex)
        //{

        //}
        ////
        //// Summary:
        ////     Removes and returns the object at the beginning of the System.Collections.Generic.Queue`1.
        ////
        //// Returns:
        ////     The object that is removed from the beginning of the System.Collections.Generic.Queue`1.
        ////
        //// Exceptions:
        ////   T:System.InvalidOperationException:
        ////     The System.Collections.Generic.Queue`1 is empty.
        //public T Dequeue()
        //{

        //}
        ////
        //// Summary:
        ////     Adds an object to the end of the System.Collections.Generic.Queue`1.
        ////
        //// Parameters:
        ////   item:
        ////     The object to add to the System.Collections.Generic.Queue`1. The value can be
        ////     null for reference types.
        //public void Enqueue(T item)
        //{

        //}
        ////
        //// Summary:
        ////     Returns an enumerator that iterates through the System.Collections.Generic.Queue`1.
        ////
        //// Returns:
        ////     An System.Collections.Generic.Queue`1.Enumerator for the System.Collections.Generic.Queue`1.
        //public Enumerator GetEnumerator()
        //{

        //}
        ////
        //// Summary:
        ////     Returns the object at the beginning of the System.Collections.Generic.Queue`1
        ////     without removing it.
        ////
        //// Returns:
        ////     The object at the beginning of the System.Collections.Generic.Queue`1.
        ////
        //// Exceptions:
        ////   T:System.InvalidOperationException:
        ////     The System.Collections.Generic.Queue`1 is empty.
        //public T Peek()
        //{

        //}
        ////
        //// Summary:
        ////     Copies the System.Collections.Generic.Queue`1 elements to a new array.
        ////
        //// Returns:
        ////     A new array containing elements copied from the System.Collections.Generic.Queue`1.
        //public T[] ToArray()
        //{

        //}
        ////
        //// Summary:
        ////     Sets the capacity to the actual number of elements in the System.Collections.Generic.Queue`1,
        ////     if that number is less than 90 percent of current capacity.
        //public void TrimExcess()
        //{

        //}
        ////
        //// Parameters:
        ////   result:
        //public bool TryDequeue(out T result)
        //{

        //}
        ////
        //// Parameters:
        ////   result:
        //public bool TryPeek(out T result)
        //{

        //}

        ////
        //// Summary:
        ////     Enumerates the elements of a System.Collections.Generic.Queue`1.
        ////
        //// Type parameters:
        ////   T:
        //public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
        //{
        //    //
        //    // Summary:
        //    //     Gets the element at the current position of the enumerator.
        //    //
        //    // Returns:
        //    //     The element in the System.Collections.Generic.Queue`1 at the current position
        //    //     of the enumerator.
        //    //
        //    // Exceptions:
        //    //   T:System.InvalidOperationException:
        //    //     The enumerator is positioned before the first element of the collection or after
        //    //     the last element.
        //    public T Current { get; }

        //    object IEnumerator.Current => throw new NotImplementedException();

        //    //
        //    // Summary:
        //    //     Releases all resources used by the System.Collections.Generic.Queue`1.Enumerator.
        //    public void Dispose()
        //    {

        //    }
        //    //
        //    // Summary:
        //    //     Advances the enumerator to the next element of the System.Collections.Generic.Queue`1.
        //    //
        //    // Returns:
        //    //     true if the enumerator was successfully advanced to the next element; false if
        //    //     the enumerator has passed the end of the collection.
        //    //
        //    // Exceptions:
        //    //   T:System.InvalidOperationException:
        //    //     The collection was modified after the enumerator was created.
        //    public bool MoveNext()
        //    {
        //        return false;
        //    }

        //    public void Reset()
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}

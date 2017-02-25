using System;
using System.Collections.Generic;

public interface IFirstLastList<T>
    where T : IComparable<T>
{
    int Count { get; }

    void Add(T element);

    IEnumerable<T> First(int count);

    IEnumerable<T> Last(int count);

    IEnumerable<T> Min(int count);

    IEnumerable<T> Max(int count);

    void Clear();

    int RemoveAll(T element);
}
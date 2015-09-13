using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class FirstLastList<T> : IFirstLastList<T>
    where T : IComparable<T>
{
    private Deque<T> elements = new Deque<T>();

    public void Add(T newElement)
    {
        this.elements.Add(newElement);
    }

    public int Count
    {
        get
        {
            return this.elements.Count;
        }
    }

    public IEnumerable<T> First(int count)
    {
        if (this.Count < count)
        {
            throw new ArgumentOutOfRangeException();
        }

        return this.elements.Take(count);
    }

    public IEnumerable<T> Last(int count)
    {
        if (this.Count < count)
        {
            throw new ArgumentOutOfRangeException();
        }

        return this.elements.Skip(Math.Max(0, this.elements.Count() - count)).Reverse();
    }

    public IEnumerable<T> Min(int count)
    {
        if (this.Count < count)
        {
            throw new ArgumentOutOfRangeException();
        }

        return this.elements.OrderBy(e => e).Take(count);
    }

    public IEnumerable<T> Max(int count)
    {
        if (this.Count < count)
        {
            throw new ArgumentOutOfRangeException();
        }

        return this.elements.OrderByDescending(e => e).Take(count);
    }

    public int RemoveAll(T element)
    {
        var result = this.elements.RemoveAll(e => e.CompareTo(element) == 0);

        if (result == null)
        {
            return 0;
        }

        return result.Count;
    }

    public void Clear()
    {
        this.elements.Clear();
    }
}
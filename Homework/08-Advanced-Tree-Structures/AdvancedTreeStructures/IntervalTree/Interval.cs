namespace IntervalTree
{
    using System;

    public class Interval<T, D> : IComparable<Interval<T, D>>
        where D : IComparable<D>
    {
        public Interval(D start, D end, T data)
        {
            this.Start = start;
            this.End = end;
            this.Data = data;
        }

        public D Start { get; set; }

        public D End { get; set; }

        public T Data { get; set; }

        public int CompareTo(Interval<T, D> other)
        {
            if (this.Start.CompareTo(other.Start) < 0)
            {
                return -1;
            }

            if (this.Start.CompareTo(other.Start) > 0)
            {
                return 1;
            }

            if (this.End.CompareTo(other.End) < 0)
            {
                return -1;
            }

            if (this.End.CompareTo(other.End) > 0)
            {
                return 1;
            }

            return 0;
        }

        public bool Contains(D time, ContainConstrains constraint)
        {
            bool isContained;

            switch (constraint)
            {
                case ContainConstrains.None:
                    isContained = this.Contains(time);
                    break;
                case ContainConstrains.IncludeStart:
                    isContained = this.ContainsWithStart(time);
                    break;
                case ContainConstrains.IncludeEnd:
                    isContained = this.ContainsWithEnd(time);
                    break;
                case ContainConstrains.IncludeStartAndEnd:
                    isContained = this.ContainsWithStartEnd(time);
                    break;
                default:
                    throw new ArgumentException("Invalid constraint " + constraint);
            }

            return isContained;
        }

        public bool Contains(D time)
        {
            return time.CompareTo(this.End) < 0 && time.CompareTo(this.Start) > 0;
        }

        public bool ContainsWithStart(D time)
        {
            return time.CompareTo(this.End) < 0 && time.CompareTo(this.Start) >= 0;
        }

        public bool ContainsWithEnd(D time)
        {
            return time.CompareTo(this.End) <= 0 && time.CompareTo(this.Start) > 0;
        }

        public bool ContainsWithStartEnd(D time)
        {
            return time.CompareTo(this.End) <= 0 && time.CompareTo(this.Start) >= 0;
        }

        public bool Intersects(Interval<T, D> other)
        {
            return other.End.CompareTo(this.Start) > 0 && other.Start.CompareTo(this.End) < 0;
        }

        public override string ToString()
        {
            return string.Format("{0}-{1}", this.Start, this.End);
        }
    }
}
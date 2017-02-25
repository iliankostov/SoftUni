namespace IntervalTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class IntervalNode<T, D>
        where D : struct, IComparable<D>
    {
        private D center;

        private OrderedDictionary<Interval<T, D>, List<Interval<T, D>>> intervals;

        private IntervalNode<T, D> leftNode;

        private IntervalNode<T, D> rightNode;

        public IntervalNode()
        {
            this.intervals = new OrderedDictionary<Interval<T, D>, List<Interval<T, D>>>();
            this.center = default(D);
            this.leftNode = null;
            this.rightNode = null;
        }

        public IntervalNode(List<Interval<T, D>> intervalList)
        {
            this.intervals = new OrderedDictionary<Interval<T, D>, List<Interval<T, D>>>();

            var endpoints = new OrderedSet<D>();

            foreach (var interval in intervalList)
            {
                endpoints.Add(interval.Start);
                endpoints.Add(interval.End);
            }

            D? median = this.GetMedian(endpoints);
            this.center = median.GetValueOrDefault();

            List<Interval<T, D>> left = new List<Interval<T, D>>();
            List<Interval<T, D>> right = new List<Interval<T, D>>();

            foreach (Interval<T, D> interval in intervalList)
            {
                if (interval.End.CompareTo(this.center) < 0)
                {
                    left.Add(interval);
                }
                else if (interval.Start.CompareTo(this.center) > 0)
                {
                    right.Add(interval);
                }
                else
                {
                    List<Interval<T, D>> posting;
                    if (!this.intervals.TryGetValue(interval, out posting))
                    {
                        posting = new List<Interval<T, D>>();
                        this.intervals.Add(interval, posting);
                    }

                    posting.Add(interval);
                }
            }

            if (left.Count > 0)
            {
                this.leftNode = new IntervalNode<T, D>(left);
            }

            if (right.Count > 0)
            {
                this.rightNode = new IntervalNode<T, D>(right);
            }
        }

        public IEnumerable<IList<Interval<T, D>>> Intersections
        {
            get
            {
                if (this.intervals.Count == 0)
                {
                    yield break;
                }

                if (this.intervals.Count == 1)
                {
                    if (this.intervals.First().Value.Count > 1)
                    {
                        yield return this.intervals.First().Value;
                    }
                }
                else
                {
                    var keys = this.intervals.Keys.ToArray();

                    int lastIntervalIndex = 0;
                    List<Interval<T, D>> intersectionsKeys = new List<Interval<T, D>>();
                    for (int index = 1; index < this.intervals.Count; index++)
                    {
                        var intervalKey = keys[index];
                        if (intervalKey.Intersects(keys[lastIntervalIndex]))
                        {
                            if (intersectionsKeys.Count == 0)
                            {
                                intersectionsKeys.Add(keys[lastIntervalIndex]);
                            }

                            intersectionsKeys.Add(intervalKey);
                        }
                        else
                        {
                            if (intersectionsKeys.Count > 0)
                            {
                                yield return this.GetIntervalsOfKeys(intersectionsKeys);
                                intersectionsKeys = new List<Interval<T, D>>();
                                index--;
                            }
                            else
                            {
                                if (this.intervals[intervalKey].Count > 1)
                                {
                                    yield return this.intervals[intervalKey];
                                }
                            }

                            lastIntervalIndex = index;
                        }
                    }

                    if (intersectionsKeys.Count > 0)
                    {
                        yield return this.GetIntervalsOfKeys(intersectionsKeys);
                    }
                }
            }
        }

        public D Center
        {
            get
            {
                return this.center;
            }

            set
            {
                this.center = value;
            }
        }

        public IntervalNode<T, D> Left
        {
            get
            {
                return this.leftNode;
            }

            set
            {
                this.leftNode = value;
            }
        }

        public IntervalNode<T, D> Right
        {
            get
            {
                return this.rightNode;
            }

            set
            {
                this.rightNode = value;
            }
        }

        public List<Interval<T, D>> Stab(D time, ContainConstrains constraint)
        {
            List<Interval<T, D>> result = new List<Interval<T, D>>();

            foreach (var entry in this.intervals)
            {
                if (entry.Key.Contains(time, constraint))
                {
                    foreach (var interval in entry.Value)
                    {
                        result.Add(interval);
                    }
                }
                else if (entry.Key.Start.CompareTo(time) > 0)
                {
                    break;
                }
            }

            if (time.CompareTo(this.center) < 0 && this.leftNode != null)
            {
                result.AddRange(this.leftNode.Stab(time, constraint));
            }
            else if (time.CompareTo(this.center) > 0 && this.rightNode != null)
            {
                result.AddRange(this.rightNode.Stab(time, constraint));
            }

            return result;
        }

        public List<Interval<T, D>> Query(Interval<T, D> target)
        {
            List<Interval<T, D>> result = new List<Interval<T, D>>();

            foreach (var entry in this.intervals)
            {
                if (entry.Key.Intersects(target))
                {
                    foreach (Interval<T, D> interval in entry.Value)
                    {
                        result.Add(interval);
                    }
                }
                else if (entry.Key.Start.CompareTo(target.End) > 0)
                {
                    break;
                }
            }

            if (target.Start.CompareTo(this.center) < 0 && this.leftNode != null)
            {
                result.AddRange(this.leftNode.Query(target));
            }

            if (target.End.CompareTo(this.center) > 0 && this.rightNode != null)
            {
                result.AddRange(this.rightNode.Query(target));
            }

            return result;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(this.center + ": ");
            foreach (var entry in this.intervals)
            {
                sb.Append("[" + entry.Key.Start + "," + entry.Key.End + "]:{");
                foreach (Interval<T, D> interval in entry.Value)
                {
                    sb.Append("(" + interval.Start + "," + interval.End + "," + interval.Data + ")");
                }

                sb.Append("} ");
            }

            return sb.ToString();
        }

        private List<Interval<T, D>> GetIntervalsOfKeys(List<Interval<T, D>> intervalKeys)
        {
            var allIntervals =
                from k in intervalKeys
                select this.intervals[k];

            return allIntervals.SelectMany(x => x).ToList();
        }

        private D? GetMedian(OrderedSet<D> set)
        {
            int i = 0;
            int middle = set.Count / 2;
            foreach (D point in set)
            {
                if (i == middle)
                {
                    return point;
                }

                i++;
            }

            return null;
        }
    }
}
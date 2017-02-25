namespace IntervalTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Wintellect.PowerCollections;

    public class IntervalTree<T, D>
        where D : struct, IComparable<D>
    {
        private IntervalNode<T, D> head;

        private bool inSync;

        private List<Interval<T, D>> intervalList;

        private int size;

        public IntervalTree()
        {
            this.head = new IntervalNode<T, D>();
            this.intervalList = new List<Interval<T, D>>();
            this.inSync = true;
            this.size = 0;
        }

        public IntervalTree(List<Interval<T, D>> intervalList)
        {
            this.head = new IntervalNode<T, D>(intervalList);
            this.intervalList = new List<Interval<T, D>>();
            this.intervalList.AddRange(intervalList);
            this.inSync = true;
            this.size = intervalList.Count;
        }

        public int CurrentSize
        {
            get
            {
                return this.size;
            }
        }

        public int ListSize
        {
            get
            {
                return this.intervalList.Count;
            }
        }

        public IList<Interval<T, D>> Intervals
        {
            get
            {
                return Algorithms.ReadOnly(this.intervalList);
            }
        }

        public List<T> Get(D time)
        {
            return this.Get(time, StubMode.Contains);
        }

        public List<T> Get(D time, StubMode mode)
        {
            List<Interval<T, D>> intervals = this.GetIntervals(time, mode);
            List<T> result = new List<T>();
            foreach (Interval<T, D> interval in intervals)
            {
                result.Add(interval.Data);
            }

            return result;
        }

        public List<Interval<T, D>> GetIntervals(D time)
        {
            return this.GetIntervals(time, StubMode.Contains);
        }

        public List<Interval<T, D>> GetIntervals(D time, StubMode mode)
        {
            this.Build();

            List<Interval<T, D>> stubedIntervals;

            switch (mode)
            {
                case StubMode.Contains:
                    stubedIntervals = this.head.Stab(time, ContainConstrains.None);
                    break;
                case StubMode.ContainsStart:
                    stubedIntervals = this.head.Stab(time, ContainConstrains.IncludeStart);
                    break;
                case StubMode.ContainsStartThenEnd:
                    stubedIntervals = this.head.Stab(time, ContainConstrains.IncludeStart);
                    if (stubedIntervals.Count == 0)
                    {
                        stubedIntervals = this.head.Stab(time, ContainConstrains.IncludeEnd);
                    }

                    break;
                default:
                    throw new ArgumentException("Invalid StubMode " + mode, "mode");
            }

            return stubedIntervals;
        }

        public List<T> Get(D start, D end)
        {
            List<Interval<T, D>> intervals = this.GetIntervals(start, end);
            List<T> result = new List<T>();
            foreach (Interval<T, D> interval in intervals)
            {
                result.Add(interval.Data);
            }

            return result;
        }

        public List<Interval<T, D>> GetIntervals(D start, D end)
        {
            this.Build();
            return this.head.Query(new Interval<T, D>(start, end, default(T)));
        }

        public void AddInterval(Interval<T, D> interval)
        {
            this.intervalList.Add(interval);
            this.inSync = false;
        }

        public void AddInterval(D begin, D end, T data)
        {
            this.intervalList.Add(new Interval<T, D>(begin, end, data));
            this.inSync = false;
        }

        public bool IsInSync()
        {
            return this.inSync;
        }

        public void Build()
        {
            if (!this.inSync)
            {
                this.head = new IntervalNode<T, D>(this.intervalList);
                this.inSync = true;
                this.size = this.intervalList.Count;
            }
        }

        public IEnumerable<ICollection<Interval<T, D>>> GetIntersections()
        {
            this.Build();

            Queue<IntervalNode<T, D>> toVisit = new Queue<IntervalNode<T, D>>();
            toVisit.Enqueue(this.head);

            do
            {
                var node = toVisit.Dequeue();
                foreach (var intersection in node.Intersections)
                {
                    yield return intersection;
                }

                if (node.Left != null)
                {
                    toVisit.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    toVisit.Enqueue(node.Right);
                }
            }
            while (toVisit.Count > 0);
        }

        public override string ToString()
        {
            return this.NodeString(this.head, 0);
        }

        private string NodeString(IntervalNode<T, D> node, int level)
        {
            if (node == null)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            for (int i = 0; i < level; i++)
            {
                sb.Append("\t");
            }

            sb.Append(node + "\n");
            sb.Append(this.NodeString(node.Left, level + 1));
            sb.Append(this.NodeString(node.Right, level + 1));
            return sb.ToString();
        }
    }
}
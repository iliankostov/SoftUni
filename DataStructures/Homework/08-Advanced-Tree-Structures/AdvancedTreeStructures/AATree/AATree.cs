namespace AATreeNamespace
{
    using System;

    public class AATree<TKey, TValue>
        where TKey : IComparable<TKey>
    {
        private Node deleted;

        private Node root;

        private Node sentinel;

        public AATree()
        {
            this.root = this.sentinel = new Node();
            this.deleted = null;
        }

        public TValue this[TKey key]
        {
            get
            {
                Node node = this.Search(this.root, key);
                return node == null ? default(TValue) : node.value;
            }

            set
            {
                Node node = this.Search(this.root, key);
                if (node == null)
                {
                    this.Add(key, value);
                }
                else
                {
                    node.value = value;
                }
            }
        }

        public bool Add(TKey key, TValue value)
        {
            return this.Insert(ref this.root, key, value);
        }

        public bool Remove(TKey key)
        {
            return this.Delete(ref this.root, key);
        }

        private void Skew(ref Node node)
        {
            if (node.level == node.left.level)
            {
                Node left = node.left;
                node.left = left.right;
                left.right = node;
                node = left;
            }
        }

        private void Split(ref Node node)
        {
            if (node.right.right.level == node.level)
            {
                Node right = node.right;
                node.right = right.left;
                right.left = node;
                node = right;
                node.level++;
            }
        }

        private bool Insert(ref Node node, TKey key, TValue value)
        {
            if (node == this.sentinel)
            {
                node = new Node(key, value, this.sentinel);
                return true;
            }

            int compare = key.CompareTo(node.key);
            if (compare < 0)
            {
                if (!this.Insert(ref node.left, key, value))
                {
                    return false;
                }
            }
            else if (compare > 0)
            {
                if (!this.Insert(ref node.left, key, value))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            this.Skew(ref node);
            this.Split(ref node);
            return true;
        }

        private bool Delete(ref Node node, TKey key)
        {
            if (node == this.sentinel)
            {
                return this.deleted != null;
            }

            int compare = key.CompareTo(node.key);
            if (compare < 0)
            {
                if (!this.Delete(ref node.left, key))
                {
                    return false;
                }
            }
            else
            {
                if (compare == 0)
                {
                    this.deleted = node;
                }

                if (!this.Delete(ref node.right, key))
                {
                    return false;
                }
            }

            if (this.deleted != null)
            {
                this.deleted.key = node.key;
                this.deleted.value = node.value;
                this.deleted = null;
                node = node.right;
            }
            else if (node.left.level < node.level - 1 || node.right.level < node.level - 1)
            {
                --node.level;
                if (node.right.level > node.level)
                {
                    node.right.level = node.level;
                }

                this.Skew(ref node);
                this.Skew(ref node.right);
                this.Skew(ref node.right.right);
                this.Split(ref node);
                this.Split(ref node.right);
            }

            return true;
        }

        private Node Search(Node node, TKey key)
        {
            if (node == this.sentinel)
            {
                return null;
            }

            int compare = key.CompareTo(node.key);
            if (compare < 0)
            {
                return this.Search(node.left, key);
            }

            if (compare > 0)
            {
                return this.Search(node.right, key);
            }

            return node;
        }

        private class Node
        {
            internal TKey key;

            internal Node left;

            internal int level;

            internal Node right;

            internal TValue value;

            public Node()
            {
                this.level = 0;
                this.left = this;
                this.right = this;
            }

            public Node(TKey key, TValue value, Node sentinel)
            {
                this.level = 1;
                this.left = sentinel;
                this.right = sentinel;
                this.key = key;
                this.value = value;
            }
        }
    }
}
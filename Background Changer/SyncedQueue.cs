using System.Collections.Generic;

namespace Background_Changer.WallUtils
{
    class SyncedQueue<T>
    {
        private List<T> list;

        public SyncedQueue(List<T> list)
        {
            this.list = list;
        }

        public SyncedQueue() : this(new List<T>()) { }

        public int Count
        {
            get
            {
                lock (this)
                {
                    return this.list.Count;
                }
            }
        }

        public void PushFirst(T item)
        {
            lock (this)
            {
                this.list.Insert(0, item);
            }
        }

        public void Enqueue(T item)
        {
            lock (this)
            {
                this.list.Add(item);
            }
        }

        public T Peek()
        {
            T item = default(T);
            lock (this)
            {
                if (this.list.Count > 0)
                    item = this.list[0];
            }
            return item;
        }

        public T Dequeue()
        {
            T item = Peek();
            if (item != null)
                lock (this)
                {
                    this.list.RemoveAt(0);
                }
            return item;
        }

        public bool Contains(T item)
        {
            lock (this)
            {
                return this.list.Contains(item);
            }
        }

        public void RemoveItem(params T[] items)
        {
            foreach (var item in items)
                lock (this)
                {
                    this.list.Remove(item);
                }
        }
    }
}
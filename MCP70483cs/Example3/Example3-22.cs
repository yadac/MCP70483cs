using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example3
{
    class Example3_22<T>
    {
        private List<T>[] buckets = new List<T>[100];

        public void Insert(T item)
        {
            int bucket = GetBucket(item.GetHashCode());
            if (Contains(item, bucket)) return;

            // create bucket in bucket for distribution more, instead of 1 bucket.
            // this technique used by the hashtable in .net fw.
            if (buckets[bucket] == null)
                buckets[bucket] = new List<T>();
            buckets[bucket].Add(item);
        }

        //public bool Contains(T item)
        //{
        //    return Contains(item, GetBucket(item.GetHashCode()));
        //}

        private int GetBucket(int hashcode)
        {
            // GetHashCode always return positive.

            // UInt32 0 to 4,294,967,295.
            // Int32  -2,147,483,648 to 2,147,483,647
            // unchecked 整数型の算術演算と変換に対してオーバーフロー チェックを抑制するために使用します
            // unchecked コンテキストでは、式が変換先の型の範囲外の値を生成した場合に、オーバーフローが検出されません

            // A hash code can be negative. 
            // To make sure that you end up with a positive value cast the value to an unsigned int.
            // the unchecked block makes sure that you can cast a value larger then int to an int safely.
            unchecked
            {
                // uncheckedコンテキスト内なのでオーバーフローが発生しないで負数となる
                // a. 4,294,967,295 % 100 = 95 ... add list in bucket[95], bucket 95 contains 2 items.
                // b. 4,294,967,195 % 100 = 95 ... add list in bucket[95]
                // c. 4,294,967,194 % 100 = 94 ... add list in bucket[94]
                return (int)((uint)hashcode % (uint)buckets.Length);
            }
        }

        private bool Contains(T item, int bucket)
        {
            if (buckets[bucket] != null)
            {
                foreach (T member in buckets[bucket])
                {
                    if (member.Equals(item)) return true;
                }
            }
            return false;
        }
    }
}

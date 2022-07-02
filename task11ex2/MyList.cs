using System;
using System.Collections;
using System.Text;

namespace task11ex2
{
    public class MyList<T>: IList<T>
    {
        List<T> myList;

        public MyList()
        {
            myList = new List<T>();
        }

        public MyList(IEnumerable<T> enumarable)
        {
            myList = new List<T>(enumarable);
        }



        public T this[int index] {
            get
            {
                ThrowExceptionIfIndexIncorret(index);
                return myList[index];
            }
            set
            {
                ThrowExceptionIfIndexIncorret(index);
                myList[index] = value;
            }
        }

        private void ThrowExceptionIfIndexIncorret(int index)
        {
            if (!CheckIndex(index))
            {
                throw new IndexOutOfRangeException("Index out of range MyList");
            }
        }

        private bool CheckIndex(int index)
        {
            return index > 0 && index < Count;
        }

        public int Count
        {
            get
            {
                //return myList.Count;
                int count = 0;
                foreach (T item in myList)
                {
                    count++;
                }
                return count;
            } 
        }  

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            myList.Add(item);
        }

        public void Clear()
        {
            //myList.Clear();
            myList = new List<T>();
        }

        public bool Contains(T item)
        {
            foreach (T checkItem in myList)
            {
                if (checkItem.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = 0; i < Count; i++)
            {
                array.SetValue(array[i], arrayIndex++);
            };
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in myList)
            {
                yield return item;
            };
        }

        public int IndexOf(T item)
        {
            for (int i=0; i<Count; i++)
            {
                if (myList[i].Equals(item))
                {
                    return i;
                }
            }
            throw new ArgumentOutOfRangeException("No such element in MyList");
        }

        public void Insert(int index, T item)
        {
            ThrowExceptionIfIndexIncorret(index);
            //myList.Insert( index, item);
            myList.Add(myList[Count - 1]);
            for (int i = (Count - 1); i > index; i--)
            {
                myList[i] = myList[i-1];
            }
            myList[index] = item;
        }

        public bool Remove(T item)
        {
            //myList.Remove(item);
            int index = IndexOf(item);
            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            ThrowExceptionIfIndexIncorret(index);
            //myList.RemoveAt(index);
            myList.Add(myList[Count - 1]);
            for (int i = index; i < (Count-1); i++)
            {
                myList[i] = myList[i+1];
            }
            myList = new List<T>(myList.ToArray()[0..(Count-1)]);

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach(T item in myList)
            {
                yield return item;
            }
        }

        public override string ToString()
        {
            string result = "MyList [EMPTY]";
            if (Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                string delimiter = ";";
                foreach (T item in myList)
                {
                    sb.Append(item.ToString());
                    sb.Append(delimiter);
                }
                result = sb.ToString()[0..^delimiter.Length];
            }
            return result;
        }
    }
}


using System;
using System.Collections;
using System.Collections.Generic;

namespace Dictionary.Models
{
    public class MainDict<TKey, TValue> : IEnumerable
    {
        private int size = 100;
        private Item<TKey, TValue>[] items;
        private List<TKey> Keys = new List<TKey>();
        public MainDict()
        {
            items = new Item<TKey, TValue>[size];
        }

        public void Add(Item<TKey, TValue> item)
        {
            var hash = GetHash(item.Key);

            if (Keys.Contains(item.Key))
            {
                return;
            }

            if (items[hash] == null)
            {
                Keys.Add(item.Key);
                items[hash] = item;
            }
            else
            {
                var placed = false;
                for (var i = hash; i < size; i++)
                {
                    if (items[i] == null)
                    {
                        Keys.Add(item.Key);
                        items[i] = item;
                        placed = true;
                        break;
                    }
                    if (items[i].Key.Equals(item.Key))
                    {
                        return;
                    }
                }
                if (!placed)
                {
                    for (var i = 0; i < hash; i++)
                    {
                        if (items[i] == null)
                        {
                            Keys.Add(item.Key);
                            items[i] = item;
                            break;
                        }
                        if (items[i].Key.Equals(item.Key))
                        {
                            return;
                        }
                    }
                }

                if (!placed)
                {
                    throw new Exception("Dictionary is full");
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in items)
            {
                if (item != null)
                {
                    yield return item;
                }
            }
        }

        public void Remove(TKey key)
        {
            var hash = GetHash(key);

            if (!Keys.Contains(key))
            {
                return;
            }

            if (items[hash] == null)
            {
                for (var i = 0; i < size; i++)
                {
                    if (items[i] != null && items[i].Key.Equals(key))
                    {
                        items[i] = null;
                        Keys.Remove(key);
                        return;
                    }
                }
                return;
            }

            if (items[hash].Key.Equals(key))
            {
                items[hash] = null;
                Keys.Remove(key);
            }
            else
            {
                for (var i = hash; i < size; i++)
                {
                    if (items[i] == null)
                    {
                        return;
                    }
                    if (items[i].Key.Equals(key))
                    {
                        items[i] = null;
                        Keys.Remove(key);
                        return;
                    }
                }
                for (var i = 0; i < hash; i++)
                {
                    if (items[i] == null)
                    {
                        return;
                    }
                    if (items[i].Key.Equals(key))
                    {
                        items[i] = null;
                        Keys.Remove(key);
                        return;
                    }
                }
            }

        }

        public TValue Search(TKey key)
        {
            var hash = GetHash(key);

            if (!Keys.Contains(key))
            {
                return default(TValue);
            }

            if (items[hash] == null)
            {
                foreach (var item in items)
                {
                    if (item.Key.Equals(key))
                    {
                        return item.Value;
                    }
                }
                return default(TValue);
            }

            if (items[hash].Key.Equals(key))
            {
                return items[hash].Value;
            }
            else
            {
                for (var i = hash; i < size; i++)
                {
                    if (items[i].Key.Equals(key))
                    {
                        return items[i].Value;
                    }
                    if (items[i] == null)
                    {
                        return default(TValue);
                    }
                }
                for (var i = 0; i < hash; i++)
                {
                    if (items[i].Key.Equals(key))
                    {
                        return items[i].Value;
                    }
                    if (items[i] == null)
                    {
                        return default(TValue);
                    }
                }
            }
            return default(TValue);
        }

        private int GetHash(TKey key)
        {
            return key.GetHashCode() % size;
        }
    }
}
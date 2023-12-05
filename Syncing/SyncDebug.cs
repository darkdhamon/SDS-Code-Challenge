using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperSample.Syncing
{
    public class SyncDebug
    {
        /// <summary>
        /// I was not sure how to do this, since this is not something I usually handle.
        /// So I decided to use an AI to help me with creating as solution for this.
        /// I knew the reason this was failing was due to the async code not getting awaited
        /// properly but having never used Parallel before I needed help.
        /// I initially was going to use google to research this issue but since I have been
        /// experimenting with AI I decided to see what ChatGPT could come up with. here is a
        /// link to my conversation with ChatGPT about this method.
        /// https://chat.openai.com/share/0943adda-5a1f-467d-9b8b-024debdd4ff4
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public List<string> InitializeList(IEnumerable<string> items)
        {
            var bag = new ConcurrentBag<string>();
            var completedEvent = new CountdownEvent(items.Count());
            Parallel.ForEach(items, async i =>
            {
                try
                {
                    var r = await Task.Run(() => i).ConfigureAwait(false);
                    bag.Add(r);
                }
                finally
                {
                    completedEvent.Signal();
                }
            });
            completedEvent.Wait();
            
            var list = bag.ToList();
            return list;
        }

        public Dictionary<int, string> InitializeDictionary(Func<int, string> getItem)
        {
            var itemsToInitialize = Enumerable.Range(0, 100).ToList();

            var concurrentDictionary = new ConcurrentDictionary<int, string>();
            var threads = Enumerable.Range(0, 3)
                .Select(i => new Thread(() => {
                    foreach (var item in itemsToInitialize)
                    {
                        concurrentDictionary.AddOrUpdate(item, getItem, (_, s) => s);
                    }
                }))
                .ToList();

            foreach (var thread in threads)
            {
                thread.Start();
            }
            foreach (var thread in threads)
            {
                thread.Join();
            }

            return concurrentDictionary.ToDictionary(kv => kv.Key, kv => kv.Value);
        }
    }
}
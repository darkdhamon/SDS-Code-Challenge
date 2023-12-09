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
        /// experimenting with AI I decided to see what ChatGPT could come up with.
        ///
        /// here is a link to my conversation with ChatGPT about this method.
        /// https://chat.openai.com/share/0943adda-5a1f-467d-9b8b-024debdd4ff4
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public List<string> InitializeList(IEnumerable<string> items)
        {
            var bag = new ConcurrentBag<string>();
            // remove possible multiple enumeration warning in case a IEnumerable that
            // can not be enumerated multiple times is passed in
            var enumerable = items.ToList(); 
            var completedEvent = new CountdownEvent(enumerable.Count());
            Parallel.ForEach(enumerable, async i =>
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

        /// <summary>
        /// I also was not sure how to do this one and used ChatGPT for ideas. In the following code
        /// "Enumerable.Range(0, 3).Select(i..." I did not know what "i" was but I should have realized
        /// that it was the index of thread. created by the Enumerable. There was a few options that I
        /// discussed with ChatGPT about this problem.
        ///
        /// After understanding what "i" was I decided to modify the code further so that if we were to modify
        /// the number of threads in the future we would only need to change one line of code as coding best
        /// practices would indicate.
        ///
        /// here is a link to my conversation with ChatGPT about how to address this issue.
        /// https://chat.openai.com/share/f4a6e7a4-d38f-4c63-a7ff-5d991b4e1f5a
        /// </summary>
        /// <param name="getItem"></param>
        /// <returns></returns>
        public Dictionary<int, string> InitializeDictionary(Func<int, string> getItem)
        {
            var itemsToInitialize = Enumerable.Range(0, 100).ToList();

            var concurrentDictionary = new ConcurrentDictionary<int, string>();
            var numThreads = 3;
            var threads = Enumerable.Range(0, numThreads)
                .Select(threadID => new Thread(() =>
                {
                    for (var index = threadID; index < itemsToInitialize.Count; index+=numThreads)
                    {
                        var item = itemsToInitialize[index];
                        concurrentDictionary.AddOrUpdate(
                            item, 
                            getItem,
                            (_, s) => s); 
                        /// Unit Test Coverage says that this lambda in the UpdateValueFactory
                        /// is untested. I do not known how to get this to be covered in UnitTest
                        /// since I do not know when this lambda would be called, or what this
                        /// lambda even does. As and educated guess, if the item already exist in
                        /// the factory it would update instead of adding, but I dont know for
                        /// sure. But for now... this means that my c# Unit Test coverage is stuck
                        /// at 99% code coverage.
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

            return concurrentDictionary
                .ToDictionary(
                    kv => kv.Key,
                    kv => kv.Value);
        }
    }
}
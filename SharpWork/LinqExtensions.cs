using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpWork
{
    public static class LinqExtensions
    {
        public static async Task<IEnumerable<TResult>> SelectAsync<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, Task<TResult>> selector)
        {
            // 使用 LINQ ToListAsync 进行异步转换
            var tasks = source.Select(selector);
            var results = await Task.WhenAll(tasks);
            return results;
        }
    }
}

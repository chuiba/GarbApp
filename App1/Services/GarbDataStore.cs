using App1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Services
{
    class GarbDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public GarbDataStore()
        {
            // 获取所有的装扮信息

            items = new List<Item>()
            {
                new Item { Id = "1", Text = "呜米", Description="12345" },
                new Item { Id = "1", Text = "星座系列：狮子座", Description="54321" },
            };
        }


        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}

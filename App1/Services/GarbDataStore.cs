using App1.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App1.Services
{
    class GarbDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        private void updateGarbInfo()
        {
            items.Clear();

            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://www.bilibili.com/h5/mall/home?navhide=1");
            StreamReader ss = new StreamReader(stream);

            string html = ss.ReadToEnd();
            // Console.WriteLine(html);

            string pattern = "{\"item_id\":[^0].*?sale_surplus\":\\d+}";
            foreach (Match match in Regex.Matches(html, pattern))
            {
                JObject jo = (JObject)JsonConvert.DeserializeObject(match.Value);
                int surplus = int.Parse(jo["sale_surplus"].ToString());
                int quantity = int.Parse(jo["properties"]["sale_quantity"].ToString());
                // 编号 = 总量 - 库存; 另外需要注意星座等没有库存限制的 
                int number = quantity - surplus;

                if (surplus <= 0)
                    continue;

                items.Add(new Item
                {
                    Id = jo["item_id"].ToString(),
                    Text = jo["name"].ToString(),
                    Description = number.ToString()
                });
            }

            // TODO: 排序这里做了, 后续可以考虑做成参数
            items.Sort();
        }

        public GarbDataStore()
        {
            // 获取所有的装扮信息
            items = new List<Item>();
            updateGarbInfo();
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.Run(() =>
            {
                updateGarbInfo();
                return items;
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App1.Services
{
    /// <summary>
    /// 一个对于B站API进行封装的库, 外部使用者只需要通过简单的接口访问, 就可以获取信息
    /// </summary>
    class Bilibili
    {
        /// <summary>
        /// 装扮的结构体
        /// </summary>
        public struct garb
        {
            public int id;
            public string name;
            public int surplus;
            public int qunarity;
        }

        /// <summary>
        /// 最新购买装扮人的信息
        /// </summary>
        public struct rencent
        {
            public int id;
            public string uid;
            public string name;
        }


        // 所有的装扮信息
        private List<garb> garbList;

        /// <summary>
        /// 获取装扮列表清单
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<garb>> GetGarbList()
        {
            return await Task.FromResult(garbList);
        }

        //public async Task<IEnumerable<rencent>> GetRecent(int id)
        //{
            
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.创建型模式.建造者模式
{
    public interface Item
    {
        /// <summary>
        /// 名称
        /// </summary>
        /// <returns></returns>
        public string Name();
        /// <summary>
        /// 打包
        /// </summary>
        /// <returns></returns>
        public IPacking Packing();
        /// <summary>
        /// 价格
        /// </summary>
        /// <returns></returns>
        public float Price();
    }
}

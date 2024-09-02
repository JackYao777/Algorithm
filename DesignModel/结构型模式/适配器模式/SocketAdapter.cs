using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.结构型模式.适配器模式
{
    /// <summary>
    /// 适配器模式 
    /// 1:目标接口,先是华为插座，现在要适配苹果插座,然后外面加一层适配器,将苹果插座实现引入，然后在目标接口调用
    /// </summary>
    public class SocketAdapter : IHuaWSocket
    {
        private IPingGuoSocket socket;
        public SocketAdapter(IPingGuoSocket socket)
        {
            this.socket = socket;
        }
        public void Charge()
        {
            socket.PingGuoCharge();
        }
    }
}

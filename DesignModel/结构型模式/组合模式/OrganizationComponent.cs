using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.结构型模式.组合模式
{
    /// <summary>
    /// 设计一个个体与组合通用的接口
    /// </summary>
    public abstract class OrganizationComponent
    {
        private string _name;

        protected OrganizationComponent(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }

        public abstract void Add(OrganizationComponent organization);

        public abstract OrganizationComponent GetChild(string orgName);

        public abstract int GetStaffCount();
    }
}

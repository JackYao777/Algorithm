using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.结构型模式.组合模式
{
    /// <summary>
    /// It部门(叶子节点)
    /// </summary>
    public class ItDepartment : OrganizationComponent
    {
        public ItDepartment(string name) : base(name)
        {
        }

        public override void Add(OrganizationComponent organization)
        {
            throw new NotImplementedException(this.GetName() + "已经是最基本部门，无法增加下属部门");
        }

        public override OrganizationComponent GetChild(string orgName)
        {
            if (this.GetName() == (orgName))
            {
                return this;
            }
            return null;
        }

        public override int GetStaffCount()
        {
            return 20;
        }
    }
}

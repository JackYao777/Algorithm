using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.结构型模式.组合模式
{
    /// <summary>
    /// 组合类
    /// </summary>
    public class OrganizationComposite : OrganizationComponent
    {
        //很关键，这体现了组合的思想
        private List<OrganizationComponent> organizations = new List<OrganizationComponent>();

        public OrganizationComposite(string name) : base(name)
        {
        }

        public override void Add(OrganizationComponent organization)
        {
            organizations.Add(organization);
        }

        public override OrganizationComponent GetChild(string orgName)
        {
            foreach (var item in organizations)
            {
                OrganizationComponent targetOrg = item.GetChild(orgName);
                if (targetOrg != null)
                {
                    return targetOrg;
                }
            }
            return null;
        }

        public override int GetStaffCount()
        {
            int num = 0;
            foreach (var item in organizations)
            {
                num += item.GetStaffCount();
            }
            return num;
        }
    }
}

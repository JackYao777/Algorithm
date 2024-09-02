using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.结构型模式.组合模式
{
    public class CompositeClient
    {
        private OrganizationComponent constructOrganization()
        {
            //构建总部
            OrganizationComposite head = new OrganizationComposite("总公司");
            AdminDepartment headAdmin = new AdminDepartment("总公司行政部");
            ItDepartment headIt = new ItDepartment("总公司It部");
            head.Add(headAdmin);
            head.Add(headIt);

            //构建分公司
            OrganizationComposite branch1 = new OrganizationComposite("天津分公司");
            AdminDepartment branch1Admin = new AdminDepartment("天津分公司行政部");
            ItDepartment branch1It = new ItDepartment("天津分公司It部");
            branch1.Add(branch1Admin);
            branch1.Add(branch1It);

            //将分公司加入到head中
            head.Add(branch1);

            return head;
        }

        public void listOrgInfo()
        {
            OrganizationComponent org = constructOrganization();
            Console.WriteLine($"{org.GetName()}共有{org.GetStaffCount()}名员工");

            OrganizationComponent subOrg = org.GetChild("天津分公司行政部");
            Console.WriteLine($"{subOrg.GetName()}共有{subOrg.GetStaffCount()}名员工");
        }
    }
}

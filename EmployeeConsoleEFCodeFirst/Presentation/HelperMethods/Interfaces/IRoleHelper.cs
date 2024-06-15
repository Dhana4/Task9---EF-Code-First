using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperMethods;
public interface IRoleHelper
{
    bool DisplayAvailableRoles();
    int ChooseRoleId();
    void AddRole();
    void EditRole();
}

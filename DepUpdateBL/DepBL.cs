using DepUpdateDAL;
using DepUpdateDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepUpdateBL
{
    public class DepBL
    {
        public int UpdateNewDepartment(DepDTO newObj)
        {
            try
            {
                DepDAL dalObj = new DepDAL();
                int result = dalObj.UpdateDepartment(newObj);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
    public class WorkShopBusiness
    {
        public bool InsertWorkShop(WorkShopBO workShopBO)
        {
            if(workShopBO.WorkShopDate > DateTime.Now)
            {
                WorkShopDB workShopDB = new WorkShopDB();
                workShopDB.InsertWorkShop(workShopBO);
                return true;
            }
            return false;
            
        }

        public List<WorkShopBO> GetAllWorkShops()
        {
            WorkShopDB workShopDB = new WorkShopDB();
            return workShopDB.GetAllWorkShops();
        }

        public WorkShopBO GetWorkShopById(int WorkShopId)
        {
            WorkShopDB workShopDB = new WorkShopDB();
            WorkShopBO workShopBO = workShopDB.GetWorkShopById(WorkShopId);
            return workShopBO;
        }

        public bool UpdateWorkShopById(WorkShopBO workShopBO, int WorkShopId)
        {
            WorkShopDB workShopDB = new WorkShopDB();
            if (workShopBO.WorkShopDate > DateTime.Now)
            {
                workShopDB.UpdateWorkShopById(workShopBO, WorkShopId);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteWorkShopById(int WorkShopId)
        {
            WorkShopDB workShopDB = new WorkShopDB();
            workShopDB.DeleteWorkShopById(WorkShopId);
            return true;
        }

        public bool AssignTrainersToWorkShop(List<TrainerWorkShopMappingBO> ls)
        {
            WorkShopDB workShopDB = new WorkShopDB();
            workShopDB.AssignTrainersToWorkShop(ls);
            return true;
        }
    }
}

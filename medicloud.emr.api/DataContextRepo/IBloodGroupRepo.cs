using medicloud.emr.api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medicloud.emr.api.DataContextRepo
{
    
    public interface ITitleRepo
    {
        bool AddNew(string name);
        IEnumerable<Title> GetAll();
        bool update(long id, Title title);
        bool Delete(long id);
        Title GetSingle(long id);
    }
    public class TitleRepo : ITitleRepo
    {

        private IDataContextRepo<Title> titleDb;

        public TitleRepo()
        {
            titleDb = new DataContextRepo<Title>();
        }

        public bool AddNew(string name)
        {
            return titleDb.AddNew(new Title() { Titlename = name, Dateadded = DateTime.Now });
        }

        public bool Delete(long id)
        {
            Title singleDelete = GetSingle(id);
            if (singleDelete != null)
            {
                return titleDb.Delete(singleDelete);
            }
            return false;
        }

        public IEnumerable<Title> GetAll()
        {
            return titleDb.GetAll();
        }

        public Title GetSingle(long id)
        {
            return titleDb.GetSingle(x => x.Titleid == id);
        }

        public bool update(long id, Title bp)
        {
            Title singleDelete = GetSingle(id);
            if (singleDelete != null)
            {
                singleDelete.Titlename = bp.Titlename;
                return titleDb.Update(singleDelete);
            }
            return false;
        }

        
    }
    public interface IBloodGroupRepo
    {
        bool AddNew(string name);
        IEnumerable<BloodGroup> GetAll();
        bool update(long id, BloodGroup bp);
        bool Delete(long id);
        BloodGroup GetSingle(long id);
        
    }
    public class BloodGroupRepo : IBloodGroupRepo
    {
        private IDataContextRepo<BloodGroup> bpo;

        public BloodGroupRepo()
        {
            bpo = new DataContextRepo<BloodGroup>();
        }

        public bool AddNew(string name)
        {
            return bpo.AddNew(new BloodGroup() { Bloodgroupname = name, Dateadded = DateTime.Now.ToString() });
        }

        public bool Delete(long id)
        {
            BloodGroup singleDelete = GetSingle(id);
            if(singleDelete != null)
            {
                return bpo.Delete(singleDelete);
            }
            return false;
        }

        public IEnumerable<BloodGroup> GetAll()
        {
            return bpo.GetAll();
        }

        public BloodGroup GetSingle(long id)
        {
            return bpo.GetSingle(x => x.Bloodgroupid == id);
        }

        public bool update(long id, BloodGroup bp)
        {
            BloodGroup singleDelete = GetSingle(id);
            if (singleDelete != null)
            {
                singleDelete.Bloodgroupname = bp.Bloodgroupname;
                return bpo.Update(singleDelete);
            }
            return false;
        }
    }
}

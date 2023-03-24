using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageGroupRepository : IPageGroupRepository
    {

        private readonly MyCmsContext db;

        public PageGroupRepository(MyCmsContext db)
        {
            this.db = db;
        }
        public IEnumerable<PageGroup> GetAll()
        {
            return db.PageGroups;
        }

        public PageGroup GetById(int id)
        {
            return db.PageGroups.Single(pageGroup => pageGroup.GroupID == id);
        }

        public bool InsertPageGroup(PageGroup group)
        {
            try
            {
                db.PageGroups.Add(group);
                return true;
            } catch (Exception)
            {
                return false;
            }
        }
        public bool UpdatePageGroup(PageGroup group)
        {
            try
            {
                db.Entry(group).State = EntityState.Modified;
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public bool DeletePageGroup(int id)
        {
            try
            {
                db.Entry(GetById(id)).State = EntityState.Deleted;//TODO how to use one query
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeletePageGroup(PageGroup group)
        {

            try
            {
                db.Entry(group).State= EntityState.Deleted;
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}

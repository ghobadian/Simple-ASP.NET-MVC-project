using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageRepository : IPageRepository
    {
        private readonly MyCmsContext db;

        public PageRepository(MyCmsContext db) => this.db = db;

        public IEnumerable<Page> GetAll() => db.Pages;

        public Page GetById(int id) => db.Pages.Single(pageComment => pageComment.PageId == id);

        public bool InsertPage(Page page) => tryInsertPage(page);

        private bool tryInsertPage(Page page)
        {
            try
            {
                db.Pages.Add(page);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdatePage(Page page) => tryUpdatePage(page);

        private bool tryUpdatePage(Page page)
        {
            try
            {
                db.Entry(page).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeletePage(int id)
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

        public bool DeletePage(Page page)
        {

            try
            {
                db.Entry(page).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Save() => db.SaveChanges();

        public void Dispose() => db.Dispose();
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageCommentRepository
    {
        private readonly MyCmsContext db;

        public PageCommentRepository(MyCmsContext db)
        {
            this.db = db;
        }

        public IEnumerable<PageComment> GetAll()
        {
            return db.PageComments;
        }

        public PageComment GetById(int id)
        {
            return db.PageComments.Single(pageComment => pageComment.CommentID == id);
        }

        public bool InsertPageComment(PageComment comment)
        {
            try
            {
                db.PageComments.Add(comment);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdatePageComments(PageComment comment)
        {
            try
            {
                db.Entry(comment).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeletePageComment(int id)
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

        public bool DeletePageComment(PageComment comment)
        {

            try
            {
                db.Entry(comment).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
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

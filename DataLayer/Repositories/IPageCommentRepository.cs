using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageCommentRepository : IDisposable
    {
        IEnumerable<PageComment> GetAll();
        PageComment GetById(int id);
        bool InsertPageComment(PageComment pageComment);
        bool UpdatePageComment(PageComment pageComment);
        bool DeletePageComment(int id);
        bool DeletePageComment(PageComment pageComment);
        void Save();
        void Dispose();
    }
}

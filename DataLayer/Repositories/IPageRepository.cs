using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageRepository : IDisposable
    {
        IEnumerable<Page> GetAll();
        Page GetById(int id);
        bool InsertPage(Page page);
        bool UpdatePage(Page page);
        bool DeletePage(int id);
        bool DeletePage(Page page);
        void Save();

        void Dispose();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageGroupRepository : IDisposable
    {
        IEnumerable<PageGroup> GetAll();
        PageGroup GetById(int id);
        bool InsertPageGroup(PageGroup group);
        bool UpdatePageGroup(PageGroup group);
        bool DeletePageGroup(int id);
        bool DeletePageGroup(PageGroup group);
        void Save();
        void Dispose();
    }
}

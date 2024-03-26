using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.IRepository
{
    internal interface IALLRepository<T> where T : class
    {
        public ICollection<T> GetAll();
        public T GetByID(dynamic id); //có thể dùng Type
        public bool Create(T obj); //tạo mới và truyền vào trong db
        public bool Update(T obj);
        public bool Delete(dynamic id);
    }
}

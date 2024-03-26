using App_Data.IRepository;
using App_Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Repository
{
    public class ALLRepository<T> : IALLRepository<T> where T : class
    {
        Sd18302Net104Context context;
        DbSet<T> dbset; // tạo ra để CRUD vì nó đại diện cho bảng
        //Khi cần gọi lại và dùng thật thì lại cần chính xác nó là DBset nào
        //lúc đó ta sẽ gán dbset = dbset cần dùng

        public ALLRepository()
        {
            context = new Sd18302Net104Context();
        }

        public ALLRepository( DbSet<T> dbset, Sd18302Net104Context context )
        {
            this.dbset = dbset; //gán lại khi dùng
            this.context = context;
        }
        public bool Create(T obj)   
        {
            try
            {
                dbset.Add(obj);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(dynamic id)
        {
            try
            {
                var del = dbset.Find(id);//chỉ sử dụng với PK
                dbset.Remove(del);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public ICollection<T> GetAll()
        {
            return dbset.ToList();
        }

        public T GetByID(dynamic id)
        {
            return dbset.Find(id);
        }

        public bool Update(T obj)
        {
            try
            {
                dbset.Update(obj);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

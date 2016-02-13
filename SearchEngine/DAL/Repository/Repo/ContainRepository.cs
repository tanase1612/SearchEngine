using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace DAL.Repository.Repo
{
   public class ContainRepository
    {
        public IEnumerable<Contain> GetAllContains()
        {
            using (var db = new SearchEngineEntities())
            {
                return db.Contains.ToList();
            }
        }

        public Contain GetContain(int id)
        {
            using (var db = new SearchEngineEntities())
            {
                var Contain = from e in db.Contains
                              where e.termId == id
                              select e;
                return Contain.FirstOrDefault();
            }
        }

        public Contain CreateContain(Contain contain)
        {
            using (var db = new SearchEngineEntities())
            {
                db.Contains.Add(contain);
                db.SaveChanges();
                return contain;
            }
        }

        //public bool Updatecontain(Contain contain)
        //{
        //    using (var db = new SearchEngineEntities())
        //    {
        //        if (contain == null)
        //        {
        //            throw new ArgumentNullException("item");
        //        }
        //        Contain containBeingUpdated = db.Contains.Single(e => e.ID == document.ID);
        //        containBeingUpdated = contain;
        //        containBeingUpdated= contain;
        //        db.SaveChanges();
        //        return true;
        //    }
        //}

        public void DeleteContain(int id)
        {
            using (var db = new SearchEngineEntities())
            {
                Contain contain = db.Contains.Single(e => e.termId == id);
                db.Contains.Remove(contain);
                db.SaveChanges();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace DAL.Repository.Repo
{
    public class TermRepository : ITermRepository
    {
        public IEnumerable<Term> GetAllTerms()
        {
            using (var db = new SearchEngineEntities())
            {
                return db.Terms.ToList();
            }
        }

        public Term GetTerm(int id)
        {
            using (var db = new SearchEngineEntities())
            {
                var Term = from e in db.Terms
                           where e.ID == id
                           select e;
                return Term.FirstOrDefault();
            }
        }

        public Term CreateTerm(Term term)
        {
            using (var db = new SearchEngineEntities())
            {
                db.Terms.Add(term);
                db.SaveChanges();
                return term;
            }
        }

        public bool UpdateTerm(Term term)
        {
            using (var db = new SearchEngineEntities())
            {
                if (term == null)
                {
                    throw new ArgumentNullException("item");
                }
                Term termBeingUpdated = db.Terms.Single(e => e.ID == term.ID);
                termBeingUpdated.value = term.value;
                db.SaveChanges();
                return true;
            }
        }

        public void DeleteTerm(int id)
        {
            using (var db = new SearchEngineEntities())
            {
                Term term = db.Terms.Single(e => e.ID == id);
                db.Terms.Remove(term);
                db.SaveChanges();
            }
        }
    }
}

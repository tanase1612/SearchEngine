using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace DAL.Repository
{
    public interface ITermRepository
    {
        IEnumerable<Term> GetAllTerms();

        Term GetTerm(int id);
        Term CreateTerm(Term term);
        bool UpdateTerm(Term term);

        void DeleteTerm(int id);
    }
}

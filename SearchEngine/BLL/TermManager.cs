using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;
using DAL.Repository;
using DAL.Repository.Repo;
using DTO;

namespace BLL
{
    
   public class TermManager
    {
       ITermRepository repo = new Facade().getTermRepository();
    

        public void Create(TermDTO termDTO)
         {
             Term term = repo.CreateTerm(new Term
             {
                 ID = termDTO.ID,
                 value = termDTO.value
             });
         }

       public IEnumerable<TermDTO> GetAll()
        {
            return repo.GetAllTerms().Select(c => new TermDTO
            {
                ID = c.ID,
                value = c.value

            });
        }

    }
}

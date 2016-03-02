using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository.Repo;

namespace DAL.Repository
{
    public class Facade
    {
        private IDocumentRepository docRepo;
        private IContainRepository contRepo;
        private ItermRepository termrepo;


        public IDocumentRepository GetDocumentRepository()
        {
            return docRepo == null ? docRepo = new DocumentRepository() : docRepo;
        }

        public IContainRepository getContainRepository()
        {
            return contRepo == null ? contRepo = new ContainRepository() : contRepo;
        }

        public ItermRepository getTermRepository()
        {
            return termrepo == null ? termrepo = new TermRepository() : termrepo;
        }
    }
}

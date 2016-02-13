using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace DAL.Repository
{
    public interface IDocumentRepository
    {
        IEnumerable<Document> GetAllDocuments();

        Document GetDocument(int id);
        Document CreateDocument(Document document);
        bool UpdateDocument(Document document);

        void DeleteDocument(int id);
    }
}

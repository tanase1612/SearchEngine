using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace DAL.Repository.Repo
{
   public class DocumentRepository : IDocumentRepository
    {
        public IEnumerable<Document> GetAllDocuments()
        {
            using (var db = new SearchEngineEntities())
            {
                return db.Documents.ToList();
            }
        }

        public Document GetDocument(int id)
        {
            using (var db = new SearchEngineEntities())
            {
                var Document = from e in db.Documents
                               where e.ID == id
                               select e;
                return Document.FirstOrDefault();
            }
        }

        public Document CreateDocument(Document document)
        {
            using (var db = new SearchEngineEntities())
            {
                db.Documents.Add(document);
                db.SaveChanges();
                return document;
            }
        }

        public bool UpdateDocument(Document document)
        {
            using (var db = new SearchEngineEntities())
            {
                if (document == null)
                {
                    throw new ArgumentNullException("item");
                }
                Document documentBeingUpdated = db.Documents.Single(e => e.ID == document.ID);
                documentBeingUpdated.IndexTime = document.IndexTime;
                documentBeingUpdated.URL = document.URL;
                db.SaveChanges();
                return true;
            }
        }

        public void DeleteDocument(int id)
        {
            using (var db = new SearchEngineEntities())
            {
                Document document = db.Documents.Single(e => e.ID == id);
                db.Documents.Remove(document);
                db.SaveChanges();
            }
        }
    }
}

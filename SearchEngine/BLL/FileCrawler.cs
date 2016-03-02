using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DTO;
using DAL.Repository;
using DAL.Repository.Repo;
using DAL.Model;

namespace BLL
{
    class FileCrawler
    {
        private IDocumentRepository docRepo = new Facade().GetDocumentRepository();

        private String URL;
        private DateTime time;
         public void Filereading(DocumentDTO documentdto)
        {
            string text = documentdto.URL;
            crawl(text);
        }
    
    
    //static int count = 0;
    //private static void crawl(string path)
    //{
    //    var start = DateTime.UtcNow.Millisecond;

    //    crawl(path, "");
    //    var end = DateTime.UtcNow.Millisecond;

    //    long timeSpan = (end - start) / 1000;

    //}

    public void crawl(string path)
    {
        if (Directory.Exists(path))
        {
            string[] subFiles = Directory.GetFiles(path);
            
            for (int i = 0; i < subFiles.Length; i++)
            {
                crawl(subFiles[i]);
                
            }
            foreach (string s in subFiles)
            {
                URL = s;
                time = File.GetCreationTimeUtc(s);
                Document doc = docRepo.CreateDocument(new Document
                 {
                     URL = URL,
                     IndexTime = time
                 });
              
            }
        }
    }
    }
}

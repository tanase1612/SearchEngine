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
    public class FileCrawler
    {
        private IDocumentRepository docRepo = new Facade().GetDocumentRepository();

        private String URL;
        private DateTime time;
        private int id;
        public void Filereading(DirectoryDTO directoryDTO)
        {
            string text = directoryDTO.dir;
            crawl(text);
        }


        

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
                         ID = id,
                         URL = URL,
                         IndexTime = time
                     });

                }
            }
        }
    }
}
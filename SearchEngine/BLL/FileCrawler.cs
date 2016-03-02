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
<<<<<<< HEAD
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
=======
    //     public void Filereading()
    //    {
    //        string text = "Documents";
    //        crawl(f);
    //    }
    
    
    //static int count = 0;
    //public static void crawl(File f)
    //{
    //    DateTime start = new DateTime();
        
    //	crawl(f, "");
    //   DateTime end = new DateTime();
    //    long timeSpan = (end.Date - start.Date)/1000;
    //    System.out.println("Renaming finished in " + timeSpan + "s. " + count + " docs renamed.");
    //}
    
    //private static void crawl(File f, String indent)
    //{
    //	//System.out.println(indent + f.getName());
    //	if (f.isDirectory()) {
    //    	File[] subFiles = f.listFiles();
    //		indent += "    ";
    //    	for (int i = 0; i < subFiles.length; i++) {
    //          	crawl(subFiles[i], indent);
    //    	}
    //    y
    //    }
    //    else 
    //        if (f.isFile() && !f.isHidden())
    //        {
    //            f.renameTo(new File(f.getAbsolutePath()+"txt"));
    //            count++;
    //        }
        
    //}
>>>>>>> 849266fbeed5edf1e85dcc35722236e553f48cfe
    }
}

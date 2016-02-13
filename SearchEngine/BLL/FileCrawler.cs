using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BLL
{
    class FileCrawler
    {
         public void Filereading()
        {
            string text = "text";
           File f = new File(text);
            crawl(f);
        }
    
    
    static int count = 0;
    public static void crawl(File f)
    {
        DateTime start = new DateTime();
        
    	crawl(f, "");
       DateTime end = new DateTime();
        long timeSpan = (end.g() - start.getTime())/1000;
        System.out.println("Renaming finished in " + timeSpan + "s. " + count + " docs renamed.");
    }
    
    private static void crawl(File f, String indent)
    {
    	//System.out.println(indent + f.getName());
    	if (f.isDirectory()) {
        	File[] subFiles = f.listFiles();
    		indent += "    ";
        	for (int i = 0; i < subFiles.length; i++) {
              	crawl(subFiles[i], indent);
        	}
        
        }
        else 
            if (f.isFile() && !f.isHidden())
            {
                f.renameTo(new File(f.getAbsolutePath()+"txt"));
                count++;
            }
        
    }
    }
}

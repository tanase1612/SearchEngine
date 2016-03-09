﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using DAL.Repository.Repo;
using DAL.Repository;
using DAL.Model;
using BLL;


namespace IndexClient
{
    public partial class Form1 : Form
    {
        IDocumentRepository docrepo = new Facade().GetDocumentRepository();
        FileCrawler crawler = new FileCrawler();
        public Form1()
        {
            InitializeComponent();
          
        }

       

        private void txtFiles_TextChanged(object sender, EventArgs e)
        {
            docrepo.GetAllDocuments();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string directory = txtFiles.Text;
            crawler.Filereading(new DirectoryDTO
            {
                dir = directory
            });
            
        }

        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}

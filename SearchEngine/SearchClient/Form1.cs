﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
namespace SearchClient
{
    public partial class Form1 : Form
    {
        TermManager term = new TermManager();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string name = txtSearch.Text;
            term.Create(new TermDTO
            {
                ID = 1,
                value = name,
            });
        }
    }
}

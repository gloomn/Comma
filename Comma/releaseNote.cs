﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comma
{
    public partial class releaseNote : UserControl
    {
        public releaseNote()
        {
            InitializeComponent();
        }

        private void githubText_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/gloomn/Comma");
        }
    }
}

﻿using System;
using System.Windows.Forms;
using Rakib.Main;


namespace Rakib
{
    internal class Program
    {
        [STAThread]

        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FRMLoginScreen());
        }
    }
}

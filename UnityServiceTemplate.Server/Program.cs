﻿using System;

namespace Tonari.UnityServiceTemplate
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var server = new UnityServiceTemplateServer())
            {
                Console.WriteLine("サーバが起動しました。");

                Console.ReadKey();
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.WebApp.Testes.Utilitarios
{
    public static class Util
    {
        public static string CaminhoNavegador()
            => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }
}

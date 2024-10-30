using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace AppToolKit
{
    public static class Session
    {
        public static bool sessionActiva(object cuentita)
        {
            Cuenta cuenta = cuentita != null ? (Cuenta)cuentita : null;
            if (cuenta != null )
                    return true;
            return false;           
        }

    }
}

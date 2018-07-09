using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MetodosAyuda
{
    public static class Encriptacion
    {
        public static string llave = "jwey89e09ewhfo24";
        public static string encriptarDatos(String dato)
        {
            byte[] keyArray;
            byte[] encriptar = Encoding.UTF8.GetBytes(dato);

            keyArray = Encoding.UTF8.GetBytes(llave);

            var tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultado = cTransform.TransformFinalBlock(encriptar, 0, encriptar.Length);
            tdes.Clear();

            string datosEncriptados = Convert.ToBase64String(resultado, 0, resultado.Length);
            return datosEncriptados;
        }

        public static string DecriptarDatos(string dato)
        {
            byte[] keyArray;
            byte[] decriptar = Convert.FromBase64String(dato);

            keyArray = Encoding.UTF8.GetBytes(llave);

            var tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultado = cTransform.TransformFinalBlock(decriptar, 0, decriptar.Length);
            tdes.Clear();

            string datosDecriptados = Encoding.UTF8.GetString(resultado);
            return datosDecriptados;
        }
    }
}

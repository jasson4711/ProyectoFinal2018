using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosAyuda
{
    public static class Metodos
    {
        public static bool verificadorCédula(String ced)
        {
            int sumaPares = 0, sumaImpares = 0, ds, st, verif, aux;
            int j = 0;
            //Para verificar que la cédula tenga 10 dígitos
            if (ced.Length >= 10 && ced.Length <= 13)
            {
                var cedula = ced.ToCharArray();
                //para verificar que se ingresen sólo números
                for (int i = 0; i < ced.Length; i++)
                {
                    if (cedula[i] > '9' || cedula[i] < '0')
                    {
                        return false;
                    }
                }
                //Ciclo suma Posiciones pares
                do
                {
                    //convertir el caracter de la posición j en entero
                    int x = ((Convert.ToInt32(Convert.ToString(cedula[j]))) * 2);
                    if (x > 9)
                    {
                        aux = x - 9;
                        x = aux;
                    }
                    sumaImpares = sumaImpares + x;
                    j = j + 2;
                } while (j < 9);

                j = 1;
                //Ciclo suma Posiciones Impares
                do
                {
                    //convertir el caracter de la posición j en entero
                    int x = Convert.ToInt32(Convert.ToString(cedula[j]));
                    sumaPares = sumaPares + x;
                    j = j + 2;
                } while (j < 8);
                st = sumaPares + sumaImpares;
                //verifica si el número es divisible para 10 de ser el caso no 
                //asciende a la decena superior
                if (st % 10 == 0)
                {
                    ds = st;
                }
                else //calcula la decena superior
                {
                    ds = ((st / 10) + 1) * 10;
                }
                //calcula el numero verificador
                verif = ds - st;
                //compara el numero verificador para el último digito de la cédula
                //llamado dígito verificador
                //retorna verdadero en caso de ser iguales, caso contrario retorna falso
                if (verif == (Convert.ToInt32(Convert.ToString(cedula[9]))))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}

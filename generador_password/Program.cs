using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generador_password
{
    class Password
    {
        private string contrasenia;
        private int longitud;
        //propiedades get set
        public string Contrasenia
        {
            get
            {
                return contrasenia;
            }
        }

        public int Longitud
        {
            get
            {
                return longitud;
            }

            set
            {
                longitud = value;
            }
        }
        //constructores
        public Password()
        {

        }
        public Password(int pLongitud)
        {
            longitud = pLongitud;
        }
        //metodos
        public bool fotalezaPassword()
        {
            int mayuscula=0;
            int minuscula=0;
            int numero=0;
            char carac;
            for (int i = 0; i < longitud; i++)
            {
                carac= Convert.ToChar(contrasenia.Substring(i, 1));

                if (char.IsNumber(carac)==true)//es numero
                {
                    numero = numero + 1;
                }
                else
                {
                    if (char.IsUpper(carac)==true)//es mayuscula
                    {
                        mayuscula = mayuscula + 1;
                    }
                    else// es minuscula
                    {
                        minuscula = minuscula + 1;
                    }
                }
            }
            if (mayuscula>2 & minuscula>1 & numero>5)//password fuerte
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public void generarPassword(ref int semilla)
        {
            int opcion;
            string cadena="";
            char caracter='0';
            
            for (int i = 0; i < longitud; i++)
            {
                Random aleatorio = new Random((semilla=semilla+1));
                opcion = aleatorio.Next(1, 4);
                switch (opcion)
                {
                    case 1:
                        {
                            //mayusculas
                            caracter= Convert.ToChar(aleatorio.Next(65, 91));
                            cadena = cadena + caracter;
                            break;
                        }
                    case 2:
                        {
                            //minisculas
                            caracter= Convert.ToChar( aleatorio.Next(97, 123));
                            cadena = cadena + caracter;
                            break;
                        }
                    case 3:
                        {
                            //numeros
                            caracter=Convert.ToChar( aleatorio.Next(48, 58));
                            cadena = cadena + caracter;
                            break;
                        }
                    default:
                        break;
                }
            }
            contrasenia = cadena;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            int lon;
            int semilla=0;
            Console.WriteLine("introduzca la cantidad de contraseñas a generar");
            n=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("introduzca la longitud de la contraseña\n(longitud minima recomendada 8 carateres)");
            lon = Convert.ToInt32(Console.ReadLine());

            //creando arrays
            Password[] con = new Password[n];
            string[] fortaleza = new string[n];

            for (int i = 0; i < n; i++)
            {
                con[i] = new Password(lon);
                con[i].generarPassword(ref semilla);

                if (con[i].fotalezaPassword() == true)
                {
                    fortaleza[i] = "contraseña fuerte";
                }
                else
                {
                    fortaleza[i] = "contraseña debil";
                }
                Console.WriteLine("contraseña: {0}\nSeguridad: {1}", con[i].Contrasenia, fortaleza[i]);
                Console.WriteLine("---------------------");
            }
            Console.ReadKey();
        }
    }
}

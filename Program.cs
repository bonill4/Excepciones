using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Uso de "try" = Intenta
                * "catch" = Captura*/

            //mulCatch();
            //exGenericos();
            //enfaExcepcion();
            //exFiltro();
           
        }

        static void mulCatch()
        {
            //Multiples Catch: Es cuando hay mas de una excepcion "catch"
            Random numero = new Random();
            int numAleatorio = numero.Next(0, 100);

            int num;
            int contador = 0;

            Console.WriteLine("Que numero se genero del 0-100");


            do
            {
                //Muntiples "catch"
                //Con el try: evalua la senticia y si lansa una excepcion se va a los catch
                try
                {
                    num = Int32.Parse(Console.ReadLine());
                }
                catch (FormatException ex)//Aqui se coloca la excepcion y da seguimiento al codigo
                {
                    Console.WriteLine("No has introducido un valor numerico valido, numero defaul 0");
                    num = 0;
                }
                catch (OverflowException ex)//Puede existen mas de una excencion en las sentencias try
                {
                    Console.WriteLine("Has introducido un valor demasiado alto, numero defaul 0");
                    num = 0;
                }

                if (numAleatorio < num) Console.WriteLine("El numero es menor");

                else if (numAleatorio > num) Console.WriteLine("El numero es mayor");

                contador++;
            } while (num != numAleatorio);

            Console.WriteLine($"Numero de intentos {contador}");
        }

        static void exGenericos()
        {
            //Excepcion generica: gobaliza todas las excepciones sin la necesidad de irlas colocando una por una

            Random numero = new Random();
            int numAleatorio = numero.Next(0, 100);

            int num;
            int contador = 0;

            Console.WriteLine("Que numero se genero del 0-100");


            do
            {
                //Recomendacion: De preferencia es de irlas especificando pero si son demasiados se utilizaria las genericas
                try
                {
                    num = Int32.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    //Muestra un mensaje del error
                    Console.WriteLine(ex.Message);
                    num = 0;
                }

                if (numAleatorio < num) Console.WriteLine("El numero es menor");

                else if (numAleatorio > num) Console.WriteLine("El numero es mayor");

                contador++;
            } while (num != numAleatorio);

            Console.WriteLine($"Numero de intentos {contador}");
        }

        static void enfaExcepcion()
        {
            //Enfatizar Excepcion: Es cuando enfatizo en una excepcion y especifico su error
            Random numero = new Random();
            int numAleatorio = numero.Next(0, 100);

            int num;
            int contador = 0;

            Console.WriteLine("Que numero se genero del 0-100");


            do
            {
                try
                {
                    num = Int32.Parse(Console.ReadLine());
                }
                //Siempre la excepcion especifica debe de ir primero y luego ira la generica
                catch (FormatException ex)
                {
                    Console.WriteLine("Has indroducido texto, numero defaul 0");
                    num = 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ha habido un error, numero defaul 0");
                    num = 0;
                }
               
                if (numAleatorio < num) Console.WriteLine("El numero es menor");

                else if (numAleatorio > num) Console.WriteLine("El numero es mayor");

                contador++;
            } while (num != numAleatorio);

            Console.WriteLine($"Numero de intentos {contador}");
        }

        static void exFiltro()
        {
            //Excepcion con Filtro: Es igual al "enfatizar excepciones" pero con filtros
            Random numero = new Random();
            int numAleatorio = numero.Next(0, 100);

            int num;
            int contador = 0;

            Console.WriteLine("Que numero se genero del 0-100");


            do
            {
                try
                {
                    num = Int32.Parse(Console.ReadLine());
                }
                //Aplicamos un filtro en donde excluimos FormatException
                catch (Exception ex) when (ex.GetType() != typeof(FormatException))
                {
                    Console.WriteLine("Ha habido un error, numero defaul 0");
                    num = 0;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Haz introducido texto, numero defaul 0");
                    num = 0;
                }

                if (numAleatorio < num) Console.WriteLine("El numero es menor");

                else if (numAleatorio > num) Console.WriteLine("El numero es mayor");

                contador++;
            } while (num != numAleatorio);

            Console.WriteLine($"Numero de intentos {contador}");
        }
    }
}

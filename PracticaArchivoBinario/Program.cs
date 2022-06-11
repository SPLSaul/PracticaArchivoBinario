using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PracticaArchivoBinario
{
    class Program
    {
        static void Main(string[] args)
        {
            Monster monster = new Monster();
            monster.Captura();
            
            try                                  //Creacion de archivo 
            {
                StreamWriter escritura = new StreamWriter("Inventario.txt",true);

                escritura.WriteLine(monster.Imprimir());   //El objeto escritura se encarga de escribir lo que el metodo Imprimir nos esta regresando
                escritura.Close();                         //Despues de escribir, se cierra el flujo de datos hacia el archivo

            }
            catch(IOException e) 
            {
                Console.WriteLine($"Error en el documento: {e.Message}");
            }           
            try
            {
                StreamReader lector = new StreamReader("Inventario.txt",true);      //Creacion de archivo para lectura
                int c = lector.Read();   //c se encarga de contar el numero de caracteres dentro del archivo
                while (c != -1)                   //Mientras c no sea igual al ultimo caracter
                {
                    c = lector.Read();              //c = numero de carcteres dentro del archivo
                    char letra = (char)c;                //letras nos convierte a letra los caraceteres dentro del documento
                    Console.Write(letra);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error en el archivo {e.Message}");
            }
        }                                                          
    }
    class Limpieza
    {
        public void Limpiar()
        {
            Console.WriteLine("Presione cualquier tecla para continuar: ");
            Console.ReadKey();
            Console.Clear();
        }
    }
    class Monster:Limpieza
    {
        string nombre,descripcion,resultados;
        float precio;
        int cantidad;        
        public void Captura()
        {
            Console.Write("Ingresa el nombre del producto: ");
            nombre = Console.ReadLine();
            Limpiar();
            Console.Write("Ingresa la descripcion del producto: ");
            descripcion = Console.ReadLine();
            Limpiar();
            try
            {
                Console.Write("Ingresa el precio del producto: ");
                precio = float.Parse(Console.ReadLine());
                Limpiar();
                Console.Write("Ingresa la cantidad de productos en existencia: ");
                cantidad = int.Parse(Console.ReadLine());
                Limpiar();
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error en la captura, trata de nuevo con un numero valido.\n{e.Message}");
            }            
        }
        public string Imprimir()
        {
             return resultados= ($"Producto: {nombre}         Precio: {precio:C}\nDespricion: {descripcion}\nCantidad en existencia: {cantidad}");            
        }        
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using InterfaceComparable.Entities;

namespace InterfaceComparable
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            * INTERFACE COMPARABLE
            - É uma interface padrão para se comparar um objeto com outro, ou seja, se for necessario devinir se um objeto de um determinado tipo é comparável com outro, esse tipo terá que implementar a interface Comparable que possui o método "CompareTo" que recebe um objeto e retorna um inteiro. Comparando se o objeto é menor, igual ou maior que o outro.
            
            PROBLEMA EXEMPLLO:
            Fazer um programa para ler um arquivo contendo nomes de pessoas ( um nome por linha), armazenando-os em uma lista. Depois, ordenar os dados dessa lista e mostra-los ordenadamente na tela. Nota: O caminho do arquivo pode ser informado "hardcode".
            
            Nomes: (EXEMPLO 01)             Nomes: (EXEMPLO 02)

            Maria Brown                     Maria Brown,4300.00
            Alex Green                      Alex Green,3100.00
            Bob Grey                        Bob Grey,3100.00
            Anna White                      Anna White,3500.00
            Alex Black                      Alex Black,2450.00
            Eduardo Rose                    Eduardo Rose,4390.00
            Willian Red                     Willian Red,2900.00
            Marta Blue                      Marta Blue,6100.00
            Alex Brown                      Alex Brown,5000.00
             */

            string path = @"C:\ProgramasCSharp\ConceitoDeInterfaceComparable\InterfaceComparable\InterfaceComparable\Nomes\ListaDeNomes.txt";
            string path1 = @"C:\ProgramasCSharp\ConceitoDeInterfaceComparable\InterfaceComparable\InterfaceComparable\Nomes\ListaDeFuncionarios.txt";
            
            try
            {
                //EXEMPLO 01
                using (StreamReader sr = File.OpenText(path)) //Abre o arquivo
                {
                    List<string> list = new List<string>(); //Instancia uma lista vazia
                    while (!sr.EndOfStream) //Percorre a lista enquanto não chegar ao fim do conteúdo do arquivo
                    {
                        list.Add(sr.ReadLine()); //Adiciona cada linha lida do arquivo para a lista instânciada do programa C#
                    }
                    
                    list.Sort(); //O método ".Sort()" ordena a lista em ordem alfabética, porém para funcionar se a lista fosse de um tipo de classe específica como "Employee" igual no segundo exemplo 02 é necessário que a lista tenha implementada a interface Comparable.
                    
                    foreach(string str in list) //Percorre todos os objetos da lista
                    {
                        Console.WriteLine(str); //Imprime os objetos da lista na tela.
                    }
                }

                Console.WriteLine();

                //EXEMPLO 02
                using (StreamReader sr1 = File.OpenText(path1)) 
                {
                    List<Employee> list = new List<Employee>(); //Lista do tipo Employee
                    while (!sr1.EndOfStream) 
                    {
                        list.Add(new Employee(sr1.ReadLine())); 
                    }

                    list.Sort(); //O método ".Sort()" ordena a lista em ordem alfabética e nesse caso para que funcione corretamente a classe Employee precisa ter implementada o método da Interface COmparable.

                    foreach (Employee emp in list) 
                    {
                        Console.WriteLine(emp); 
                    }
                }
            }
            catch(IOException e)
            {
                Console.WriteLine("An error ocurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}

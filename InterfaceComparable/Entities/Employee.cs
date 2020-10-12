using System;
using System.Globalization;

namespace InterfaceComparable.Entities
{
    class Employee : IComparable
    {
        public string Name { get; set; }
        public double Salary { get; set; }

        public Employee(string csvEmployee) //Construtor que recebe os dados dos funcionarios em formato csv
        {
            string[] vect = csvEmployee.Split(',');
            Name = vect[0];
            Salary = double.Parse(vect[1], CultureInfo.InvariantCulture);
        }

        public override string ToString()
        {
            return Name + ", " + Salary.ToString("F2", CultureInfo.InvariantCulture);
        }

        public int CompareTo(object obj) // O CompareTo realiza a compração entre os objetos e retorna 1 se o objeto que foi comparado é maior que o outro especificado no método .CompareTo, 0 se for igual e -1 se for menor.
            // Exemplo = "maria".Compareto("alex") irá retornar "1" pois o objeto maria é maior que o objeto alex, "alex".COmpareTo("maria") irá retornar "-1" e "maria".ComprateTo("maria") retornara 0 pois são iguais.
        {
            if(!(obj is Employee)) //Lógica de segunrança para garantir que todos os objetos que forem analizados sejam to tipo Employeer, caso contraro será lançada uma exceção.
            {
                throw new ArgumentException("Comparing error: argument is not an Employeer");
            }
            Employee other = obj as Employee;
            return Name.CompareTo(other.Name); //Compara os objetos de acordo com o especificado. Nesse caso foi comparado por Nome, porém poderia comparar por salário para ordenar por ordem de salário do menor para o maior.
        }
    }
}

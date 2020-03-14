using System;
using System.Collections.Generic;
using System.Text;

namespace Pierwszy_Projekt
{
    public class OwnComparer : IEqualityComparer<Student>
    {

        public bool Equals(Student x, Student y)
        {
            // Do porównania korzystamy z klasy StringComparer
            // W metodzie Equals klasy StringComparer tworzymy wartość tekstową,
            // która będzie porównywana między obiektami
            return StringComparer
                .InvariantCultureIgnoreCase
                .Equals($"{x.FirstName} {x.LastName} {x.Index}",
                $"{y.FirstName} {y.LastName} {y.Index}");
        }

        public int GetHashCode(Student obj)
        {
            return StringComparer
                .CurrentCultureIgnoreCase
                .GetHashCode($"{obj.FirstName} {obj.LastName} {obj.Index}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using Microsoft.VisualBasic.CompilerServices;

namespace EkspresijaVjezba
{
    class Program
    {
        private static  Entitet[] list = new Entitet[]
        {
            new Entitet(){Id = 1, Name = "Jedan"},
            new Entitet(){Id = 2, Name = "Dva"},
            new Entitet(){Id = 3, Name = "Tri"}
        };

        static void Main(string[] args)
        {
            int[] a = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9};

            List<string> operators = new List<string>
            {
                "let", "grt", "eql"
            };

            /* Ovaj dio koda je za ispitivanje operatora >, < ili = kroz niz
            Console.WriteLine("Unesi vrijednost parametra: ");
            var parametarValue = Console.ReadLine();

            Console.WriteLine("Izaberi operator:");
            Console.WriteLine(string.Join(", ", operators));
            var op = Console.ReadLine();

            var lambda = GetWhereNiz(op, int.Parse(parametarValue));

            var rezultat = a.AsQueryable().Where(lambda);

            Console.WriteLine(string.Join(", ", rezultat));

            Console.ReadKey();*/

            Console.WriteLine("Unesi vrijednost parametra: ");
            var paramValue = Console.ReadLine();

            Console.WriteLine("Unesite operator sa sledeceg spiska: ");
            Console.WriteLine(string.Join(", ", operators));
            var operat = Console.ReadLine();

            //pri testiranju properti unesite malim slovima - dodao sam metodu ToLower da sama to regulise
            Console.WriteLine("Unesite properti nad kojim vrsimo upit: ");
            var prop = Console.ReadLine().ToLower();

            var ekspresija = GetWhereExpression<Entitet>(operat, prop, paramValue);
            var rezultat = list.AsQueryable().Where(ekspresija);

            Console.WriteLine(string.Join(", ", rezultat));
            Console.ReadKey();


        }

        private static Expression<Func<int, bool>> GetWhereNiz(string op, int value)
        {
            ParameterExpression promenljiva = Expression.Parameter(typeof(int), "x");
            ConstantExpression konstanta = Expression.Constant(value);

            BinaryExpression binarnaEkspresija;
            switch (op)
            {
                case "let":
                    binarnaEkspresija = Expression.LessThan(promenljiva, konstanta);
                    break;
                case "grt":
                    binarnaEkspresija = Expression.GreaterThan(promenljiva, konstanta);
                    break;
                case "eql":
                    binarnaEkspresija = Expression.Equal(promenljiva, konstanta);
                    break;
                default:
                    throw new InvalidOperationException($"Nedefinisan operator {op} .");
            }

            return Expression.Lambda<Func<int, bool>>(binarnaEkspresija, promenljiva);
        }

        private static Expression<Func<TEntity, bool>> GetWhereExpression<TEntity>(string op, string propertyName,
            string value)
        {
            //x
            ParameterExpression parameter = Expression.Parameter(typeof(TEntity), "x");

            //x.propertyName
            MemberExpression propExpression = Expression.Property(parameter, propertyName);

            //sada treba ispitati tip propExpression-a
            var type = propExpression.Type;
            var convertedValue = Convert.ChangeType(value, type);
            ConstantExpression constant = Expression.Constant(convertedValue);

            BinaryExpression binary;
            switch (convertedValue)
            {
                //ako je string pozovi kreiranu metodu GetBinaryExpressionForString
                case string _:
                    binary = GetBinaryExpressionForString(op, propExpression, constant);
                    break;
                case int _:
                    binary = GetExpressionForInt(op, propExpression, constant);
                    break;
                default:
                    throw new ArgumentException($"Za uneseni tip {type.Name} morate kreirati novu ekspresiju.");
            }

            Expression<Func<TEntity, bool>> lambda = Expression.Lambda<Func<TEntity, bool>>(binary, parameter);
            return lambda;
        }

        private static BinaryExpression GetExpressionForInt(string op, MemberExpression propExpression, ConstantExpression constant)
        {
            switch (op)
            {
                // <
                case "let":
                    return Expression.LessThan(propExpression, constant);
                // >
                case "grt":
                    return Expression.GreaterThan(propExpression, constant);
                // =
                case "eql":
                    return Expression.Equal(propExpression, constant);
                default:
                    throw new InvalidOperationException("Nije definisana operacija op za tip int.");
            }
        }

        private static BinaryExpression GetBinaryExpressionForString(string op, MemberExpression propExpression, ConstantExpression constant)
        {
            switch (op)
            {
                //nad stringovima ima funcija ispitivanje jednakosti stringova
                case "eql":
                    return Expression.Equal(propExpression, constant);
                default:
                    throw  new InvalidOperationException("Za string smo definisali samo operaciju poredjenja Equal.");
            }
        }

    }
}

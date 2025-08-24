using LINQ_Operators.Int_Extension;
using LINQ_Operators.List_Generator;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using static LINQ_Operators.List_Generator.ListGenerator; // to easy to not call ListGerator class
namespace LINQ_Operators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region To Make Any Non Letter Like English Display it As it is
            Console.OutputEncoding = Encoding.UTF8;
            #endregion
            #region Implicitly Type Local Variable[Var-Dynamic KeyWord]
            // Implicitly Type Local Variable[Var-Dynamic KeyWord]:
            // Var KeyWord: [Common Use]
            // Make Compiler Can Detect Data Type Of Variable Based on Initial Value at Compile time
            // var Name = Null;  Invalid =>  Implicitly Type Can't Initialized With Null
            // var Name; => Invalid =>  Implicitly Type Must Be Initialized
            // Can't Use var as a Paramter or return type in Function
            var Name = "Abdelrahman";
            Console.WriteLine(Name);
            Name = "mo"; // Valid But String Only
            Console.WriteLine(Name);

            // Dynamic KeyWord: Like var in Java Script
            // CLR Can Detect Data Type Of Variable Based on Last Value
            // Can Hold any data Type + i Know data Type at run time
            // Can Use dynamic as a Paramter or return type in Function
            // dynamic x; // Valid
            // dynamic x = null; // Valid
            dynamic Thing = "Mansour";
            Console.WriteLine(Thing.GetType().Name);
            Thing = 12;
            Console.WriteLine(Thing.GetType().Name);
            Thing = 12.5;
            Console.WriteLine(Thing.GetType().Name);
            Thing = 12.5f;
            Console.WriteLine(Thing.GetType().Name);
            #endregion
            #region Anonymous Type: Internaly Class at Compile Time
            // Anonymous Type: Internaly Class at Compile Time:
            // if U Use The Type only once
            var E01 = new { Id = 1, Name = "Mansour", Salary = 15000 };
            Console.WriteLine($"Id: {E01.Id} , Name: {E01.Name} , Salary: {E01.Salary}");
            // if i want to set value:
            // E01.Id = 2; // Invalid
            Console.WriteLine(E01.GetType().Name); // <> f__AnonymousType0`3 
            // <> f__AnonymousType0`3 :
            // 0 => first E01 in program
            // 3 => has 3 Property
            var E02 = new { Name = "Ahmed", Id = 2, Salary = 12000 };
            Console.WriteLine(E02.GetType().Name);

            // The Same Anonymous Type:
            // 1. The Same Property Name[Case Senstive]
            // 1. The Same Property Order

            // Anonymous Type: Internaly Class at Compile Time:
            // this class :
            // override the ToString();
            // override the Equals();
            Console.WriteLine(E01); //  { Id = 1, Name = Mansour, Salary = 15000 }
            Console.WriteLine(E02); //  { Name = Ahmed, Id = 2, Salary = 12000 }

            Console.WriteLine(E01.GetHashCode()); // 1330164322
            Console.WriteLine(E02.GetHashCode()); // 165265078

            if (E01.Equals(E02))
            {
                Console.WriteLine("E01==E02");
            }
            else
            {
                Console.WriteLine("E01!=E02");
            }

            var E03 = E01 with { Id = 5, Name = "Sara" };
            Console.WriteLine(E03); // { Id = 5, Name = Sara, Salary = 15000 } 
            #endregion
            #region Extension Method
            // Extension Method:
            // Make Method to add it to struct int as Extension Method
            int Number = 12345;
            var result = Number.Reverse_Integer();
            Console.WriteLine($"Result is: {result}");
            #endregion
            #region  What is A LINQ
            // What is A LINQ:
            // Extension to: Language Integrated Query
            // LINQ: +40 Extension Methods (LINQ Operators) with any data [Sequence]
            // Regardless Data Store
            // 13 Categories
            // LINQ Operators in Built-in Class "Enumerable"

            // Sequence: Object From Class Implement Interface "IEnumerable"
            // Local Sequence : L2O,L2XML
            // Remote Sequence : L2EF

            // LINQ Operators: الاشكال
            // Input Sequence  -> LINQ Operators  -< Output Sequence:
            List<int> Numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var Result = Enumerable.Where(Numbers, N => N % 2 == 0);
            Console.Write($"Result is: ");
            foreach (var item in Result)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            // LINQ Operators  -< Output Sequence:
            var Sequence = Enumerable.Range(1, 50);
            foreach (var item in Sequence)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            // Input Sequence  -> LINQ Operators  -< One Value:
            var Item = Enumerable.Any(Numbers, N => N % 2 == 0);
            Console.WriteLine(Item);
            #endregion
            #region LINQ Syntax
            // LINQ Syntax:
            // 1. Fluent Syntax [Use LINQ Method]
            // 1.1 - LINQ Operator => Class Member Method from "Enumerable"
            List<int> NumbersList = new List<int>() { 2, 5, 6, 10, 12, 99 };
            var EvenNumber = Enumerable.Where(NumbersList, N => N % 2 == 0);
            Console.Write($"Result is: ");
            foreach (var item in EvenNumber)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            // 1.2 - LINQ Operator => Extension Method Through Sequence[Recommended]
            var ODDNumers = NumbersList.Where(X => X % 2 != 0);
            Console.Write($"Result is: ");
            foreach (var item in ODDNumers)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();


            // 2. Query Syntax[Query Expression]: Like SQL
            // easier than fluent (join,group by,let, into)
            // start from
            // end select or group by
            /*
            Select N
            From NumbersList
            Where N % 2 = 0
            */

            var query = from N in NumbersList
                        where N % 2 == 0
                        select N;
            Console.Write($"Result is: ");
            foreach (var item in query)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            #endregion
            #region LINQ Execution Ways
            // LINQ Execution Ways:
            // 1. Differed Execution Ways[10 Cat]:
            List<int> Numberes01 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var num = Numberes01.Where(x => x % 2 == 0);
            Numberes01.AddRange(new int[] { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });
            Console.Write($"Result is: ");
            foreach (var item in num)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            // 2. Immediate Execution Ways[3 Cat(Elements,Casting,Aggregate) Operators]:
            List<int> Numberes02 = new List<int>() { 1, 2, 0, 5, 6, 8, 9, 10, 12, 11, 200, 30, 8 };
            var num01 = Numberes02.Where(x => x % 2 == 0).ToList();
            Numberes02.AddRange(new int[] { 55, 62, 13, 14, 15, 16, 17, 18, 19, 20 });
            Console.Write($"Result is: ");
            foreach (var item in num01)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            #endregion
            #region Setup Data
            // Setup Data:
            // Done 
            Console.WriteLine(ProductList[0]);
            Console.WriteLine(CustomerList[0]);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            #endregion
            #region Filtration Operator - Where & OfType[Differed]
            // Filtration Operator - Where & OfType[Differed]: 
            #region 1. All Product => Out Of Stock(Equal To Zero)
            // 1. All Product => Out Of Stock(Equal To Zero)?
            // Use => Fluent Syntax[Extension Method]:
            var outstock = ProductList.Where(p => p.UnitsInStock == 0);
            foreach (var item in outstock)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            // Use => Query Syntax[Query Expression]:
            var outstockQuery = from p in ProductList
                                where p.UnitsInStock == 0
                                select p;
            foreach (var item in outstockQuery)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion
            #region 2. All Product in Category => "Meat/Poultry"
            // 2. All Product in Category => "Meat/Poultry"?
            // Use => Fluent Syntax[Extension Method]:
            var category = ProductList.Where(p => p.Category == "Meat/Poultry");
            foreach (var item in category)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            // Use => Query Syntax[Query Expression]:
            var categoryQuery = from p in ProductList
                                where p.Category == "Meat/Poultry"
                                select p;
            foreach (var item in categoryQuery)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion
            #region 3. All Product in Category => "Meat/Poultry" && Not Out Of Stock
            // 3. All Product in Category => "Meat/Poultry" && Not Out Of Stock?
            // Use => Fluent Syntax[Extension Method]:
            var categoryinsotock = ProductList.Where
                (p => p.Category == "Meat/Poultry" && p.UnitsInStock > 0);
            foreach (var item in categoryinsotock)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            // Use => Query Syntax[Query Expression]:
            var categoryinsotockQuery = from p in ProductList
                                        where p.Category == "Meat/Poultry" && p.UnitsInStock > 0
                                        select p;
            foreach (var item in categoryinsotockQuery)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion
            #region Note About Where Operator
            // Where Operator => Two Overload 
            // first => Func
            // Second => Func,Index
            // Indexed Where => Valid Only Fluent Syntax  
            #endregion
            #region 4. Get First 10 Product where UnitinStock == 0
            // Get First 10 Product where UnitinStock == 0?
            // Use => Fluent Syntax[Extension Method]:
            var first10product = ProductList.Where((p, I) => p.UnitsInStock == 0 && I < 10);
            foreach (var item in first10product)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion
            #region Get First 5 Product
            // 5. Get First 5 Product?
            // Use => Fluent Syntax[Extension Method]:
            var first5product = ProductList.Where((p, I) => I < 5);
            foreach (var item in first5product)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion
            #region Get First 5 Product in ProductList where UnitinStock > 0
            // Get First 5 Product in ProductList where UnitinStock > 0?
            var first5Product = ProductList.Where(p => p.UnitsInStock > 0).Where((p, I) => I < 5);
            foreach (var item in first5Product)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion
            #region OfType Operator
            // OfType Operator: Get Values which U want it 
            ArrayList arrayList = new ArrayList()
            {
                1,2,1.5,20.5,4.5f,5.5f,ProductList[0],ProductList[1],10.5m,45.5m
            };
            var list = arrayList.OfType<decimal>();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion
            #endregion
            #region Transformation Operators - Select, SelectMany[Differed]
            // Transformation Operators - Select, SelectMany[Differed]:
            #region 1. Display ProductName
            // 1. Display ProductName?
            // Use => Fluent Syntax[Extension Method]:
            var name = ProductList.Select(p => p.ProductName);
            foreach (var item in name)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            // Use => Query Syntax[Query Expression]:
            var nameQuery = from p in ProductList
                            select p.ProductName;
            foreach (var item in nameQuery)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion
            #region 2. Display Name && Category only With Condition Specific
            // 2. Display Name && Category only With Condition Specific?
            // Use => Fluent Syntax[Extension Method]:
            // Use Anonmeus Type
            var output = ProductList.Where(p => p.UnitsInStock > 0 && p.Category == "Seafood")
                                    .Select(p => new { p.UnitsInStock, p.Category }); // Anonmeus Type
            foreach (var item in output)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            // Use => Query Syntax[Query Expression]:
            var outputQuery = from p in ProductList
                              where p.UnitsInStock > 0 && p.Category == "Seafood"
                              select new { p.UnitsInStock, p.Category }; // Anonmeus Type
            foreach (var item in outputQuery)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion
            #region 2.1 Display Name && Category only With Condition Specific,oldPrice,NewPrice %10
            // Display Name && Category only With Condition Specific,oldPrice,NewPrice %10?
            // Use => Fluent Syntax[Extension Method]:
            // Use Anonmeus Type
            var output1 = ProductList.Where(p => p.UnitsInStock > 0 && p.Category == "Seafood")
                                    .Select(p => new
                                    {
                                        p.UnitsInStock,
                                        p.Category,
                                        OldPrice = p.UnitPrice,
                                        NewPrice = p.UnitPrice - p.UnitPrice * 0.1m
                                    }); // Anonmeus Type
            foreach (var item in output1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            // Use => Query Syntax[Query Expression]:
            var outputQuery1 = from p in ProductList
                               where p.UnitsInStock > 0 && p.Category == "Seafood"
                               select new
                               {
                                   p.UnitsInStock,
                                   p.Category,
                                   OldPrice = p.UnitPrice,
                                   NewPrice = p.UnitPrice - p.UnitPrice * 0.1m
                               }; // Anonmeus Type
            foreach (var item in outputQuery1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion
            #region Use Select Many Operator 
            // if i have one property is a sequence: array,list
            // Don't Use Select Operator 
            // Use Select Many Operator 
            // Use => Fluent Syntax[Extension Method]:
            var input = CustomerList.SelectMany(c => c.Orders);
            foreach (var item in input)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            // Use => Query Syntax[Query Expression]:
            var input1 = from c in CustomerList
                         from o in c.Orders
                         select o;
            foreach (var item in input1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion
            #region Display first 5 ProductName
            //  Display first 5 ProductName?
            // Use => Fluent Syntax[Extension Method]:
            // Indexed Select => Valid in only Fluent Syntax
            var display = ProductList.Where((p, I) => I < 5).Select(p => new { p.ProductName });
            foreach (var item in display)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion
            #endregion
            #region Ordering Operators[Differed]
            // Ordering Operators[Differed]:
            #region Order Ascending By UnitPrice
            // Use => Fluent Syntax[Extension Method]:
            var Asc = ProductList.OrderBy(p => p.UnitPrice);
            foreach (var item in Asc)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            // Use => Query Syntax[Query Expression]:
            var AscQuery = from p in ProductList
                           orderby p.UnitPrice
                           select p;
            foreach (var item in AscQuery)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion
            #region Order Ascending By UnitPrice & Select Anything
            // Use => Fluent Syntax[Extension Method]:
            var Asc01 = ProductList.OrderBy(P => P.UnitPrice)
                                   .Select(p =>
                                   new
                                   {
                                       p.ProductID,
                                       p.UnitPrice,
                                       p.ProductName
                                   });
            foreach (var item in Asc01)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            // Use => Query Syntax[Query Expression]:
            var Acs01Query = from p in ProductList
                             orderby p.UnitPrice
                             select new
                             {
                                 p.ProductID,
                                 p.UnitPrice,
                                 p.ProductName
                             };
            foreach (var item in Acs01Query)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion
            #region Order By ThenBy => if unitstock equal => order by price
            // Use => Fluent Syntax[Extension Method]:
            var asc = ProductList.Where(p => p.Category == "Beverages")
                                  .OrderBy(p => p.UnitsInStock)
                                  .ThenByDescending(p => p.UnitPrice)
                                  .Select
                                  (p => new
                                  {
                                      p.ProductID,
                                      p.ProductName,
                                      p.UnitPrice,
                                      p.UnitsInStock

                                  });
            foreach (var item in asc)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            // Use => Query Syntax[Query Expression]:
            var ascQuerey = from p in ProductList
                            where p.Category == "Beverages"
                            orderby p.UnitsInStock, p.UnitPrice descending
                            select new
                            {
                                p.ProductID,
                                p.ProductName,
                                p.UnitPrice,
                                p.UnitsInStock
                            };
            foreach (var item in ascQuerey)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            #endregion
            #region Reverse
            // Revese:
            // Use => Fluent Syntax[Extension Method]:
            var reverse = ProductList.Reverse<Product>().Select(p => p.ProductID);
            foreach (var item in reverse)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion
            #endregion
            #region Element Operators - Immediate Execution
            // Return One Element
            #region First => Get The First Index In ProductList
            var first = ProductList.First();
            Console.WriteLine(first);
            Console.WriteLine();
            first = ProductList.First(p => p.UnitsInStock == 0);
            Console.WriteLine(first);
            Console.WriteLine();

            // if i Want to get First Index In ProductList which is empty => Exception
            //ProductList = new List<Product>();
            //var empty = ProductList.First();
            //Console.WriteLine(empty); // Sequence contains no elements
            #endregion
            #region Last => Get The Last Index In ProductList
            var last = ProductList.Last();
            Console.WriteLine(last);
            Console.WriteLine();
            last = ProductList.Last(p => p.UnitPrice == 19.4500M);
            Console.WriteLine(last);
            Console.WriteLine();

            // if i Want to get Last Index In ProductList which is empty => Exception
            //ProductList = new List<Product>();
            //var empty = ProductList.Last();
            //Console.WriteLine(empty); // Sequence contains no elements
            #endregion
            #region FirstOrDefault => Get The First Index In ProductList
            // Handle Exception if list is empty
            var firstordefault = ProductList.FirstOrDefault();
            Console.WriteLine(firstordefault);
            Console.WriteLine();
            firstordefault = ProductList.FirstOrDefault(p => p.UnitsInStock == 0);
            Console.WriteLine(firstordefault);
            Console.WriteLine();

            // if i Want to get First Index In ProductList which is empty => string empty
            //ProductList = new List<Product>();
            //var empty = ProductList.FirstOrDefault();
            //Console.WriteLine(empty); // string empty
            //Console.WriteLine();
            #endregion
            #region LastOrDefault => Get The Last Index In ProductList
            // Handle Exception if list is empty
            var lastordefault = ProductList.LastOrDefault();
            Console.WriteLine(lastordefault);
            Console.WriteLine();
            lastordefault = ProductList.LastOrDefault(p => p.UnitPrice == 19.4500M);
            Console.WriteLine(lastordefault);
            Console.WriteLine();

            // if i Want to get Last Index In ProductList which is empty => string empty
            //ProductList = new List<Product>();
            //var empty = ProductList.LastOrDefault();
            //Console.WriteLine(empty); // string empty
            //Console.WriteLine();
            #endregion
            #region ElementAt => Return value of this index
            var at = ProductList.ElementAt(0);
            Console.WriteLine(at);
            // if empty => 
            //ProductList = new List<Product>();
            //at = ProductList.ElementAt(1);
            //Console.WriteLine(at); // Index was out of range
            #endregion
            #region ElementAtOrDefault => Return value of this index
            var at01 = ProductList.ElementAtOrDefault(5);
            Console.WriteLine(at);
            Console.WriteLine();
            // if empty => 
            // ProductList = new List<Product>();
            // at01 = ProductList.ElementAtOrDefault(1);
            // Console.WriteLine(at); //String Empty
            // Console.WriteLine();
            #endregion
            #region Single => Return Only One Element 
            //var sinlge = ProductList.Single();
            var sinlge = ProductList.Single(p => p.ProductID == 1);
            Console.WriteLine(sinlge);
            // if empty =>
            //ProductList = new List<Product>();
            //var sinlge = ProductList.Single();
            //Console.WriteLine(sinlge); // Sequence contains no elements
            //Console.WriteLine();
            #endregion
            #region SingleOrDefault =>  Exception
            var sinlgeordefault = ProductList.SingleOrDefault(p => p.ProductID == 1);
            Console.WriteLine(sinlgeordefault);
            //if empty =>
            //ProductList = new List<Product>();
            //sinlgeordefault = ProductList.SingleOrDefault();
            //Console.WriteLine(sinlge); // Sequence contains no elements
            //Console.WriteLine();
            #endregion
            #region DefaultIfEmpty => Check if empty
            var Empty = ProductList.DefaultIfEmpty(new Product() { ProductName = "Default" })
                                   .Select(p => new { p.ProductName });
            foreach (var item in Empty)
            {
                Console.WriteLine(item); // Return List
            }
            Console.WriteLine();
            #endregion
            #endregion
            #region Aggregate Operators - Immediate Execution
            // Built-in Operators Like Built-in Function in Aggregate method in SQL
            #region Count => Return The Count of condition
            var count = ProductList.Count();
            Console.WriteLine(count);  // 77
            count = ProductList.Count;
            Console.WriteLine(count);  // 77 [Property]
            count = ProductList.Count(P => P.UnitsInStock == 0);
            Console.WriteLine(count);  // 5
            #endregion
            #region Sum => Return Summtion
            var sum = ProductList.Sum(p => p.UnitsInStock);
            Console.WriteLine(sum);
            #endregion
            #region Max => Rerurn Max
            var max = ProductList.Max();
            Console.WriteLine(max);
            var maxi = ProductList.Max(p => p.UnitsInStock);
            Console.WriteLine(maxi);
            var maxprice = ProductList.Max(p => p.UnitPrice);
            var Res = ProductList.FirstOrDefault(p => p.UnitPrice == maxprice);
            Console.WriteLine(Res);
            var Max = ProductList.MaxBy(p => p.UnitPrice); // هات صاحب اعلى سعر
            Console.WriteLine(Max);
            #endregion
            #region Min => Rerurn Min
            var min = ProductList.Min();
            Console.WriteLine(min);
            var mini = ProductList.Min(p => p.UnitsInStock);
            Console.WriteLine(mini);
            var minprice = ProductList.Min(p => p.UnitPrice);
            var Res01 = ProductList.FirstOrDefault(p => p.UnitPrice == maxprice);
            Console.WriteLine(Res01);
            var Min = ProductList.MinBy(p => p.UnitPrice); // هات صاحب اقل سعر
            Console.WriteLine(Min);
            #endregion
            #region Agv => Rerurn Agv
            var avg = ProductList.Average(p => p.UnitsInStock);
            Console.WriteLine(avg);
            #endregion
            #region Aggergate => Concatination
            List<string> Names = new List<string>()
            {
                "Abdelrahman",
                "Mansour",
                "Hamed",
                "Abdelatif"
            };
            var n = Names.Aggregate((s1, s2) => $"{s1} {s2}");
            Console.WriteLine(n);
            #endregion
            #endregion
            #region Casting Operators - Immediate Execution
            // If U Want To Convert From IEnumrable To (List,Array,Dictionary,HashSet)
            #region To List
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            //List<Product> products = (List<Product>)ProductList.Where(p => p.UnitsInStock == 0); // Invalid
            List<Product> products = ProductList.Where(p => p.UnitsInStock == 0).ToList();
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
            #endregion
            #region To Array
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Product[] products1 = ProductList.Where(p => p.UnitsInStock == 0).ToArray();
            foreach (var product in products1)
            {
                Console.WriteLine(product);
            }
            #endregion
            #region To Dictionary
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            // Must Key Matching With Each Other
            Dictionary<long, Product> products2 = ProductList.Where(p => p.UnitsInStock == 0).ToDictionary(p => p.ProductID);
            foreach (var product in products2)
            {
                Console.WriteLine(product);
            }
            #endregion
            #region To HashSet
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            // HashSet Take Values Only
            HashSet<Product> products4 = ProductList.Where(p => p.UnitsInStock == 0).ToHashSet();
            foreach (var product in products4)
            {
                Console.WriteLine(product);
            }
            #endregion
            #endregion
            #region Generation Operators[Differed]
            // The Only Way To Call This Methods => With Enumrable Class Not Extension Method
            // [Range,Empty,Repeat]
            #region Range
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            var range = Enumerable.Range(1, 100);
            foreach (var item in range)
            {
                Console.Write($"{item} ");
            }
            #endregion
            #region Empty
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            // var empty = Enumerable.Empty<Product>(); // Empty
            var empty = Enumerable.Empty<Product>().ToList(); // To Add
            empty.Add(ProductList[0]);
            foreach (var item in empty)
            {
                Console.WriteLine(item);
            }
            #endregion
            #region Repeat
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            var repeat = Enumerable.Repeat(ProductList[5], 2);
            foreach (var item in repeat)
            {
                Console.WriteLine(item);
            }
            #endregion
            #endregion
            #region Set Operators[Differed]
            // Union Family[Union,Concat(UnionAll),Intersect,Except,Distinct]
            #region Union
            // Without Duplication
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            var Seq01 = Enumerable.Range(1, 100);
            var Seq02 = Enumerable.Range(50, 100);
            var union = Seq01.Union(Seq02);
            foreach (var item in union)
            {
                Console.Write($"{item} ");
            }
            #endregion
            #region Concat(Like UnionAll)
            // With Duplication
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            // because 50 + 100 − 1 = 149)
            var seq01 = Enumerable.Range(1, 100);
            var seq02 = Enumerable.Range(50, 100);
            var concat = seq01.Concat(seq02);
            foreach (var item in concat)
            {
                Console.Write($"{item} ");
            }
            #endregion
            #region Distinct
            // Remove Duplication
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            concat = concat.Distinct();
            foreach (var item in concat)
            {
                Console.Write($"{item} ");
            }
            #endregion
            #region Intersect
            // التقاطع
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            var intersect = Seq01.Intersect(Seq02);
            foreach (var item in intersect)
            {
                Console.Write($"{item} ");
            }
            #endregion
            #region Except
            // اى اللى موجود ف الاول مش موجود ف التانى
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            var except = Seq01.Except(Seq02);
            foreach (var item in except)
            {
                Console.Write($"{item} ");
            }
            #endregion
            #endregion
            #region Quantifier Operators - Return Boolean[Differed]
            // Return Boolean
            #region Any
            // Return True => if there are at least one element in sequece Or Match Condition
            Console.WriteLine();
            Console.WriteLine();
            var any = ProductList.Any(); // True
            Console.WriteLine(any);
            var anyCondition = ProductList.Any(p => p.UnitsInStock == 0); // Condition
            Console.WriteLine(anyCondition);
            #endregion
            #region All
            // Return True => if All element Match Condition or sequence empty
            var all = ProductList.All(p => p.UnitsInStock == 0);
            Console.WriteLine(all); // False
            //ProductList = new List<Product>();
            var allempty = ProductList.All(p => p.UnitsInStock == 0);
            Console.WriteLine(allempty); // True
            #endregion
            #region SequenceEqual
            // If any element pair is different, it immediately returns false
            // If it reaches the end of both sequences without differences → returns true
            // If lengths are different → returns false
            var sequenceEqual = Seq01.SequenceEqual(Seq02);
            Console.WriteLine(sequenceEqual); // False
            #endregion
            #region Contains
            var contains = Seq01.Contains(1);
            Console.WriteLine(contains);  // True
            #endregion
            #endregion
            #region Zip Operator[Differed]
            // دمج داتا
            Console.WriteLine();
            Console.WriteLine();
            List<string> strings = new List<string>() { "True", "False" };
            List<string> stringss = new List<string>() { "T", "F" };
            List<int> ints = new List<int>() { 1, 0 };
            //var zip = strings.Zip(ints);  // First Overload
            //var zip = strings.Zip(stringss, ints); // Second Overload
            var zip = strings.Zip(ints, (S, I) => $"[{S} => {I}]"); // Third Overload
            foreach (var item in zip)
            {
                Console.WriteLine(item);
            }
            #endregion
            #region Grouping Operators[Differed]
            // Like Group By SQL
            #region Group By Category
            // Using Fluent Syntax: 
            Console.WriteLine();
            Console.WriteLine();
            var group = ProductList.GroupBy(p => p.Category);   // (string=> Key , product)

            // Using Query Syntax:
            group = from p in ProductList
                    group p by p.Category;
            foreach (var Category in group)
            {
                Console.WriteLine(Category.Key);
                foreach (var product in Category)
                {
                    Console.WriteLine(product);
                }
            }
            #endregion
            #region Group By Category && in Unitistock
            // Using Fluent Syntax: 
            Console.WriteLine();
            Console.WriteLine();
            var group01 = ProductList.Where(p => p.UnitsInStock > 0).GroupBy(p => p.Category);  // (string=> Key , product)

            // Using Query Syntax:
            group = from p in ProductList
                    where p.UnitsInStock > 0
                    group p by p.Category;
            foreach (var Category in group01)
            {
                Console.WriteLine(Category.Key);
                foreach (var product in Category)
                {
                    Console.WriteLine(product);
                }
            }
            #endregion
            #region Group By Category && in Unitistock && Category > 10
            // Using Fluent Syntax: 
            Console.WriteLine();
            Console.WriteLine();
            var group03 = ProductList.Where(p => p.UnitsInStock > 0)
                                     .GroupBy(p => p.Category)
                                     .OrderByDescending(c => c.Count())
                                     .Where(c => c.Count() > 5)
                                     .Select(c => new { CategoryName = c.Key, CategoryCount = c.Count() });
            foreach (var item in group03)
            {
                Console.WriteLine(item);
            }
            // Using Query Syntax:
            var group04 = from p in ProductList
                          where p.UnitsInStock > 0
                          group p by p.Category
                          // Having In Sql
                          into Category
                          where Category.Count() > 12
                          select Category;

            foreach (var Category in group04)
            {
                Console.WriteLine(Category.Key);
                foreach (var product in Category)
                {
                    Console.WriteLine(product);
                }
            }
            #endregion
            #endregion
            #region Partitioning Operators[Differed] => Important
            // [Take,TakeLast,Skip,SkipLast,TakeWhile,SkipWhile] => Pagination
            // اقسم الصفحة بتاعتى
            #region Take
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            var take = ProductList.Take(5);  // Return First 5 Product
            foreach (var item in take)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            var take01 = ProductList.Where(P => P.UnitsInStock == 0).Take(4);
            foreach (var item in take01)
            {
                Console.WriteLine(item);
            }
            #endregion
            #region TakeLast
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            var takelast = ProductList.TakeLast(5);  // Return Last 5 Product
            foreach (var item in takelast)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            var takelast01 = ProductList.Where(P => P.UnitsInStock > 0).TakeLast(4);
            foreach (var item in takelast01)
            {
                Console.WriteLine(item);
            }
            #endregion
            #region Skip
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            var skip = ProductList.Skip(5);  // Return Product From 6
            foreach (var item in skip)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            var skip01 = ProductList.Where(P => P.UnitsInStock == 0).Skip(4); // Return Product From 5
            foreach (var item in skip01)
            {
                Console.WriteLine(item);
            }
            #endregion
            #region SkipLast
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            var skiplast = ProductList.SkipLast(5);  // Return Product Without Last 5 Product
            foreach (var item in skiplast)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            var skiplast01 = ProductList.Where(P => P.UnitsInStock == 0).SkipLast(4); // Return Product Without Last 4 Product
            foreach (var item in skiplast01)
            {
                Console.WriteLine(item);
            }
            #endregion
            #region TakeWhile
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            int[] Num = { 9, 1, 2, 3, 4, 5, 6, 7, 8 };
            var takewhile = Num.TakeWhile(n => n % 3 == 0);
            foreach (var item in takewhile)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            //  0  1  2  3  4  5  6  7
            int[] Numers = { 9, 5, 8, 6, 4, 3, 2, 1 };
            var r = Numers.Select((P, I) => new { P, I }).TakeWhile(p => p.P > p.I);
            foreach (var item in r)
            {
                Console.WriteLine(item);
            }
            #endregion
            #region SkipWhile
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            int[] Nums = { 9, 6, 1, 2, 3, 4, 5, 6, 7, 15, 8 };
            var skipwhile = Nums.SkipWhile(n => n % 3 == 0);
            foreach (var item in skipwhile)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            //  0  1  2  3  4  5  6  7
            int[] Numerss = { 9, 5, 8, 6, 4, 3, 2, 1 };
            var r1 = Numerss.Select((P, I) => new { P, I }).SkipWhile(p => p.P > p.I);
            foreach (var item in r1)
            {
                Console.WriteLine(item);
            }
            #endregion
            #endregion
            #region Let and Into[Query Syntax]
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            List<string> names = new List<string>() { "Alice", "Bob", "Charlie", "Diana", "Edward", "Fiona", "George", "Hannah" };
            // Built-in Class Regex To Remove Vowles Characters
            var ress = Regex.Replace("Charlie", "[aeiouAEIOU]", string.Empty); // Chrl
            Console.WriteLine(ress);
            #region Into
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            List<string> namess = new List<string>() { "Alice", "Bob", "Charlie", "Diana", "Edward", "Fiona", "George", "Hannah" };
            // Built-in Class Regex To Remove Vowles Characters then show character >3
            var ress01 = from N in namess
                         select Regex.Replace(N, "[aeiouAEIOU]", string.Empty)
                         into Characters  // Restart Query
                         where Characters.Length > 3
                         select Characters;
            foreach (var item in ress01)
            {
                Console.WriteLine(item);
            }
            #endregion
            #region Let
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            var ress02 = from N in namess
                         let Characters = Regex.Replace(N, "[aeiouAEIOU]", string.Empty) // Continue  Query
                         where Characters.Length > 3
                         select Characters;
            foreach (var item in ress02)
            {
                Console.WriteLine(item);
            }
            #endregion
            #endregion
        }
    }
}

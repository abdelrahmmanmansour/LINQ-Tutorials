using System.Text;

namespace Questions_For_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Assignment LINQ:

            #region To Make Any Non Letter Like English Display it As it is
            Console.OutputEncoding = Encoding.UTF8;
            #endregion

            #region LINQ - Restriction Operators>< 

            #region 1. Find all products that are out of stock
            // Using Fluent Syntax[Extension Method]:
            //var OutOfStock_Fluent = ProductList.Where(P => P.UnitsInStock == 0);
            //foreach (var Unit in OutOfStock_Fluent) Console.WriteLine(Unit);
            //Console.WriteLine();
            //Console.WriteLine();
            // Using Query Syntax[Query Expression]:
            //var OutOfStock_Query = from P in ProductList
            //                       where P.UnitsInStock == 0
            //                       select P;
            //foreach (var Unit in OutOfStock_Query) Console.WriteLine(Unit);
            #endregion

            #region 2. Find all products that are in stock and cost more than 3.00 per unit
            // Using Fluent Syntax[Extension Method]:
            //var INStock_Fluent = ProductList.Where(P => P.UnitsInStock > 0 && P.UnitPrice > 3.00M);
            //foreach (var Unit in INStock_Fluent) Console.WriteLine(Unit);
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            // Using Query Syntax[Query Expression]:
            //var INStock_Query = from P in ProductList
            //                    where P.UnitsInStock > 0 && P.UnitPrice > 3.00M
            //                    select P;
            //foreach (var Unit in INStock_Query) Console.WriteLine(Unit);
            #endregion

            #endregion

            #region LINQ - Element Operators

            #region 1. Get first Product out of Stock
            // Using Fluent Syntax[Extension Method]:
            //var First_Fluent = ProductList.FirstOrDefault(P => P.UnitsInStock == 0);
            //Console.WriteLine(First_Fluent);
            //Console.WriteLine();
            #endregion

            #region 2. Return the first product whose Price > 1000, unless there is no match, in which case null is returned
            // Using Fluent Syntax[Extension Method]:
            //var FirstPrice_Fluent = ProductList.FirstOrDefault(P => P.UnitPrice > 1000M);
            //if (FirstPrice_Fluent is not null) Console.WriteLine(FirstPrice_Fluent);
            //else  Console.WriteLine("Null ===> No product found with price > 1000");
            #endregion

            #endregion

            #region LINQ - Aggregate Operators

            #region 1. Uses Count to get the number of odd numbers in the array
            // int[] Arr_Q01 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            // Using Fluent Syntax[Extension Method]:
            //var OODNumbers_Fluent = Arr_Q01.Count(N => N % 2 != 0);
            //Console.WriteLine($"OODNumbers_Fluent: {OODNumbers_Fluent}");       
            #endregion

            #region 2. Get the total of the numbers in an array
            // Using Fluent Syntax[Extension Method]:
            //int[] Arr_Q02 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var TotalNumbers_Fluent = Arr_Q02.Sum();
            //Console.WriteLine($"TotalNumbers_Fluent: {TotalNumbers_Fluent}"); 
            #endregion

            #region 3. Get the total number of characters of all words in dictionary_english.txt (Read dictionary_english.txt into Array of String First)
            // File.ReadAllLines  => To Load The File
            //string[] Words = File.ReadAllLines("dictionary_english.txt");
            //var TotalCharacters_Fluent = Words.Sum(W => W.Length);
            //Console.WriteLine($"TotalCharacters_Fluent: {TotalCharacters_Fluent}");
            #endregion

            #region 4. Get the length of the shortest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First)
            //string[] words = File.ReadAllLines("dictionary_english.txt");
            //var ShortestLength_Fluent = words.Min(W => W.Length);
            //Console.WriteLine($"ShortestLength_Fluent: {ShortestLength_Fluent}");
            #endregion

            #region 5. Get the total units in stock for each product category
            // Using Fluent Syntax[Extension Method]:
            //var Total_Fluent = ProductList.GroupBy(T => T.Category)
            //                              .Select(T => new
            //                              {
            //                                  Cateegory = T.Key,
            //                                  SumOfUnitOfStock = T.Sum(T => T.UnitsInStock)
            //                              });
            //foreach (var Unit in Total_Fluent) Console.WriteLine(Unit);
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            // Using Query Syntax[Query Expression]:
            //var Total_Query = from T in ProductList
            //                  group T by T.Category
            //                  into Category
            //                  select new
            //                  {
            //                      Cateegory = Category.Key,
            //                      SumOfUnitOfStock = Category.Sum(T => T.UnitsInStock)
            //                  };
            //foreach (var Unit in Total_Query) Console.WriteLine(Unit);
            #endregion

            #region 6. Get the cheapest price among each category's products
            // Using Fluent Syntax[Extension Method]:
            //var Cheapest_Fluent = ProductList.GroupBy(T => T.Category)
            //                              .Select(T => new
            //                              {
            //                                  Cateegory = T.Key,
            //                                  Cheapest_Price = T.Min(T => T.UnitPrice)
            //                              });
            //foreach (var Unit in Cheapest_Fluent) Console.WriteLine(Unit);
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            // Using Query Syntax[Query Expression]:
            //var Cheapest_Query = from T in ProductList
            //                  group T by T.Category
            //                  into Category
            //                  select new
            //                  {
            //                      Cateegory = Category.Key,
            //                      Cheapest_Price = Category.Min(T => T.UnitPrice)
            //                  };
            //foreach (var Unit in Cheapest_Query) Console.WriteLine(Unit);
            #endregion

            #region 7. Get the products with the cheapest price in each category (Use Let)
            // Using Fluent Syntax[Extension Method]:
            //var Cheapest_Fluent01 = ProductList.GroupBy(T => T.Category)
            //                                   .Select(T => new 
            //                                   {
            //                                       Cateegory = T.Key,
            //                                       Cheapest_Price = T.Min(T => T.UnitPrice) 
            //                                   });

            //foreach (var Unit in Cheapest_Fluent01) Console.WriteLine(Unit);
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            // Using Query Syntax[Query Expression]:
            //var Cheapest_Query01 = from T in ProductList
            //                     group T by T.Category
            //                     into Category
            //                     let MinPrice = Category.Min(T => T.UnitPrice)
            //                     select new
            //                     {
            //                         Cateegory = Category.Key,
            //                         Cheapest_Price = MinPrice
            //                     };
            //foreach (var Unit in Cheapest_Query01) Console.WriteLine(Unit);
            #endregion

            #region 8. Get the average price of each category's products
            // Using Fluent Syntax[Extension Method]:
            //var Average_Fluent = ProductList.GroupBy(T => T.Category)
            //                              .Select(T => new
            //                              {
            //                                  Cateegory = T.Key,
            //                                  AverageOfUnitPrice = T.Average(T => T.UnitPrice)
            //                              });
            //foreach (var Unit in Average_Fluent) Console.WriteLine(Unit);
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            // Using Query Syntax[Query Expression]:
            //var Average_Query = from T in ProductList
            //                  group T by T.Category
            //                  into Category
            //                  select new
            //                  {
            //                      Cateegory = Category.Key,
            //                      AverageOfUnitPrice = Category.Average(T => T.UnitPrice)
            //                  };
            //foreach (var Unit in Average_Query) Console.WriteLine(Unit);
            #endregion

            #endregion

            #region LINQ - Ordering Operators

            #region 1. Sort a list of products by name
            // Using Fluent Syntax[Extension Method]:
            //var Sortname_Fluent = ProductList.OrderBy(N => N.ProductName);
            //foreach (var Unit in Sortname_Fluent) Console.WriteLine(Unit);
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            // Using Query Syntax[Query Expression]:
            //var Sortname_Query = from N in ProductList
            //                     orderby N.ProductName
            //                     select N;

            //foreach (var Unit in Sortname_Query) Console.WriteLine(Unit);
            #endregion

            #region 2. Sort a list of products by units in stock from highest to lowest
            // Using Fluent Syntax[Extension Method]:
            //var Unitsinstocke_Fluent = ProductList.OrderByDescending(N => N.UnitsInStock);
            //foreach (var Unit in Unitsinstocke_Fluent) Console.WriteLine(Unit);
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            // Using Query Syntax[Query Expression]:
            //var Unitsinstock_Query = from N in ProductList
            //                     orderby N.UnitsInStock descending
            //                     select N;

            //foreach (var Unit in Unitsinstock_Query) Console.WriteLine(Unit);
            #endregion

            #region 3. Sort a list of digits, first by length of their name, and then alphabetically by the name itself
            // Using Fluent Syntax[Extension Method]:
            //string[] Digits01 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            //var sort_Fluent = Digits01.OrderBy(S => S.Length).ThenBy(S => S);
            //foreach (var Unit in sort_Fluent) Console.WriteLine(Unit);
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            // Using Query Syntax[Query Expression]:
            //var sort_Query = from N in Digits01
            //                         orderby N.Length ascending , N ascending
            //                         select N;

            //foreach (var Unit in sort_Query) Console.WriteLine(Unit);
            #endregion

            #region 4. Sort a list of products, first by category, and then by unit price, from highest to lowest
            // Using Fluent Syntax[Extension Method]:
            //var sorts_Fluent = ProductList.OrderBy(S => S.Category).ThenByDescending(S => S.UnitPrice);
            //foreach (var Unit in sorts_Fluent) Console.WriteLine(Unit);
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            // Using Query Syntax[Query Expression]:
            //var sorts_Query = from N in ProductList
            //                         orderby N.Category, N.UnitPrice descending
            //                         select N;

            //foreach (var Unit in sorts_Query) Console.WriteLine(Unit);
            #endregion

            #region 5. Sort first by-word length and then by a case-insensitive descending sort of the words in an array
            //String[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            // Using Fluent Syntax[Extension Method]:
            // StringComparer.OrdinalIgnoreCase : sorts alphabetically descending, ignoring case
            //var sortWord_Fluent = Arr.OrderBy(S => S.Length).ThenByDescending(S => S , StringComparer.OrdinalIgnoreCase);
            //foreach (var Unit in sortWord_Fluent) Console.WriteLine(Unit);
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            // Using Query Syntax[Query Expression]:
            // StringComparer.OrdinalIgnoreCase => ToLower() descending
            //var sortWord_Query = from N in Arr
            //                         orderby N.Length, N.ToLower() descending
            //                         select N;

            //foreach (var Unit in sortWord_Query) Console.WriteLine(Unit);
            #endregion

            #region 6. Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array
            //string[] Digits02 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            //var Reverse = Digits02.Where(R => R.Length > 0 && R[1] == 'i').Reverse();
            //foreach (var str in Reverse)  Console.WriteLine(str);
            #endregion

            #endregion

            #region LINQ – Transformation Operators

            #region 1. Return a sequence of just the names of a list of products
            // Using Fluent Syntax[Extension Method]:
            //var Names_Fluent = ProductList.Select(N => new { N.ProductName });
            //foreach (var Names in Names_Fluent) Console.WriteLine(Names);
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            // Using Query Syntax[Query Expression]:
            //var Names_Query = from N in ProductList
            //                  select new { N.ProductName };
            //foreach (var Names in Names_Query) Console.WriteLine(Names);
            #endregion

            #region 2. Produce a sequence of the uppercase and lowercase versions of each word in the original array (Anonymous Types)
            // Using Fluent Syntax[Extension Method]:
            //String[] W = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            //var result_Fluent = W.Select(W => new { UPPER = W.ToUpper(), LOWER = W.ToLower() });
            //foreach(var word in result_Fluent)  Console.WriteLine(word);
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            // Using Query Syntax[Query Expression]:
            //var result_Query = from Wo in W
            //                   select new { UPPER = Wo.ToUpper(), LOWER = Wo.ToLower() };
            //foreach (var word in result_Query) Console.WriteLine(word);
            #endregion

            #region 3. Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB
            // Using Fluent Syntax[Extension Method]:
            //int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            //int[] numbersB = { 1, 3, 5, 7, 8 };
            //var Compares_Fluent = numbersA.SelectMany(a => numbersB, (a, b) => new { A = a, B = b })
            //                              .Where(P => P.A < P.B);
            //foreach (var pair in Compares_Fluent) Console.WriteLine($"({pair.A}, {pair.B})");
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            // Using Query Syntax[Query Expression]:
            //var Comparies_Query = from A in numbersA
            //                      from B in numbersB
            //                      where A < B
            //                      select new { A, B };
            //foreach (var pair in Comparies_Query) Console.WriteLine($"({pair.A}, {pair.B})");
            #endregion

            #region 4. Select all orders where the order total is less than 500.00
            // Using Fluent Syntax[Extension Method]:
            //var order_Fluent = CustomerList.SelectMany(O => O.Orders).Where(O => O.Total < 500.00M);
            //foreach (var Order in order_Fluent) Console.WriteLine(Order);
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            // Using Query Syntax[Query Expression]:
            //var order_Query = from O in CustomerList
            //                  from P in O.Orders
            //                  where P.Total < 500.00M
            //                  select P;
            //foreach (var Order in order_Query) Console.WriteLine(Order);
            #endregion

            #endregion

            #region LINQ - Set Operators

            #region 1. Find the unique Category names from Product List
            // Using Fluent Syntax[Extension Method]:
            //var uniqueCategory = ProductList.Select(C => new { C.Category}).Distinct();
            //foreach ( var item in uniqueCategory) Console.WriteLine(item);
            #endregion

            #region 2. Produce a Sequence containing the unique first letter from both product and customer names
            // Using Fluent Syntax[Extension Method]:
            //var uniqueFirstLetters = ProductList.Select(p => p.ProductName[0]) // first letter of product names
            //                                    .Union(CustomerList.Select(c => c.CustomerName[0])); // first letter of customer names
            //                        
            //foreach (var letter in uniqueFirstLetters) Console.Write($"{letter} ");
            #endregion

            #region 3. Create one sequence that contains the common first letter from both product and customer names
            // Using Fluent Syntax[Extension Method]:
            //var comonFirstLetters = ProductList.Select(p => p.ProductName[0]) // first letter of product names
            //                                    .Intersect(CustomerList.Select(c => c.CustomerName[0])); // first letter of customer names
            //                        
            //foreach (var letter in comonFirstLetters) Console.Write($"{letter} ");
            #endregion

            #region 4. Create one sequence that contains the first letters of product names that are not also first letters of customer names
            // Using Fluent Syntax[Extension Method]:
            //var exceptFirstLetters = ProductList.Select(p => p.ProductName[0]) // first letter of product names
            //                                    .Except(CustomerList.Select(c => c.CustomerName[0])); // first letter of customer names
            //                        
            //foreach (var letter in exceptFirstLetters) Console.Write($"{letter} ");
            #endregion

            #endregion

            #region LINQ - Partitioning Operators

            #region 1. Get the first 3 orders from customers in Washington
            // Using Fluent Syntax[Extension Method]:
            //var f3order = CustomerList.Where(C => C.Region == "WA").Take(3);
            //foreach ( var f in f3order ) Console.WriteLine(f);
            #endregion

            #region 2. Get all but the first 2 orders from customers in Washington
            // Using Fluent Syntax[Extension Method]:
            //var s2order = CustomerList.Where(C => C.Region == "WA").Skip(2);
            //foreach ( var f in s2order) Console.WriteLine(f);
            #endregion

            #region 3. Return elements starting from the beginning of the array until a number is hit that is less than its position in the array
            // Using Fluent Syntax[Extension Method]:
            //     0  1  2  3  4  5  6  7  8  9
            //int[] numbers_Q01 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var res = numbers_Q01.TakeWhile((N, I) => N >= I);
            //foreach (var item in res) Console.WriteLine(item);
            #endregion

            #region 4.Get the elements of the array starting from the first element divisible by 3
            // Using Fluent Syntax[Extension Method]:
            //int[] numbers_Q02 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var skipres = numbers_Q02.SkipWhile(X => X % 3 != 0);
            //foreach (var item in skipres) Console.WriteLine(item);
            #endregion

            #endregion

            #region LINQ - Quantifiers

            #region 1. Determine if any of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First) contain the substring 'ei'
            // Using Fluent Syntax[Extension Method]:
            //string[] Letters = File.ReadAllLines("dictionary_english.txt");
            //var Check = Letters.Any(L => L.Contains("ei"));
            //Console.WriteLine(Check);
            #endregion

            #region 2. Return a grouped a list of products only for categories that have at least one product that is out of stock
            // Using Fluent Syntax[Extension Method]:
            //var list = ProductList.Where(P => ProductList.Any(X => X.Category == P.Category && X.UnitsInStock == 0))
            //                      .GroupBy(P => P.Category);
            //foreach (var group in list)
            //{
            //    Console.WriteLine($"Category: {group.Key}");
            //    foreach (var product in group)
            //    {
            //        Console.WriteLine($"{product} ");
            //    }
            //}
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            // Using Query Syntax[Query Expression]:
            //var listQuery = from P in ProductList
            //                where ProductList.Any(X => X.Category == P.Category && X.UnitsInStock == 0)
            //                group P by P.Category;
            //foreach (var group in listQuery)
            //{
            //    Console.WriteLine($"Category: {group.Key}");
            //    foreach (var product in group)
            //    {
            //        Console.WriteLine($"{product} ");
            //    }
            //}
            #endregion

            #region 3. Return a grouped a list of products only for categories that have all of their products in stock
            // Using Fluent Syntax[Extension Method]:
            //var list01 = ProductList.GroupBy(P => P.Category)
            //                        .Where(P => P.All(X => X.UnitsInStock >0));
            //foreach (var group in list01)
            //{
            //    Console.WriteLine($"Category: {group.Key}");
            //    foreach (var product in group)
            //    {
            //        Console.WriteLine($"{product} ");
            //    }
            //}
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            // Using Query Syntax[Query Expression]:
            //var list01Query = from P in ProductList
            //                  group P by P.Category
            //                  into g
            //                  where g.All(P => P.UnitsInStock > 0)
            //                  select g;
            //                  
            //foreach (var group in list01Query)
            //{
            //    Console.WriteLine($"Category: {group.Key}");
            //    foreach (var product in group)
            //    {
            //        Console.WriteLine($"{product} ");
            //    }
            //}
            #endregion

            #endregion

            #region LINQ – Grouping Operators

            #region 1. Uses group by to partition a list of words by their first letter[Use dictionary_english.txt for Input]
            //string[] Wo = File.ReadAllLines("dictionary_english.txt");
            //var Res = Wo.GroupBy(W => W[0]);  // use first char of each word
            //
            //foreach (var group in Res)
            //{
            //    Console.WriteLine($"Letter: {group.Key}");
            //    foreach (var word in group)
            //    {
            //        Console.WriteLine($"{word} ");
            //    }
            //}
            #endregion

            #endregion
        }
    }
}

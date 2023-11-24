using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Fast24
{
    class Program
    {
        static void Main(string[] args)
        {
            Number number = new Number(4);
            var permutations = number.GetEnumer();
            var symbols = new List<List<string>>();
            var strings = new string[] { "+", "-", "*", "/", };
            Common.GenerateCombinations(strings, 3, new List<string>(), 0, symbols);

            //foreach (var p in permutations)
            //{
            //    foreach (var s in symbols)
            //    {

            //    }
            //}
            //char[] characters = { 'A', 'B', 'C', 'D' };
            //int positions = 3;
            //GenerateCombinations(characters, positions, new char[positions], 0);

            Console.WriteLine("All permutations:");
            foreach (var permutation in symbols)
            {
                Console.WriteLine(string.Join(", ", permutation));
            }
            Console.WriteLine($"{symbols.Count}");
            Console.ReadKey();
        }


        void GetE()
        {
            List<double> origin = new List<double>();


        }
    }

    // 1、数字顺序问题：A * B * C * D；4*3*2*1 = 24种情况
    // 2、操作符问题：  A * B * C * D；4*4*4   = 64种情况
    // 3、括号问题：  (A * B * C) * D；3*2*1   = 单个括号：6种情况，两个括号：1种情况
    // 4、输出：[]A[]*[]B[]*[]C[]*[]D[]

    class Meta
    { 
        
    }

    abstract class OperatorSymbol
    {
        public OperatorSymbol(OperatorSymbol @operator = null)
        {
            _operator = @operator;
        }

        public double Front { get; set; }

        public double Back { get; set; }

        protected OperatorSymbol _operator;

        public int Level { get; set; }

        public abstract double Calculate();
    }

    class Add : OperatorSymbol
    {
        public Add(OperatorSymbol @operator = null) : base(@operator)
        {
            Level = 0;
        }

        public override double Calculate()
        {
            if(_operator == null)
            {
                return Front + Back;
            }

            // Front + Back * B
            if (_operator.Level > this.Level)
            {
                Back = _operator.Calculate();
                return Front + Back;
            }
            else
            {
                _operator.Front = Front + Back;
                return _operator.Calculate();
            }
        }
    }

    class Reduce : OperatorSymbol
    {
        public override double Calculate()
        {
            throw new NotImplementedException();
        }
    }

    class Multiply : OperatorSymbol
    {
        public override double Calculate()
        {
            throw new NotImplementedException();
        }
    }

    class Divided : OperatorSymbol
    {
        public override double Calculate()
        {
            throw new NotImplementedException();
        }
    }

    class Number 
    {
        public Number(int size)
        {
            OriginData = GetOriginData(size);
        }

        public IList<IList<double>> GetEnumer()
        {
            return GetEnumer<double>(OriginData.ToArray(), OriginData.Count);
        }

        public IList<IList<T>> GetEnumer<T>(T[] values, int remaining)
        {
            IList<IList<T>> result = new List<IList<T>>();
            Common.GetPartialPermutationsHelper(values, new List<T>(), remaining, result);
            return result;
        }

        protected Random _random = new Random();

        protected IList<double> OriginData { get; set; }

        protected IList<double> GetOriginData(int size)
        {
            IList<double> data = new List<double>();
            int s = size;

            while ((s--) > 0)
            {
                data.Add(_random.Next(1, 9));
            }

            return data;
        }
    }

    class Common
    {
        //public static void GetPermutationsHelper<T>(T[] numbers, int start, int end, IList<IList<T>> result)
        //{
        //    if (start == end)
        //    {
        //        result.Add(new List<T>(numbers));
        //    }
        //    else
        //    {
        //        for (int i = start; i <= end; i++)
        //        {
        //            Swap(numbers, start, i);
        //            GetPermutationsHelper(numbers, start + 1, end, result);
        //            Swap(numbers, start, i); // Backtrack
        //        }
        //    }
        //}
        public static void GenerateCombinations<T>(T[] characters, int positions, List<T> currentCombination, int index, List<List<T>> result)
        {
            if (index == positions)
            {
                //Console.WriteLine(string.Join(", ", currentCombination));
                result.Add(currentCombination);
                return;
            }

            for (int i = 0; i < characters.Length; i++)
            {
                currentCombination[index] = characters[i];
                GenerateCombinations(characters, positions, currentCombination, index + 1, result);
            }
        }

        public static void GetPartialPermutationsHelper<T>(T[] numbers, List<T> currentPermutation, int remaining, IList<IList<T>> result)
        {
            if (remaining == 0)
            {
                result.Add(new List<T>(currentPermutation));
            }
            else
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (!currentPermutation.Contains(numbers[i]))
                    {
                        currentPermutation.Add(numbers[i]);
                        GetPartialPermutationsHelper(numbers, currentPermutation, remaining - 1, result);
                        currentPermutation.Remove(numbers[i]); // Backtrack
                    }
                }
            }
        }

        public static void Swap<T>(T[] numbers, int i, int j)
        {
            T temp = numbers[i];
            numbers[i] = numbers[j];
            numbers[j] = temp;
        }
    }


    class Solution
    {
        public Solution(int size)
        {
            Dimension = size;
            ReSetData();
        }

        /// <summary>
        /// todo
        /// </summary>
        public void OutPut()
        {
            string data = string.Empty;

            foreach (var d in Data)
            {
                data += (d + " ");
            }

            Console.WriteLine(data);
        }

        public IList<Record> Records { get; } = new List<Record>();

        public IList<int> Data { get; } = new List<int>();

        public int Dimension { get; } = 0;

        private Random _random = new Random();

        private IList<string> _solutions = new List<string>();

        private IList<Record> CreateRecords(List<int> indexes)
        {
            for(int i = 0; i < Dimension && !indexes.Contains(i); i++)
            {
                indexes.Add(i);

                if (indexes.Count == Dimension)
                {
                    Record record = new Record(Dimension);

                    foreach(var index in indexes)
                    {
                        record.Data.Add(Data[index]);
                    }

                    Records.Add(record);
                }
                else
                {
                    CreateRecords(indexes);
                }
            }

            return null;
        }

        public void ReSetData()
        {
            int size = Dimension;
            Data.Clear();
            Records.Clear();
            _solutions.Clear();

            while ((size--) > 0)
            {
                Data.Add(_random.Next(1, 9));
            }

            List<int> indexes = new List<int>();
            CreateRecords(indexes);
        }

        public IList<string> GetSolutions(bool re = false)
        {
            if(re == false && _solutions.Count != 0)
            {
                return _solutions;
            }

            foreach(var record in Records)
            {
                _solutions.Add(record.GetSolution());
            }

            return _solutions;
        }
    }

    class Record
    {
        public Record(int size)
        {
            Data = new List<int>(size);
        }

        public string GetSolution()
        {
            return string.Empty;
        }

        public IList<int> Data { get; set; }
    }
}

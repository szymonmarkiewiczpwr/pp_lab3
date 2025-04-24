using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pp_lab3_lib
{
    [MemoryDiagnoser]
    public class MatrixMultiplicationBenchmark
    {
        [Params(100, 250, 500)]
        public int Size;

        [Params(1, 2, 4, 8)]
        public int ThreadCount;

        private double[,] A;
        private double[,] B;
        private double[,] Result;

        [GlobalSetup]
        public void Setup()
        {
            A = GenerateMatrix(Size);
            B = GenerateMatrix(Size);
            Result = new double[Size, Size];
        }

        [Benchmark(Baseline = true)]
        public void MultiplySequential()
        {
            MultiplySequential(A, B, Result);
        }

        [Benchmark]
        public void MultiplyParallel()
        {
            MultiplyParallel(A, B, Result, ThreadCount);
        }

        private static double[,] GenerateMatrix(int size)
        {
            var matrix = new double[size, size];
            var rand = new Random(0);
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    matrix[i, j] = rand.Next(1, 10);
            return matrix;
        }

        private static void MultiplySequential(double[,] A, double[,] B, double[,] result)
        {
            int size = A.GetLength(0);
            Array.Clear(result, 0, result.Length);
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    for (int k = 0; k < size; k++)
                        result[i, j] += A[i, k] * B[k, j];
        }

        private static void MultiplyParallel(double[,] A, double[,] B, double[,] result, int threads)
        {
            int size = A.GetLength(0);
            Array.Clear(result, 0, result.Length);
            var options = new ParallelOptions { MaxDegreeOfParallelism = threads };

            Parallel.For(0, size, options, i =>
            {
                for (int j = 0; j < size; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < size; k++)
                        sum += A[i, k] * B[k, j];
                    result[i, j] = sum;
                }
            });
        }
    }
}

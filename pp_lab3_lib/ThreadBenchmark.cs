using System;
using System.Threading;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace pp_lab3_lib
{
    [MemoryDiagnoser]
    public class ThreadMatrixMultiplicationBenchmark
    {
        [Params(100, 250, 500)]
        public int Size;

        [Params(2, 4, 8)]
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
        public void MultiplyUsingThreads()
        {
            MultiplyWithThreads(A, B, Result, ThreadCount);
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

        private static void MultiplyWithThreads(double[,] A, double[,] B, double[,] result, int threadCount)
        {
            int size = A.GetLength(0);
            Array.Clear(result, 0, result.Length);

            Thread[] threads = new Thread[threadCount];
            int rowsPerThread = size / threadCount;

            for (int t = 0; t < threadCount; t++)
            {
                int startRow = t * rowsPerThread;
                int endRow = (t == threadCount - 1) ? size : startRow + rowsPerThread;

                threads[t] = new Thread(() =>
                {
                    for (int i = startRow; i < endRow; i++)
                        for (int j = 0; j < size; j++)
                        {
                            double sum = 0;
                            for (int k = 0; k < size; k++)
                                sum += A[i, k] * B[k, j];
                            result[i, j] = sum;
                        }
                });

                threads[t].Start();
            }

            foreach (var thread in threads)
                thread.Join();
        }
    }
}

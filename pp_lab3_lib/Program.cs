﻿using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pp_lab3_lib
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<MatrixMultiplicationBenchmark>();
            //var summary = BenchmarkRunner.Run<ThreadMatrixMultiplicationBenchmark>();
        }
    }
}

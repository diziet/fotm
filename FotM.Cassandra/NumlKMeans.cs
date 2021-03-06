﻿using System;
using System.Collections.Generic;
using numl.Math.LinearAlgebra;
using numl.Math.Metrics;
using numl.Model;
using numl.Unsupervised;

namespace FotM.Cassandra
{
    public class NumlKMeans: IKMeans<PlayerChange>
    {
        private readonly IDistance _distanceMetric;

        private static readonly Descriptor DiffDescriptor = Descriptor.Create<PlayerChange>();

        public NumlKMeans(IDistance distanceMetric = null)
        {
            _distanceMetric = distanceMetric ?? new HammingDistance();
        }

        public int[] ComputeGroups(PlayerChange[] dataSet, int nGroups)
        {
            var kMeans = new KMeans();
            kMeans.Descriptor = DiffDescriptor;

            if (_distanceMetric != null) 
            return kMeans.Generate(dataSet, nGroups, _distanceMetric);
            else return kMeans.Generate(dataSet, nGroups);
        }
    }

    public class FuncMetric : IDistance
    {
        private readonly Func<double[], double[], double> _func;

        public FuncMetric(Func<double[], double[], double> func)
        {
            _func = func;
        }

        public double Compute(Vector x, Vector y)
        {
            return _func(x.ToArray(), y.ToArray());
        }
    }
}
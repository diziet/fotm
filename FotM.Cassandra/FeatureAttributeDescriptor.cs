﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Accord.Math;
using FotM.Utilities;
using MoreLinq;

namespace FotM.Cassandra
{
    public class FeatureAttributeDescriptor<T>
    {
        private readonly Dictionary<string, int> _featureIndices;
        private readonly PropertyInfo[] _featureProperties;
        private readonly AccordFeatureAttribute[] _attributeValues;

        private readonly double[] _means;
        private readonly double[] _scales;


        public FeatureAttributeDescriptor()
        {
            _featureProperties = typeof (T).GetProperties()
                .Where(p => p.IsDefined(typeof (AccordFeatureAttribute), false))
                .ToArray();

            _featureIndices = _featureProperties
                .Select((prop, idx) => new { prop, idx })
                .ToDictionary(pi => pi.prop.Name, pi => pi.idx);

            _attributeValues = _featureProperties
                .Select(p => p.GetCustomAttribute<AccordFeatureAttribute>(false))
                .ToArray();

            _means = new double[TotalFeatures];
            _scales = new double[TotalFeatures];

            for (int i = 0; i < TotalFeatures; ++i)
            {
                _means[i] = 0;
                _scales[i] = 1;
            }
        }

        public void NormalizeFor(T[] trainingSet)
        {
            for (int i = 0; i < TotalFeatures; ++i)
            {
                if (!_attributeValues[i].Normalize)
                    continue;

                int featureIdx = i;

                double[] values = trainingSet
                    .Select(x => GetFeatureValue(featureIdx, x))
                    .ToArray();

                double min, max;
                values.MinMaxAvg(out min, out max, out _means[i]);

                double range = max - min;
                _scales[i] = range.IsRelativelyEqual(0, 1e-5) ? 1 : range;
            }
        }

        public HashSet<string> Features
        {
            get { return _featureIndices.Keys.ToHashSet(); }
        }

        public int TotalFeatures
        {
            get
            {
                return _featureProperties.Length;
            }
        }

        public int GetFeatureIndex(string name)
        {
            int idx;

            if (_featureIndices.TryGetValue(name, out idx))
            {
                return idx;
            }

            string msg = string.Format("Feature with name {0} couldn't be found", name);
            throw new ArgumentException(msg);
        }

        public double GetFeatureValue(string featureName, T obj)
        {
            var idx = GetFeatureIndex(featureName);
            return GetFeatureValue(idx, obj);
        }

        public double GetFeatureValue(int idx, T obj)
        {
            var prop = _featureProperties[idx];

            //double w = _attributeValues[idx].Weight;

            var value = Convert.ToDouble(prop.GetValue(obj));
            return (value - _means[idx]) / _scales[idx];
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMiner.Clustering;
using System.IO;

namespace DataMiner.ClusterDataReaders
{
    public class CsvDataReader : ClusterDataReader
    {
        public CsvDataReader(string fileName, ClusterData clusterData) : base(fileName, clusterData)
        {
        }

        public override void ReadData()
        {
            using (StreamReader sr = new StreamReader(this.FileName))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] values = line.Split(',');

                    this.clusterData.Add(new ClusterPoint(double.Parse(values[0]), double.Parse(values[1])));
                }
            }
        }
    }
}

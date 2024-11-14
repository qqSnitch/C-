﻿using System;
using System.IO;

namespace OneProject.NeuroNet
{
    class InputLayer
    {
        //Поля
        private Random random = new Random();
        private double[,] trainset = new double[100, 16];
        private double[,] testset = new double [10, 16];

        //Свойства
        public double[,] Trainset { get => trainset; }

        //Конструктор
        public InputLayer(NetworkMode nm)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;//где находится exe
            string[] tmpStr;
            string[] tmpArrStr;
            double[] tmpArr;
            switch (nm)
            {
                case NetworkMode.Train:
                    tmpArrStr = File.ReadAllLines(path + "Train.txt");
                    for (int i = 0; i < tmpArrStr.Length; i++)
                    {
                        tmpStr = tmpArrStr[i].Split();
                        tmpArr = new double[tmpStr.Length];
                        for (int j = 0; j < tmpArr.Length; j++)
                        {
                            tmpArr[j] = double.Parse(tmpStr[j], System.Globalization.CultureInfo.InvariantCulture);
                        }

                    }
                    for (int n = trainset.GetLength(0) - 1; n >= 1; n--)
                    {
                        int j = random.Next(n + 1);
                        double[] temp = new double[trainset.GetLength(1)];

                        for (int i = 0; i < trainset.GetLength(1); i++)
                        {
                            temp[i] = trainset[n, i];
                        }
                        for (int i = 0; i < trainset.GetLength(1); i++)
                        {
                            trainset[n, i] = trainset[j, i];
                            trainset[j, i] = temp[i];
                        }
                    }
                    break;
                    //дописать ветку test

                    /*case NetworkMode.Test:
                        tmpArrStr = File.ReadAllLines(path + "Test.txt");
                        for (int i = 0; i < tmpArrStr.Length; i++)
                        {
                            tmpStr = tmpArrStr[i].Split();
                            tmpArr = new double[tmpStr.Length];
                            for (int j = 0; j < tmpArr.Length; j++)
                            {
                                tmpArr[j] = double.Parse(tmpStr[j], System.Globalization.CultureInfo.InvariantCulture);
                            }

                        }
                        for (int n = trainset.GetLength(0) - 1; n >= 1; n--)
                        {
                            int j = random.Next(n + 1);
                            double[] temp = new double[trainset.GetLength(1)];

                            for (int i = 0; i < trainset.GetLength(1); i++)
                            {
                                temp[i] = trainset[n, i];
                            }
                            for (int i = 0; i < trainset.GetLength(1); i++)
                            {
                                trainset[n, i] = trainset[j, i];
                                trainset[j, i] = temp[i];
                            }
                        }
                        break;*/
            }

        }
    }
}

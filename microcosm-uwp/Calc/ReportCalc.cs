using microcosm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microcosm.Calc
{
    class ReportCalc
    {
        public int down = 0;
        public int right = 0;
        public int up = 0;
        public int left = 0;

        public int fire = 0;
        public int earth = 0;
        public int air = 0;
        public int water = 0;

        public int cardinalSign = 0;
        public int fixedSign = 0;
        public int mutableSign = 0;

        public int angularHouse = 0;
        public int succedentHouse = 0;
        public int cadentHouse = 0;

        public void ReCalcReport(Calcuration ringsData)
        {
            double[] newList = new double[13];

            // 計算の都合差分がマイナスなら360足す
            Enumerable.Range(1, 12).ToList().ForEach(i =>
            {
                newList[i] = ringsData.cusps[i] - ringsData.cusps[1];
                if (newList[i] < 0)
                {
                    newList[i] += 360;
                }
                //                Console.WriteLine(list1[i].ToString());
            });

            double target;

            // ハウス上下左右
            Enumerable.Range(0, 10).ToList().ForEach(i =>
            {
                target = ringsData.planetData[i].absolute_position - ringsData.cusps[1];
                if (target < 0)
                {
                    target += 360;
                }
                if (
                    (newList[1] <= target && target < newList[2])
                )
                {
                    //                    Console.WriteLine(i.ToString() + " " + target +  ":1");
                    down++;
                    left++;
                }
                else if (
                    (newList[2] <= target && target < newList[3])
                )
                {
                    //                    Console.WriteLine(i.ToString() + " " + target + ":2");
                    down++;
                    left++;
                }
                else if (
                    (newList[3] <= target && target < newList[4])
                )
                {
                    //                    Console.WriteLine(i.ToString() + " " + target + ":3");
                    down++;
                    left++;
                }
                else if (
                    (newList[4] <= target && target < newList[5])
                )
                {
                    //                    Console.WriteLine(i.ToString() + " " + target + ":4");
                    down++;
                    right++;
                }
                else if (
                    (newList[5] <= target && target < newList[6])
                )
                {
                    //                    Console.WriteLine(i.ToString() + " " + target + ":5");
                    down++;
                    right++;
                }
                else if (
                    (newList[6] <= target && target < newList[7])
                )
                {
                    //                    Console.WriteLine(i.ToString() + " " + target + ":6");
                    down++;
                    right++;
                }
                else if (
                    (newList[7] <= target && target < newList[8])
                )
                {
                    //                    Console.WriteLine(i.ToString() + " " + target + ":7");
                    up++;
                    right++;
                }
                else if (
                    (newList[8] <= target && target < newList[9])
                )
                {
                    //                    Console.WriteLine(i.ToString() + " " + target + ":8");
                    up++;
                    right++;
                }
                else if (
                    (newList[9] <= target && target < newList[10])
                )
                {
                    //                    Console.WriteLine(i.ToString() + " " + target + ":9");
                    up++;
                    right++;
                }
                else if (
                    (newList[10] <= target && target < newList[11])
                )
                {
                    //                    Console.WriteLine(i.ToString() + " " + target + ":10");
                    up++;
                    left++;
                }
                else if (
                    (newList[11] <= target && target < newList[12])
                )
                {
                    //                    Console.WriteLine(i.ToString() + " " + target + ":11");
                    up++;
                    left++;
                }
                else
                {
                    //                    Console.WriteLine(i.ToString() + " " + target + ":12");
                    up++;
                    left++;
                }
            });


            Enumerable.Range(0, 10).ToList().ForEach(i =>
            {
                if (
                    (0.0 <= ringsData.planetData[i].absolute_position && ringsData.planetData[i].absolute_position < 30.0) ||
                    (120.0 <= ringsData.planetData[i].absolute_position && ringsData.planetData[i].absolute_position < 150.0) ||
                    (240.0 <= ringsData.planetData[i].absolute_position && ringsData.planetData[i].absolute_position < 270.0)
                )
                {
                    fire++;
                }
                else if (
                    (30.0 <= ringsData.planetData[i].absolute_position && ringsData.planetData[i].absolute_position < 60.0) ||
                    (150.0 <= ringsData.planetData[i].absolute_position && ringsData.planetData[i].absolute_position < 180.0) ||
                    (270.0 <= ringsData.planetData[i].absolute_position && ringsData.planetData[i].absolute_position < 300.0)
                )
                {
                    earth++;
                }
                else if (
                    (60.0 <= ringsData.planetData[i].absolute_position && ringsData.planetData[i].absolute_position < 90.0) ||
                    (180.0 <= ringsData.planetData[i].absolute_position && ringsData.planetData[i].absolute_position < 210.0) ||
                    (300.0 <= ringsData.planetData[i].absolute_position && ringsData.planetData[i].absolute_position < 330.0)
                )
                {
                    air++;
                }
                else
                {
                    water++;
                }

            });


            Enumerable.Range(0, 10).ToList().ForEach(i =>
            {
                if (
                    (0.0 <= ringsData.planetData[i].absolute_position && ringsData.planetData[i].absolute_position < 30.0) ||
                    (90.0 <= ringsData.planetData[i].absolute_position && ringsData.planetData[i].absolute_position < 120.0) ||
                    (180.0 <= ringsData.planetData[i].absolute_position && ringsData.planetData[i].absolute_position < 210.0) ||
                    (270.0 <= ringsData.planetData[i].absolute_position && ringsData.planetData[i].absolute_position < 300.0)
                )
                {
                    cardinalSign++;
                }
                else if (
                    (30.0 <= ringsData.planetData[i].absolute_position && ringsData.planetData[i].absolute_position < 60.0) ||
                    (120.0 <= ringsData.planetData[i].absolute_position && ringsData.planetData[i].absolute_position < 150.0) ||
                    (210.0 <= ringsData.planetData[i].absolute_position && ringsData.planetData[i].absolute_position < 240.0) ||
                    (300.0 <= ringsData.planetData[i].absolute_position && ringsData.planetData[i].absolute_position < 330.0)
                )
                {
                    fixedSign++;
                }
                else
                {
                    mutableSign++;
                }

            });

            Enumerable.Range(0, 10).ToList().ForEach(i =>
            {
                target = ringsData.planetData[i].absolute_position - ringsData.cusps[1];
                if (target < 0)
                {
                    target += 360;
                }
                if (
                    (newList[1] <= target && target < newList[2]) ||
                    (newList[4] <= target && target < newList[5]) ||
                    (newList[7] <= target && target < newList[8]) ||
                    (newList[10] <= target && target < newList[11])
                )
                {
                    angularHouse++;
                }
                else if (
                    (newList[2] <= target && target < newList[3]) ||
                    (newList[5] <= target && target < newList[6]) ||
                    (newList[8] <= target && target < newList[9]) ||
                    (newList[11] <= target && target < newList[12])
                )
                {
                    succedentHouse++;
                }
                else
                {
                    cadentHouse++;
                }
            });

        }
    }
}

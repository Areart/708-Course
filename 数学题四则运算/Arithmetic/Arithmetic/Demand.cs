﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data;
namespace Arithmetic
{
    public class Demand
    {
        /// <summary>
        /// 判断输入的类型是否为整数
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNumber(string input)
        {
            if (Regex.IsMatch(input, @"^[+-]?\d*[.]?$"))
            {
                return true;
            }
            else
            {
                Console.WriteLine("请输入整数");
                return false;
            }
        }
        /// <summary>
        /// 问题验证
        /// </summary>
        /// <param name="input"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        public static bool IsNumber(string input, int l)
        {
            if (Regex.IsMatch(input, @"^[+-]?\d*[.]?$"))
            {
                var num = Convert.ToDouble(input);
                if (l == 1)
                {
                    if (num <= 0 || num >= 100000)
                    {
                        Console.WriteLine("请输入正确的出题量范围");
                    }
                }
                if (l == 2)
                {
                    if (num <= 0 || num > 100)
                    {
                        Console.WriteLine("请输入正确的数据范围");
                    }
                }
                return true;

            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// 公式配置与运算
        /// </summary>
        /// <param name="Number">初始数</param>
        /// <param name="Range">数据范围</param>
        public static void OpNumber(string Number, string Range)
        {
            Random number = new Random(); //实例化一个随机数  
            int num = Convert.ToInt32(Number);
            int range = Convert.ToInt32(Number);

            string[] op = new string[] { "＋", "－", "×", "÷" };
            string[] ll = new string[] { "+", "-", "*", "/" };
            string Formula = "";
            string Formulanum = "";
            string[] myArray = new string[num];
            DataTable dt = new DataTable();
            for (int i = 1; i <= num; i++)
            {
                double number1 = number.Next(0, range);//随机一个初始数
                int OP = number.Next(1, 4);//随机运算符数量
                string result = "";//结果
                Formulanum = Formula = "";
                Formulanum = Formula += number1;
                for (int j = 1; j <= OP; j++)
                {
                    int opnext = number.Next(0, 4);//随机一个符号
                    int number2 = number.Next(0, range);//随机一个数

                    if (opnext == 3 && number2 == 0)//判断算式是否存在除0
                    {
                        number2 = number.Next(0, range);//重新随机一个数
                    }
                    int newOP = FormulaOP(opnext);
                    Formula += op[newOP] + number2;
                    Formulanum += ll[newOP] + number2;
                }

                result = dt.Compute(Formulanum, "false").ToString();
                if (IsNumber(result, 6) == false)
                {
                    result = Convert.ToDouble(result).ToString("#0.00");  //使小数结果保留两位小数
                    Console.WriteLine(Formula + "≈" + result);
                }
                Console.WriteLine(Formula + "=" + result);

            }

        }
        /// <summary>
        /// 代码算式优化
        /// </summary>
        /// <param name="opnext"></param>
        /// <returns></returns>
        public static int FormulaOP(int opnext)
        {
            Random number = new Random();
            int i = 0, l = 0, NewOpnext = 0;
            if (opnext == 2)//避免太多的乘法
            {
                i++;
                if (i > 2)
                {
                    NewOpnext = number.Next(0, 4);
                    return NewOpnext;
                }

                return opnext;
            }
            if (opnext == 3)//避免太多的除法
            {

                if (opnext == l)
                {
                    NewOpnext = number.Next(0, 4);
                    return NewOpnext;
                }
                l = opnext;
                return opnext;
            }
            return opnext;
        }

    }
}

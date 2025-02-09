﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using static Home_Work_Collection.Application.App.Utils;       // для использования утилит

/*
 * Задача 1. Разработайте, пожалуйста, консольное приложение C# для решения следующих 
 * задач, с использованием типизированных коллекций, закрытых типом int. 
 * •	Dynamic10. Дан непустой стек. Создать два новых стека, переместив в первый из 
 *      них все элементы исходного стека с четными значениями, а во второй — с 
 *      нечетными (элементы в новых стеках будут располагаться в порядке, обратном 
 *      исходному; один из этих стеков может оказаться пустым). 
 * •	Dynamic24. Даны две непустые очереди, очереди содержат одинаковое количество 
 *      элементов. Объединить очереди в одну, в которой элементы исходных очередей 
 *      чередуются (начиная с первого элемента первой очереди)
 * •	Dynamic37. Дан непустой список. Продублировать в списке все элементы с 
 *      нечетными номерами (новые элементы добавлять перед существующими элементами 
 *      с такими же значениями)
*/

namespace Home_Work_Collection.Application
{
    // константы для меню
    internal enum Cmd
    {
        pointExit,
        pointOne,
        pointTwo,
        pointThree,
        pointFour,
        pointFive,
        pointSix
    }

    public partial class App
    {

    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;        // для работы с потоками данных
using HomeWork.Views;   // формы


/*
 * Задача 1. Разработайте приложение Windows Forms для вычислений параметров 
 * объемных геометрических тел по выбору пользователя. Каждый расчет выполняется 
 * на собственной форме, открываемой в модальном режиме. Выбор формы – при помощи
 * меню (MenuStrip). В меню должен быть пункт Объемные тела, в подменю которого и
 * размещаются команды перехода на формы вычисления фигур.  Используйте шорткаты,
 * горячие клавиши, картинки в пунктах меню.
 * В пункте меню Помощь разместите подменю с командой О программе, по которой в 
 * отдельной форме выводить в TextBox сведения о приложении и разработчике (фамилия,
 * имя, группа). При помощи таймера реализуйте закрытие формы «О программе» через 10
 * секунд после открытия.
 * В формах фигур разместить строки ввода NumericUpDown для параметров фигур, 
 * чек-боксы для задания вычисляемых параметров фигуры, комбо-бокс выбора материала 
 * фигуры, изображение фигуры, изображение материала фигуры. Изображения выводить в 
 * Paintbox, Вы без проблем найдете изображения в интернете.
 * Собственно вычисления выполнять при клике на кнопку "Вычислить" формы. По этой же
 * кнопке в файл журнала, размещенный в папке исполняемого файла выводить дату и время
 * выполнения расчетов, параметры тела и результаты вычислений.
 * Что именно вычислять для каждого объемного тела:
 * •	площадь поверхности 
 * •	объем
 * •	масса 
 * Типы объемных тел для расчетов:
 * •	усеченный конус
 * •	сфера
 * •	цилиндр
 * •	прямоугольный параллелепипед
 * Виды материалов, из которых создаются тела (расширения номенклатуры материалов не
 * предвидится 😊):
 * •	сталь (нержавеющая)
 * •	медь
 * •	водяной лед
 * •	гранит
 * В пункте меню Журнал разместите подменю с командами Просмотр и Очистка. По команде
 * Просмотр в отдельной форме выводить журнал работы приложения в TextBox (загрузка 
 * журнала в событии Load формы). По команде Очистка очищать журнал работы приложения.
 * Также журнал работы выводите в главной форме приложения, в TextBox. Обновление 
 * TextBox выполняйте после вызовов ShowDialog для отображения форм объемных тел и 
 * в обработчике события Load главной формы. 
 * Задача 2. В приложение задачи 1 добавьте пункт меню Списки по которому выполните
 * переход на отдельную форму, на которой разместите два лист-бокса. В одном разместите 
 * не менее 12 строк – названия городов, второй оставьте пустым.
 * По командным кнопкам выполните:
 * •	перемещение выбранного элемента из первого лист-бокса во второй
 * •	перемещение всех элементов из первого лист-бокса во второй
 * •	перемещение выбранного элемента из второго лист-бокса в первый
 * •	перемещение всех элементов из второго лист-бокса в первый
 * •	очистка обоих лист-боксов
 * •	ввод названия города в строку ввода и добавление города по кнопке в первый 
 *      лист-бокс
 * •	выбор названия города из комбо-бокса и добавление города по событию выбора во 
 *      второй лист-бокс 
*/

namespace HomeWork
{
    // главная форма
    public partial class MainForm : Form
    {
        // название файла 
        public static string saveFileName = "operations.log";

        public MainForm()
        {
            InitializeComponent();


            // делегат 
            Func<DialogResult> op;

            // запись в тег делегата для открытия формы в модальном режиме
            op = () => new FormConoid().ShowDialog();
            MniConoid.Tag = op;
            op = () => new FormSphere().ShowDialog();
            MniSphere.Tag = op;
            op = () => new FormCylinder().ShowDialog();
            MniCylinder.Tag = op;
            op = () => new FormParallelepiped().ShowDialog();
            MniParallelepiped.Tag = op;
        }

        // открытие формы "Усеченный конус" в модальном режиме
        private void MniFigure_Click(object sender, EventArgs e)
        {
            // unboxing
            var control = (ToolStripMenuItem)sender;

            // запуск формы
            ((Func<DialogResult>)control.Tag).Invoke();

            // перечитывание файла журнала
            LoadLog();
        }

        // открытие формы "О программе" в модальном режиме
        private void MniInfo_Click(object sender, EventArgs e)
        {
            new FormInfo().ShowDialog();
        }

        // загрузка формы
        private void MainForm_Load(object sender, EventArgs e) => LoadLog();

        // считывание файла журнала
        private void LoadLog()
        {
            // создание или открытие файла для сохранения истории операций
            using (File.OpenWrite(saveFileName)) { }

            // чтение файла и вывод в журнал
            TbxHistory.Text = File.ReadAllText(saveFileName, Encoding.UTF8);
        }

        // открытие формы "Журанал"
        private void MniViewHistory_Click(object sender, EventArgs e)
        {
            // запуск формы в модальном режиме
            new LogForm().ShowDialog();

            // перечитывание файла журнала
            LoadLog();
        }

        // очистка журнала
        private void MniClear_Click(object sender, EventArgs e)
        {
            // очистка журнала
            File.WriteAllText(MainForm.saveFileName, "");

            // считывание файла журнала
            LoadLog();
        }

        // открытие формы "Списки"
        private void MniLists_Click(object sender, EventArgs e) => new ListsForm().ShowDialog();
    }
}

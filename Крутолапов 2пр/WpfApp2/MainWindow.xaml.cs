using Lib_1;
using LibArray;
using System;
using System.Windows;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Array<int> _array;               

        private void CreateFill(object sender, RoutedEventArgs e)
        {
            try
            {
                int min = int.Parse(tbMin.Text);
                int max = int.Parse(tbMax.Text);
                int count = int.Parse(tbColCount.Text);

                _array = ExtensionArray.CreateArr(_array, count, min, max);
                _array.Length = count;
                _array.Capacity = count;

                dataGrid.ItemsSource = _array.ToDataTable<int>().DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("Данные введены некорректно, либо отсутствуют");
            }            
        }

        private void ButtonTask(object sender, RoutedEventArgs e)
        {
            try
            {
                int result = ExtensionArray.SumB5(_array);

                tbTask.Text = result.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Таблица не создана!");
            }            
        }

        private void ButtonAdd(object sender, RoutedEventArgs e)
        {
            try
            {
                int[] ints = Array.ConvertAll(tbAdd.Text.Split(' '), int.Parse);

                _array.AddRange(ints);

                dataGrid.ItemsSource = _array.ToDataTable<int>().DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("Некорректно введены числа на добавление!");
            }            
        }

        private void ButtonDelete(object sender, RoutedEventArgs e)
        {
            try
            {
                string tbSource = tbDelete.Text;
                string[] tbNumbers = tbSource.Split(' ');

                for (int i = 0; i < tbNumbers.Length; i++)
                {
                    _array.Remove(int.Parse(tbNumbers[i]));
                }

                dataGrid.ItemsSource = _array.ToDataTable<int>().DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("Таблица пуста, либо некорректно введены числа на удаление!");
            }
        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void About(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Выполнил: студент группы ИСП-31 Крутолапов Валерий Формулировка задания:" +
                            " 1.Разработать библиотеку, содержащую класс для работы с массивом: " +
                "очистить, добавить, реализовать методы . Разработать библиотеку, содержащую " +
                "вычислительные модули (функции) программы для решения задачи по варианту задания." +
                "Вариант-1: Найти сумму чисел > 5.");
        }

        private void Buttonclear(object sender, RoutedEventArgs e)
        {
            try
            {
                _array.Clear();
                dataGrid.ItemsSource = _array.ToDataTable<int>().DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("Таблица пуста!");
            }
            
        }
    }
}
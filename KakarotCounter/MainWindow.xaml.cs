using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Kakarot
{
    public partial class MainWindow : Window
    {
        public List<Lap> Laps { get; set; } = new List<Lap>();

        private int LapCount { get; set; } = 0;
        private int TotalRot { get; set; } = 0;
        private int MaxRot { get; set; } = 0;
        private double AverageRot { get; set; } = 0;

        public MainWindow()
        {
            InitializeComponent();

            SetLabel();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show(
                "終了します。よろしいですか？",
                "確認",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result != MessageBoxResult.Yes) e.Cancel = true;
        }

        private void button01_Click(object sender, RoutedEventArgs e)
        {
            Add(1);
        }

        private void button02_Click(object sender, RoutedEventArgs e)
        {
            Add(2);
        }

        private void button03_Click(object sender, RoutedEventArgs e)
        {
            Add(3);
        }

        private void button04_Click(object sender, RoutedEventArgs e)
        {
            Add(4);
        }

        private void button05_Click(object sender, RoutedEventArgs e)
        {
            Add(5);
        }

        private void button06_Click(object sender, RoutedEventArgs e)
        {
            Add(6);
        }

        private void button07_Click(object sender, RoutedEventArgs e)
        {
            Add(7);
        }

        private void button08_Click(object sender, RoutedEventArgs e)
        {
            Add(8);
        }

        private void button09_Click(object sender, RoutedEventArgs e)
        {
            Add(9);
        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            Add(10);
        }

        private void button11_Click(object sender, RoutedEventArgs e)
        {
            Add(11);
        }

        private void button12_Click(object sender, RoutedEventArgs e)
        {
            Add(12);
        }

        private void button13_Click(object sender, RoutedEventArgs e)
        {
            Add(13);
        }

        private void button14_Click(object sender, RoutedEventArgs e)
        {
            Add(14);
        }

        private void button15_Click(object sender, RoutedEventArgs e)
        {
            Add(15);
        }

        private void button00_Click(object sender, RoutedEventArgs e)
        {
            Add(0);
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Cancel();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void Add(int rot)
        {
            Laps.Add(new Lap(rot));

            Calc();

            SetLabel();
        }

        private void Cancel()
        {
            LapCount = Laps.Count;

            if (LapCount == 0) return;

            Laps.RemoveAt(LapCount - 1);

            Calc();

            SetLabel();
        }

        private void Calc()
        {
            LapCount = Laps.Count;

            if (LapCount == 0)
            {
                TotalRot = 0;
                MaxRot = 0;
                AverageRot = 0;
            }
            else
            {
                TotalRot = Laps.Sum(x => x.Rot);
                MaxRot = Laps.Max(x => x.Rot);
                AverageRot = (double)TotalRot / LapCount;
            }
        }

        private void SetLabel()
        {
            labelLapCount.Content = LapCount.ToString() + "   ";
            labelTotalRot.Content = TotalRot.ToString() + "   ";
            labelMaxRot.Content = MaxRot.ToString() + "   ";
            labelAverageRot.Content = AverageRot.ToString("f2");
        }

        private void Save()
        {
            var div = "\t";

            var sb = new StringBuilder();

            sb.Append("時刻")
              .Append(div)
              .Append("ロット数")
              .AppendLine();

            Laps.ForEach(x =>
            {
                sb.Append(x.TimeStamp.ToString("yyyy/MM/dd HH:mm:ss"))
                  .Append(div)
                  .Append(x.Rot)
                  .AppendLine();
            });

            sb.AppendLine();

            sb.Append("悟飯の出番").Append(div).Append(LapCount.ToString()).AppendLine();
            sb.Append("合計ロット数").Append(div).Append(TotalRot.ToString()).AppendLine();
            sb.Append("最大ロット数").Append(div).Append(MaxRot.ToString()).AppendLine();
            sb.Append("平均ロット数").Append(div).Append(AverageRot.ToString("f2")).AppendLine();

            try
            {
                Clipboard.SetText(sb.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "クリップボードにコピーできませんでした。",
                    "エラー",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);

                return;
            }

            MessageBox.Show(
                "カカログをクリップボードにコピーしました。",
                "完了",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}

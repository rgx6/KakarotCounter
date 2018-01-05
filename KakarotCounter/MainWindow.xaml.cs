using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Kakarot
{
    public partial class MainWindow : Window
    {
        public List<Lap> Laps { get; set; } = new List<Lap>();

        private int LapCount { get; set; } = 0;
        private int TotalRot { get; set; } = 0;
        private int MaxRot { get; set; } = 0;
        private double AverageRot { get; set; } = 0;

        private Key[] KeyBindForNumbers { get; set; } = new Key[16];
        private Key KeyBindForCancel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            InitKeyConfig();

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

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            var key = e.Key;

            if (Key.System == key)
            {
                // F10対策
                key = e.SystemKey;
                e.Handled = true;
            }

            if (e.IsRepeat) return;

            for (var i = 0; i < KeyBindForNumbers.Length; i++)
            {
                if (KeyBindForNumbers[i] != Key.None && KeyBindForNumbers[i] == key)
                {
                    Add(i);
                    return;
                }
            }

            if (KeyBindForCancel != Key.None && KeyBindForCancel == key)
            {
                Cancel();
                return;
            }
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

        private void InitKeyConfig()
        {
            KeyBindForNumbers[0] = Key.Escape;
            KeyBindForNumbers[1] = Key.F1;
            KeyBindForNumbers[2] = Key.F2;
            KeyBindForNumbers[3] = Key.F3;
            KeyBindForNumbers[4] = Key.F4;
            KeyBindForNumbers[5] = Key.F5;
            KeyBindForNumbers[6] = Key.F6;
            KeyBindForNumbers[7] = Key.F7;
            KeyBindForNumbers[8] = Key.F8;
            KeyBindForNumbers[9] = Key.F9;
            KeyBindForNumbers[10] = Key.F10;
            KeyBindForNumbers[11] = Key.F11;
            KeyBindForNumbers[12] = Key.F12;
            KeyBindForNumbers[13] = Key.None;
            KeyBindForNumbers[14] = Key.None;
            KeyBindForNumbers[15] = Key.None;
            KeyBindForCancel = Key.Back;
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
                sb.Append(x.TimeStamp.ToString("yyyy/MM/dd HH:mm:ss.fff"))
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

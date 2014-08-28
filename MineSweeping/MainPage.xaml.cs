using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using Windows.UI;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace MineSweeping
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private const  int DefaultMineNum = 10;
        private const int DefaultRow = 9;
        private const int DefaultColumn = 9;

        private int totalSquares;
        private bool[] mineArray;
        public MainPage()
        {
            this.InitializeComponent();
            InitializeMine();

        }

        private void InitializeMine(int mineNum = DefaultMineNum, int row = DefaultRow, int column = DefaultColumn)
        {
            totalSquares = row * column;
            mineArray = new bool[totalSquares];

            for(int i = 0; i < totalSquares; i++)
            {
                mineArray[i] = false;
            }

            Random rand = new Random(Guid.NewGuid().GetHashCode());
            for (int i = mineNum; i > 0; )
            {
                int index = rand.Next(0, totalSquares);
                if(mineArray[index] == false)
                {
                    mineArray[index] = true;
                    i--;
                }
            }

            for (int i = 0; i < row; i++)
            {
                RowDefinition rd = new RowDefinition();
                rd.Height = new GridLength(74);
                mineArea.RowDefinitions.Add(rd);
            }

            for (int i = 0; i < row; i++)
            {
                ColumnDefinition cd = new ColumnDefinition();
                cd.Width = new GridLength(74);
                mineArea.ColumnDefinitions.Add(cd);
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Rectangle rect = new Rectangle
                    {
                        Width = 64,
                        Height = 64,
                        Fill = new SolidColorBrush(Colors.OrangeRed),
                        Margin = new Thickness(10, 10, 10, 10)
                    };

                    mineArea.Children.Add(rect);
                    Grid.SetRow(rect, i);
                    Grid.SetColumn(rect, j);
                }
            }

        }
    }
}

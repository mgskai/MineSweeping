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
        private Button[,] mineControl;

        private bool firstClick = true;

        public MainPage()
        {
            this.InitializeComponent();
            InitializeMineForm();

        }

        private void InitializeMineForm(
            int mineNum = DefaultMineNum, 
            int row = DefaultRow, 
            int column = DefaultColumn)
        {
            totalSquares = row * column;
            mineControl = new Button[row, column];

            Random rand = new Random(Guid.NewGuid().GetHashCode());


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
                    mineControl[i, j] = new Button
                    {
                        Tag = 0,
                        Name = i.ToString() +" " +  j.ToString(),
                        Width = 50, 
                        Height = 50,
                        Background = new SolidColorBrush(Colors.Red),
                        Margin = new Thickness(10, 10, 10, 10)
                    };

                    mineControl[i, j].Click += new RoutedEventHandler(MineControlClick);

                    mineArea.Children.Add(mineControl[i, j]);
                    Grid.SetRow(mineControl[i, j], i);
                    Grid.SetColumn(mineControl[i, j], j);
                }
            }
        }

        private void MineControlClick(object sender, RoutedEventArgs e)
        {
            if(firstClick)
            {
                InitializeMine();
                firstClick = false;
            }

            Button mine = sender as Button;
            int posX = 0;
            int posY = 0;

            GetMineControlPos(mine, ref posX, ref posY);
            mine.IsEnabled = false;

            if(IsMine(mine))
            {
                mine.Background = new SolidColorBrush(Colors.Black);
            }
            else
            {
                int mineNum = GetNeighborMineNum(posX, posY);
                mine.Background = new SolidColorBrush(Colors.Green);
                mine.Content = mineNum.ToString();
                
            }
        }

        private void InitializeMine()
        {

        }

        private int GetNeighborMineNum(int posX, int posY)
        {
            return 0;
        }
        
        private void GetMineControlPos(Button mine, ref int x, ref int y)
        {
            string[] pos = mine.Name.Split(' ');
            x = Convert.ToInt32(pos[0]);
            y = Convert.ToInt32(pos[1]);
        }

        private bool IsMine(Button mine)
        {
            if(Convert.ToInt32(mine.Tag) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SetMineControlState(ref Button mine, bool isMine)
        {
            if(isMine)
            {
                mine.Tag = 1;
            }
            else
            {
                mine.Tag = 0;
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;


namespace MineSweeping
{
    enum MineSquareState
    {
        Mine,
        Normal
    }

    enum MineSquareLabelState
    {
        MineLabeled,
        MineDoubted
    }

    class MineSquare :Button
    {
        private int _PositionX;
        public int PositionX
        {
            get
            {
                return _PositionX;
            }
            set
            {
                _PositionX = value;
            }
        }

        private int _PositionY;
        public int PositionY
        {
            get
            {
                return _PositionY;
            }
            set
            {
                _PositionY = value;
            }
        }

        private int _MaxPositionX;
        public int MaxPositionX
        {
            get
            {
                return _MaxPositionX;
            }
            set
            {
                _MaxPositionX = value;
            }
        }

        private int _MaxPositionY;
        public int MaxPositionY
        {
            get
            {
                return _MaxPositionY;
            }
            set
            {
                _MaxPositionY = value;
            }
        }

    }
}

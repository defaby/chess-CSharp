using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace фывфыв
{
    public class Ladia : defolt
    {
        public bool ReturnTrueAndSwap(int X, int Y, ref string[,] mass)
        {
            mass[X, Y] = mass[X, Y].Replace("L", "Ĺ");
            return true;
        }

        public override bool canMove(int X, int Y, int moveX, int moveY, ref string[,] mass)
        {
            if (LeaveBoard(moveY, moveX))
            {
                if (Y == moveY)
                {
                    if (longWolkX(X, moveX, Y, mass))
                        return ReturnTrueAndSwap(X, Y, ref mass);
                }
                if (X == moveX)
                {
                    if (longWolkY(Y, moveY, X, mass))
                        return ReturnTrueAndSwap(X, Y, ref mass);
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}

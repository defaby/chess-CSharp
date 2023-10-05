using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace фывфыв
{
    public class ferz : defolt
    {
        public override bool canMove(int X, int Y, int moveX, int moveY, ref string[,] mass)
        {
            if (LeaveBoard(moveY, moveX))
            {
                if (Math.Abs(X - moveX) == Math.Abs(Y - moveY) && DiagonalWolk(X, Y, moveX, moveY, mass))
                {
                    return true;
                }
                if (Y == moveY)
                {
                    if (!longWolkX(X, moveX, Y, mass))
                        Console.WriteLine("препядствие по пути X");
                    else
                        return true;
                }
                if (X == moveX)
                {
                    if (longWolkY(Y, moveY, X, mass))
                        return true;
                    else
                    {
                        Console.WriteLine("препядствие по пути Y");
                        return false;
                    }
                }
            }


            return false;
        }
    }
}

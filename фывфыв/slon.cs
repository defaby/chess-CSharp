using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace фывфыв
{
    public class slon : defolt
    {
        public override bool canMove(int X, int Y, int moveX, int moveY, ref string[,] mass)
        {
            if (LeaveBoard(moveY, moveX))
            {
                if (Math.Abs(X - moveX) == Math.Abs(Y - moveY))
                {
                    if (DiagonalWolk(X, Y, moveX, moveY, mass))
                        return true;
                }
            }

            return false;
        }
    }
}

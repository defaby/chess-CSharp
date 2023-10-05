using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace фывфыв
{
    public class horse : defolt
    {

        public override bool canMove(int X, int Y, int moveX, int moveY, ref string[,] mass)
        {
            if (LeaveBoard(moveY, moveX))
            {
                if (Math.Abs(X - moveX) == 1 && Math.Abs(Y - moveY) == 2)
                {
                    return true;
                }
                if (Math.Abs(Y - moveY) == 1 && Math.Abs(X - moveX) == 2)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

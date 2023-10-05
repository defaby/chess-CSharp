using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace фывфыв
{
    public class peshka : defolt
    {
        public override bool canMove(int X, int Y, int moveX, int moveY, ref string[,] mass)
        {
            if (LeaveBoard(moveY, moveX))
            {
                if ((X < moveX && mass[X, Y][0] == '[') || (X > moveX && mass[X, Y][0] == '('))
                {
                    return false;
                }
                if (Math.Abs(X - moveX) == 2 && moveY == Y && mass[X, Y][1] == 'P' && (mass[moveX, moveY] == "{ }"))
                {
                    mass[X, Y] = mass[X, Y].Replace('P', 'Ρ');
                    return true;
                }
                if (Math.Abs(X - moveX) == 1 && moveY == Y && (mass[moveX, moveY] == "{ }"))
                {
                    mass[X, Y] = mass[X, Y].Replace('P', 'Р');
                    return true;
                }
                if (mass[moveX, moveY] != "{ }" && Math.Abs(X - moveX) == 1 && Math.Abs(Y - moveY) == 1)
                {
                    mass[X, Y] = mass[X, Y].Replace('P', 'Р');
                    return true;
                }
                if (mass[moveX, moveY] == "{ }" && Math.Abs(X - moveX) == 1 && Math.Abs(Y - moveY) == 1 && mass[X, moveY][1] == 'Ρ')
                {
                    mass[X, Y] = mass[X, Y].Replace('P', 'Р');
                    mass[X, moveY] = "{ }";
                    return true;
                }
                else
                {

                }
            }
            return false;
        }
    }
}

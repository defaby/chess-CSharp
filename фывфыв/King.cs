using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace фывфыв
{
    public class King : defolt
    {
        public override bool canMove(int X, int Y, int moveX, int moveY, ref string[,] mass)
        {
            if (moveY == Y && moveX == X)
                return false;


            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (mass[moveX + i, moveY + j] != null)
                    {
                        if ((mass[moveX + i, moveY + j][1] == 'K') || (mass[moveX + i, moveY + j][1] == 'К'))
                        {
                            if (Y != moveY + j && X != moveX + i)
                            {
                                return false;
                            }
                        }
                    }
                }
            }


            int KingX = 0;
            int KingY = 0;
            char AnamuColor;
            var figure = new defolt();

            KingY = X; KingX = Y;

            if (mass[X, Y][0] == '[') AnamuColor = '('; else AnamuColor = '[';

            for (int x = 1; x < 9; x++)
            {
                for (int y = 1; y < 9; y++)
                {
                    if (mass[x, y][1] != 'К' && mass[x, y][1] != 'K' && mass[x, y] != "{ }" && mass[x, y][0] == AnamuColor)
                    {
                        string Anamy = mass[x, y];
                        Console.WriteLine(mass[x, y]);
                        switch (mass[x, y][1])
                        {
                            case 'S':
                                figure = new slon();
                                break;
                            case 'H':
                                figure = new horse();
                                break;
                            case 'Р':
                                figure = new peshka();
                                break;
                            case 'P':
                                figure = new peshka();
                                break;
                            case 'Ρ':
                                figure = new peshka();
                                break;
                            case 'F':
                                figure = new ferz();
                                break;
                            case 'L':
                                figure = new Ladia();
                                break;
                            case 'Ĺ':
                                figure = new Ladia();
                                break;
                            default: break;
                        }
                        if (figure.canMove(x, y, moveX, moveY, ref mass))
                        {

                            return false;
                        }
                    }
                }
            }

            bool nowPath = false;
            {
                char color1 = mass[X, Y][0];
                int KingX1 = X;
                int KingY1 = Y;
                var figure1 = new defolt();

                for (int nn = 1; nn < 9; nn++)
                {
                    for (int mm = 1; mm < 9; mm++)
                    {
                        if (mass[nn, mm][1] != 'К' && mass[nn, mm][1] != 'K' && mass[nn, mm] != "{ }" && mass[nn, mm][0] == AnamuColor)
                        {
                            switch (mass[nn, mm][1])
                            {
                                case 'S':
                                    figure = new slon();
                                    break;
                                case 'H':
                                    figure = new horse();
                                    break;
                                case 'Р':
                                    figure = new peshka();
                                    break;
                                case 'P':
                                    figure = new peshka();
                                    break;
                                case 'Ρ':
                                    figure = new peshka();
                                    break;
                                case 'F':
                                    figure = new ferz();
                                    break;
                                case 'L':
                                    figure = new Ladia();
                                    break;
                                case 'Ĺ':
                                    figure = new Ladia();
                                    break;
                                case 'K':
                                    figure = new King();
                                    break;
                                case 'К':
                                    figure = new King();
                                    break;
                            }
                            if (figure.canMove(nn, mm, KingX1, KingY1, ref mass))
                            {
                                Console.WriteLine("МАТУЮТ КОРОЛЯ НА  " + KingX1 + " " + KingY1);
                                Console.WriteLine("ВНИМАНИЕ МАТ " + nn + " " + mm);
                                nowPath = false;
                            }//тут ШАХ
                        }
                    }
                }
                nowPath = true;//ТУТ НЕ ШАХ
            }



            if (nowPath)
            {

                if (Y == 5 && mass[X, Y][1] == 'K' && AreYouFrendly(mass[X, Y], mass[X, Y - 4]) && mass[X, Y - 1] == "{ }" && mass[X, Y - 4][1] == 'L' && moveY == 3 && moveX == X) //Длинная рокировка 
                {
                    Console.WriteLine("произошла Длинная рокировка");

                    mass[X, Y - 1] = mass[X, Y][0] + "Ĺ" + mass[X, Y][2];
                    mass[X, Y - 4] = "{ }";
                    return true;
                }
                if (Y == 5 && AreYouFrendly(mass[X, Y], mass[X, Y + 3]) && mass[X, Y][1] == 'K' && mass[X, Y + 1] == "{ }" && mass[X, Y + 3][1] == 'L' && moveY == 7 && moveX == X) //Короткая рокировка 
                {
                    Console.WriteLine("произошла Короткая рокировка");
                    mass[X, Y + 1] = mass[X, Y][0] + "Ĺ" + mass[X, Y][2];

                    mass[X, Y + 3] = "{ }";
                    return true;
                }

            }

            if (LeaveBoard(moveY, moveX))
            {
                if ((Math.Abs(moveY - Y) < 2) && (Math.Abs(moveX - X) < 2))
                {
                    mass[X, Y] = mass[X, Y].Replace("K", "К");
                    return true;
                }
            }
            return false;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System;
using фывфыв;

internal class Program
{
    private static void Main(string[] args)
    {
        bool VBARg_HAndler(bool arg0, bool arg1, bool arg2, bool arg3)
        {
            if (arg0)
            {
                return true;
            }
            else if (arg1 && !arg2 && !arg3)
            {
                return true;
            }
            else if (!arg1 && arg2 && !arg3)
            {
                return true;
            }
            else if (!arg1 && !arg2 && arg3)
            {
                return true;
            }
            return false;
        }

        bool examinationShaHH(string[,] mass, char color)
        {
            int KingX = 0;
            int KingY = 0;
            char AnamuColor;
            if (color == '[') AnamuColor = '('; else AnamuColor = '[';
            var figure = new defolt();

            for (int x = 1; x < 9; x++)
            {
                for (int y = 1; y < 9; y++)
                {
                    if (mass[x, y][1] == 'K' || mass[x, y][1] == 'К')
                    {
                        if (mass[x, y][0] == color)
                        {
                            KingY = y; KingX = x; Console.WriteLine("король стоит на " + x + " " + y); ; break;
                        }
                    }
                }
            }
            if (KingX == 0 && KingY == 0) { Console.WriteLine("КОРОЛЬ НЕ НАЙДЕН"); return false; }


            for (int x = 1; x < 9; x++)
            {
                for (int y = 1; y < 9; y++)
                {
                    if (mass[x, y][1] != 'К' && mass[x, y][1] != 'K' && mass[x, y] != "{ }" && mass[x, y][0] == AnamuColor)
                    {
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
                            case 'K':
                                figure = new King();
                                break;
                            case 'К':
                                figure = new King();
                                break;
                        }
                        if (figure.canMove(x, y, KingX, KingY, ref mass))
                        {
                            Console.WriteLine("МАТУЮТ КОРОЛЯ НА  " + KingX + " " + KingY);
                            Console.WriteLine("ВНИМАНИЕ МАТ " + x + " " + y);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        bool examinationMATT(string[,] mass, char color)
        {
            int KingX = 0;
            int KingY = 0;
            var figure = new King();

            for (int x = 1; x < 9; x++)
            {
                for (int y = 1; y < 9; y++)
                {
                    if (mass[x, y][1] == 'K' || mass[x, y][1] == 'К')
                    {
                        if (mass[x, y][0] == color)
                        {
                            KingY = y; KingX = x; break;
                        }
                    }
                }
            }

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (KingX + x <= 8 && KingY + y <= 8 && KingX + x > 0 && KingY + y > 0)
                    {
                        if (figure.canMove(KingX, KingY, KingX + x, KingY + y, ref mass))
                        {
                            Console.WriteLine("немат   можно идти на", KingX + x, KingY + y);
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        bool examinationPATTT(string[,] mass, char color)
        {
            var figure = new defolt();

            string[,] delMass = mass.Clone() as string[,];

            for (int x = 1; x < 9; x++)
            {
                for (int y = 1; y < 9; y++)
                {
                    if (mass[x, y][0] == color)
                    {
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
                            case 'K':
                                figure = new King();
                                break;
                            case 'К':
                                figure = new King();
                                break;
                        }
                        for (int Xmove = 1; Xmove < 9; Xmove++)
                        {
                            for (int Ymove = 1; Ymove < 9; Ymove++)
                            {
                                delMass = mass.Clone() as string[,];
                                if (delMass == null)
                                {
                                    continue;
                                }
                                if (figure.canMove(x, y, Xmove, Ymove, ref delMass))
                                {
                                    Console.WriteLine(mass[x, y] + "может идти на " + Xmove + " " + Ymove + " Т.Е  пата нет");
                                    Console.Clear();
                                    return true;
                                }

                                else
                                    Console.WriteLine("идти на " + Xmove + " " + Ymove + " нельзя");
                            }
                        }
                    }
                }
            }

            Console.Clear();
            Console.WriteLine("данный ход ПАТ");
            return false;
        }

        void inFig(char color, ref int WhiteCounter, ref int BlackCounter)
        {
            if (color == '[')
                BlackCounter++;
            else
                WhiteCounter++;
        }

        bool MassPrin(string[,] mass)
        {

            string Svodka = "";
            char Color = ' ';

            int BlackFig = 0;
            int WhiteFig = 0;

            int BlackSlon0 = 0;
            int WhiteSlon0 = 0;

            int BlackSlon1 = 0;
            int WhiteSlon1 = 0;

            int BlackHorse = 0;
            int WhiteHorse = 0;


            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (mass[i, j][0] == '[')
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(mass[i, j]);
                        Console.ResetColor();
                    }
                    else if (mass[i, j][0] == '(')
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.Write(mass[i, j]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(mass[i, j]);
                    }


                    if (mass[i, j] != "{ }" && i != 0 && j != 0)
                    {
                        Color = mass[i, j][0];
                        if (Color == '[')
                            Svodka += "черный";
                        else
                            Svodka += "белый";


                        switch (mass[i, j][1])
                        {
                            case 'S':
                                if ((i + j) % 2 == 0)
                                    inFig(Color, ref WhiteSlon0, ref BlackSlon0);
                                else
                                    inFig(Color, ref WhiteSlon1, ref BlackSlon1);

                                Svodka += " слон";
                                break;
                            case 'H':
                                inFig(Color, ref WhiteHorse, ref BlackHorse);
                                Svodka += " конь";
                                break;
                            case 'P':
                                inFig(Color, ref WhiteFig, ref BlackFig);
                                Svodka += " пешка";
                                break;
                            case 'Р':
                                inFig(Color, ref WhiteFig, ref BlackFig);
                                Svodka += " пешка";
                                break;
                            case 'Ρ':
                                inFig(Color, ref WhiteFig, ref BlackFig);
                                Svodka += " пешка";
                                break;
                            case 'F':
                                inFig(Color, ref WhiteFig, ref BlackFig);
                                Svodka += " ферзь";
                                break;
                            case 'L':
                                inFig(Color, ref WhiteFig, ref BlackFig);
                                Svodka += " Ладья";
                                break;
                            case 'Ĺ':
                                inFig(Color, ref WhiteFig, ref BlackFig);
                                Svodka += " Ладья";
                                break;
                            case 'K':
                                Svodka += " король";
                                break;
                            case 'К':
                                Svodka += " король";
                                break;
                        }
                    }


                }
                Console.WriteLine();
            }

            if (WhiteFig == 0 && BlackFig == 0)
            {
                bool Barg0 = BlackHorse == 0 && BlackSlon0 == 0 && BlackSlon1 == 0;
                bool Barg1 = BlackHorse == 1;
                bool Barg2 = BlackSlon0 <= 4 && BlackSlon0 > 0 && BlackSlon1 == 0;
                bool Barg3 = BlackSlon1 <= 4 && BlackSlon1 > 0 && BlackSlon0 == 0;


                bool Warg0 = WhiteHorse == 0 && WhiteSlon0 == 0 && WhiteSlon1 == 0;
                bool Warg1 = WhiteHorse == 1;
                bool Warg2 = WhiteSlon0 <= 4 && WhiteSlon0 > 0 && WhiteSlon1 == 0;//
                bool Warg3 = WhiteSlon1 <= 4 && WhiteSlon1 > 0 && WhiteSlon0 == 0;//


                if (VBARg_HAndler(Barg0, Barg1, Barg2, Barg3) && VBARg_HAndler(Warg0, Warg1, Warg2, Warg3))
                {
                    return true;
                }
            }



            return false;
        }


        Console.OutputEncoding = System.Text.Encoding.Unicode;
        string[,] mass = new string[20, 20];
        mass[0, 0] = "   ";
        for (int i = 1; i < 9; i++)
        {
            mass[0, i] = mass[i, 0] = " " + Convert.ToString(i) + " ";
            for (int j = 1; j < 9; j++)
            {
                mass[i, j] = "{ }";
            }
        }

        mass[7, 1] = "[P]";
        mass[7, 2] = "[P]";
        mass[7, 3] = "[P]";
        mass[7, 4] = "[P]";
        mass[7, 5] = "[P]";
        mass[7, 6] = "[P]";
        mass[7, 7] = "[P]";
        mass[7, 8] = "[P]";
        mass[8, 5] = "[K]";
        mass[1, 5] = "(K)";
        mass[2, 1] = "(P)";
        mass[2, 2] = "(P)";
        mass[2, 3] = "(P)";
        mass[2, 4] = "(P)";
        mass[2, 5] = "(P)";
        mass[2, 6] = "(P)";
        mass[2, 7] = "(P)";
        mass[2, 8] = "(P)";
        mass[1, 1] = "(L)";
        mass[1, 8] = "(L)";
        mass[8, 1] = "[L]";
        mass[8, 8] = "[L]";
        mass[1, 2] = "(H)";
        mass[1, 7] = "(H)";
        mass[8, 2] = "[H]";
        mass[8, 7] = "[H]";
        mass[1, 3] = "(S)";
        mass[1, 6] = "(S)";
        mass[8, 3] = "[S]";
        mass[8, 6] = "[S]";
        mass[1, 4] = "(F)";
        mass[8, 4] = "[F]";




        int x; int y; int moovX; int moovY; var figure = new defolt();
        char whoIsNext = '[';

        while (true)
        {

            if (examinationShaHH(mass, whoIsNext))
            {
                MassPrin(mass);
                if (examinationMATT(mass, whoIsNext))
                {
                    MassPrin(mass);
                    Console.WriteLine("ШАХ И МАТ");
                    break;
                }
            }
            else if (examinationPATTT(mass, '[') && examinationPATTT(mass, '('))
            {

                if (MassPrin(mass))
                {
                    Console.WriteLine("НИЧЬЯ Невозможно поставить мат");
                    break;
                }
            }
            else
            {
                Console.WriteLine("ничья из за пата");
                MassPrin(mass);
                break;
            }

            Console.WriteLine("сейчас ход " + whoIsNext);



            {
                Console.WriteLine("выберите фигуру X");
                if (int.TryParse(Console.ReadLine(), out y))
                {
                    Console.WriteLine("выберите фигуру Y");
                    if (!int.TryParse(Console.ReadLine(), out x) || !(0 < x && x < 9 && 0 < y && y < 9))
                        continue;
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
                        case 'K':
                            figure = new King();
                            break;
                        case 'К':
                            figure = new King();
                            break;
                        case ' ':
                            Console.WriteLine("тут пусто");
                            continue;
                    }
                    if (mass[x, y][0] != whoIsNext)
                    {
                        Console.WriteLine("сейчас не ваш ход");
                        continue;
                    }
                }
                else
                    continue;

            }


            {
                Console.WriteLine("выберите ход X");
                if (!int.TryParse(Console.ReadLine(), out moovY))
                    continue;
                Console.WriteLine("выберите ход Y");
                if (!int.TryParse(Console.ReadLine(), out moovX))
                    continue;
                if (!(0 < moovX && moovX < 9 && 0 < moovY && moovY < 9))
                    continue;
            }

            Console.Clear();
            if (figure.canMove(x, y, moovX, moovY, ref mass))
            {
                if (mass[moovX, moovY] == "{ }")
                {
                    mass[moovX, moovY] = mass[x, y];
                    mass[x, y] = "{ }";
                }
                else
                {

                    if (mass[x, y][0] != mass[moovX, moovY][0])
                    {
                        Console.WriteLine(mass[x, y] + " срубает " + mass[moovX, moovY]);
                        mass[moovX, moovY] = mass[x, y];
                        mass[x, y] = "{ }";
                    }
                    else
                    {
                        Console.WriteLine("нельзя рубить своих");
                        continue;
                    }
                }
                if ((mass[moovX, moovY][1] == 'P' || mass[moovX, moovY][1] == 'Р') && (moovX == 8 || moovX == 1))
                {
                    Console.WriteLine("Пешка Эволюционирует Выберите {H} {F} {L} {S}");
                    while (mass[moovX, moovY][1] == 'P' || mass[moovX, moovY][1] == 'Р')
                    {
                        switch (Console.ReadLine())
                        {
                            case "H":
                                mass[moovX, moovY] = mass[moovX, moovY].Replace("Р", "H");
                                mass[moovX, moovY] = mass[moovX, moovY].Replace("P", "H");
                                mass[moovX, moovY] = mass[moovX, moovY].Replace("Ρ", "H");
                                break;
                            case "F":
                                mass[moovX, moovY] = mass[moovX, moovY].Replace("Р", "F");
                                mass[moovX, moovY] = mass[moovX, moovY].Replace("P", "F");
                                mass[moovX, moovY] = mass[moovX, moovY].Replace("Ρ", "F");
                                break;
                            case "L":
                                mass[moovX, moovY] = mass[moovX, moovY].Replace("Р", "Ĺ");
                                mass[moovX, moovY] = mass[moovX, moovY].Replace("P", "Ĺ");
                                mass[moovX, moovY] = mass[moovX, moovY].Replace("Ρ", "Ĺ");
                                break;
                            case "S":
                                mass[moovX, moovY] = mass[moovX, moovY].Replace("Р", "S");
                                mass[moovX, moovY] = mass[moovX, moovY].Replace("P", "S");
                                mass[moovX, moovY] = mass[moovX, moovY].Replace("Ρ", "S");
                                break;
                            default:
                                Console.WriteLine("повторите");
                                continue;
                        }
                    }
                }

                if (whoIsNext == '[')
                    whoIsNext = '(';
                else
                    whoIsNext = '[';


                if (whoIsNext == '[')
                {
                    for (int i = 1; i < 9; i++)
                    {
                        for (int j = 1; j < 9; j++)
                        {
                            if (mass[i, j] == "[Ρ]")
                            {
                                mass[i, j] = "[Р]";
                                break;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 1; i < 9; i++)
                    {
                        for (int j = 1; j < 9; j++)
                        {
                            if (mass[i, j] == "(Ρ)")
                            {
                                mass[i, j] = "(Р)";
                                break;
                            }
                        }
                    }
                }


            }
            else
            {
            }




        }
    }
}

public class defolt
{

    public bool LeaveBoard(int moveY, int moveX)
    {
        return ((0 < moveY && moveY < 9) && (0 < moveX && moveX < 9));
    }
    public bool longWolkX(int x, int moveX, int y, string[,] mass)
    {
        if (x == moveX)
            return false;

        if (x > moveX)
        {
            for (int i = x - 1; i > moveX; i--)
            {
                if (mass[i, y] != "{ }")
                {
                    Console.WriteLine(mass[i, y] + " препятствие перед целью");
                    return false;
                }
            }
        }
        else
        {
            for (int i = x + 1; i < moveX; i++)
            {
                if (mass[i, y] != "{ }")
                {
                    Console.WriteLine(mass[i, y] + " препятствие перед целью");
                    return false;
                }

            }
        }
        return true;
    }
    public bool longWolkY(int y, int moveY, int x, string[,] mass)
    {

        if (y == moveY)
            return false;

        if (y > moveY)
        {
            for (int i = y - 1; i > moveY; i--)
            {
                if (mass[x, i] != "{ }")
                {
                    Console.WriteLine(mass[x, i] + " препятствие перед целью");
                    return false;
                }
            }
        }
        else
        {
            for (int i = y + 1; i < moveY; i++)
            {
                if (mass[x, i] != "{ }")
                {
                    Console.WriteLine(mass[x, i] + " препятствие перед целью");
                    return false;
                }

            }
        }
        return true;
    }
    public virtual bool canMove(int X, int Y, int moveX, int moveY, ref string[,] mass)
    {
        return false;
    }
    public bool AreYouFrendly(string FirstFigur, string SecondFigur)
    {
        if (SecondFigur != null)
            return FirstFigur[0] == SecondFigur[0];
        else return false;

    }
    public bool DiagonalWolk(int x, int y, int moveX, int moveY, string[,] mass)
    {
        if (x > moveX)
        {
            if (y > moveY)
            {
                Console.WriteLine("идем в левый вверх");
                for (int i = 1; x - i > moveX; i++)
                {
                    if (mass[x - i, y - i] != "{ }")
                    {
                        Console.WriteLine("проход закрыт " + mass[x - i, y - i]);
                        return false;
                    }
                }
            }
            else
            {
                Console.WriteLine("идем в правый вверх");
                for (int i = 1; x - i > moveX; i++)
                {
                    if (mass[x - i, y + i] != "{ }")
                    {
                        Console.WriteLine("проход закрыт " + mass[x - i, y + i]);
                        return false;
                    }
                }
            }
        }
        else
        {
            if (y > moveY)
            {
                Console.WriteLine("идем в левый низ");
                for (int i = 1; x + i < moveX; i++)
                {
                    if (mass[x + i, y - i] != "{ }")
                    {
                        Console.WriteLine("проход закрыт " + mass[x + i, y - i]);
                        return false;
                    }
                }
            }
            else
            {
                Console.WriteLine("идем в правый низ");
                for (int i = 1; x + i < moveX; i++)
                {
                    if (mass[x + i, y + i] != "{ }")
                    {
                        Console.WriteLine("проход закрыт " + mass[x + i, y + i]);
                        return false;
                    }
                }
            }
        }


        return true;
    }

}
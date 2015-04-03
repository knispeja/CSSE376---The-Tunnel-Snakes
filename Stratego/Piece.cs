﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 0 - Blank
 * 1-9 Normal Peieces
 * 10 - Spy
 * 11 - Bomb
 * 12 - Flag
 * NULL = place you cant move (lakes)
 */
namespace Stratego
{
    public class Piece
    {
        public static int? attack(int? first, int? second)
        {
            if (Math.Abs(first.Value) == 11 || Math.Abs(second.Value) == 11)
            {
                if (Math.Abs(first.Value) == 11)
                {
                    if (Math.Abs(second.Value) != 8)
                        return first;
                    else
                        return second;
                }
                else
                {
                    if (Math.Abs(first.Value) != 8)
                        return second;
                    else
                        return first;
                }
            }
            if (Math.Abs(first.Value) < Math.Abs(second.Value))
                return first;
            else if (Math.Abs(first.Value) > Math.Abs(second.Value))
                    return second;
            return null;
        }
    }
}

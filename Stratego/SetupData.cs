﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego
{
    [Serializable]
    public class SetupData
    {
        public Gameboard boardState { get; private set; }
        public Dictionary<String, int> placements { get; private set; } //TODO: this will make serialization fail
        public int turn { get; private set; }

        public SetupData(Gameboard boardState, Dictionary<String, int> placements, int turn)
        {
            this.boardState = boardState;
            this.placements = placements;
            this.turn = turn;
        }
    }
}
﻿using System;
using Stratego;
using NUnit.Framework;

namespace StrategoTest
{
    [TestFixture()]
    public class PieceTest
    {
        //Marshal = 1, General = 2, Colonel = 3, Major = 4, Captain = 5, Lieutenant = 6, Sergeant = 7, Miner = 8, Cout = 9, Spy = 10, Bomb = 11, Flag = 12;
        [TestCase(1, -2, Result = 1)] //Tests for regular cases where lowest absolute
        [TestCase(-4, 7, Result = -4)] //value wins
        [TestCase(9, -5, Result = -5)]
        [TestCase(1, -10, Result = 1)]
        [TestCase(8, -12, Result = 8)]
        [TestCase(1, -2, Result = 1)]
        [TestCase(1, -3, Result = 1)]
        [TestCase(1, -4, Result = 1)]
        [TestCase(1, -5, Result = 1)]
        [TestCase(1, -6, Result = 1)]
        [TestCase(1, -7, Result = 1)]
        [TestCase(1, -8, Result = 1)]
        [TestCase(1, -9, Result = 1)]
        [TestCase(1, -10, Result = 1)]
        [TestCase(1, -12, Result = 1)]
        [TestCase(2, -1, Result = -1)]
        [TestCase(2, -2, Result = 0)]
        [TestCase(2, -3, Result = 2)]
        [TestCase(2, -4, Result = 2)]
        [TestCase(2, -5, Result = 2)]
        [TestCase(2, -6, Result = 2)]
        [TestCase(2, -7, Result = 2)]
        [TestCase(2, -8, Result = 2)]
        [TestCase(2, -9, Result = 2)]
        [TestCase(2, -10, Result = 2)]
        [TestCase(2, -12, Result = 2)]
        [TestCase(3, -1, Result = -1)]
        [TestCase(3, -2, Result = -2)]
        [TestCase(3, -3, Result = 0)]
        [TestCase(3, -4, Result = 3)]
        [TestCase(3, -5, Result = 3)]
        [TestCase(3, -6, Result = 3)]
        [TestCase(3, -7, Result = 3)]
        [TestCase(3, -8, Result = 3)]
        [TestCase(3, -9, Result = 3)]
        [TestCase(3, -10, Result = 3)]
        [TestCase(3, -12, Result = 3)]
        [TestCase(8, -1, Result = -1)]
        [TestCase(8, -2, Result = -2)]
        [TestCase(8, -3, Result = -3)]
        [TestCase(8, -4, Result = -4)]
        [TestCase(8, -5, Result = -5)]
        [TestCase(8, -6, Result = -6)]
        [TestCase(8, -7, Result = -7)]
        [TestCase(8, -8, Result = 0)]
        [TestCase(8, -9, Result = 8)]
        [TestCase(8, -10, Result = 8)]
        [TestCase(8, -12, Result = 8)]
        [TestCase(-1, 2, Result = -1)]
        [TestCase(-1, 3, Result = -1)]
        [TestCase(-1, 4, Result = -1)]
        [TestCase(-1, 5, Result = -1)]
        [TestCase(-1, 6, Result = -1)]
        [TestCase(-1, 7, Result = -1)]
        [TestCase(-1, 8, Result = -1)]
        [TestCase(-1, 9, Result = -1)]
        [TestCase(-1, 10, Result = -1)]
        [TestCase(-1, 12, Result = -1)]
        [TestCase(-2, 1, Result = 1)]
        [TestCase(-2, 3, Result = -2)]
        [TestCase(-2, 4, Result = -2)]
        [TestCase(-2, 5, Result = -2)]
        [TestCase(-2, 6, Result = -2)]
        [TestCase(-2, 7, Result = -2)]
        [TestCase(-2, 8, Result = -2)]
        [TestCase(-2, 9, Result = -2)]
        [TestCase(-2, 10, Result = -2)]
        [TestCase(-2, 12, Result = -2)]
        [TestCase(-3, 1, Result = 1)]
        [TestCase(-3, 2, Result = 2)]
        [TestCase(-3, 4, Result = -3)]
        [TestCase(-3, 5, Result = -3)]
        [TestCase(-3, 6, Result = -3)]
        [TestCase(-3, 7, Result = -3)]
        [TestCase(-3, 8, Result = -3)]
        [TestCase(-3, 9, Result = -3)]
        [TestCase(-3, 10, Result = -3)]
        [TestCase(-3, 12, Result = -3)]
        [TestCase(-8, 1, Result = 1)]
        [TestCase(-8, 2, Result = 2)]
        [TestCase(-8, 3, Result = 3)]
        [TestCase(-8, 4, Result = 4)]
        [TestCase(-8, 5, Result = 5)]
        [TestCase(-8, 6, Result = 6)]
        [TestCase(-8, 7, Result = 7)]
        [TestCase(-8, 9, Result = -8)]
        [TestCase(-8, 10, Result = -8)]
        [TestCase(-8, 12, Result = -8)]

        [TestCase(-3, 3, Result = 0)] // Test tie cases
        [TestCase(-10, 10, Result = 0)]
        [TestCase(6, -6, Result = 0)]
        [TestCase(-8, 8, Result = 0)]
        [TestCase(-2, 2, Result = 0)]
        [TestCase(-1, 1, Result = 0)]
        [TestCase(1, -1, Result = 0)]

        [TestCase(-3, 11, Result = 11)] // Test that bomb beats all attackers except the miner
        [TestCase(3, -11, Result = -11)]
        [TestCase(-2, 11, Result = 11)]
        [TestCase(2, -11, Result = -11)]
        [TestCase(-1, 11, Result = 11)]
        [TestCase(1, -11, Result = -11)]

        [TestCase(8, -11, Result = 8)] // Test that bomb is beaten by miners
        [TestCase(-8, 11, Result = -8)]

        [TestCase(10, -1, Result = 10)] // Test that Spy beats marshall if it attacks
        [TestCase(-10, 1, Result = -10)]

        [TestCase(11, -11, Result = 0)] // Test that movable bombs kill one another
        [TestCase(-11, 11, Result = 0)]
        // Tests the various cases for the attack function for pieces.
        public int TestAttack(int a, int b)
        {
            return Piece.attack(a, b).Value;
        }

        [TestCase(-1,-1)]
        [TestCase(1, 1)]
        [TestCase(-4, -4)]
        [TestCase(4, 4)]
        [TestCase(8, 11)]
        [TestCase(-8, -11)]
        [TestCase(7, 3)]
        [TestCase(-7, -3)]
        [TestCase(-7, 42)]
        [TestCase(7, 42)]
        // Tests that attack returns null two pieces of the same team
        // Or if the piece being attacked is the obsticle piece (42)
        public void TestThatAttackReturnsNullOnInvalidAttack(int a, int b)
        {
            Assert.Null(Piece.attack(a, b));
        }

        [TestCase(1, Result = "Marshall")]
        [TestCase(2, Result = "General")]
        [TestCase(3, Result = "Colonel")]
        [TestCase(4, Result = "Major")]
        [TestCase(5, Result = "Captain")]
        [TestCase(6, Result = "Lieutenant")]
        [TestCase(7, Result = "Sergeant")]
        [TestCase(8, Result = "Miner")]
        [TestCase(9, Result = "Scout")]
        [TestCase(10, Result = "Spy")]
        [TestCase(11, Result = "Bomb")]
        [TestCase(12, Result = "Flag")]
        [TestCase(-4, Result = "Major")]
        [TestCase(-5, Result = "Captain")]
        [TestCase(-8, Result = "Miner")]
        // Tests that toString() method in Piece will convert integers to the appropriate 
        // name for that piece.
        public string TestPieceToString(int pieceNumber)
        {
            return Piece.toString(pieceNumber);
        }

        [TestCase(0)]
        [TestCase(42)]
        [TestCase(-100)]
        // Tests Piece's toString() method for invalid inputs
        public void TestToStringThrowsException(int invalidPiece)
        {
            Assert.Throws<ArgumentException>(() => Piece.toString(invalidPiece));
        }
    }
}

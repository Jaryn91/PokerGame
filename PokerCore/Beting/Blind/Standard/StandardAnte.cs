using System.Collections.Generic;

namespace PokerCore.Beting.Blind.Standard
{
    public class StandardAnte : Ante
    {
        public StandardAnte()
        {
            BlindAnte = new Dictionary<int, int>
            {
                {1, 0},
                {2, 0},
                {3, 0},
                {4, 0},
                {5, 0},
                {6, 0},
                {7, 0},
                {8, 0},
                {9, 100},
                {10, 100}
            };
        }
    }
}

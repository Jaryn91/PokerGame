using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using PokerCore.DeckOfCards;

namespace PokerCore.Dealing
{

    public interface IDealTableCards
    {
        List<Card> Deal();
    }
}

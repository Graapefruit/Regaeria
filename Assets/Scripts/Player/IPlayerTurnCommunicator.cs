using System.Collections;
using System.Collections.Generic;

// Used by players to either send/receive info about their turn over the web, or locally if they are the host
public interface IPlayerTurnCommunicator {
    public void submitTurn(string codifiedTurn);
    public void receiveTurn();
}

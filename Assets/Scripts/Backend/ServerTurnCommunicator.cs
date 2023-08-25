using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerTurnCommunicator : IPlayerTurnCommunicator {
    public TurnManager turnManager;
    private int playerId;
    
    public ServerTurnCommunicator(int playerId, TurnManager turnManager) {
        this.playerId = playerId;
        this.turnManager = turnManager;
    }
    public void submitTurn(string codifiedTurn) {
        turnManager.addPlayerTurn(playerId, codifiedTurn);
    }
    public void receiveTurn() {
        
    }
}

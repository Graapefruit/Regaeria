using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {
    private S_Tile[,] board;
    private string?[] playerTurns;
    private int remainingUnsubmittedPlayers;

    void Awake() {
        // TODO: Map loading
        // TODO: multiple players
        board = new S_Tile[16, 16];
        playerTurns = new string?[1];
        remainingUnsubmittedPlayers = 1;
    }

    public void addPlayerTurn(int _playerId, string turn) {
        int playerIndex = _playerId-1;

        if (playerTurns[playerIndex] == null) {
            remainingUnsubmittedPlayers--;
        }

        playerTurns[playerIndex] = turn;

        if (remainingUnsubmittedPlayers == 0) {
            doTurn();
            playerTurns = new string?[1];
            remainingUnsubmittedPlayers = 1;
        }
    }

    // TODO: Tiebreaks, sorting, organizing of command orders etc
    // TODO: Virtual board. In the EditorTile in Unit, also fill out their position in this board.
    public void doTurn() {
        for (int i = 0; i < GlobalDefines.INITIATIVES; i++) {

        }
        Debug.Log("Success");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Inject creation of playerTurnCommunicator?
public class Player : MonoBehaviour {
    public TurnManager turnManager;
    public UnitManager unitManager;
    private IPlayerTurnCommunicator playerTurnCommunicator;
    void Awake() {
        playerTurnCommunicator = new ServerTurnCommunicator(1, turnManager);
    }

    public void doSubmitTurn() {
        string codifiedTurn = codifyTurn();
        this.playerTurnCommunicator.submitTurn(codifiedTurn);
    }

    private string codifyTurn() {
        string codifiedTurn = "";

        foreach (Unit unit in unitManager.units) {
            for(int i = 0; i < GlobalDefines.INITIATIVES; i++) {
                codifiedTurn += string.Format("{0},{1},{2}\n", unit.id, i, getCommandSubstring(unit.submittedCommands[i]));
            }
        }

        return codifiedTurn;
    }

    private string getCommandSubstring(SubmittedCommand submittedCommand) {
        if (submittedCommand == null) {
            return GlobalDefines.NO_COMMAND_ID.ToString();
        }

        string commandSubstring = submittedCommand.command.codifiedForm;
        commandSubstring.Replace("<x>", submittedCommand.tile.index.x.ToString());
        commandSubstring.Replace("<z>", submittedCommand.tile.index.z.ToString());

        return commandSubstring;
    }
}

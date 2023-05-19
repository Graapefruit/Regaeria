using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastActionManager : MonoBehaviour {
    public int NUM_INITIATIVES = 6;
    private bool previousTurnExists;
    private int currentViewingInitiative;
    private List<ActionRecord>[] lastTurnRecords;
    // TODO:
    private UnitState turnEndState;
    private bool atTurnEnd;
    void Awake() {
        resetLastTurnRecords();
    }

    // TODO: Separate ActionRecord and UnitState (for turn end (don't need beginning, work backwards through records))
    public void resetLastTurnRecords() {
        lastTurnRecords = new List<ActionRecord>[NUM_INITIATIVES];
    }

    public void populateInitiativeActions(int initiative, List<ActionRecord> actions) {
        lastTurnRecords[initiative] = actions;
        Debug.Log(actions.Count);
    }

    public void viewPreviousInitiative() {
        if (previousTurnExists && currentViewingInitiative > 0) {
            currentViewingInitiative--;
            updateCurrentTurnViewing();
        }
        Debug.Log(currentViewingInitiative);
    }

    public void viewNextInitiative() {
        if (previousTurnExists && currentViewingInitiative < NUM_INITIATIVES) {
              currentViewingInitiative++;
              if (currentViewingInitiative == NUM_INITIATIVES) {
                  gotoTurnEnd();
              } else {
                  updateCurrentTurnViewing();
              }
        }
        Debug.Log(currentViewingInitiative);
    }

    public void gotoTurnEnd() {
        atTurnEnd = true;
    }

    public void updateCurrentTurnViewing() {
        foreach(ActionRecord actionRecord in lastTurnRecords[currentViewingInitiative]) {
            actionRecord.unit.Tile = actionRecord.tile;
        }
    }

    public void markTurnAsFinished() {
        previousTurnExists = true;
        currentViewingInitiative = 6;
    }
}

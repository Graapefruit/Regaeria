using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionList {
    private Dictionary<Tile, List<Action>> actions;
    public ActionList() {
        actions = new Dictionary<Tile, List<Action>>();
    }
    public void addAction(Action action) {
        if (!actions.ContainsKey(action.dest)) {
            actions[action.dest] = new List<Action>();
        }
        actions[action.dest].Add(action);
    }
    public List<ActionRecord> doActions() {
        // TODO
        List<ActionRecord> actionRecords = new List<ActionRecord>();
        foreach(KeyValuePair<Tile, List<Action>> actionsPerDestination in actions) {
            Action action = actionsPerDestination.Value[0];
            ActionRecord actionRecord = action.doAction();
            actionRecords.Add(actionRecord);
        }
        return actionRecords;
    }
}

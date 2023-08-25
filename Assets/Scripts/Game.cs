using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    public GameObject player;
    public GameObject board;
    public TurnManager turnManager;
    public IntReference turn;
    public GameEvent nextTurnEvent;
    public readonly bool isServer = true;

    void Awake() {
        turn.set(1);
    }

    void Start() {

    }

    public void onGo() {
        
    }
}

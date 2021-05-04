using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject tilePrefab;
    public GameObject playerPrefab;
    private Board board;
    private GameObject player;
    void Awake() {
        Reference<UnitStatBlock> selectedUnit = new Reference<UnitStatBlock>();
        board = new Board(tilePrefab, selectedUnit);
        player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        player.GetComponent<PlayerController>().board = board;
        player.transform.Find("PlayerUI").GetComponent<PlayerUI>().selectedUnit = selectedUnit;
    }

    // Update is called once per frame
    void Update() {
    }
}

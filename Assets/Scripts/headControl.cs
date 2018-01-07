using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headControl : MonoBehaviour {
    public GameObject GameLogic;
    public GameObject Player;
    private GameLogic _Logic;
    private holdPiece _PieceHolder;

    private float speed = 5.0f;
	// Use this for initialization
	void Start () {
        _Logic = GameLogic.GetComponent<GameLogic>();
        _PieceHolder = GameLogic.GetComponent<holdPiece>();
    }
	
	// Update is called once per frame
	void Update () {
        if(_Logic.playerTurn == true) {
            if (_PieceHolder.holdingPiece == true) {
                Vector3 dir = _PieceHolder.pieceBeingHeld.transform.position - transform.position;
                Quaternion rot = Quaternion.LookRotation(-dir);
                // slerp to the desired rotation over time
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, speed * Time.deltaTime);
            }
        } else {
            Vector3 dir = Player.transform.position - transform.position;
            dir.y = 0; // keep the direction strictly horizontal
            Quaternion rot = Quaternion.LookRotation(-dir);
            // slerp to the desired rotation over time
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, speed * Time.deltaTime);
        }
        
	}
}

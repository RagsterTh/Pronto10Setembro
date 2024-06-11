using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class TouchScreen : MonoBehaviour
{
    Vector2 initialPos;
    BoxCollider2D collision;
    PlayerMove playerMove;
    // Start is called before the first frame update
    void Start()
    {
        collision = GetComponent<BoxCollider2D>();
        GameController.instance.OnGamePhaseChanged += SetTouchScreen;
        playerMove = GameController.instance.playerMove;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
       initialPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void OnMouseUp()
    {
        playerMove.Play(initialPos, Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
    void SetTouchScreen(GamePhases phase)
    {
        switch (phase) 
        {
            case GamePhases.Play:
                collision.enabled = true;
                break;
                case GamePhases.BallMoving: 
                collision.enabled = false;
                break;
        }
    }
}

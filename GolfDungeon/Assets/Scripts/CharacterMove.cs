using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;

public class CharacterMove : MonoBehaviour
{
    Transform ballPos;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        GameController.instance.OnGamePhaseChanged += SetCharacter;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        ballPos = GameController.instance.playerMove.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetCharacter(GamePhases phase)
    {
        switch (phase)
        {
            case GamePhases.Play:

                break;
            case GamePhases.BallMoving:
                
                break;
            case GamePhases.WalkingToBall:
                agent.SetDestination(ballPos.position);
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GameController.instance.gamePhase.Equals(GamePhases.WalkingToBall))
        {
            GameController.instance.SetGamePhase(GamePhases.Play);
        }
    }
}

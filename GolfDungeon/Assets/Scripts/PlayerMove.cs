using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speedModifier = 10;
    float speed;
    Rigidbody2D body;
    Vector2 initiaPos;
    bool isMoving;
    GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        character = transform.GetChild(0).gameObject;
        GameController.instance.OnMouseDrag.AddListener(delegate
        {
            if (character.activeSelf)
            {
                character.transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
        });
        GameController.instance.OnGamePhaseChanged += SetCharacter;
    }

    // Update is called once per frame
    void Update()
    {
        speed = body.velocity.magnitude;
        if (speed < 0.5f && isMoving)
        {
            body.velocity = new Vector3(0, 0, 0);
            GameController.instance.SetGamePhase(GamePhases.Play);
            isMoving = false;
        }
    }
    
    public void Play(Vector2 initialPos, Vector2 finalPos)
    {
        GameController.instance.SetGamePhase(GamePhases.BallMoving);
        body.AddForce((initiaPos - finalPos) * Vector2.Distance(initiaPos, finalPos * speedModifier));
        StartCoroutine(Played());
    }
    IEnumerator Played()
    {
        yield return new WaitForSeconds(1);
        isMoving = true;
    }
    void SetCharacter(GamePhases phase)
    {
        switch (phase)
        {
            case GamePhases.Play:
                character.SetActive(true);
                break;
            case GamePhases.BallMoving:
                character.SetActive(false);
                break;
        }
    }
}

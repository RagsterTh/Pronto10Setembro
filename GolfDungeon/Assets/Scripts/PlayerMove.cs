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
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = body.velocity.magnitude;
        if (speed < 0.5f && isMoving)
        {
            body.velocity = new Vector3(0, 0, 0);
            GameController.instance.SetGamePhase(GamePhases.WalkingToBall);
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(body.velocity.magnitude > 15)
        {
            print("QUEBROU TUDO");
        }
    }
}

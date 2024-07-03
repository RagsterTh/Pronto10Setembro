using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hole : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D rigidbody = collision.GetComponent<Rigidbody2D>();
            if (rigidbody.velocity.magnitude < 3)
                StartCoroutine(BallEntering(collision.transform));
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D rigidbody = collision.GetComponent<Rigidbody2D>();
            print("rolou");
            if (rigidbody.velocity.magnitude < 1)
                rigidbody.velocity = Vector2.zero;
        }
    }
    IEnumerator BallEntering(Transform playerScale)
    {
        Rigidbody2D ballBody = playerScale.GetComponent<Rigidbody2D>();
        ballBody.velocity = Vector3.Lerp(ballBody.velocity, Vector2.zero, 0.7f);
        while (playerScale.localScale.x > 0) 
        {
            yield return new WaitForSeconds(0.2f);

            playerScale.localScale -= new Vector3(0.1f, 0.1f);
        }
        playerScale.gameObject.SetActive(false);
    }
}

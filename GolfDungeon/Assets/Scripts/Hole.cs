using System.Collections;
using System.Collections.Generic;
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
    IEnumerator BallEntering(Transform playerScale)
    {
        Rigidbody2D ballBody = playerScale.GetComponent<Rigidbody2D>();
        while (playerScale.localScale.x > 0) 
        {
            yield return new WaitForSeconds(0.2f);
            ballBody.velocity -= new Vector2(1.5f, 1.5f);
            playerScale.localScale -= new Vector3(0.1f, 0.1f);
        }
        playerScale.gameObject.SetActive(false);
    }
}

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
            if(rigidbody.velocity.magnitude < 3)
                collision.gameObject.SetActive(false);
        }
    }
}

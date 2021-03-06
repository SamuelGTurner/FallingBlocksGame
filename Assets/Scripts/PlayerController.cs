using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 7;
    public event System.Action OnPlayerDeath;
    float screenHalfWidthinWorldUnits;
    

    // Start is called before the first frame update
    void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidthinWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);
        
        if (transform.position.x < -screenHalfWidthinWorldUnits) {
            transform.position = new Vector2(screenHalfWidthinWorldUnits, transform.position.y);
        }
        if (transform.position.x > screenHalfWidthinWorldUnits) {
            transform.position = new Vector2(-screenHalfWidthinWorldUnits, transform.position.y);
        }
    }


    void OnTriggerEnter2D(Collider2D triggerCollider) {
        if (triggerCollider.tag == "Falling Block") {
            if (OnPlayerDeath != null) {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }
    }


}

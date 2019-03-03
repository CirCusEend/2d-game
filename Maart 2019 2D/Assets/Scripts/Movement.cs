using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float movementSpeed = 10;
    public float upForce = 10;
    private bool isGrounded = false;
    public int health = 10;
    public int obstacleDamage = 10;
    public float rayCastLenght = 10;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Debug.Log(health);
        MovePlayer();
        Jump();
        
    }

    private void Jump() {
        Vector2 jumpForce = new Vector2(0, upForce);
        if (Input.GetKeyDown(KeyCode.W) && isGrounded == true)
        {
            rb.AddForce(jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground") {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground") {
            isGrounded = false;
        }
    } 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle") {
            health = health - 1000000;
        }

        if (health <= 0)
        {
            Defeat("Main");
        }
    }

    private void Defeat(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    private void MovePlayer() {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Vector2.right * movementSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        }
    }
}

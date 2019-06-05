using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    
    public float speed = 100;

    public bool playerLostGame = false;

    public bool playerWonGame = false;

    public TextMeshProUGUI scoreText;

    private Rigidbody rb;

    private int score = 0;

    void Start() {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody>();
        score = 0;
        scoreText.text = "Score " + score.ToString();
    }

    void FixedUpdate() {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // addforce to vector x y and z
        Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            score++;
            Win();
        }
    }

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Monster"))
        {
            playerLostGame = true;
        }
        else
        {
            playerLostGame = false;
        }
    }

    void Win()
    {

        scoreText.text = "Score " + score.ToString();
        if (score >= 8)
        {
            playerWonGame = true;
        }
        else
        {
            playerWonGame = false;
        }

    }
}   


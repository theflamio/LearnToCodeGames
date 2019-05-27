using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    public float speed = 100;

    public Text scoreText;
    public Text winText;

    private Rigidbody rb;

    private int gameScore = 0;

    void Start() {
        rb = GetComponent<Rigidbody>();
        SetScoreText();
        winText.text = "";
    }

    void FixedUpdate() {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // addforce to vector x y and z
        Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other) {

        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            gameScore++;
            SetScoreText();
        }
        
    }

    void OnCollisionEnter(Collision other){
        
        if (other.gameObject.CompareTag("Monster"))
        {
            Lose();
        }
    }

    void SetScoreText(){

        scoreText.text = "Score: " + gameScore.ToString();
        if (gameScore >= 8)
        {
            winText.text = "You win !";
        }
        
    }

    void Lose()
    {
        winText.text = "You Lose !";
    }       
}   


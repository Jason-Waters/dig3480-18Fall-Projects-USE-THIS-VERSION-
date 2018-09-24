using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Update is called once per frame
    public float speed;
    public Text countText;
    public Text winText;


    private Rigidbody rb;
    private int count;
    private int score;
    private bool gameSet;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        SetCountText();
        winText.text = "";
        gameSet = false;
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            score++;
            SetCountText();
        }

        if (other.gameObject.CompareTag("Pick up drop score"))
        {
            other.gameObject.SetActive(false);
            score--;
            SetCountText();
        }
    }

    void SetCountText ()
    {
        countText.text = "Score: " + score.ToString() + "    Count: " + count.ToString();
        if(count >= 12 && gameSet == false)
        {
            winText.text = "You win! Your final score is " + score.ToString();
            gameSet = true;
        }
    }
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}

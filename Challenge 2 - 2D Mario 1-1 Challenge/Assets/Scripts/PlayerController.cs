using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;
    private bool facingRight = true;

    public float speed;
    public float jumpforce;

    public int numberOfCoins;
    public int CoinScore;

    public Text coinText;
    public Text winText;

    //ground check
    private bool isOnGround;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask allGround;

    public AudioSource source;
    public AudioClip grabCoin;
   // private float jumpTimeCounter;
    //public float jumpTime;
    //private bool isJumping;

    //audio stuff
    
   
    

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();

        numberOfCoins = 6;
        CoinScore = 0;
        coinText.text = "Coins x0";
        winText.text = "";
        setCoinText ();
    
	}

    void Awake()
    {

       source = GetComponent<AudioSource>();

    }

    void LateUpdate(){
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    
    // Update is called once per frame
    void FixedUpdate () {

        float moveHorizontal = Input.GetAxis("Horizontal");

        //Vector2 movement = new Vector2(moveHorizontal, 0);

       // rb2d.AddForce(movement * speed);

        rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);

        isOnGround = Physics2D.OverlapCircle(groundcheck.position, checkRadius, allGround);

        Debug.Log(isOnGround);



        //stuff I added to flip my character
        if(facingRight == false && moveHorizontal > 0)
        {
            Flip();
        }
        else if(facingRight == true && moveHorizontal < 0)
        {
            Flip();
        }

	}

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" && isOnGround)
        {


            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
                rb2d.velocity = Vector2.up * jumpforce;
                
                
                // Audio stuff
              
                
                
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            CoinScore++;
            source.PlayOneShot(grabCoin, 10);
            
        }

        if (other.gameObject.CompareTag("CoinBlock"))
        {
            if (numberOfCoins <= 0){
                other.gameObject.SetActive(false);
            }else{
                numberOfCoins--;
                CoinScore++;
                source.PlayOneShot(grabCoin, 10);
            }
        }
        setCoinText ();
        if (other.gameObject.CompareTag("Win"))
        {
            winText.text = "You Win";
        }
    }

    void setCoinText()
    {
        {
            coinText.text = "Coins x" + CoinScore.ToString();
        }
    }
    
}

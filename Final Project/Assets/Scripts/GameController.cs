using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameController : MonoBehaviour {

    public float subtractBy;
    public float addBy;
    private float barLength = 0;
    public float maxBar;
    private float AdditionUpperBound;
    private int loseCounter;
    private int gameOver;

    private float timer;
    public Text timeLeft;
    public float timeLeftInt;

    public GameObject HighArms;
    public GameObject LowArms;
    public GameObject LoseScreen;
    public GameObject WinScreen;

    public AudioSource source;
    public AudioClip theMusic;

    // Use this for initialization


    void Start () {
        AdditionUpperBound = maxBar - addBy;
        LowArms.SetActive(false);
        timer = 0;
        gameOver = 0;
        timeLeft.text = "";
        source.PlayOneShot(theMusic, 10);
    }

    void Awake()
    {
        //source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {

        //Count to ten
        timer += Time.deltaTime;

        //Update bar
        if (gameOver == 0)
        {
            //Count from 10
            timeLeftInt = 10 - (int)timer;
            timeLeft.text = timeLeftInt.ToString();

            //Decrease barLength
            if (barLength < subtractBy)
            {
                barLength = 0;
            }
            else
            {
                barLength = barLength - subtractBy;
            }

            //Increase barLength
            if (Input.GetKeyDown("1"))
            {
                if (barLength > AdditionUpperBound)
                {
                    barLength = maxBar;
                    gameOver = 2;

                    HighArms.SetActive(false);
                    LowArms.SetActive(true);
                }
                else
                {
                    barLength = barLength + addBy;
                }
            }

            //Update bar length
            gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(-barLength, 0);
        }

        if (timer >= 10)
        {
            gameOver = 1;
        }

        if (gameOver > 0)
        {
            EndGame();
        }
	}

    public void EndGame()//1 = lose, 2 = win
    {
        if (gameOver == 1)
        {
            //GameLoader.Addscore(0);
            if (WinScreen.activeSelf == false)
            LoseScreen.SetActive(true);
            StartCoroutine(ByeAfterDelay(2));
        }
        else
        {
            //GameLoader.AddScore(10);
            StartCoroutine(JustDelay(1));
        }
    }

    IEnumerator ByeAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);
        //GameLoader.gameOn = false;
    }
    IEnumerator JustDelay(float time)
    {
        yield return new WaitForSeconds(time);
        WinScreen.SetActive(true);
        StartCoroutine(ByeAfterDelay(1));
    }
}

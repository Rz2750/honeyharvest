using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dice : MonoBehaviour {

    // Array of dice sides sprites to load from Resources folder
    private Sprite[] diceSides;
    private Sprite[] diceSides9;
    // Reference to sprite renderer to change sprites
    private SpriteRenderer rend;

    public bool bosstile;


    public static int die1roll;
    public static int die2roll;
    public static int bossroll;



    public GameObject player;
    public GameObject enemy;
    public GameObject life;
    public GameObject powerup;
    
    public GameObject die1;
    public GameObject die2;
    
    public GameObject cl1;
    public GameObject cl2;
    public GameObject cl3;
    public GameObject cl4;
    // public GameObject hl1;
    public GameObject bd;
    
    

	// Use this for initialization
	private void Start () {
        // Assign Renderer component
        rend = GetComponent<SpriteRenderer>();
        // Load dice sides sprites to array from DiceSides subfolder of Resources folder
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        diceSides9 = Resources.LoadAll<Sprite>("DiceSides9/");
    }



    // If you left click over the dice then RollTheDice coroutine is started
    private void OnMouseDown() {
        if (name == "Die1")
            StartCoroutine("RollTheDice");
        //else if (name == "die7")
        //{
        //    StartCoroutine("RollTheDice7");
        //}
        //else if (name == "die8")
        //{
        //    StartCoroutine("RollTheDice8");
        //}
        //else if (name == "die9")
        //{
        //    StartCoroutine("RollTheDice9");
        //}
    }



    // Coroutine that rolls the dice
    public IEnumerator RollTheDice()
    {
        // IS THE SPRITE ON THE BOSS TILE OR NOT?


        // Variable to contain random dice side number.
        // It needs to be assigned. Let it be 0 initially
        int randomDiceSide = 0;

        // Final side or value that dice reads in the end of coroutine
        int finalSide = 0;

        // Loop to switch dice sides ramdomly
        // before final side appears. 20 itterations here.
        for (int i = 0; i <= 20; i++)
        {
            // Pick up random value from [0..6)
            randomDiceSide = Random.Range(0, 6);

            // Set sprite to upper face of dice from array according to random value
            rend.sprite = diceSides[randomDiceSide];

            // Pause before next itteration
            yield return new WaitForSeconds(0.05f);
        }

        // Assigning final side so you can use this value later in your game
        // for player movement for example
        finalSide = randomDiceSide + 1;

        // Track final dice value
        if (name == "Die1") {
            die1roll = finalSide;
            Debug.Log("debug1");
        }
        else if (name == "Die2") {
            die2roll = finalSide;
            Debug.Log("debug2");
        }

        Debug.Log("die1roll: " + die1roll + ", die2roll: " + die2roll);
        
        
        Debug.Log(name + " rolled a " + finalSide); // for debugging
        
        if (name == "Die1")
            StartCoroutine("FinishCombat",player.GetComponent<CheckCollide>().lastTouched);
    }

    //public IEnumerator RollTheDiceB()
    //{
    //    // Variable to contain random dice side number.
    //    // It needs to be assigned. Let it be 0 initially
    //    int randomDiceSide = 0;

    //    // Final side or value that dice reads in the end of coroutine
    //    int finalSide = 0;

    //    // Loop to switch dice sides ramdomly
    //    // before final side appears. 20 itterations here.
    //    for (int i = 0; i <= 20; i++)
    //    {
    //        // Pick up random value from 0 to 5 (All inclusive)
    //        randomDiceSide = Random.Range(1, 6);

    //        // Set sprite to upper face of dice from array according to random value
    //        rend.sprite = diceSides9[randomDiceSide];

    //        // Pause before next itteration
    //        yield return new WaitForSeconds(0.05f);
    //    }

    //    // Assigning final side so you can use this value later in your game
    //    // for player movement for example
    //    finalSide = randomDiceSide + 3;

    //    // Track final dice value
    //    if (name == "Die1")
    //    {
    //        die1roll = finalSide;
    //        Debug.Log("debug1");
    //    }
    //    else if (name == "Die9b")
    //    {
    //        bossroll = finalSide;
    //        Debug.Log("debugB");
    //    }

    //    Debug.Log("die1roll: " + die1roll + ", bossroll: " + bossroll);


    //    Debug.Log(name + " rolled a " + finalSide); // for debugging

    //    if (name == "Die1")
    //        StartCoroutine("FinishCombatB", player.GetComponent<CheckCollide>().lastTouched);
    //}

    // Coroutine that does everything after rolling the dice
    public IEnumerator FinishCombat(GameObject fighting) {
        if (die1roll > die2roll) {
            Debug.Log("Player rolled a " + die1roll + " to beat computer's " + die2roll);
            if (fighting.tag == "Boss") {
              yield return new WaitForSeconds(1.5f);
              SceneManager.LoadScene("WinScene");                                                   // restart same level
            } else {
                StartCoroutine(fighting.GetComponent<HideOnStart>().Defeated());
            }
        }
        else if (die1roll < die2roll){
            Debug.Log("Player rolled a " + die1roll + " but lost to computer's " + die2roll);
            ScoreScript.scoreValue -= 1;
            if(fighting.tag != "Boss"){
                StartCoroutine(fighting.GetComponent<HideOnStart>().Defeated());
            }            
            if (ScoreScript.scoreValue <= 0) {
              yield return new WaitForSeconds(1.5f);
              SceneManager.LoadScene("LostScene");                                                   // restart same level
            }
            
        }
        else{
            Debug.Log("Player and computer tied, both rolling " + die1roll);
            yield return new WaitForSeconds(2f);
            //todo reroll die 2
            StartCoroutine("RollTheDice");
        }
            
        yield return new WaitForSeconds(1.5f);
        
        if (name == "Die1")
            hideEverything();
    }

    //public IEnumerator FinishCombatB(GameObject fighting)
    //{
    //    if (die1roll > bossroll)
    //    {
    //        Debug.Log("Player rolled a " + die1roll + " to beat computer's " + bossroll);
    //        StartCoroutine(fighting.GetComponent<HideOnStart>().Defeated());
            
    //            yield return new WaitForSeconds(1.5f);
    //            SceneManager.LoadScene("WinScene");                                                   // restart same level
   
    //    }
    //    else if (die1roll < bossroll)
    //    {
    //        Debug.Log("Player rolled a " + die1roll + " but lost to computer's " + bossroll);
    //        ScoreScript.scoreValue -= 1;
            
    //            StartCoroutine(fighting.GetComponent<HideOnStart>().Defeated());
            
    //        if (ScoreScript.scoreValue <= 0)
    //        {
    //            yield return new WaitForSeconds(1.5f);
    //            SceneManager.LoadScene("LostScene");                                                   // restart same level
    //        }

    //    }
    //    else
    //    {
    //        Debug.Log("Player and computer tied, both rolling " + die1roll);
    //        yield return new WaitForSeconds(2f);
    //        //reroll die 2
    //        yield return RollTheDice();
    //    }

    //    yield return new WaitForSeconds(1.5f);

    //    if (name == "Die1")
    //        hideEverything();
    //}



    private void hideEverything() {
        die1.GetComponent<Renderer>().enabled = false;
        die2.GetComponent<Renderer>().enabled = false;
        cl1.SetActive(false);
        cl2.SetActive(false);
        cl3.SetActive(false);
        cl4.SetActive(false);
        // hl1.SetActive(true);
        bd.SetActive(false);
    }
}

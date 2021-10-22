using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour {

    // Array of dice sides sprites to load from Resources folder
    private Sprite[] diceSides;
    // Reference to sprite renderer to change sprites
    private SpriteRenderer rend;
    
    
    
    public static int die1roll;
    public static int die2roll;
    
    
    
    public GameObject player;
    public GameObject enemy;
    
    public GameObject die1;
    public GameObject die2;
    
    public GameObject cl1;
    public GameObject cl2;
    public GameObject cl3;
    public GameObject cl4;
    public GameObject hl1;
    public GameObject bd;
    
    

	// Use this for initialization
	private void Start () {
        // Assign Renderer component
        rend = GetComponent<SpriteRenderer>();
        // Load dice sides sprites to array from DiceSides subfolder of Resources folder
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
	}



    // If you left click over the dice then RollTheDice coroutine is started
    private void OnMouseDown() {
        if (name == "Die1")
            StartCoroutine("RollTheDice");
    }



    // Coroutine that rolls the dice
    public IEnumerator RollTheDice()
    {
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
    
    
    // Coroutine that does everything after rolling the dice
    public IEnumerator FinishCombat(GameObject fighting) {
        if (die1roll > die2roll) {
            Debug.Log("Player rolled a " + die1roll + " to beat computer's " + die2roll);
            StartCoroutine(fighting.GetComponent<HideOnStart>().Defeated());
        }
        else if (die1roll < die2roll)
            Debug.Log("Player rolled a " + die1roll + " but lost to computer's " + die2roll);
        else
            Debug.Log("Player and computer tied, both rolling " + die1roll);
            
        yield return new WaitForSeconds(3f);
        
        if (name == "Die1")
            hideEverything();
    }
    
    
    
    private void hideEverything() {
        die1.GetComponent<Renderer>().enabled = false;
        die2.GetComponent<Renderer>().enabled = false;
        cl1.SetActive(false);
        cl2.SetActive(false);
        cl3.SetActive(false);
        cl4.SetActive(false);
        hl1.SetActive(true);
        bd.SetActive(false);
    }
}

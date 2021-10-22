using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollide : MonoBehaviour {
    
    public GameObject die1;
    public GameObject die2;
    
    public GameObject cl1;
    public GameObject cl2;
    public GameObject cl3;
    public GameObject cl4;
    public GameObject hl1;
    public GameObject bd;
    
    public GameObject lastTouched;

    // Start is called before the first frame update
    void Start() {
        hideEverything();
    }

    // Update is called once per frame
    void Update () {
      
    }
    
    void OnCollisionEnter2D(Collision2D other){
         if (other.gameObject.tag == "Enemy"){
            lastTouched = other.gameObject;
            
            die1.GetComponent<Renderer>().enabled = true;
            die2.GetComponent<Renderer>().enabled = true;
            cl1.SetActive(true);
            cl2.SetActive(true);
            cl3.SetActive(true);
            cl4.SetActive(true);
            hl1.SetActive(false);
            bd.SetActive(true);
            
            StartCoroutine(die2.GetComponent<Dice>().RollTheDice());
        }
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


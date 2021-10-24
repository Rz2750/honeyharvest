using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnStart : MonoBehaviour
{
    
    public GameObject enemy;
    public GameObject life;
    public GameObject powerup;

    // Start is called before the first frame update
    void Start() {
        enemy.GetComponent<Renderer>().enabled = false;
        life.GetComponent<Renderer>().enabled = false;
        powerup.GetComponent<Renderer>().enabled = false;
    }

    void Update() {
        
    }
    
    void OnCollisionEnter2D(Collision2D other){
         if (other.gameObject.tag == "Player"){
              enemy.GetComponent<Renderer>().enabled = true;
              life.GetComponent<Renderer>().enabled = true;
            powerup.GetComponent<Renderer>().enabled = true;
         }
    }
    
    public string Defeated() {
        Destroy(gameObject);
        return "PLEASE IGNORE THIS"; //??????????????????????????????
    }
}

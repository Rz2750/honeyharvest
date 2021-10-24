using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnStart : MonoBehaviour
{
    public GameObject enemy;

    // Start is called before the first frame update
    void Start() {
        enemy.GetComponent<Renderer>().enabled = false;
    }

    void Update() {
        
    }
    
    void OnCollisionEnter2D(Collision2D other){
         if (other.gameObject.tag == "Player"){
              enemy.GetComponent<Renderer>().enabled = true;
         }
    }
    
    public string Defeated() {
        Destroy(gameObject);
        return "PLEASE IGNORE THIS"; //??????????????????????????????
    }
}

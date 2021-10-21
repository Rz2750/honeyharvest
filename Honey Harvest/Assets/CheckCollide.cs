using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollide : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {
      
    }
    
    void OnCollisionEnter2D(Collision2D other){
         if (other.gameObject.tag == "Enemy"){
              // Destroy(other.gameObject);
              Debug.Log("Is Touching");
         }
    }

}


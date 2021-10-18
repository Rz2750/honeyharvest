using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollide : MonoBehaviour
{
    public GameObject BeePurple;
    // Start is called before the first frame update
    void Start()
    {
        BeePurple.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BeePurple.SetActive(true);
    }

}


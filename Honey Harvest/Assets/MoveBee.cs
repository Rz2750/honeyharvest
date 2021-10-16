using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBee : MonoBehaviour
{
    private Grid hexmap;
    private GameObject bee;
    
    // Start is called before the first frame update
    void Start() {
        hexmap = gameObject.GetComponent<Grid>(); // get the hexmap grid
        bee    = GameObject.Find("BeeOrange");
    }

    // Update is called once per frame
    void Update() {
        // get our mouse position
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        
        // find the hex grid coordinate of where our mouse is
        Vector3Int hexCoord = hexmap.WorldToCell(worldPos);
        
        // convert that to world coordinate
        Vector3 moveTo = hexmap.GetCellCenterWorld(hexCoord);
        moveTo.z = 0;
        
        // move the bee there
        bee.transform.position = moveTo;
    }
}

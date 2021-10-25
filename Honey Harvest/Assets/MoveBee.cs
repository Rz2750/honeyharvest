using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class MoveBee : MonoBehaviour
{
    private Grid hexmap;
    private GameObject bee;
    private Tilemap tilemap;
    private Tile visited;
    
    private GameObject cam;
    private Vector3 cam_target;
    
    // Start is called before the first frame update
    void Start() {
        hexmap  = gameObject.GetComponent<Grid>(); // get the hexmap grid
        tilemap = hexmap.GetComponent<Tilemap>();
        bee     = GameObject.Find("BeeOrange");
        visited = Resources.Load<Tile>("Visited/hex_visited");
        
        cam        = GameObject.Find("Main Camera");
        cam_target = cam.transform.position;
    }

    // Update is called once per frame
    void Update() {
        // vvv   this stuff moves the camera   vvv
        Vector3 cam_curr = cam.transform.position;
        Vector3 cam_goto = cam_curr;
        cam_goto.x = (cam_curr.x + cam_target.x)/2;
        cam_goto.y = (cam_curr.y + cam_target.y)/2;
        cam_goto.z = cam_curr.z;
        cam.transform.position = cam_goto;
        // ^^^   this stuff moves the camera   ^^^
        
        if (Input.GetMouseButtonDown(1)) {
            // get our mouse position
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            
            // find the hex grid coordinate of where our mouse is
            Vector3Int hexCoord = hexmap.WorldToCell(worldPos);
            
            // convert that to world coordinate
            Vector3 moveTo = hexmap.GetCellCenterWorld(hexCoord);
            moveTo.z = 0;
            
            // move the bee and camera there
            bee.transform.position = moveTo;
            cam_target = moveTo;
            
            // paint that tile visited
            tilemap.SetTile(hexCoord, visited);
        }
    }
}

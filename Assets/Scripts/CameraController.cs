using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float scrollSpeed = 5f;
    public int minX, maxX, minY, maxY, minZ, maxZ;
    private Vector3 startPos;

    private bool AllowMouseMovement = false;

    void Start()
    {
        startPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {


        // No camera control allowed if game is over
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        // Toggle movement selection
        if (Input.GetKeyDown("m"))
        {
            AllowMouseMovement = !AllowMouseMovement;
        }


        if (AllowMouseMovement && Input.mousePosition.y >= Screen.height * 0.97)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (AllowMouseMovement && Input.mousePosition.y <= Screen.height * 0.03)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World); // Space.World ignores rotation
        }
        if (AllowMouseMovement && Input.mousePosition.x <= Screen.width * 0.03)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World); // Space.World ignores rotation
        }
        if (AllowMouseMovement && Input.mousePosition.x >= Screen.width * 0.97)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World); // Space.World ignores rotation
        }

        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World); // Space.World ignores rotation
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World); // Space.World ignores rotation
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World); // Space.World ignores rotation
        }
        if (Input.GetKey("f"))
        {
            transform.position = startPos;
        }
        if (Input.GetKey(KeyCode.LeftControl) && transform.position.y <= 50)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime * 4);   
        }
        if (Input.GetKey(KeyCode.LeftShift) && 5 <= transform.position.y)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime * 4);
        }

        // scroll not working at all

        //float scroll = Input.GetAxis("Mouse ScrollWheel");
        //Debug.Log(scroll);
        //Vector3 pos = transform.position;
        //pos.y -= scroll * 1000000;
        //pos.y = Mathf.Clamp(pos.y, minY, maxY);
    }
}

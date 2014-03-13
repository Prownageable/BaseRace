using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    public bool movingLeft;
    public bool movingRight;

    public int boundary = 50;
    public int speed = 5;

    public int screenWidth;
    public int screenHeight;

	void Start () {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
	}
	
	void Update () {
        //left button
        if (Input.GetKeyDown("left"))
        {
            movingLeft = true;
        }
        if (Input.GetKeyUp("left"))
        {
            movingLeft = false;
        }
        if (movingLeft)
        {
            this.transform.position += new Vector3(-2, 0, 0) * speed * Time.deltaTime;
        }

        //right button
        if (Input.GetKeyDown("right"))
        {
            movingRight = true;
        }
        if (Input.GetKeyUp("right"))
        {
            movingRight = false;
        }
        if (movingRight)
        {
            this.transform.position += new Vector3(2, 0, 0) * speed * Time.deltaTime;
        }

        //mouseMovement
        if (Input.mousePosition.x > screenWidth - boundary)
        {
            transform.position += new Vector3(2, 0, 0) * speed * Time.deltaTime; // move on +X axis
        }

        if (Input.mousePosition.x < 0 + boundary)
        {
            transform.position += new Vector3(-2, 0, 0) * speed * Time.deltaTime; // move on -X axis
        }

        if (Input.mousePosition.y > screenHeight - boundary)
        {
            //transform.position.z += speed * Time.deltaTime; // move on +Z axis
        }

        if (Input.mousePosition.y < 0 + boundary)
        {
            //transform.position.z -= speed * Time.deltaTime; // move on -Z axis
        }



	}
}

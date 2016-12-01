using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {
    private bool doorOpen;
    public float doorAngle;
    public GameController gameController;
	// Use this for initialization
	void Start () {
        doorOpen = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (doorOpen && transform.rotation.eulerAngles.y <= doorAngle)
        {
            transform.eulerAngles += new Vector3(0, 3, 0);
        }

        if (doorOpen && transform.rotation.eulerAngles.y > doorAngle)
        {
            gameController.MoveAhead();
            doorOpen = false;
        }

        

    }

    public void OpenDoor()
    {
        doorOpen = true;
    }
}

using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private bool moveAhead;
    public CameraController cameraController;
    public GameObject doorObject;
    public GameObject greatFilter;

	// Use this for initialization
	void Start () {
        moveAhead = false;
	}
	
	// Update is called once per frame
	void Update () {
        if ( moveAhead)
        {
            cameraController.MoveForward( Time.deltaTime * 4 );
        }
	
	}

    public void MoveAhead()
    {
        moveAhead = true;
    }

    public void removeDoor()
    {
        Destroy(doorObject);
    }

    public void addFilter()
    {
        Instantiate(greatFilter, new Vector3(0, 0, 1000), Quaternion.identity);
    }
}

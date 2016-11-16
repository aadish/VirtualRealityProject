using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    private bool changeSkyDome;
    public Material skyBox;
    public GameController gameController;
    public GameObject greatFilter;
    // Use this for initialization
    void Start () {
        changeSkyDome = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if ( !changeSkyDome && transform.position.z > 0)
        {
            RenderSettings.skybox = skyBox;
            gameController.removeDoor();
            gameController.addFilter();
            changeSkyDome = true;
        }  
	}

    public void MoveForward( float delta )
    {
        transform.position += Vector3.forward * delta;
    }

}

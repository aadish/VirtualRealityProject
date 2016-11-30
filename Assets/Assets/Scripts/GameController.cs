using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    private bool moveAhead;
    private bool action1PanelFlag;
    private Vector3 cameraPosition;
    public CameraController cameraController;
    public GameObject doorObject;
    public GameObject greatFilter;
    public GameObject action1Panel;

	// Use this for initialization
	void Start () {
        moveAhead = false;
        action1PanelFlag = true;
        action1Panel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        cameraPosition = cameraController.CameraPosition();
        // instantiate first action panel
        if ( cameraPosition.z > 20 && cameraPosition.z < 40 && action1PanelFlag )
        {
            action1Panel.SetActive(true);
            moveAhead = false;
            action1PanelFlag = false;
        }
        if ( moveAhead )
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
        Instantiate(greatFilter, new Vector3(0, -150, 1000), Quaternion.identity);
    }

    public void ResetScene()
    {
        print("In Reset");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}

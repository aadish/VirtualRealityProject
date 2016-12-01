using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    private bool moveAhead;
    private bool action1PanelFlag;
    private bool action2PanelFlag;
    private bool action3PanelFlag;
    private bool moveGreatFilter;
    private GameObject instantiatedFilter;
    private Vector3 cameraPosition;
    public CameraController cameraController;
    public GameObject doorObject;
    public GameObject greatFilter;
    public GameObject rainbowRoad;
    public GameObject action1Panel;
    public GameObject action2Panel;
    public GameObject action3Panel;

    

    // Use this for initialization
    void Start () {
        moveAhead = false;
        moveGreatFilter = false;
        action1PanelFlag = true;
        action2PanelFlag = true;
        action3PanelFlag = true;
        action1Panel.SetActive(false);
        action2Panel.SetActive(false);
        action3Panel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        /*if( GvrViewer.Instance.BackButtonPressed)
        {
            Application.Quit();
        }*/
        cameraPosition = cameraController.CameraPosition();
        
        // instantiate first action panel
        if ( cameraPosition.z > 60 && cameraPosition.z < 80 && action1PanelFlag )
        {
            action1Panel.SetActive(true);
            moveAhead = false;
            action1PanelFlag = false;
        }
        // instantiate second action panel
        if (cameraPosition.z > 330 && cameraPosition.z < 350 && action2PanelFlag)
        {
            action2Panel.SetActive(true);
            moveAhead = false;
            action2PanelFlag = false;
        }
        // instantiate third action panel
        if (cameraPosition.z > 590 && cameraPosition.z < 610 && action3PanelFlag)
        {
            action3Panel.SetActive(true);
            moveAhead = false;
            action3PanelFlag = false;
        }
        if ( moveAhead )
        {
            cameraController.MoveForward( Time.deltaTime * 8 );
            //print ( cameraController.CameraPosition() );
        }

        if ( moveGreatFilter)
        {
            instantiatedFilter.GetComponent<Transform>().Translate( Vector3.back * Time.deltaTime * 100 );
            if ( instantiatedFilter.GetComponent<Transform>().position.z < cameraController.CameraPosition().z)
            {
                
                moveGreatFilter = false;
                SceneManager.LoadScene(1);
            }
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
        instantiatedFilter = (GameObject)Instantiate(greatFilter, new Vector3(0, -150, 1000), Quaternion.identity);
        Instantiate(rainbowRoad, new Vector3(0, -5, -10), Quaternion.Euler( 0, 90, 0 ));
    }

    public void ResetScene()
    {
        print("In Reset");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteAction1()
    {
        moveAhead = true;
        action1Panel.SetActive(false);
    }

    public void CompleteAction2()
    {
        moveAhead = true;
        action2Panel.SetActive(false);
    }
    public void CompleteAction3()
    {
        moveAhead = true;
        action3Panel.SetActive(false);
    }

    public void PassAction1()
    {
        moveGreatFilter = true;
        action1Panel.SetActive(false);
    }
    public void PassAction2()
    {
        moveGreatFilter = true;
        action2Panel.SetActive(false);
    }
    public void PassAction3()
    {
        moveGreatFilter = true;
        action3Panel.SetActive(false);
    }
}

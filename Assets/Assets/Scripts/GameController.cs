using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    private bool moveAhead;
    private bool action1PanelFlag;
    private bool action2PanelFlag;
    private bool action3PanelFlag;
    private bool moveGreatFilter;
    private bool animateScroll;
    private bool animateSpaceship;
    private bool endGameFlag;
	private int counter;
    private GameObject instantiatedFilter;
    private GameObject instantiatedScroll;
    private GameObject instantiatedSpaceShip;
    private Vector3 cameraPosition;
    public CameraController cameraController;
    public GameObject roomObject;
    public GameObject greatFilter;
    public GameObject rainbowRoad;
    public GameObject action1Panel;
    public GameObject action2Panel;
    public GameObject action3Panel;
    public GameObject endMessage;
	public GameObject fireLog;
    public GameObject scroll;
    public GameObject scrollPile;
    public GameObject spaceShip;
    public GameObject quill;
    

    // Use this for initialization
    void Start () {
		counter = 0;
        moveAhead = false;
        moveGreatFilter = false;
        action1PanelFlag = true;
        action2PanelFlag = true;
        action3PanelFlag = true;
        animateScroll = false;
        animateSpaceship = false;
        endGameFlag = false;
        action1Panel.SetActive(false);
        action2Panel.SetActive(false);
        action3Panel.SetActive(false);
        endMessage.SetActive(false);
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
        // check for the end of game
        if (cameraPosition.z > 850 && !endGameFlag)
        {
            moveAhead = false;
            endGameFlag = true;
        }
        if ( moveAhead && counter == 0)
        {
            cameraController.MoveForward( Time.deltaTime * 12 );
        }

        // animate the scroll
        if ( animateScroll && instantiatedScroll.GetComponent<Transform>().eulerAngles.x > 5)
        {
            instantiatedScroll.GetComponent<Transform>().eulerAngles -= new Vector3(0.5f, 0, 0);
        }

        // animate spaceship
        if (animateSpaceship && instantiatedSpaceShip.GetComponent<Transform>().position.z < 4000 && counter < 200 )
        {
            instantiatedSpaceShip.GetComponent<Transform>().position += Vector3.forward * Time.deltaTime * 32;
        }
        if ( counter > 0){
			counter--;
		}

        // crush from filter
        if ( moveGreatFilter)
        {
            instantiatedFilter.GetComponent<Transform>().Translate( Vector3.back * Time.deltaTime * 100 );
            if ( instantiatedFilter.GetComponent<Transform>().position.z < cameraController.CameraPosition().z)
            {
                
                moveGreatFilter = false;
                SceneManager.LoadScene(1);
            }
        }

        // end the game dialog
        if (endGameFlag)
        {
            
            instantiatedFilter.GetComponent<Transform>().Translate(new Vector3( 0, Time.deltaTime * -10, 0) );
            if (instantiatedFilter.GetComponent<Transform>().position.y < -260)
            {

                endGameFlag= false;
                endMessage.SetActive(true);
            }
        }



    }

    public void MoveAhead()
    {
        moveAhead = true;
    }

    public void removeDoor()
    {
        Destroy(roomObject);
    }

    public void addFilter()
    {
        instantiatedFilter = (GameObject)Instantiate(greatFilter, new Vector3(0, -150, 1000), Quaternion.identity);
        Instantiate(rainbowRoad, new Vector3(0, -5, -10), Quaternion.Euler( 0, 90, 0 ));
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteAction1()
    {
        moveAhead = true;
        action1Panel.SetActive(false);
		Instantiate(fireLog, new Vector3(0, -1.5f, 67), Quaternion.identity);
		counter = 200;

    }

    public void CompleteAction2()
    {
        moveAhead = true;
        action2Panel.SetActive(false);
        instantiatedScroll = (GameObject)Instantiate(scroll);
        Instantiate(scrollPile);
        Instantiate(quill);
        counter = 200;
        animateScroll = true;
    }

    public void CompleteAction3()
    {
        moveAhead = true;
        action3Panel.SetActive(false);
        instantiatedSpaceShip =  (GameObject)Instantiate(spaceShip);
        counter = 300;
        animateSpaceship = true;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject cameraOrbit;
    public GameObject aimGuide;
    public GameObject ball;
    public GameObject levelManager;
    public GameObject uIManager;

    public GameObject MainMenu;
    public GameObject GamePlayUI;
    public GameObject BallGroup;
        
    private GameObject LevelInfo;
    //private int shotsToComplete;
    private int shotsLeft = 99;

    private BallController _ballController;
    private LevelManager _levelManager;
    private LevelInfo _levelInfo;
    private UIManager _uIManager;

    private int nextScene;

    public GameObject startPosition;

    private bool MouseOrbitOn;

    // Start is called before the first frame update
    void Start()
    {
        MouseOrbitOn = false;
        cameraOrbit.GetComponent<MouseOrbitImproved>().enabled = false;
        _ballController = ball.GetComponent<BallController>();
        _levelManager = levelManager.GetComponent<LevelManager>();
        _uIManager = uIManager.GetComponent<UIManager>();
        startPosition = GameObject.FindWithTag("StartPos");
    }

    // Update is called once per frame
    void Update()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;      
        mouseOrbitControl();

        Debug.Log(_ballController.isBallMoving());

        // if the ball is not moving, you can press Space to shoot
        if (Input.GetKeyDown(KeyCode.Space) && _ballController.isBallMoving() == false)
        {
            _ballController.ballShoot();            
            shotsLeft -= 1;
            _uIManager.UpdateShotsleft(shotsLeft);
        }

        if (LevelInfo != null && shotsLeft <= 0 && _ballController.isBallMoving() == false)            
        {
            Debug.Log("no shots left, game over");
        }

        if (shotsLeft <= 0 && _ballController.isBallMoving() == false)
        {
            _levelManager.ReloadCurrentScene();
        }                
    }

    void mouseOrbitControl()
    {
        if (MouseOrbitOn == true)
        {
            cameraOrbit.GetComponent<MouseOrbitImproved>().enabled = true;
        }
        else if (MouseOrbitOn == false)
        {
            cameraOrbit.GetComponent<MouseOrbitImproved>().enabled = false;
        }        
    }


    public void GoalReached()
    {
        //Debug.Log("WINNER!!!!!");
        _ballController.StopBall();
        _levelManager.LoadNextlevel();
    }

    public void StartGame()
    {
        _levelManager.LoadNextlevel();
        MainMenu.SetActive(false);
        GamePlayUI.SetActive(true);
        BallGroup.SetActive(true);
        MouseOrbitOn = true;
    }

    public void ResetBallPos()
    {           
        ball.transform.position = startPosition.transform.position;
        _ballController.StopBall();
        cameraOrbit.GetComponent<MouseOrbitImproved>().ResetCamera();
    }

        
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LevelInfo = GameObject.FindWithTag("LevelInfo");
        _levelInfo = LevelInfo.GetComponent<LevelInfo>();
        shotsLeft = _levelInfo.ShotsToComplete;        

        startPosition = GameObject.FindWithTag("StartPos");
        ResetBallPos();        
        _uIManager.UpdateShotsleft(shotsLeft);
    }

}

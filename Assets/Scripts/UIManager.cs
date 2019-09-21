using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //Script references
    public GameObject ball;
    private BallController _ballController;

    //private GameObject gameManager;
    //private GameManager _gameManager;


    public Text modeText;
    public Text ballMovingText;
    public Text ShotsLeftCount;
    

    // Start is called before the first frame update
    void Start()
    {
        //gameManager = GameObject.FindWithTag("GameController");
        //_gameManager = gameManager.GetComponent<GameManager>();

        _ballController = ball.GetComponent<BallController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (_ballController.isBallMoving() == true)
        {
            modeText.text = "Wait";
            ballMovingText.text = "BALL MOVING";
        }

        else
        {
            modeText.text = "Aim & Shoot";
            ballMovingText.text = "BALL STOPPED";
        }        
    }

    public void UpdateShotsleft(int count)
    {
        Debug.Log(count);
        ShotsLeftCount.text = count.ToString();
    }

}

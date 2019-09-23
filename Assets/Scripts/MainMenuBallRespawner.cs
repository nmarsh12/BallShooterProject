using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBallRespawner : MonoBehaviour
{
    public GameObject ball;
    public int StartingBalls = 1;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < StartingBalls; i++)
        {
            int RandomX = Random.Range(-25, 25);
            int RandomY = Random.Range(0, 100);
            int RandomZ = Random.Range(-29, -30);

            Instantiate(ball, new Vector3(RandomX, RandomY, RandomZ), transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {        
        Destroy(other.gameObject);

        int RandomX = Random.Range(-25, 25);
        int RandomY = Random.Range(0, 10);
        int RandomZ = Random.Range(-27, -30);

        Instantiate(ball, new Vector3(RandomX, RandomY, RandomZ), transform.rotation);          
    }


}

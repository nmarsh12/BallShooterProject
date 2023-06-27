using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sam Robichaud 
// NSCC Truro 2022

public class MainMenuBallRespawner : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private int StartingBalls = 120;

    [SerializeField] private int SpawnXmin = -25;
    [SerializeField] private int SpawnXmax = 25;
    [SerializeField] private int SpawnYmin = 7;
    [SerializeField] private int SpawnYmax = 10;
    [SerializeField] private int SpawnZmin = -40;
    [SerializeField] private int SpawnZmax = -45;
   

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < StartingBalls; i++)
        {
            int RandomX = Random.Range(-25, 25);
            int RandomY = Random.Range(4, 125);
            int RandomZ = Random.Range(-30, 10);

            GameObject go = Instantiate(ball, new Vector3(RandomX, RandomY, RandomZ), transform.rotation);
            
            go.GetComponentInChildren<MeshRenderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {        
        Destroy(other.gameObject);

        int RandomX = Random.Range(SpawnXmin, SpawnXmax);
        int RandomY = Random.Range(SpawnYmin, SpawnYmax);
        int RandomZ = Random.Range(SpawnZmin, SpawnZmax);
                

        GameObject go = Instantiate(ball, new Vector3(RandomX, RandomY, RandomZ), transform.rotation);

        go.GetComponentInChildren<MeshRenderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));


    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Generate Spawn Settings")]
    [SerializeField] private GameObject[] circlePrefabs;
    [SerializeField] private GameObject colorChangerprefab;
    [SerializeField] private float ySpawnPos = 60;
    



    [Header("Get Player Rigidbody")]
    private Player player;
    private Rigidbody2D playerRB;

   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerRB = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    public void SpawnCircles()
    {
         
            int index = Random.Range(0, circlePrefabs.Length);
            Instantiate(circlePrefabs[index], new Vector2(playerRB.transform.position.x,playerRB.transform.position.y+10),circlePrefabs[index].transform.rotation);

         
    }

    public void SpawnColorChangers()
    {
        Instantiate(colorChangerprefab, new Vector2(playerRB.transform.position.x, playerRB.transform.position.y+30), colorChangerprefab.transform.rotation);
    }

  


}

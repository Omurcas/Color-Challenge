using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Player")]
    public float SpeedJump = 10f;
    public Rigidbody2D rb;
    public SpriteRenderer sr;

    [Header("Color Settings")]
    [SerializeField] private string currentColor;
    [SerializeField] private Color colorBlue;
    [SerializeField] private Color colorYellow;
    [SerializeField] private Color colorPink;
    [SerializeField] private Color colorPurple;

    [Header("Score")]
    private int scoreD=5;

    [Tooltip("Button displayed when player failed")]public GameObject restartButton;

    [HideInInspector] public SpawnManager sManager;
    
    void Start()
    {
        SetRandomColor();
        sManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        
    }


    void Update()
    {
        PlayerJump();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag =="ColorChanger")
        {
            
            SetRandomColor();
            sManager.SpawnCircles();
            sManager.SpawnColorChangers();
            ScoreScript.scoreCount += scoreD;
            scoreD += 10;
            Destroy(collision.gameObject);
            return;
        }
        if(collision.tag != currentColor)
        {
            Time.timeScale = 0;
            restartButton.SetActive(true);
            
        }
        if(collision.tag == "a")
        {
            Time.timeScale = 0;
            restartButton.SetActive(true);
        }
    }

    void SetRandomColor()
    {
        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0:
                currentColor = "Blue";
                sr.color = colorBlue;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColor = "Pink";
                sr.color = colorPink;
                break;
            case 3:
                currentColor = "Purple";
                sr.color = colorPurple;
                break;
        }
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * SpeedJump;
        }
    }

   
}

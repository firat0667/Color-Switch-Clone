using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public float jumpForce = 10f;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public string currentColor;
    public Color colorCyan;
    public Color colorPink;
    public Color colorMagenta;
    public Color colorYellow;
    public TextMeshProUGUI tmpro;
    public Animator anim;
    int score;
    public GameObject LevelCompleted;
    IEnumerator animSecand()
    {
        anim.SetBool("TenPoint", true);
        yield return new WaitForSeconds(2.5f);
        anim.SetBool("TenPoint", false);
    }
    
    private void Start()
    {
        LevelCompleted.SetActive(false);
        SetRandomColor();
        score = 0;
        anim.SetBool("TenPoint", false);
        
    }

    // Update is called once per frame
    void Update()
    {
        tmpro.text = score.ToString();
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Application quit");
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
     
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            LevelCompleted.SetActive(true);
            Time.timeScale = 0;

        }
        if (collision.tag == "ColorChancer")
        {
            SetRandomColor();
            Destroy(collision.gameObject);
            score += 10;
            StartCoroutine(animSecand());
            return;
         }
        


        if (collision.tag != currentColor && collision.tag != "Finish")
        {
            Debug.Log("Game 0ver");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
       
      
       
    }
    void SetRandomColor()
    {
        int index = Random.Range(0, 4);
        switch (index)
        {
            case 0:
                currentColor ="Cyan";
                sr.color = colorCyan;
                break;
            case 1:
                currentColor ="Yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColor ="Magenta";
                sr.color = colorMagenta;
                break;
            case 3:
                currentColor ="Pink";
                sr.color = colorPink;
                break;
        }
    }
}

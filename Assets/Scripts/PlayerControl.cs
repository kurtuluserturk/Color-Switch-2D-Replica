using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;                   
using System.Collections;     //for coroutine

public class PlayerControl : MonoBehaviour
{
    public float jumpForce = 8f;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public string currentColor;
    public Color colorCyan;
    public Color colorYellow;
    public Color colorMagenta;
    public Color colorPink;
    public int prev = -1;    //Player renk kontrolü için
    public int index;        
    public TMP_Text scoreNumber;
    public int score = 0;
    public AudioClip[] gameAudios;
    AudioSource audioSource;   
    void Start()
    {      
        Physics2D.gravity = new Vector2(0, 0);
        SetRandomColor();
        audioSource = GetComponent<AudioSource>();        
    }
    void Update()
    {
        if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
            Physics2D.gravity = new Vector2(0, -30);
            audioSource.PlayOneShot(gameAudios[0]);
        }                
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ColorChanger")
        {
            audioSource.PlayOneShot(gameAudios[3]);
            SetRandomColor();
            score++;
            scoreNumber.text = score.ToString();
            Destroy(col.gameObject);
            return;     
        }
        if (col.tag == "LastPoint")
        {
            Destroy(col.gameObject);
            StartCoroutine(Win());
        }   
        else if(col.tag != currentColor)
        {
            StartCoroutine(Lost());
        }
    }    
    void SetRandomColor()
    {
        index = Random.Range(0, 4);
        if (prev != index)       //Önceki player rengi ile aynı rengi atamasın diye bu kontrolü yaptık.
        {                        
            switch (index)
            {
                case 0:
                    sr.color = colorCyan;
                    currentColor = "Cyan";
                    break;
                case 1:
                    sr.color = colorYellow;
                    currentColor = "Yellow";
                    break;
                case 2:
                    sr.color = colorMagenta;
                    currentColor = "Magenta";
                    break;
                case 3:
                    sr.color = colorPink;
                    currentColor = "Pink";
                    break;
            }
            prev = index;
        }  
        else
        {
            SetRandomColor();
        }
    }
    IEnumerator Win()
    {
        score++;
        scoreNumber.text = score.ToString();
        audioSource.PlayOneShot(gameAudios[2]);
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    IEnumerator Lost()
    {
        audioSource.PlayOneShot(gameAudios[1]);
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

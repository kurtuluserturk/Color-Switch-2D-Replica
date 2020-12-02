using UnityEngine;
using UnityEngine.SceneManagement;

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
    void Start()
    {                             
        Physics2D.gravity = new Vector2(0, 0);
        SetRandomColor();        
    }
    void Update()
    {
        if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
            Physics2D.gravity = new Vector2(0, -30);
        }                
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ColorChanger")
        {
            SetRandomColor();
            Destroy(col.gameObject);
            return;     
        }
        if (col.tag != currentColor)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }     
    }
    void SetRandomColor()
    {
        int index = Random.Range(0, 4);    
        switch (index)
        {
            case 0:
                currentColor = "Cyan";
                sr.color = colorCyan;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColor = "Magenta";
                sr.color = colorMagenta;
                break;
            case 3:
                currentColor = "Pink";
                sr.color = colorPink;
                break;
        }
    }
}

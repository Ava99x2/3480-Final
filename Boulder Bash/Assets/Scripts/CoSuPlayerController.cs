using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoSuPlayerController : MonoBehaviour
{

    public float speed;             
    public Text countText;          
    public Text winText;
    public Text endText;

    private Rigidbody2D rb2d;      
    private int count;              

    private float timer;
    private int wholetime;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        count = 0;

        winText.text = "";

        SetCountText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb2d.AddForce(movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Boulder"))

        {
            other.gameObject.SetActive(false);

            count = count + 1;

            SetCountText();
        }
    }

    
    void SetCountText()
    {   
        countText.text = "Boulders: " + count.ToString();
       
        if (count >= 7)

        {
            winText.text = "Boulders Bashed!";
        }

        
    }
}
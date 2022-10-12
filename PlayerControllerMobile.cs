using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float jumpForce = 10f;
    [SerializeField] private float currentColor = -1f;
    [SerializeField] private string curColorStr = "";
    [SerializeField] private Color[] colors;
    private List<string> colsString = new List<string>{"Blue", "Yellow", "Pink", "Purple"};
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Score score;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        score = GetComponent<Score>();
        ColorSet();
    }  
    void FixedUpdate()
    {
        foreach(Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Jump();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "ColorSwitch"){
            return;
        }else
        {
            if(other.tag != curColorStr && colsString.Contains(other.tag)){
                Fail();
            }
        }
    }
    void Jump()
    {
        if(rb.gravityScale == 0){
            rb.gravityScale = 2f;
        }
        rb.velocity = Vector2.up * jumpForce;
    }
    public void ColorSet()
    {
        float nextColor = -1f;
        do {
            nextColor = Mathf.RoundToInt(Random.Range(0,4));
        } while(nextColor == currentColor);
        curColorStr = nextColor switch{
            0 => "Blue",
            1 => "Yellow",
            2 => "Pink",
            3 => "Purple",
            _ => throw new System.Exception("wrong value")
        };
        currentColor = nextColor;
        sr.color = colors[(int)currentColor];
    }
    void Fail(){
        
        SceneManager.LoadScene("SampleScene");
    }
}

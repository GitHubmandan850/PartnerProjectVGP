using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float speed = 5.0f;
    public float horizontalInput;
    public string inputID;
    public SpriteRenderer SR;
    public Sprite turnRightSprite; 
    public Sprite turnLeftSprite; 
    public Sprite baseSprite; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal" + inputID);
        
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        if(Input.GetKeyDown(KeyCode.D))
        {
            SR.sprite = turnRightSprite;
        }
        if(Input.GetKeyUp(KeyCode.D))
        {
            SR.sprite = baseSprite;
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            SR.sprite = turnLeftSprite;
        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            SR.sprite = baseSprite;
        }
    }
}

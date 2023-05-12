using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PeguinAnimation : MonoBehaviour
{
    Animator anim;
    public float speed = 2, restartDelay = 4f;
    bool CanJump = true;
    public int heart = 5;
    bool isDie, isUnderground, isReset, isHighJump;
    public bool isActiveStone = false;
    Rigidbody2D rgb2d;
    AudioM1 ado;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rgb2d = GetComponent<Rigidbody2D>();
        ado = GameObject.Find("Main Camera").GetComponent<AudioM1>();
    }
    float move;
    // Update is called once per frame
    void Update()
    {
        // di chuyển trái phải
        if (Input.GetKey(KeyCode.D))
        {
            move = 1;
            //hướng mặt 
            Vector3 direction = transform.localScale;
            direction.x = 0.75f;
            transform.localScale = direction;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            move = -1;
            //hướng mặt
            Vector3 direction = transform.localScale;
            direction.x = -0.75f;
            transform.localScale = direction;
        }
        else
        {
            move = 0;
        }
        transform.Translate(Vector3.right * Time.deltaTime * speed * move);

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isWalk", true);
            anim.SetBool("isIdle", false);
        }
        else
        {
            anim.SetBool("isWalk", false);
            anim.SetBool("isIdle", true);
        }
        /* ------------------------------------------------------------------------------------------------*/
        //nhảy
        if (Input.GetKeyDown(KeyCode.Space) && CanJump)
        {
                rgb2d.AddForce(Vector2.up * 750);
        }

        /* ------------------------------------------------------------------------------------------------*/
        // audio hiệu ứng nhảy
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ado.playAudioJump();
        }

        // audio hiệu ứng di chuyển
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            ado.playAudioWalk();
        }

        // audio hiệu ứng chạm bẫy
        if (isDie)
        {
            ado.playAudioHurt();
        }

        /* ------------------------------------------------------------------------------------------------*/
        //chạm bẫy
        if (isDie)
        {
            transform.position = new Vector3(transform.position.x - 2.5f, transform.position.y,0);
            heart -=1;
        }
        isDie = false;
        //
        if (heart <= 0)
        {
            Dead();
        }
    }

    /* ------------------------------------------------------------------------------------------------*/
    
    private void OnTriggerEnter2D(Collider2D otherHitbox)
    {
        //kiểm tra chạm đất
        if (otherHitbox.gameObject.tag == "ground" ||  otherHitbox.gameObject.tag == "activeStone")
        {
            CanJump = true;
        }
        if (otherHitbox.gameObject.tag == "highjump2")
        {
            HighJump();
            CanJump = false;
        }
    }
    
    //
    private void OnTriggerExit2D(Collider2D otherHitbox)
    {
        if (otherHitbox.gameObject.tag == "ground" )
        {
            CanJump = false;
        }
        
    }

    /* ------------------------------------------------------------------------------------------------*/
    //kiểm tra chạm bẫy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "barrier" || collision.gameObject.tag == "stone")
        {
            isDie = true;
        }
        if (collision.gameObject.tag == "underground" )
        {
            ado.playAudioDie();
            Invoke("Dead", restartDelay);
        }
        if(collision.gameObject.tag == "highjump")
        {
            HighJump();
            CanJump=false;
        }
    }
    /* ------------------------------------------------------------------------------------------------*/
    
    void Dead()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void HighJump()
    {
        rgb2d.AddForce(Vector2.up * 1950);      
    }

    void loadSceneBegin()
    {
        SceneManager.LoadScene(0);
    }
}

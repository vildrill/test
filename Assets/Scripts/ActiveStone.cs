using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActiveStone : MonoBehaviour
{
    Rigidbody2D rgb2dStone;
    PeguinAnimation pgi;
    bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        rgb2dStone = GameObject.FindGameObjectWithTag("stone").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       if(isActive)
        {
            rgb2dStone.gravityScale = 3f;
        }  
    }

    private void OnTriggerEnter2D(Collider2D otherHitbox)
    {
        if(otherHitbox.gameObject.tag == "player")
        {
            isActive = true;
        }
        
    }





}

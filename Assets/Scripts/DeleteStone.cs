using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteStone : MonoBehaviour
{
    bool isDelete;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDelete)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "activeStone")
        {
            isDelete = true;
        }
    }
}

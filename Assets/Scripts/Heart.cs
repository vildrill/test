using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public PeguinAnimation pgi;
    public Sprite[] spriteHeart;
    public Image imageHeart;
    // Start is called before the first frame update
    void Start()
    {
        pgi = GameObject.FindGameObjectWithTag("player").GetComponent<PeguinAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        imageHeart.sprite = spriteHeart[pgi.heart];
    }
}

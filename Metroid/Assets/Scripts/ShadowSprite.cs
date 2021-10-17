using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSprite : MonoBehaviour
{
    
    //private Transform player;
    public Transform cBullet;
    private SpriteRenderer thisSprite;
    private SpriteRenderer playerSprite;

    private Color color;

    //dash time
    public float activeTime;

    //alpha value of player
    private float alpha;
    public float alphaSet;
    public float alphaMultiplier;

    private void OnEnable()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        //cBullet = GameObject.FindGameObjectWithTag("cBullet").transform;

        thisSprite = GetComponent<SpriteRenderer>();
        //playerSprite = player.GetComponent<SpriteRenderer>();

        alpha = alphaSet;


    }

    void Update()
    {
        Debug.Log(cBullet);
    }
}

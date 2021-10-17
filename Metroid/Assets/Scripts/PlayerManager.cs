using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{


    public static PlayerManager instance;

    //player attribute
    public static float PlayerHP = 100f;
    
    // Start is called before the first frame update
    void Start()
    {
        
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    

    
}

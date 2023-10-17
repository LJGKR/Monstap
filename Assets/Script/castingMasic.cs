using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castingMasic : MonoBehaviour
{
    public ParticleSystem Lightning_Tornado;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Lightning_Tornado.Play();
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particletest : MonoBehaviour
{
    public ParticleSystem particle1;
    public ParticleSystem particle2;

    private void OnMouseDown()
    {
        particle1.Play();
        //particle2.Play();
    }
}

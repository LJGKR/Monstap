using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGo : MonoBehaviour
{
    public ParticleSystem[] LightningTonado;
    public float speed;
    public AudioSource audioSource;


    private void Start()
    {
        DoParticle();
    }

    public void DoParticle()
    {
        foreach (var i in LightningTonado)
        {
            i.Play();
			audioSource.Play();

		}
        StartCoroutine(RunWhileForThreeSeconds());
    }

    IEnumerator RunWhileForThreeSeconds()
    {

        float startTime = Time.time;
        float duration = 2.0f;

        while (Time.time - startTime < duration)
        {
            transform.Translate(Vector3.forward * speed *Time.deltaTime); 
            yield return null;
        }

        this.gameObject.SetActive(false);
        //Destroy(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHpManager>().HpDown(100f);
        }
    }
}


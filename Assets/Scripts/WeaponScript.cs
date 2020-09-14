using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sound;

    public Transform FirePoint;
    public ParticleSystem muzzleEffect;

    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            StartCoroutine("Fire", delay);
        }
    }

    IEnumerator Fire(float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.PlayOneShot(sound);
        muzzleEffect.Play();
        StopCoroutine("Fire");
    }
}

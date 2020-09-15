using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sound;

    public Transform FirePoint;
    public ParticleSystem muzzleEffect;

    public GameObject decal;

    public float delay;

    public Vector2 xscatter = new Vector2(0.5f,1f);
    public Vector2 yscatter = new Vector2(-0.5f, 0.5f);

    CameraScript camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.GetComponent<CameraScript>();
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
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0));
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.yellow);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Quaternion hitRotation = Quaternion.FromToRotation(Vector3.back, hit.normal);
            GameObject Decal = Instantiate<GameObject>(decal, hit.point + (hit.normal * 0.01f),hitRotation);
            Decal.transform.parent = hit.collider.transform;
        }
        camera.xRotation -= Random.Range(yscatter.x, yscatter.y);
        camera.Player.Rotate(Vector3.up * Random.Range(xscatter.x, xscatter.y));
        StopCoroutine("Fire");
    }
}

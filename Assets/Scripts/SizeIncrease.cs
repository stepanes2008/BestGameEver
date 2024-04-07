using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeIncrease : MonoBehaviour
{
    public float stunTime = 5f;
    public float invokeTime = 3f;
    public float increaseSpeed;
    private float soundTime = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "FirstSmoke")
        {
            Destroy(gameObject);
        }
        //GetComponent<AudioSource>().Play();
        transform.localScale = Vector3.zero;
        Invoke("StopSound", soundTime);
        Invoke("DestroyExplosion", invokeTime);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.localScale += Vector3.one * Time.deltaTime * increaseSpeed;
    }
    void DestroyExplosion()
    {
        Destroy(gameObject);
    }
    void StopSound()
    {
        GetComponent<AudioSource>().Stop();
    }
}

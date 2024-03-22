using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeIncrease : MonoBehaviour
{
    public float invokeTime = 3f;
    public float increaseSpeed;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.zero;
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
}

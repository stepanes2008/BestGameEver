using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeIncrease : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.zero;
        Invoke("DestroyExplosion", 3);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.localScale += Vector3.one * Time.deltaTime;
    }
    void DestroyExplosion()
    {
        Destroy(gameObject);
    }
}

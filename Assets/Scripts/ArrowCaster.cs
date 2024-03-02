using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCaster : MonoBehaviour
{
    public ArrowController Arrow;
    public GameObject SpawnPoint;
    private float _reloadDelay = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnArrow();
    }
    private void SpawnArrow()
    {
        if (_reloadDelay > 0f)
        {
            _reloadDelay += Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0))
        {
            _reloadDelay += Time.deltaTime;
        }
        if (Input.GetMouseButtonUp(0) && _reloadDelay >= 0.5f)
        {
            _reloadDelay = 0f;
            var Arr = Instantiate(Arrow, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
//            Arr.transform.position = SpawnPoint.transform.position;
            Arr.transform.eulerAngles = new Vector3(SpawnPoint.transform.eulerAngles.x + 90f, SpawnPoint.transform.eulerAngles.y, SpawnPoint.transform.eulerAngles.z);
        }
        if (Input.GetMouseButtonUp(0) && _reloadDelay <= 0.5f)
        {
            _reloadDelay = 0f;
        }
    }
}

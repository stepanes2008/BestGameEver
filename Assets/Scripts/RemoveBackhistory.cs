using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBackhistory : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Player.GetComponent<Move>().enabled = true;
            Player.GetComponent<CameraRotation>().enabled = true;
            Player.GetComponent<PlayerHealth>().enabled = true;
            Player.GetComponent<ArrowCaster>().enabled = true;
            Player.GetComponent<UltimateHex>().enabled = true;
            Camera.GetComponent<RotateByX>().enabled = true;
            gameObject.SetActive(false);
        }
    }
}

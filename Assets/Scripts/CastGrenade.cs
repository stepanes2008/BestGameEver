using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastGrenade : MonoBehaviour
{
    public float stunTime = 5f;
    public GameObject Grenade;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(stunTime);
        if (Input.GetMouseButtonDown(1))
        {
            Player.GetComponent<Animator>().SetTrigger("ThrowGrenade");
            Invoke("Cast", 0.5f);
        }
    }

    void Cast()
    {
        var grenade = Instantiate(Grenade, transform.position, transform.rotation);
        grenade.GetComponent<Rigidbody>().AddForce(transform.forward * 400f);
        grenade.GetComponent<Grenade>().stunTime = stunTime;
    }
}

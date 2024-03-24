using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastGrenade : MonoBehaviour
{
    public GameObject Grenade;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Player.GetComponent<Animator>().SetTrigger("ThrowGrenade");
            Invoke("Cast", 2.2f);
        }
    }

    void Cast()
    {
        var grenade = Instantiate(Grenade, transform.position, transform.rotation);
        grenade.GetComponent<Rigidbody>().AddForce(transform.forward * 500f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadOnESC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GetComponent<PlayerHealth>().IsDead)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

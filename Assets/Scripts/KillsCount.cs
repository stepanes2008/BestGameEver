using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillsCount : MonoBehaviour
{
    public bool Win;
    public Animator PlayerAnimator;
    public GameObject VictoryScreen;
    public GameObject Camera;
    public int kills = 0;
    public float KillsToWin;
    public GameObject Text;
    public GameObject VictoryText;
    public AudioClip winSound;
    // Update is called once per frame
    void Update()
    {
        Text.GetComponent<TMP_Text>().text = kills.ToString();
        if (kills >= KillsToWin)
        {
            Win = true;
            GetComponent<AudioSource>().PlayOneShot(winSound);
            PlayerAnimator.SetTrigger("Victory");
            VictoryText.GetComponent<TMP_Text>().text = "Victory";
            VictoryScreen.SetActive(true);
            GetComponent<UltimateHex>().enabled = false;
            Camera.GetComponent<RotateByX>().enabled = false;
            GetComponent<CameraRotation>().enabled = false;
            GetComponent<Move>().enabled = false;
            enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchControl : MonoBehaviour {
    public GameObject _Laser;
    public GameObject _Retricle;
    public GameObject _Teleport;
    public GameObject Mover;
    int c = 0;
    int count = 0;
    bool dd;

    private static SwitchControl SC;
    // Use this for initialization
    void Start () {
        SC = this;
        _Teleport.SetActive(true);
        _Retricle.SetActive(false);
        _Laser.SetActive(false);
        Mover.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.GetDown(OVRInput.Button.One)){

            if (c % 2 == 0)
            {
                _Teleport.SetActive(false);
                _Retricle.SetActive(true);
                _Laser.SetActive(true);
            }
            else
            {
                _Teleport.SetActive(true);
                _Retricle.SetActive(false);
                _Laser.SetActive(false);
            }

            c++;
        }
       

    }

    public static void DisplayLaser()
    {
        SC._Retricle.SetActive(true);
        SC._Laser.SetActive(true);
    }

    public static void Disaple()
    {
        SC._Retricle.SetActive(false);
        SC._Laser.SetActive(false);
    }

    public static void DisplayMove()
    {
        SC._Teleport.SetActive(true);

    }

    public static void DisapleMove()
    {
        SC._Teleport.SetActive(false);
    }

    public static void DisplayMover()
    {
        SC.Mover.SetActive(true);
    }

    public static void DisapleMover()
    {
        SC.Mover.SetActive(false);
    }
}

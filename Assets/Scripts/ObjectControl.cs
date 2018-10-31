using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectControl : MonoBehaviour {

    private static ObjectControl Instance;


   // public ArcRaycaster arcRaycaster;
    //public Text txt;
    Vector3 ControllerPos;
    Vector2 touch;
    Quaternion Orig;
    Vector3 forward1;
    Vector3 up;
    int c;


    public GameObject _Laser;
    public GameObject _Retricle;
    public GameObject _Teleport;
    public GameObject Mover;

    float zee;
    public static int ObjInx;
    public static int MenInx;
    public static bool DoneChose;
    public static bool MovingWork;
    public bool RotatingWork;

    public static Vector3 Pos;

    int count = 0;
   
    public GameObject[] _SelectedObject;
    public GameObject _canv;
    public GameObject _cam;
    public GameObject _ParLaser;
    public GameObject _PublicPar;

    public static bool _DisActive;
    public static bool _MoveMent;
    private bool _stopMov;
    public static bool _Rotate;
    private Vector3 OrigDis;
    private Vector3 OrigScale;
    private Quaternion OrigRot;
   

    private void Awake()
    {
        
        Vector3 up = Vector3.up;
        Instance = this;
        forward1 = Vector3.zero;
    }

    // Use this for initialization
    void Start () {
        
        ObjInx = -1;
        MenInx = -1;
        _canv.SetActive(false);

        _Teleport.SetActive(true);
        _Retricle.SetActive(false);
        _Laser.SetActive(false);
        Mover.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            if (MovingWork)
            {
                _Laser.SetActive(true);
                _Retricle.SetActive(true);
                _Teleport.SetActive(false);
                Mover.SetActive(false);

                MovingWork = false;
            }
            else
            {
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

        if (Mover.active == true)
        {
            _canv.SetActive(false);
        }

        if (DoneChose)
        {
            _canv.SetActive(true);
            _canv.transform.position = _SelectedObject[ObjInx].transform.position;
            OrigDis = _SelectedObject[ObjInx].transform.position;
            OrigScale = _SelectedObject[ObjInx].transform.localScale;
            OrigRot = _SelectedObject[ObjInx].transform.rotation;
            _canv.transform.Translate(0,3f,0);
            _canv.transform.LookAt(_cam.transform.position);
            _canv.transform.Rotate(0, 180, 0);

            DoneChose = false;
        }

        

        if (MenInx == 0)
        {
            _canv.SetActive(false);
            _SelectedObject[ObjInx].SetActive(false);
            _DisActive = true;
            _MoveMent = false;
            _Rotate = false;
            MenInx = -1;
        }
        else if(MenInx == 1)
        {
            _canv.SetActive(false);

            _Laser.SetActive(false);
            _Retricle.SetActive(false);
            _Teleport.SetActive(false);
            Mover.SetActive(true);
           

            _DisActive = false;
            _MoveMent = true;
            MovingWork = true;
            MenInx = -1;

        }

        if (OVRInput.Get(OVRInput.Button.Back))
        {
            if (_DisActive)
            {
                _SelectedObject[ObjInx].SetActive(true);
               
            }

            if(_MoveMent)
            {
                _SelectedObject[ObjInx].transform.position = OrigDis;
                _SelectedObject[ObjInx].transform.rotation = OrigRot;
             
            }

            MenInx = -1;
            _MoveMent = false;
            _DisActive = false;
           
        }
	}
}

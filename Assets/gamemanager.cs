using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public Vector3 currentEulerAngles;
    public bool Povorachivaet;
    public WheelRotatingL rotL;
    public WheelRotatingR rotR;
    public Transform rul;
    private void Start()
    {
        Povorachivaet = false;
    }

    void FixedUpdate()
    {
        Povorachivaet = (rotL.povorachivaetL || rotR.povorachivaetR);
    }

    public void PovorotRulya() 
    {
        Povorachivaet = true;
        currentEulerAngles.y = rul.eulerAngles.y;
    }

}

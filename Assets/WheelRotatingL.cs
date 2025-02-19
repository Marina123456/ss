using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotatingL : MonoBehaviour
{
    public float whlRotate;
    public static float whlRotationSpd = 15f;
    public const float maxAngleMod = 35f;
    public gamemanager gm;
    public static Vector3 rotateWhl;
    public WheelRotatingR rotR;

    public bool povorachivaetL = false;
    public RaceCarControl.CarCntrl car;


    void FixedUpdate()
    {
        

        rotateWhl = transform.localEulerAngles;
        float SPD = car.currSpeed;

        if (povorachivaetL && SPD != 0) { gm.currentEulerAngles += new Vector3(0, -1f, 0) * Time.deltaTime * whlRotationSpd; }
        

        if (gm.currentEulerAngles.y < -maxAngleMod) { gm.currentEulerAngles.y = -maxAngleMod; }
        if (gm.currentEulerAngles.y > maxAngleMod) { gm.currentEulerAngles.y = maxAngleMod; }
        transform.localEulerAngles = gm.currentEulerAngles;
    }
    public void povL()
    {
        if (!rotR.povorachivaetR)
            povorachivaetL = true;
    }
   
    public void povLstop()
    {
        povorachivaetL = false;
    }
  
    
}

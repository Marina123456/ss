using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotating : MonoBehaviour
{
    public float whlRotate;
    public static float whlRotationSpd = 15f;
    public const float maxAngleMod = 35f;
    public gamemanager gm;
    public static Vector3 rotateWhl;

    public bool povorachivaetL = false;
    public bool povorachivaetR = false;
    public RaceCarControl.CarCntrl car;


    void FixedUpdate()
    {
        gm.Povorachivaet = (povorachivaetL || povorachivaetR);

        rotateWhl = transform.localEulerAngles;
        float SPD = car.currSpeed;

        if (povorachivaetL && SPD != 0) { gm.currentEulerAngles += new Vector3(0, -1f, 0) * Time.deltaTime * whlRotationSpd; }
        if (povorachivaetR && SPD != 0) { gm.currentEulerAngles += new Vector3(0, 1f, 0) * Time.deltaTime * whlRotationSpd; }

        if (gm.currentEulerAngles.y < -maxAngleMod) { gm.currentEulerAngles.y = -maxAngleMod; }
        if (gm.currentEulerAngles.y > maxAngleMod) { gm.currentEulerAngles.y = maxAngleMod; }
        transform.localEulerAngles = gm.currentEulerAngles;
    }
    public void povL()
    {
        if (!povorachivaetR)
            povorachivaetL = true;
    }
    public void povR()
    {
        if (!povorachivaetL)
            povorachivaetR = true;
    }
    public void povLstop()
    {
        povorachivaetL = false;
    }
    public void povRstop()
    {
        povorachivaetR = false;
    }
}

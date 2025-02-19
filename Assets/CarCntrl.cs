using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace RaceCarControl
{
    public class CarCntrl : MonoBehaviour
    {
        bool gazuet, tormozit, dvizenie, stoit;
        public const float acc = 8f;
        float accTime;
        public gamemanager gm;

        public const float posiSpeed = 40f;
        public const float antiSpeed = -20f;
        public float currSpeed;
        public TMP_Text speedText;

        void Start()
        {
            gazuet = false;
            tormozit = false;
            dvizenie = false;
            stoit = true;
            currSpeed = 0f;
        }

        static float spdAngle(float currSpeed, float angleSpeed, float posiSpeed, float antiSpeed, float whlAngle)
        {
            float ans = 0;
            float pos = posiSpeed / 2;
            float ant = antiSpeed / 2;
            if (currSpeed == pos) { ans = 5 * angleSpeed; }
            if (currSpeed == ant) { ans = 5 * angleSpeed; }
            if (currSpeed > pos) { ans = angleSpeed * 5 - (Time.deltaTime * currSpeed * 2); }
            if (currSpeed < ant) { ans = angleSpeed * 5 - (Time.deltaTime * currSpeed * 2); }
            if (currSpeed < pos && currSpeed >= 0) { ans = angleSpeed * 5 - (Time.deltaTime * currSpeed * 2); }
            if (currSpeed > ant && currSpeed <  0) { ans = angleSpeed * 5 - (Time.deltaTime * currSpeed * 2); }
            return ans * Time.deltaTime;
        }

        void FixedUpdate()
        {
            stoit = !(gazuet || tormozit || dvizenie);
            if (currSpeed < -8 || currSpeed > 8) { dvizenie = true; }
            speedText.text = currSpeed.ToString();

            Vector3 rotateCar = transform.eulerAngles;
            if (dvizenie && currSpeed > 0 && gm.Povorachivaet) { rotateCar.y -= Time.deltaTime * -gm.currentEulerAngles.y; }
            if (dvizenie && currSpeed > 0 && gm.Povorachivaet) { rotateCar.y += Time.deltaTime * gm.currentEulerAngles.y; }
            if (dvizenie && currSpeed < 0 && gm.Povorachivaet) { rotateCar.y -= Time.deltaTime * gm.currentEulerAngles.y; }
            if (dvizenie && currSpeed < 0 && gm.Povorachivaet) { rotateCar.y += Time.deltaTime * -gm.currentEulerAngles.y; }

            if (gazuet && accTime <= currSpeed/acc) { accTime += Time.deltaTime*10; }
            if (tormozit && accTime>=currSpeed/acc) { accTime -= Time.deltaTime*10; }

            currSpeed = acc * accTime;
            if (currSpeed > posiSpeed) { currSpeed = posiSpeed; }
            if (currSpeed < antiSpeed) { currSpeed = antiSpeed; }


            float ugolCar = Mathf.Deg2Rad * rotateCar.y;
            transform.position += new Vector3(currSpeed * Time.deltaTime * Mathf.Sin(ugolCar), 0, currSpeed * Time.deltaTime * Mathf.Cos(ugolCar));
            transform.rotation = Quaternion.Euler(rotateCar);
        }

        public void gaz()
        {
            if(!tormozit)
                gazuet = true;
        }
        public void tormoz()
        {
            if (!gazuet)
                tormozit = true;
        }

        public void gazStop()
        {
            gazuet = false;
        }
        public void tormozStop()
        {
            tormozit = false;
        }
    }
}
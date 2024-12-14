using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Popub_Book
{
    public class OpenBook : MonoBehaviour
    {
        public Transform leftside;
        public Transform rightside;
        public Vector3 targetScale = new Vector3(5.947747f, 5.947747f, 7.929536f);
        public Vector3 targetposition = new Vector3(-3.42966437f, 2.9719398f, -3.44442201f);
        public Vector3 targetpositionButterfly = new Vector3(4.34700012f, 2.37199998f, 1.21000004f);
        public Vector3 targetpositionBee = new Vector3(3.2579999f, 5.91499996f, 13.7060003f);
        public Vector3 targetpositionmainflower = new Vector3(3.30999994f, 5.79400015f, 14.5450001f);
        public Vector3 targetpositioncamera = new Vector3(5.23025799f, 6.54249954f, 13.9532461f);
        private Vector3 targetpositionButterflyafterbookopen;
        public Transform landscalleft;
        public Transform landscalright;
        public Transform Butterfly;
        public GameObject Bee;
        public GameObject MainFlower;
        public GameObject Bookcamera;
        public Transform sideofbook;
        private Vector3 originalScale;
        private Vector3 originalScaleright;
        private Vector3 originalpositionright;
        private Vector3 originalpositionbee;
        private Vector3 originalpositionmainflower;
        private Vector3 originalpositionButterfly;
        private Vector3 originalpositioncamera = new Vector3(11.0799999f,8.03892803f,13.5003252f);
        public float speed = 30F;
        public float scalspeed = 0.5F;
        bool bookopen;
        bool closebook;


        void Start()
        {
            originalpositionbee = Bee.transform.localPosition;
            originalpositionmainflower = MainFlower.transform.localPosition;
            Bee.SetActive(false);
            MainFlower.SetActive(false);
            originalScale = landscalleft.localScale;
            originalScaleright = landscalright.localScale;
            originalpositionright = landscalright.localPosition;
            originalpositionButterfly = Butterfly.localPosition;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                bookopen = true;
                closebook = false;
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                bookopen = false;
                closebook = true;
            }
            if (bookopen)
            {
                if (Quaternion.Angle(leftside.rotation, Quaternion.identity) < 1f)
                {
                    Bee.SetActive(true);
                    MainFlower.SetActive(true);
                    targetpositionButterflyafterbookopen = new Vector3(1.79999995f, 3.8900001f, 2.06999993f);
                    speed = 0;
                    landscalleft.localScale = targetScale;
                    landscalright.localScale = targetScale;
                    landscalright.localPosition = targetposition;
                    Bee.transform.localPosition = Vector3.Lerp(
                            Bee.transform.localPosition,
                            targetpositionBee,
                            scalspeed * Time.deltaTime
                    );
                    MainFlower.transform.localPosition = Vector3.Lerp(
                            MainFlower.transform.localPosition,
                            targetpositionmainflower,
                            scalspeed * Time.deltaTime
                    );
                    Butterfly.localPosition = Vector3.Lerp(
                            Butterfly.localPosition,
                            targetpositionButterflyafterbookopen,
                            0.2f * Time.deltaTime
                    );
                    Bookcamera.transform.LookAt(Butterfly);
                    Bookcamera.transform.localPosition = Vector3.Lerp(
                            Bookcamera.transform.localPosition,
                            targetpositioncamera,
                            0.2f * Time.deltaTime
                    );
                }
                else
                {
                    leftside.localRotation = Quaternion.Lerp(
                    leftside.localRotation,
                    Quaternion.Euler(new Vector3(0, 0, 0)),
                    scalspeed * Time.deltaTime
                    );
                    sideofbook.localRotation = Quaternion.Lerp(
                    sideofbook.localRotation,
                    Quaternion.Euler(new Vector3(90f, 0, 0)),
                    scalspeed * Time.deltaTime
                    );

                    if (Time.time > 0.6f)
                    {
                        landscalleft.localScale = Vector3.Lerp(
                            landscalleft.localScale,
                            targetScale,
                            scalspeed * Time.deltaTime
                        );
                        landscalright.localScale = Vector3.Lerp(
                                landscalright.localScale,
                                targetScale,
                                scalspeed * Time.deltaTime
                            );
                        landscalright.localPosition = Vector3.Lerp(
                                landscalright.localPosition,
                                targetposition,
                                scalspeed * Time.deltaTime
                        );
                        Butterfly.localPosition = Vector3.Lerp(
                                Butterfly.localPosition,
                                targetpositionButterfly,
                                scalspeed * Time.deltaTime
                        );
                    }
                }
            }

            if (closebook)
            {
                if(leftside.localRotation != Quaternion.Euler(new Vector3(180, 0, 0)))
                {
                    leftside.localRotation = Quaternion.Lerp(
                    leftside.localRotation,
                    Quaternion.Euler(new Vector3(180, 0, 0)),
                    scalspeed * Time.deltaTime
                    );
                    sideofbook.localRotation = Quaternion.Lerp(
                    sideofbook.localRotation,
                    Quaternion.Euler(new Vector3(0, 0, 0)),
                    scalspeed * Time.deltaTime
                    );

                    Bee.SetActive(false);
                    MainFlower.SetActive(false);
                    Butterfly.localPosition = Vector3.Lerp(
                            Butterfly.localPosition,
                            originalpositionButterfly,
                            scalspeed * Time.deltaTime
                    );
                    
                    Bookcamera.transform.localPosition = Vector3.Lerp(
                            Bookcamera.transform.localPosition,
                            originalpositioncamera,
                            scalspeed* Time.deltaTime
                    );

                        landscalleft.localScale = Vector3.Lerp(
                            landscalleft.localScale,
                            originalScale,
                            scalspeed * Time.deltaTime
                        );
                        landscalright.localScale = Vector3.Lerp(
                                landscalright.localScale,
                                originalScaleright,
                                scalspeed * Time.deltaTime
                            );
                        landscalright.localPosition = Vector3.Lerp(
                                landscalright.localPosition,
                                originalpositionright,
                                scalspeed * Time.deltaTime
                        );
                        Butterfly.localPosition = Vector3.Lerp(
                                Butterfly.localPosition,
                                originalpositionButterfly,
                                scalspeed * Time.deltaTime
                        );
                        Bee.transform.localPosition = Vector3.Lerp(
                                Bee.transform.localPosition,
                                originalpositionbee,
                                scalspeed * Time.deltaTime
                        );
                        MainFlower.transform.localPosition = Vector3.Lerp(
                                MainFlower.transform.localPosition,
                                originalpositionmainflower,
                                scalspeed * Time.deltaTime
                        );
                }
                
            }

        }

    }
}

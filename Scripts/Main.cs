using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



class Main : MonoBehaviour
{

    //    Звук
    //    public GameObject audio_object;
    //    private AudioSource[] my_audio;
    //    my_audio = audio_object.GetComponents<AudioSource>();
    //    GetComponent<AudioSource>().Play();


    //   public AudioClip myClip;
    //   void Start()
    //   {
    //   audio.PlayOneShot(myClip);


    public const float ae  =   149_597_870.691f; //149597870.691f;
    public       float aeg =        10_000.000f;


  //  public static GameObject go, myGameObject; //, Spaceship;


    public static GameObject CENTRE;


    void Start()
    {
        //  Объект визуализации центра
        CENTRE = ObjectFactory.CreatePrimitive(PrimitiveType.Sphere);
        CENTRE.name = "CENTRE";
        CENTRE.transform.position = Vector3.zero ;
        CENTRE.transform.localScale = new Vector3(0.006f, 0.006f, 0.006f);
        Renderer rendCENTRE = CENTRE.GetComponent<Renderer>();
        rendCENTRE.material.color = Color.yellow;

        //     CENTRE.AddComponent<AudioSource>();

        /*
                //    Create(string name, int lengthSamples, int channels, int frequency, bool stream);
                AudioClip myClip = AudioClip.Create("flight", 500000, 1, 44100, false);
                AudioSource aud = CENTRE.GetComponent<AudioSource>();
                aud.volume /= 2;
                aud.loop    = true;

                aud.clip    = myClip;
                aud.Play();

        */

        // GameObject go = new GameObject();
        //  go.AddComponent<spaceship>();   // .AddComponent<spaceship>();
        //  spaceship.AddComponent<spaceship>();   // .AddComponent<spaceship>();


        /*
                CameraSkybox.name = "CameraSkybox";
                CameraSkybox.transform.localEulerAngles = new Vector3(0f, 0f, 60f);
                //   CameraSkybox.targetDisplay. = target;

       */



        GameObject Spaceship = new GameObject();
        Spaceship = ObjectFactory.CreatePrimitive(PrimitiveType.Cube);

        Spaceship.name = "Spaceship";
        Spaceship.transform.localScale = new Vector3(.6f, .2f, 1.9f);
        Spaceship.transform.position = Vector3.zero;
       
        Spaceship.transform.position = new Vector3(4000f, 0, 0);
        Spaceship.transform.Rotate(new Vector3(0, -45, 0));

        Renderer rendSpaceship = Spaceship.GetComponent<Renderer>();
        rendSpaceship.material.color = Color.gray;
     //   rendSpaceship.material.

        Spaceship.AddComponent<Rigidbody>();
        Spaceship.GetComponent<Rigidbody>().isKinematic = true;
        Spaceship.GetComponent<BoxCollider>().size = new Vector3(0.009f, 0.004f, 0.006f);
        Spaceship.GetComponent<BoxCollider>().isTrigger = true;

        Spaceship.AddComponent<PlayerController>();


        Camera.main.Reset();
        Camera.main.transform.parent = Spaceship.transform;
        Camera.main.transform.localPosition =
            new Vector3(0, 
                        Spaceship.transform.position.y +  2f,
                        Spaceship.transform.position.z - 2f);
        Camera.main.transform.Rotate(new Vector3(0, -45, 0));
        Camera.main.farClipPlane = 1000_000f;



        //       Camera.main.transform.localPosition = spaceship.transform.localPosition;



        // Автоматическое удаление объекта 
        // ~spaceship() {Debug.Log("Ded spaceship");}






        // временно
        aeg = 10000f; // 149597870.691f;           Наклонение к плоскости Млечного Пути    60,19°


        Planet P00000 = new Planet("P000000", 20,2000.0f, new Vector3(0f, 0f, 0f));//  R 696000,7 км
        Planet P00001 = new Planet("P000001", 15,20.439f, new Vector3(0f, 0f, 1100f));//  R   2439,7 км  L 0,386ае     m 0,055274 земной v 47,36 км/с  накл-ние 3,38°  относительно солн. экватора
        Planet P00002 = new Planet("P000002", 10,60.051f, new Vector3(0f, 0f, 1400f));//  R   6051,8 km  L 0,72333199  m 0,815    земной v 35,02 км/с  накл-ние 3,86°
        Planet P00003 = new Planet("P000003", 13,60.365f, new Vector3(0f, 0f, 2400f));//  R   6365,0 km  L 1,00000261  m 1        земной v 29,79 км/с  накл-ние 7,155°
        Planet P00004 = new Planet("P000004", 11,30.385f, new Vector3(0f, 0f, 2500f));//  R   3385,0 km  L 1,5235      m 0,107    земной v 24,13 км/с  накл-ние 5,65°
        Planet P00005 = new Planet("P000005", 5,290.911f, new Vector3(0f, 0f, 2800f));//  R  69911,0 km  L 5,2042665   m 317,8    земной v 13,07 км/с  накл-ние 6,09°  Наклон оси 3,13°
        Planet P00006 = new Planet("P000006", 4,200.1f, new Vector3(0f, 0f, 3500f));
        Planet P00007 = new Planet("P000007", 7,50.35f, new Vector3(0f, 0f, 4400f));
        Planet P00008 = new Planet("P000008", 8,50.9f, new Vector3(0f, 0f, 5300f));
        Planet P00009 = new Planet("P000009", 9,200.1f, new Vector3(0f, 0f, 5900f));
        Planet P00010 = new Planet("P000010", 1,50.35f, new Vector3(0f, 0f, 6800f));
        Planet P00011 = new Planet("P000011", 2,50.9f, new Vector3(0f, 0f, 7900f));
        Planet P00012 = new Planet("P000012", 3,20.439f, new Vector3(0f, 0f, 8300f));//  R   2439,7 км  L 0,386ае     m 0,055274 земной v 47,36 км/с  накл-ние 3,38°  относительно солн. экватора
        Planet P00013 = new Planet("P000013", 4,60.051f, new Vector3(0f, 0f, 8800f));//  R   6051,8 km  L 0,72333199  m 0,815    земной v 35,02 км/с  накл-ние 3,86°
        Planet P00014 = new Planet("P000014", 5,60.365f, new Vector3(0f, 0f, 10400f));//  R   6365,0 km  L 1,00000261  m 1        земной v 29,79 км/с  накл-ние 7,155°
        Planet P00015 = new Planet("P000015", 6,30.385f, new Vector3(0f, 0f, 11500f));//  R   3385,0 km  L 1,5235      m 0,107    земной v 24,13 км/с  накл-ние 5,65°
        Planet P00016 = new Planet("P000016", 7,290.911f, new Vector3(0f, 0f, 12500f));//  R  69911,0 km  L 5,2042665   m 317,8    земной v 13,07 км/с  накл-ние 6,09°  Наклон оси 3,13°
        Planet P00017 = new Planet("P000017", 8,200.1f, new Vector3(0f, 0f, 14000f));
        Planet P00018 = new Planet("P000018", 9,350.35f, new Vector3(0f, 0f, 20_000f));
        Planet P00019 = new Planet("P000019", 1,550.35f, new Vector3(0f, 0f, 100_000f));
        Planet P00020 = new Planet("P000020", 2,1550.35f, new Vector3(0f, 0f, 200_000f));
        Planet P00021 = new Planet("P000021", 3,9550.35f, new Vector3(0f, 0f, 900_000f));




        /*
               // Солнечная система
               Planet.Generation("P000", 700.000f, 0f, 0f, 0f);          //  R 696000,7 км
               Planet.Generation("P100",   2.439f, 0f, 0f, aeg * 0.387f);//  R   2439,7 км  L 0,386ае (57 744 778,086)     m 0,055274 земной v 47,36 км/с  накл-ние 3,38°  относительно солн. экватора
               Planet.Generation("P200",   6.051f, 0f, 0f, aeg * 0.723f);//  R   6051,8 km  L 0,72333199  m 0,815    земной v 35,02 км/с  накл-ние 3,86°
               Planet.Generation("P300",   6.365f, 0f, 0f, aeg         );//  R   6365,0 km  L 1,00000261  m 1        земной v 29,79 км/с  накл-ние 7,155°
               Planet.Generation("P400",   3.385f, 0f, 0f, aeg * 1.524f);//  R   3385,0 km  L 1,5235      m 0,107    земной v 24,13 км/с  накл-ние 5,65°
               Planet.Generation("P500",  69.911f, 0f, 0f, aeg * 5.203f);//  R  69911,0 km  L 5,2042665   m 317,8    земной v 13,07 км/с  накл-ние 6,09°  Наклон оси 3,13°
               Planet.Generation("P600",  60.100f, 0f, 0f, aeg * 9.539f);
               Planet.Generation("P700",   5.350f, 0f, 0f, aeg * 19.19f);
               Planet.Generation("P800",   5.900f, 0f, 0f, aeg * 30.06f);
       */





    }
    private void FixedUpdate() 
    {

    }
}

/*
GameObject.CreatePrimitive.

Sphere Capsule Cylinder Cube Plane Quad
Selection.activeGameObject = ObjectFactory.CreatePrimitive(PrimitiveType.Cube);


public GameObject hand;
hand = GameObject.Find("Hand");





*/

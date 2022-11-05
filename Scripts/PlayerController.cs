using System;
using UnityEngine;




public class PlayerController: MonoBehaviour
{

    public float speed = 0.0f;
    public Vector3 move;
    public float sensitivity = 1000.0f;


    public float RotationSpeedW     = 0f;
    public float RotationSpeedH     = 0f;
  //public float dumpAmt            = 2f;
    public float speedX, speedY, speedZ, speedOldX, speedOldY, speedOldZ = 0f;


    private void Awake()    {}


    //  private float _rotationX=1f;
    //   private float ad_LR=0f, ws_FB=0f;

    private void Update()

    {
        //      Debug.Log("rr");


        // тормоз
        if (Input.GetKeyDown("`") || Input.GetKeyDown("0"))
        {
            move = new Vector3(0f, 0f, 0f);
            speed = 0f;
            RotationSpeedW = 0f;
            RotationSpeedH = 0f;
            speedX = 0f;
            speedY = 0f;
            speedZ = 0f;
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            // Перевороты  расчет   
            if (Input.GetKeyDown(KeyCode.A)) RotationSpeedW += 1f;
            if (Input.GetKeyDown(KeyCode.D)) RotationSpeedW -= 1f;

            if (Input.GetKeyDown(KeyCode.W)) RotationSpeedH += 1f; // Math.Abs(RotationSpeed - 20f)
            if (Input.GetKeyDown(KeyCode.S)) RotationSpeedH -= 1f;
        }
        else
        {
            // выбор скорости
            if (Input.GetKeyDown(KeyCode.Alpha1))   speed  =   10f;
            if (Input.GetKeyDown(KeyCode.Alpha2))   speed  =   50f;
            if (Input.GetKeyDown(KeyCode.Alpha3))   speed  =  100f;

            // рaсчет для Vectora3
            if (Input.GetKeyDown(KeyCode.D)) speedX += speed;
            if (Input.GetKeyDown(KeyCode.A)) speedX -= speed;
            if (Input.GetKeyDown(KeyCode.W)) speedZ += speed;
            if (Input.GetKeyDown(KeyCode.S)) speedZ -= speed;

            //Применение выбранной скорости
            //if (speedX != speedOldX) speedX += speed;
            //if (speedX != speedOldX) speedX -= speed;
            //if (speedZ != speedOldZ) speedZ += speed; 
            //if (speedZ != speedOldZ) speedZ -= speed;

            if (Input.GetKeyDown(KeyCode.PageUp))   { speedX *= 2f; speedZ *= 2f; }
            if (Input.GetKeyDown(KeyCode.PageDown)) { speedX /= 2f; speedZ /= 2f; }

            //if (speedX != speedOldX && speedX > 0) { speedX += speed; speedOldX = speedX; }
            //if (speedX != speedOldX && speedX < 0) { speedX -= speed; speedOldX = speedX; }
            //if (speedZ != speedOldZ && speedZ > 0) { speedZ += speed; speedOldZ = speedZ; }
            //if (speedZ != speedOldZ && speedZ < 0) { speedZ -= speed; speedOldZ = speedZ; }

            //if (speedX != speedOldX) { speedOldX = speedX; }
            //if (speedZ != speedOldZ) { speedOldZ = speedZ; }

            // Составление Vectora3
            //move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

            move = new Vector3(speedX,speedY,speedZ);
        }


        // Перевороты  действие
        if (RotationSpeedW != 0f) transform.Rotate((RotationSpeedW < 0f ? new Vector3(0f, 0f, RotationSpeedW) : new Vector3(0f, 0f, RotationSpeedW)) * Time.deltaTime, Space.World);   
        if (RotationSpeedH != 0f) transform.Rotate((RotationSpeedH > 0f ? new Vector3(RotationSpeedH, 0f, 0f) : new Vector3(RotationSpeedH, 0f, 0f)) * Time.deltaTime, Space.World); 

        // Движение  действие
        if (move != new Vector3(0, 0, 0))   transform.Translate(move * Time.deltaTime);

        // Старый вариант движения корабля
              move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;


        Debug.Log(move + "/          speed/" + speed + "/        speedXYZ/" + speedX + "/" + speedY + "/" + speedZ + "/          speedOldXZ/" + speedOldX + "/" + speedOldY + "/" + speedOldZ + "/               speedXYZ/ " + speedX + "/" + speedY + "/" + speedZ + "/");
        //     Debug.Log("/     speed: " + speed + "     RotationSpeedW: " + RotationSpeedW + "     RotationSpeedH: " + RotationSpeedH);



        // МЫШЬ   Camera.main.
        transform.Rotate(
            Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime,
            Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime,
            0);


    }
}








//  if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))

/*
using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
//Переменные ***************************************************
  public float horizontalSpeed = 2.0F;
     public float verticalSpeed = 2.0F;
  public float speed = 1f;  
  private Transform myTransform;
//**************************************************************
   
  void Start(){
   myTransform = transform; // оптимизация
   Screen.showCursor = false; //убрать курсор
  }
   
     void Update() {     
         float h = horizontalSpeed * Input.GetAxis("Mouse X");
         float v = verticalSpeed * Input.GetAxis("Mouse Y");
    
         myTransform.Rotate(v, h, 0);

   }
     }

------------------------------------------------------------------
а вот самого корабля
------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {
  //пременные***************************************
  public Transform target;//цель
  public int moveSpeed; //скорость перемещения
  public int rotationSpeed; //скорость поворота
  public float rot = 1.0f;
   
  private Transform myTransform ;//временная переменная для хранения ссылки
                    //на свойство transform (это оптимизация)
  //************************************************
  void Awake (){
        //ссылаемся на свойство transform для того чтобы сократить время
        //обращения к нему в скрипте
        myTransform = transform;
  }

  // начальная инициализация
  void Start () {
        //ищем обьект по тегу Player
        GameObject go = GameObject.FindGameObjectWithTag("aim");
        //и делаем его целью
        target = go.transform;    
  }
   
  // Update is called once per frame
  void Update () {
   //чертим вспомогательную линию от нас к игроку
   Debug.DrawLine(target.position, myTransform.position,
                      Color.yellow);
   //поворачивемся в сторону игрока
   myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
                       Quaternion.LookRotation(target.position - myTransform.position),
                       rotationSpeed * Time.deltaTime);
   //усли позволяет дистанция двигаемся к игроку
   if(moveSpeed >0){
   //двигаемся к цели
   myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;  
    
   rot = -5*Input.GetAxis("Mouse X");
   myTransform.Rotate(0,0,rot);
   }
  }
}
*/
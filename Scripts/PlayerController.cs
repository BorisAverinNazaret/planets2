using System;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    public float speed = 0.0f, speedRL =2.00f;
    public Vector3 move;
    public float sensitivity = 1000.0f;


    public float RoSpeedW     = 0f;
    public float RoSpeedH     = 0f;
    public float RoSpeedX, RoSpeedY, RoSpeedZ = 0f;


    private void Update()
    {
        // тормоз
        if (Input.GetKeyDown("`") || Input.GetKeyDown("0"))
        {
            move = new Vector3(0f, 0f, 0f);
            speed = 0f; 
            speedRL = 2f;
            RoSpeedW = 0f;
            RoSpeedH = 0f;
            RoSpeedX = 0f;
            RoSpeedY = 0f;
            RoSpeedZ = 0f;
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            // Перевороты  расчет   
            if (Input.GetKeyDown(KeyCode.A)) RoSpeedW += 4f;
            if (Input.GetKeyDown(KeyCode.D)) RoSpeedW -= 4f;

            if (Input.GetKeyDown(KeyCode.W)) RoSpeedH += 4f; // Math.Abs(RotationSpeed - 20f)
            if (Input.GetKeyDown(KeyCode.S)) RoSpeedH -= 4f;
        }
        else
        {
            // выбор скорости
            if (Input.GetKeyDown(KeyCode.Alpha1)) speed = 5f;
            if (Input.GetKeyDown(KeyCode.Alpha2)) speed = 10f;
            if (Input.GetKeyDown(KeyCode.Alpha3)) speed = 20f;
            if (Input.GetKeyDown(KeyCode.Alpha4)) speed = 100f;
            if (Input.GetKeyDown(KeyCode.Alpha5)) speed = 500f;

            // рaсчет для Vectora3
            if (Input.GetKeyDown(KeyCode.D)) RoSpeedX += speed;
            if (Input.GetKeyDown(KeyCode.A)) RoSpeedX -= speed;
            if (Input.GetKeyDown(KeyCode.W)) RoSpeedZ += speed;
            if (Input.GetKeyDown(KeyCode.S)) RoSpeedZ -= speed;
            if (Input.GetKeyDown(KeyCode.E)) RoSpeedY += speedRL;
            if (Input.GetKeyDown(KeyCode.Q)) RoSpeedY -= speedRL;

            if (Input.GetKeyDown(KeyCode.PageUp)) { RoSpeedX *= 2f; RoSpeedZ *= 2f; }
            if (Input.GetKeyDown(KeyCode.PageDown)) { RoSpeedX /= 2f; RoSpeedZ /= 2f; }

            move = new Vector3(RoSpeedX, RoSpeedY, RoSpeedZ);
        }

        // Действие движение WSDA
        if (move != new Vector3(0, 0, 0)) transform.Translate(move * Time.deltaTime);
        // Движение  поворот корпуса в лево право 
        if (RoSpeedY != 0) transform.Rotate(new Vector3(0f, RoSpeedY, 0) * Time.deltaTime, Space.Self);
      
        // Старый вариант движения корабля
        // move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;


       //     Debug.Log(move + "/          speed/" + speed + "/        RoSpeedXYZ/" + RoSpeedX + "/" + RoSpeedY + "/" + RoSpeedZ + "/              RoSpeedXYZ/ " + RoSpeedX + "/" + RoSpeedY + "/" + RoSpeedZ + "/");

        // Перевороты  действие
        if (RoSpeedW != 0f) 
            transform.Rotate(new Vector3(0f, 0f, RoSpeedW) * Time.deltaTime, Space.Self);
        if (RoSpeedH != 0f) 
            transform.Rotate(new Vector3(RoSpeedH, 0f, 0f) * Time.deltaTime, Space.Self);

        // МЫШЬ   Camera.main.
        Camera.main.transform.Rotate(
            0, //Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime,
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
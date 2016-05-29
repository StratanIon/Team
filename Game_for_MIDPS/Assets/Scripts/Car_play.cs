using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Car_play : MonoBehaviour {

     WheelJoint2D[] wheeljoint;
     JointMotor2D frontwheel;
     JointMotor2D backwheel;

     public float maxSpeed = -1000f;
     private float maxBackSpeed = 1500f;
     private float acceleration = 250f;
     private float deacceleration = -100f;
     public float breackForce = 3000f;
     private float gravity = 9.8f;
     private float angleCar = 0f;

     public bool grounded = false;
     public LayerMask map;
     public Transform bwheel;

    public Text coinsText;
    private int coinsInt = 0;

     public ClickScript[] ControlCar;
	// Use this for initialization
	void Start () {

          wheeljoint = gameObject.GetComponents<WheelJoint2D>();
          backwheel = wheeljoint[1].motor;
          frontwheel = wheeljoint[0].motor;
	
	}
	
	// Update is called once per frame

    void Update ()
    {
        grounded = Physics2D.OverlapCircle(bwheel.transform.position, 0.25f, map);

        coinsText.text = coinsInt.ToString();
    }

	void FixedUpdate () {
          frontwheel.motorSpeed = backwheel.motorSpeed;

          angleCar = transform.localEulerAngles.z;

          if(angleCar >=180)
          {
               angleCar = angleCar - 360;
          }
        if (grounded == true)
        {

            if (ControlCar[0].clickedIs == true)
            {
                backwheel.motorSpeed = Mathf.Clamp(backwheel.motorSpeed - (acceleration - gravity * Mathf.PI * (angleCar / 180) * 80) * Time.deltaTime, maxSpeed, maxBackSpeed);
            }

           else if ((backwheel.motorSpeed < 0) || ControlCar[0].clickedIs == false && backwheel.motorSpeed < 0 || (ControlCar[0].clickedIs == false && backwheel.motorSpeed == 0 && angleCar < 0))
            {
                backwheel.motorSpeed = Mathf.Clamp(backwheel.motorSpeed - (deacceleration - gravity * Mathf.PI * (angleCar / 180) * 80) * Time.deltaTime, maxSpeed, 0);
            }

             if ((ControlCar[0].clickedIs == false && backwheel.motorSpeed > 0) || (ControlCar[0].clickedIs == false && backwheel.motorSpeed == 0 && angleCar > 0))
            {
                backwheel.motorSpeed = Mathf.Clamp(backwheel.motorSpeed - (-deacceleration - gravity * Mathf.PI * (angleCar / 180) * 80) * Time.deltaTime, 0, maxSpeed);
            }
        }

        else if (ControlCar[0].clickedIs == false && backwheel.motorSpeed < 0)
        {
            backwheel.motorSpeed = Mathf.Clamp(backwheel.motorSpeed + deacceleration * Time.deltaTime, maxSpeed, 0);
        }
        else if (ControlCar[0].clickedIs == false && backwheel.motorSpeed > 0)
        {
            backwheel.motorSpeed = Mathf.Clamp(backwheel.motorSpeed - deacceleration * Time.deltaTime, 0, maxBackSpeed);
        }

          if(ControlCar[1].clickedIs == true && backwheel.motorSpeed > 0)
          {
               backwheel.motorSpeed = Mathf.Clamp(backwheel.motorSpeed - breackForce * Time.deltaTime, 0, maxBackSpeed);

          }

          else if (ControlCar[1].clickedIs == true && backwheel.motorSpeed < 0)
          {
               backwheel.motorSpeed = Mathf.Clamp(backwheel.motorSpeed + breackForce * Time.deltaTime, maxBackSpeed, 0);
          }

          wheeljoint[1].motor = backwheel;
          wheeljoint[0].motor = frontwheel;

     }

    void OnTriggerEnter2D (Collider2D coins)
    {
        Destroy(coins.gameObject);
        coinsInt++;
    }
    

	}


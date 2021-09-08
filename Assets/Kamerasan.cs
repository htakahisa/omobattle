using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Kamerasan : MonoBehaviour
{
    Transform tf; //Main CameraのTransform
    Camera cam; //Main CameraのCamera
    float zoom = 1f;

    

    private float rotateSpeed = 2.0f;
    private float walkSpeed = 0.14f;
    private float upSpeed = 0.2f;

    private float gravity = 0.01f;
    private float gravityX = 1.07f;
    private float gravitySum = 0.05f;

    private float jumpt = 0.1f;
    private float jumpTime = 99f;

    CharacterController controller;


    private bool up;
    private bool down;
    private bool right;
    private bool left;
    private bool jump;

    public void setUp(bool b) {
        this.up = b;
    }
    public void setDown(bool b) {
        this.down = b;
    }
    public void setRight(bool b) {
        this.right = b;
    }
    public void setLeft(bool b) {
        this.left = b;
    }
    public void setJump(bool b) {
        this.jump = b;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.controller = GetComponent<CharacterController>();
        // マウスを真ん中でロックする
        Cursor.lockState = CursorLockMode.Locked;

        controller = GetComponent<CharacterController>();

        cam = GetComponent<Camera>();
        this.zoom = cam.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        


        if (Input.GetKey(KeyCode.Z)) {
            
            cam.fieldOfView = Mathf.Clamp(10f, 0.1f, 45f);
        } else {
            cam.fieldOfView = this.zoom;
        }

            jumpTime += Time.deltaTime;

        float moveX = 0;
        float moveZ = 0;
        float moveY = 0;

        if (Input.GetKey(KeyCode.D) || right) {

            moveX = transform.right.x * walkSpeed;
            moveZ = transform.right.z * walkSpeed;
            Vector3 direction = new Vector3(moveX, moveY, moveZ);
            this.controller.Move(direction);
        }
        if (Input.GetKey(KeyCode.A) || left) {

            moveX = transform.right.x * walkSpeed * -1;
            moveZ = transform.right.z * walkSpeed * -1;
            Vector3 direction = new Vector3(moveX, moveY, moveZ);
            this.controller.Move(direction);
        }
        if (Input.GetKey(KeyCode.W) || up) {

            moveX = transform.forward.x * walkSpeed;
            moveZ = transform.forward.z * walkSpeed;
            Vector3 direction = new Vector3(moveX, moveY, moveZ);
            this.controller.Move(direction);
        }
        if (Input.GetKey(KeyCode.S) || down) {
            moveX = transform.forward.x * walkSpeed * -1;
            moveZ = transform.forward.z * walkSpeed * -1;
            Vector3 direction = new Vector3(moveX, moveY, moveZ);
            this.controller.Move(direction);
        }

        if (Input.GetKey(KeyCode.Space) || jump) {

            // ジャンプ中ではないなら初期化
            if (jumpTime >= jumpt) {
                jumpTime = 0;
            }


            //moveY = transform.up.y * upSpeed;

            //Debug.Log("up:" + moveY);
            //transform.Translate(0, 0.3f, 0);
        }
        //if (Input.GetKey(KeyCode.LeftShift)) {
        //    moveY = transform.up.y * upSpeed * -1;
        //}



        // 重力
        //Debug.Log(charaCon.isGrounded);
        if (controller.isGrounded) {
            // 地面に着いたら初期化
            gravitySum = gravity;
        } else {
            // 地面についてないとき
            gravitySum = gravitySum * gravityX;

            if (jumpTime < jumpt) {
                // ジャンプ中
                moveY = gravitySum * -1 + transform.up.y * upSpeed;
            } else {
                moveY = gravitySum * -1;
            }


            //Debug.Log(moveY);
        }



        Vector3 direction1 = new Vector3(moveX, moveY, moveZ);
        this.controller.Move(direction1);


        this.rotateCamera();


    }

    //カメラを回転させる関数
    private void rotateCamera() {
        //Vector3でX,Y方向の回転の度合いを定義
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, Input.GetAxis("Mouse Y") * rotateSpeed, 0);

        //transform.RotateAround()をしようしてメインカメラを回転させる
        transform.RotateAround(transform.position, Vector3.up, angle.x);
        transform.RotateAround(transform.position, transform.right, -angle.y);








    }
}

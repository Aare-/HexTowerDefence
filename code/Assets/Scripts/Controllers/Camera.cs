using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Controllers {
    class Camera:MonoBehaviour{

        public float rotationSpeed = 10f;
        public float moveSpeed = 5f;
        public float translation;

        

        void Update(){
            CameraHandler();
        }

        public void CameraHandler(){
            Rotate();
            Move();
        }

        private void Rotate(){
            if (Input.GetMouseButton(1)) {
                float k15k = Input.GetAxis("Mouse X");
                gameObject.transform.Rotate(0,k15k,0);
                //TODO -> we should change camera in production
                /*gameObject.transform.LookAt(Vector3.zero);
                gameObject.transform.Translate(((k15k > 0) ? Vector3.right : Vector3.left) * Time.deltaTime);*/
            }
        }
        private void Move(){
            translation = Time.deltaTime*moveSpeed;
            

            if (Input.GetKey("w")) {
                gameObject.transform.Translate(0,0,translation);
            }
            if (Input.GetKey("a")) {
                gameObject.transform.Translate(-translation, 0, 0);
            }
            if (Input.GetKey("s")) {
                gameObject.transform.Translate(0, 0, -translation);
            }
            if (Input.GetKey("d")) {
                gameObject.transform.Translate(translation, 0, 0);
            }
        }
        

    }
}

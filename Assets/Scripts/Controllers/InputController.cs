using UnityEngine;

namespace TPS.Script.Controllers
{
    public class InputController : MonoBehaviour
    {
        public float Vertical;
        public float Horizontal;
        public Vector2 MouseInput;

        public bool Fire1;
        public bool Reload;
        public bool Iswalking;
        public bool IsCrouched;


        void Update()
        {

            Vertical = Input.GetAxis("Vertical");
            Horizontal = Input.GetAxis("Horizontal");
            MouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            Fire1 = Input.GetButton("Fire1");
            Reload = Input.GetKey(KeyCode.R);
            Iswalking = Input.GetKey(KeyCode.LeftShift);
            IsCrouched = Input.GetKey(KeyCode.C);
        }


    }
}
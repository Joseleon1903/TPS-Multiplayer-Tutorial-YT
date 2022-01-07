using TPS.Script.Combat;
using TPS.Script.Controllers;
using TPS.Share;
using UnityEngine;

namespace TPS.Script.Players
{

    [RequireComponent(typeof(MoveController))]
    public class Player : MonoBehaviour
    {

        [System.Serializable]
        public class MouseInput
        {
            public Vector2 Damping;
            public Vector2 Sensitivity;
            public bool lockMouse;
        }

        [SerializeField] private float runspeed;
        [SerializeField] private float walkSpeed;
        [SerializeField] private float crouchSpeed;

        [SerializeField]
        private MouseInput MouseControl;

        // variable of the object
        private MoveController m_moveController;

        public MoveController MoveController
        {
            get
            {
                if (m_moveController == null)
                    m_moveController = GetComponent<MoveController>();
                return m_moveController;
            }
        }

        private InputController playeInput;

        Vector2 mouseInput;

        private CrossHair m_crossHair;

        private CrossHair CrossHair
        {
            get
            {
                if (m_crossHair == null)
                {
                    m_crossHair = GetComponentInChildren<CrossHair>();
                }

                return m_crossHair;
            }
        }

        void Awake()
        {
            playeInput = GameManager.Instance.InputController;
            GameManager.Instance.LocalPlayer = this;

            if (MouseControl.lockMouse) {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }

        }

        void Move() {

            float moveSpeed = runspeed;

            if (playeInput.Iswalking) {
                moveSpeed = walkSpeed;
            }

            if (playeInput.IsCrouched)
            {
                moveSpeed = crouchSpeed;
            }

            Vector2 direction = new Vector2(playeInput.Vertical * runspeed, playeInput.Horizontal * moveSpeed);
            MoveController.move(direction);
        }

        void LookAround() {

            mouseInput.x = Mathf.Lerp(mouseInput.x, playeInput.MouseInput.x, 1f / MouseControl.Damping.x);
            mouseInput.y = Mathf.Lerp(mouseInput.y, playeInput.MouseInput.y, 1f / MouseControl.Damping.y);

            transform.Rotate(Vector3.up * mouseInput.x * MouseControl.Sensitivity.x);

            CrossHair.LookHeight(mouseInput.y * MouseControl.Sensitivity.y);
        }

  

        // Update is called once per frame
        void Update()
        {
            Move();

            LookAround();        }
    }
}
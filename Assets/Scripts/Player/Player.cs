using UnityEngine;

[RequireComponent(typeof(MoveController))]
public class Player : MonoBehaviour
{

    [System.Serializable]
    public class MouseInput {
        public Vector2 Damping;
        public Vector2 Sensitivity;
    }

    [SerializeField]
    private float speed;

    [SerializeField]
    private MouseInput MouseControl;

    // variable of the object
    private MoveController m_moveController;

    public MoveController MoveController { 
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
            if (m_crossHair == null) { 
               m_crossHair = GetComponentInChildren<CrossHair>();
            }

            return m_crossHair;
        }
    }

    void Awake() {
        playeInput = GameManager.Instance.InputController;
        GameManager.Instance.LocalPlayer = this;
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(playeInput.Vertical * speed, playeInput.Horizontal * speed);
        MoveController.move(direction);

        mouseInput.x = Mathf.Lerp(mouseInput.x, playeInput.MouseInput.x, 1f / MouseControl.Damping.x);
        mouseInput.y = Mathf.Lerp(mouseInput.y, playeInput.MouseInput.y, 1f / MouseControl.Damping.y);

        transform.Rotate(Vector3.up * mouseInput.x * MouseControl.Sensitivity.x);

        CrossHair.LookHeight(mouseInput.y * MouseControl.Sensitivity.y);
    }
}

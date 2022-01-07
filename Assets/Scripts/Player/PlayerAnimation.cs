using TPS.Share;
using UnityEngine;

namespace TPS.Script.Players
{
    public class PlayerAnimation : MonoBehaviour
    {
        Animator animator;

        void Awake()
        {

            animator = GetComponentInChildren<Animator>();
        }

        void Update()
        {

            animator.SetFloat("Vertical", GameManager.Instance.InputController.Vertical);
            animator.SetFloat("Horizontal", GameManager.Instance.InputController.Horizontal);
            animator.SetBool("IsWalking", GameManager.Instance.InputController.Iswalking);
            animator.SetBool("IsCrouched", GameManager.Instance.InputController.IsCrouched);
        }

    }
}
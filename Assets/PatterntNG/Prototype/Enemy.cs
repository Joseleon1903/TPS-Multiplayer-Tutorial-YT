using UnityEngine;

namespace PatterntNG.Prototype
{
    public class Enemy : MonoBehaviour, iCopyable
    {
        public iCopyable Copy()
        {
            return Instantiate(this);
        }
    }
}
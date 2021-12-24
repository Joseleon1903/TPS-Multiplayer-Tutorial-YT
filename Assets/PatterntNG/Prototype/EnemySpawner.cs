using UnityEngine;

namespace PatterntNG.Prototype
{
    public class EnemySpawner : MonoBehaviour
    {
        public iCopyable m_Copy;

        public Enemy SpawnEnemy(PatterntNG.Prototype.Enemy prototype)
        {
            m_Copy = prototype.Copy();
            return (Enemy)m_Copy;
        }
    }
}
using UnityEngine;

public class MoveController : Shooter
{

    /// <summary>
    /// 
    ///     Move the gameObjec trasform on direction Vector2
    /// </summary>
    /// <param name="direction"></param>
    public void move(Vector2 direction) { 
        transform.position += transform.forward * direction.x * Time.deltaTime +
            transform.right * direction.y * Time.deltaTime;
    }


}

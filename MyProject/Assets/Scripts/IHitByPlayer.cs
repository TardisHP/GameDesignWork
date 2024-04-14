using UnityEngine;
/// <summary>
/// 接口，定义目标是否可以被玩家子弹击退
/// </summary>
interface IHitByPlayer
{
    public void HitByPlayer(Vector2 vector, float force);
}

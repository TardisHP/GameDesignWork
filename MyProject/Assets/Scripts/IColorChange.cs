using UnityEngine;

/// <summary>
/// 接口，定义目标是否可以被改变颜色
/// </summary>
interface IColorChange
{
    public void ChangeColor(Color color, float t);
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFixer
{
    /// <summary>
    /// ��������ɫ����ģ����
    /// </summary>
    /// <param name="color1">��ɫ1</param>
    /// <param name="color2">��ɫ2</param>
    /// <returns>��Ϻ����ɫ</returns>
    public Color Fix(Color color1, Color color2, float t)
    {
        Color fixedColor = ToColor(Mixbox.Lerp(ToArgbVal(color1), ToArgbVal(color2), t));
        return fixedColor;
        
    }
    /// <summary>
    /// ��Unity��ColorֵתΪ32λintֵ
    /// </summary>
    /// <param name="color">�����Colorֵ</param>
    /// <returns>Color��Ӧ��intֵ�����и�8λΪalpha��������ÿ8λ����һ��RGBֵ</returns>
    private int ToArgbVal(Color color)
    {
        return (255 << 24) | (ToIntColor(color.r) << 16) | (ToIntColor(color.g) << 8) | ToIntColor(color.b);
    }
    /// <summary>
    /// ��32λintֵתΪUnity��Colorֵ
    /// </summary>
    /// <param name="argb">�����intֵ</param>
    /// <returns>Unity��Colorֵ</returns>
    private Color ToColor(int argb)
    {
        return new Color(((argb >> 16) & 0xFF) / 255f, ((argb >> 8) & 0xFF) / 255f, (argb & 0xFF) / 255f);
    }
    /// <summary>
    /// ��(0,1)��floatֵתΪ(0,255)��intֵ
    /// </summary>
    /// <param name="x">float</param>
    /// <returns>int</returns>
    private int ToIntColor(float x)
    {
        return (int)(x * 255f);
    }
}

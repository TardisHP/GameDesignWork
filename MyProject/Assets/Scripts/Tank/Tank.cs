using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Tank : MonoBehaviour, IColorChange
{
    private AudioController audioController;
    private SpriteRenderer sprite => GetComponent<SpriteRenderer>();
    public SpriteRenderer shade;
    public Canvas canvas;
    private StainGenerator stainGenerator => FindFirstObjectByType<StainGenerator>();
    public Collider2D explodeCollider; // ��ը�����ײ��
    public Image durabilityBar;
    private ColorFixer colorFixer;
    private float durability;
    private void Start()
    {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
        colorFixer = new ColorFixer();
        durability = 0f;
        explodeCollider.enabled = false;
    }
    private void Update()
    {
        durabilityBar.fillAmount = durability;
        durabilityBar.color = sprite.color;
    }
    public void ChangeColor(Color color, float t)
    {
        durability += t;
        if (durability > 1.1f)
        {
            ExplodeTan();
        }
        else
        {
            sprite.color = colorFixer.Fix(sprite.color, color, t);
        }
        // Debug.Log(durability);
    }
    private void ExplodeTan()
    {
        GetComponent<Collider2D>().enabled = false;
        explodeCollider.enabled = true;
        sprite.enabled = false;
        shade.enabled = false;
        canvas.enabled = false;
        //���ű�ը��Ч
        audioController.PlaySfx(audioController.bombBullet);
        // ���ӵ�������һ̲��ը�ۼ�
        stainGenerator.Generate(sprite.color, transform.position, Vector3.up, 1.5f, 3f, transform);
        FindFirstObjectByType<PlayerEffect>().ShakeScreen();
        // ��������
        Destroy(gameObject, 3f);
    }
}

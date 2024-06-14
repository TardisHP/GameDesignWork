using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private Player player;
    public HealthUI healthUI;
    private void Start()
    {
        player = GetComponent<Player>();
    }
    public void ChangeHealth(Transform whereFrom)
    {
        if (player.canHurt)
        {
            Vector2 vector = player.transform.position - whereFrom.position;
            player.stateMachine.ChangeState(player.hitState);
            // »÷ÍË
            player.rb.AddForce(vector.normalized * 10f, ForceMode2D.Impulse);
            player.health -= 1;
            healthUI.DeleteHeart();
            if (player.health <= 0)
            {
                player.stateMachine.ChangeState(player.deadState);
            }
        }
    }
}

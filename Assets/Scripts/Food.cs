using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Head"))
        {
            collision.GetComponent<Player>().AddBody();
            ChangePosition();
        }
        else
        {
            ChangePosition();
        }
    }
    private void ChangePosition()
    {
        transform.position =new Vector3(GameManager.Instance.GetLimits('x'), GameManager.Instance.GetLimits('y'), 0);
    }
}

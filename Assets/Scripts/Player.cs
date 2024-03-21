using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<GameObject> Body = new List<GameObject>();
    private float Timer;
    private Vector3 Direction = Vector3.right;

    private void Start()
    {
        AddBody();
        AddBody();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (x != 0 || y != 0)
        {
            Vector3 newDirection = new Vector3(x, y, 0f).normalized;
            if (newDirection != -Direction)
            {
                Direction = newDirection;
            }
        }

        Timer += Time.deltaTime;

        if (Timer >= GameManager.Instance.velocityPlayer)
        {
            transform.Translate(Direction);
            Timer = 0f;
            UpdatePosition();
        }
    }

    private void UpdatePosition()
    {
        for (int i = Body.Count - 1; i > 0; i--)
        {
            Body[i].transform.position = Body[i - 1].transform.position;
        }
        Body[0].transform.position = transform.position - Direction;
        
        //Revisa si no se salio de los limites
        if (GameManager.Instance.MapDistance.x + 0.5f < transform.position.x || (GameManager.Instance.MapDistance.x + 0.5f) * -1 > transform.position.x || GameManager.Instance.MapDistance.y + 0.5f < transform.position.y || (GameManager.Instance.MapDistance.y + 0.5f) * -1 > transform.position.y) {
            GameManager.Instance.GameEnded = true;
        }
    }

    public void AddBody()
    {
        Vector3 positionToAdd = transform.position - Direction;
        if (Body.Count > 0)
        {
            positionToAdd = Body[Body.Count - 1].transform.position;
        }
        GameObject nuevoCuerpo = Instantiate(GameManager.Instance.prefabBody, positionToAdd, Quaternion.identity);
        Body.Add(nuevoCuerpo);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Body"))
        {
            GameManager.Instance.GameEnded = true;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float Speed;

    public Bounds Bounds;

    // Use this for initialization
    void Start()
    {
        Speed = 3;
        Bounds = new Bounds(Vector2.zero, new Vector2(10, 10));
    }

    // Update is called once per frame
    void Update()
    {
        float axisX = Input.GetAxis("Horizontal");
        float axisY = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(axisX, axisY) * Time.deltaTime * Speed;
        Vector2 pos = transform.position;

        move = BoundedMove(pos, move);

        transform.Translate(move);
    }

    Vector2 BoundedMove(Vector2 position, Vector2 move)
    {
        Vector2 result = new Vector2(move.x, move.y);
        Vector2 modifiedPos = position + move;
        if (!Bounds.Contains(modifiedPos))
        {
            // Move to the edge if full move would move out of bounds
            if (modifiedPos.x > Bounds.max.x)
            {
                result.x = Bounds.max.x - position.x;
            }
            else if (modifiedPos.x < Bounds.min.x)
            {
                result.x = Bounds.min.x - position.x;
            }

            if (modifiedPos.y > Bounds.max.y)
            {
                result.y = Bounds.max.y - position.y;
            }
            else if (modifiedPos.y < Bounds.min.y)
            {
                result.y = Bounds.min.y - position.y;
            }
        }
        return result;
    }
}
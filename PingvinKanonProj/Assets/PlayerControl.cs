using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float speed = 3;

    public Bounds bounds { get; set; }

    // Use this for initialization
    void Start()
    {
        speed = 3;
        bounds = new Bounds(Vector2.zero, new Vector2(10, 10));
    }

    // Update is called once per frame
    void Update()
    {
        float axisX = Input.GetAxis("Horizontal");
        float axisY = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(axisX, axisY) * Time.deltaTime * speed;
        Vector2 pos = transform.position;

        move = BoundedMove(pos, move);

        transform.Translate(move);
    }

    Vector2 BoundedMove(Vector2 position, Vector2 move)
    {
        Vector2 result = new Vector2(move.x, move.y);
        Vector2 modifiedPos = position + move;
        if (!bounds.Contains(modifiedPos))
        {
            // Move to the edge if full move would move out of bounds
            if (modifiedPos.x > bounds.max.x)
            {
                result.x = bounds.max.x - position.x;
            }
            else if (modifiedPos.x < bounds.min.x)
            {
                result.x = bounds.min.x - position.x;
            }

            if (modifiedPos.y > bounds.max.y)
            {
                result.y = bounds.max.y - position.y;
            }
            else if (modifiedPos.y < bounds.min.y)
            {
                result.y = bounds.min.y - position.y;
            }
        }
        return result;
    }
}
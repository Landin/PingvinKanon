using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float Speed;

    public Bounds BoundingBox;

    // Use this for initialization
    void Start()
    {
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
        Bounds spriteBounds = gameObject.GetComponent<SpriteRenderer>().bounds;
        Vector3 min = spriteBounds.min + new Vector3(move.x, move.y);
        Vector3 max = spriteBounds.max + new Vector3(move.x, move.y);

        if (!BoundingBox.Contains(max) || !BoundingBox.Contains(min))
        {
            if (max.x > BoundingBox.max.x)
            {
                result.x = BoundingBox.max.x - max.x;
            }
            else if (min.x < BoundingBox.min.x)
            {
                result.x = BoundingBox.min.x - min.x;
            }

            if (max.y > BoundingBox.max.y)
            {
                result.y = BoundingBox.max.y - max.y;
            }
            else if (min.y < BoundingBox.min.y)
            {
                result.y = BoundingBox.min.y - min.y;
            }
        }
        // Move to the edge if full move would move out of bounds
        return result;
    }
}
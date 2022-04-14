using UnityEngine;

public class Grid{
    public Vector2 point;
    public Vector2 position;
    public bool isEmpty;

    public Grid(Vector2 point, Vector2 position, bool isEmpty) {
        this.point = point;
        this.position = position;
        this.isEmpty = isEmpty;
    }
}

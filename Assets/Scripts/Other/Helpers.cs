using UnityEngine;

public static class Helpers {
    
    private static Camera camera;
    public static Camera Camera {
        get {
            if (camera == null) camera = Camera.main;
            return camera;
        }
    }

    public static Vector3 Mouse {
        get => Camera.ScreenToWorldPoint(Input.mousePosition);
    }

    public static void LookAt2D(this Transform transform, Vector2 lookTo) {
        transform.right = new(lookTo.x - transform.position.x, lookTo.y - transform.position.y);
    }

    public static void LookAt2D(this Transform transform, Transform lookTo) {
        transform.LookAt2D(lookTo.position);
    }
}
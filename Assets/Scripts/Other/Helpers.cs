using UnityEngine;
using System.Collections.Generic;

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

    private static Dictionary<float, WaitForSeconds> waits = new Dictionary<float, WaitForSeconds>();

    public static WaitForSeconds Wait(float time) {
        WaitForSeconds value = waits.GetValueOrDefault(time, null);
        if (value == null) {
            value = new WaitForSeconds(time);
            waits.Add(time, value);
        }

        return value;
    }
}
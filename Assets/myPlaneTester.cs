using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myPlaneTester : MonoBehaviour {
    public Transform v1, v2, v3;
    public Transform target;
    void Start () {

    }

    void Update () {

    }

    static float vecMultiplication (Vector3 v1, Vector3 v2) {
        return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
    }

    Vector3 projectAOnB (Vector3 A, Vector3 B) {
        float size = vecMultiplication (A, B) / vecMultiplication (B, B);
        return size * B;
    }

    static Vector3 complete (Vector3 b1, Vector3 b2) {

        return Vector3.zero;
    }

    private void OnDrawGizmos () {
        Gizmos.color = Color.red;
        Gizmos.DrawLine (v1.position, v2.position);
        Gizmos.color = Color.blue;

        var dir = v2.position - v1.position;
        var origin = v1.position + projectAOnB (v3.position - v1.position, dir);
        Gizmos.DrawSphere (origin, 0.2f);
        Gizmos.DrawLine (origin, v3.position);
        //Gizmos.DrawSphere (projectAOnB (v1.position + v3.position, v1.position - v2.position), 1);
        //Gizmos.DrawCube (v1.position, Vector3.one * 10);
    }
}

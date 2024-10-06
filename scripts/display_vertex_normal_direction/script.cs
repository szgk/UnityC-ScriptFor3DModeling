using UnityEngine;

[ExecuteInEditMode]
public class NormalHelper : MonoBehaviour
{
    public GameObject TargetObject;

    public float length = 1;

    public Vector3 bias;

    void Start()
    {
        Debug.Log("Start");

        if (TargetObject == null)
        {
            Debug.Log("TargetObjectがないよ");
            return;
        }
        if (TargetObject.GetComponent<SkinnedMeshRenderer>() == null)
        {
            Debug.Log("SkinnedMeshRendererがないよ");
            return;
        }
        if (TargetObject.GetComponent<SkinnedMeshRenderer>().sharedMesh == null)
        {
            Debug.Log("sharedMeshがないよ");
            return;
        }
        if (TargetObject.GetComponent<SkinnedMeshRenderer>().sharedMesh.vertices == null)
        {
            Debug.Log("verticesがないよ");
            return;
        }
        if (TargetObject.GetComponent<SkinnedMeshRenderer>().sharedMesh.normals == null)
        {
            Debug.Log("normalsがないよ");
            return;
        }
    }

    void Update()
    {

        if (TargetObject == null) return;

        SkinnedMeshRenderer skinnedMeshRenderer = TargetObject.GetComponent<SkinnedMeshRenderer>();

        if (skinnedMeshRenderer == null) return;


        var sharedMesh = skinnedMeshRenderer.sharedMesh;

        var vertices = sharedMesh.vertices;
        var normals = sharedMesh.normals;

        for (var i = 0; i < normals.Length; i++)
        {
            var pos = vertices[i];
            pos.x *= transform.localScale.x;
            pos.y *= transform.localScale.y;
            pos.z *= transform.localScale.z;
            pos += transform.position + bias;

            Debug.DrawLine
            (
                pos,
                pos + normals[i] * length, Color.red);
        }
    }
}
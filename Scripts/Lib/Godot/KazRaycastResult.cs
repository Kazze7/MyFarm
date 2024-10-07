using Godot;
using Godot.Collections;

public class KazRaycastResult
{
    public Vector3 position;
    Vector3 normal;
    //Object collider;
    //ObjectID collider_id;
    Rid rid;
    int shape;
    Variant metadata;

    public KazRaycastResult() { }
    public KazRaycastResult(Dictionary _result)
    {
        position = (Vector3)_result["position"];
    }
}

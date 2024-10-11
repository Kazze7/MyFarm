using Godot;
using Godot.Collections;

public class GRaycastResult
{
    public Vector3 position;
    Vector3 normal;
    //Object collider;
    //ObjectID collider_id;
    Rid rid;
    int shape;
    Variant metadata;

    public GRaycastResult() { }
    public GRaycastResult(Dictionary _result)
    {
        position = (Vector3)_result["position"];
    }
}

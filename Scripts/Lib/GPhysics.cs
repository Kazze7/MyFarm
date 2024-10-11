using Godot;
using Godot.Collections;

public static class GPhysics
{
    //https://docs.godotengine.org/en/stable/tutorials/physics/ray-casting.html

    public static bool MouseRaycast(Camera3D _camera, float _rayLength, out GRaycastResult _result)
    {
        bool isResult = false;
        Camera3D camera3D = _camera;

        Vector2 mousePosition = camera3D.GetViewport().GetMousePosition();
        Vector3 from = camera3D.ProjectRayOrigin(mousePosition);
        Vector3 to = from + camera3D.ProjectRayNormal(mousePosition) * _rayLength;

        PhysicsRayQueryParameters3D query = PhysicsRayQueryParameters3D.Create(from, to);
        PhysicsDirectSpaceState3D spaceState = camera3D.GetWorld3D().DirectSpaceState;
        Dictionary result = spaceState.IntersectRay(query);

        if (result.Count > 0)
        {
            isResult = true;
            _result = new GRaycastResult(result);
        }
        else
            _result = null;

        return isResult;
    }
}

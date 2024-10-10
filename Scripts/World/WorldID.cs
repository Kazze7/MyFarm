using Godot;
using System;

public struct WorldID
{
    public short x { get; set; }
    public short y { get; set; }
    public short z { get; set; }

    public static explicit operator WorldID(Vector3I _vector3I)
    {
        return new WorldID
        {
            x = (short)_vector3I.X,
            y = (short)_vector3I.Y,
            z = (short)_vector3I.Z,
        };
    }
    public static explicit operator Vector3I(WorldID _worldID)
    {
        return new Vector3I
        {
            X = _worldID.x,
            Y = _worldID.y,
            Z = _worldID.z,
        };
    }
    public override string ToString()
    {
        return "(" + x + ", " + y + ", " + z + ")";
    }
}

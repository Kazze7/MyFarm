using Godot;
using System;

public static class GMath
{
    static float density = 2.0f;
    public static Vector3I PositionToWorldID(Vector3 _position)
    {
        Vector3I wordlID = new();
        _position *= density;
        wordlID.X = Mathf.RoundToInt(_position.X);
        wordlID.Y = Mathf.RoundToInt(_position.Y);
        wordlID.Z = Mathf.RoundToInt(_position.Z);
        return wordlID;
    }

}

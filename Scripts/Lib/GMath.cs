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
    public static Vector3 WorldIDToPosition(Vector3I _worldID)
    {
        Vector3 position = new();
        position = (Vector3)_worldID / density;
        return position;
    }
    public static Vector3 PositionToTile(Vector3 _position)
    {
        Vector3 position = new();
        _position *= density / 2.0f;
        position.X = Mathf.RoundToInt(_position.X);
        position.Y = Mathf.RoundToInt(_position.Y);
        position.Z = Mathf.RoundToInt(_position.Z);
        position /= density / 2.0f;
        return position;
    }

}

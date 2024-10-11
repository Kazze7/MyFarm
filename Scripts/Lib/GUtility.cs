using Godot;
using System;
using System.Linq;

public static class GUtility
{
    public static void FreeAllChildNode(Node _parentNode)
    {
        _parentNode.GetChildren().ToList().ForEach(child => child.Free());
    }
}

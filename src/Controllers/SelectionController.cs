using Godot;
using System;
using System.Collections.Generic;

public class SelectionController : Node
{
    static SelectionController instance;
    static List<Entity> selectionQueue = new List<Entity>();
    public static Entity SelectedEntity { get; private set; }

    public static void AddToSelectionQueue(Entity entity) {
        selectionQueue.Add(entity);
        instance.SetProcess(true);
    }

    public static void DeselectAll() {
        SelectedEntity = null;
    }

    public override void _Ready() {
        if (instance == null) {
            instance = this;
        }
        SetProcess(false);
    }

    public override void _Process(float delta) {
        if (instance == this) {
            if (selectionQueue.Count > 0) {
                float? maxY = null;
                foreach (Entity entity in selectionQueue) {
                    float entityY = entity.GlobalPosition.y;
                    if (maxY == null || maxY < entityY) {
                        maxY = entityY;
                        SelectedEntity = entity;
                    }
                }
                selectionQueue.Clear();
            }
        }
        SetProcess(false);
    }
}

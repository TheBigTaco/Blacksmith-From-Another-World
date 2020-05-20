using System;
using System.Collections.Generic;
using Godot;

public class SelectionController : Node {
    static SelectionController instance;
    static List<EntitySelectable> selectionQueue = new List<EntitySelectable>();
    public static EntitySelectable SelectedEntity { get; private set; }

    public static void AddToSelectionQueue(EntitySelectable entity) {
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
                foreach (EntitySelectable entity in selectionQueue) {
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

    public override void _Input(InputEvent e) {
        var mouseEvent = e as InputEventMouseButton;
        if (Input.IsActionJustPressed("right_click") && mouseEvent != null) {
            EntityControllable entity = SelectedEntity as EntityControllable;
            if (entity != null) {
                entity.MoveTo(mouseEvent.GlobalPosition);
            }
        }
    }
}

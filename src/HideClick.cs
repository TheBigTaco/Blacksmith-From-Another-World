using Godot;
using System;

public class HideClick : Area2D
{
    Node2D parentNode;
    public override void _Ready()
    {
        parentNode = (Node2D)GetParent();
    }

    public void _on_Clickable_input_event(Godot.Object viewport, InputEvent @event, int shapeIdx)
    {
        if (Input.IsActionJustPressed("click"))
        {
            parentNode.Visible = false;
            GlobalVars.SelectedEntity = null;
            // GlobalVars.CurrentClickMode = ClickMode.Select;
            //ProjectSettings.SetSetting("physics/common/enable_object_picking", false);
        }
    }
}

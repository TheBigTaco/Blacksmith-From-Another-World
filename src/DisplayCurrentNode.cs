using Godot;
using System;

public class DisplayCurrentNode : Node2D
{
    Node2D currentEntity;
    Sprite selectedSprite;
    public override void _Ready()
    {
        Visible = false;
        selectedSprite = (Sprite)GetNode("Sprite");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        currentEntity = GlobalVars.SelectedEntity;
        if (currentEntity != null)
        {
            Sprite currentSprite = (Sprite)currentEntity.GetNode("Sprite");
            selectedSprite.Texture = currentSprite.Texture;
            Visible = true;
        }
        else
        {
            Visible = false;
            selectedSprite.Texture = null;
        }

    }
}

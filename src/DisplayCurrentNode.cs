using Godot;
using System;

public class DisplayCurrentNode : Node2D
{
    Node2D currentEntity;
    Sprite selectedSprite;
    public override void _Ready()
    {
        Visible = false;
        selectedSprite = GetNode<Sprite>("Sprite");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        currentEntity = GlobalVars.SelectedEntity;
        if (currentEntity != null)
        {
            Sprite currentSprite = currentEntity.GetNode<Sprite>("Sprite");
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

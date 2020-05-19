using Godot;
using System;
using System.Collections.Generic;

public enum StationType
{
    Null,
    Forge, // Forge
    Anvil, // Refine
    Grindstone, // Finish
}

public class Station : Node2D
{
    [Export] public StationType Type { get; set; } = StationType.Null;
    Dictionary<string, Blacksmith> workingBlacksmiths;

    public bool InProgress { get; set; } = false;
    float currentProgress = 0F;
    ProgressBar progressBar;

    public override void _Ready()
    {
        workingBlacksmiths = new Dictionary<string, Blacksmith>();
        progressBar = GetNode<ProgressBar>("ProgressBar");
        progressBar.Visible = false;

        // TODO: Remove degub Blacksmith
        Blacksmith tempSmith = new Blacksmith();
        tempSmith.Level = 42;
        AddBlacksmith(tempSmith);

    }

    public override void _Process(float delta)
    {
        if (InProgress && progressBar.Value < 100F)
        {
            progressBar.Visible = true;
            currentProgress += 1.23F;
            progressBar.Value = currentProgress;
            if (currentProgress >= 100)
            {
                // TODO: Handle providing weapons
                Weapon tempWeapon = new Weapon();
                tempWeapon.Stage = WeaponStage.Forge;
                tempWeapon = ProcessWeapon(tempWeapon);
                // TODO: Show processed weapon
                GD.Print($"Weapon now has power level: {tempWeapon.Power}");
            }
        }
        else {
            InProgress = false;
            currentProgress = 0F;
            progressBar.Value = 0F;
            progressBar.Visible = false;
        }
    }

    public void _on_Station_input_event()
    {
        if (Input.IsActionJustPressed("click"))
        {
            InProgress = true;
            GD.Print("Click!");
        }
    }



    public void AddBlacksmith(Blacksmith blacksmith)
    {
        workingBlacksmiths.Add(blacksmith.EntityName, blacksmith);
    }
    public void RemoveBlacksmith(Blacksmith blacksmith)
    {
        workingBlacksmiths.Remove(blacksmith.EntityName);
    }

    public Weapon ProcessWeapon(Weapon currentWeapon)
    {
        // Modify weapon based on all blacksmiths
        int weaponModifier = 0;
        if (workingBlacksmiths.Count <= 0) {
            return currentWeapon;
        }
        foreach (KeyValuePair<string, Blacksmith> smith in workingBlacksmiths)
        {
            weaponModifier += smith.Value.Level;
        }

        currentWeapon.Power += weaponModifier;
        int weaponIndex;
        switch(currentWeapon.Stage)
        {
            case (WeaponStage.Forge):
                currentWeapon.Stage = WeaponStage.Refine;
                // Add to refinble weapons
                StationsController.RefinableWeapons.Add(currentWeapon);
                break;
            case (WeaponStage.Refine):
                currentWeapon.Stage = WeaponStage.Finish;
                // move from refinable to finishable
                weaponIndex = StationsController.RefinableWeapons.FindIndex(n => n == currentWeapon);
                StationsController.FinishableWeapons.Add(currentWeapon);
                break;
            case (WeaponStage.Finish):
                currentWeapon.Stage = WeaponStage.Sell;
                // move from finishable to sellable
                weaponIndex = StationsController.FinishableWeapons.FindIndex(n => n == currentWeapon);
                StationsController.SellableWeapons.Add(currentWeapon);
                break;
            default:
                GD.Print("Warning: Invalid Weapon State!");
                break;
        }
        return currentWeapon;
    }

}

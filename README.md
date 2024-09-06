# Unity - Vertical ProgressBar

My take on a custom Vertical ProgressBar for Unity's UI Toolkit, designed to track a Player Stat (Health, Mana, Etc)

To Use:

1) Place `VerticalProgressBar.cs` wherever you wish and `VerticalProgressBar.uxml` in `Assets/Resources/CustomComponents/`
2) Drag an instance of the Template into your UI Document and set it's **width** property.
3) Set the Min (defaults to 0) and the Max (defaults to 100) to the minimum and maximum values of your tracked stat.
4) Set the Value to the value of the tracked stat.
5) Internal logic will handle clamping and interpolating the bar based on the given Value.

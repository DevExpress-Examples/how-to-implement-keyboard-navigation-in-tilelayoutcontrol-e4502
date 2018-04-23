# How to implement keyboard navigation in TileLayoutControl


<p>This example illustrates how to implement keyboard navigation in TileLayoutControl.</p><br />
<p>To change a Tile style when it is selected, create the attached IsSelected property and use it as a DataTrigger.</p><br />
<p>To implement this feature, create a SelectionHelper class where subscribe to the TileLayoutControl.KeyDown, TileLayoutControl.ItemPositionChanged and TileLayoutControl.PreviewMouseDown events to change the IsSelected property value.</p><br />
<p>To obtain the next Tile by the direction key, use the TileLayoutControl.ChildAt method that returns a Tile under a specific point.</p>

<br/>



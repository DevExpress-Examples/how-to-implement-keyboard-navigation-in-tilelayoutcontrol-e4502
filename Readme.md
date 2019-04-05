<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/WpfApplication49/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/WpfApplication49/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/WpfApplication49/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/WpfApplication49/MainWindow.xaml.vb))
* [MoveActions.cs](./CS/WpfApplication49/MoveActions.cs) (VB: [MoveActions.vb](./VB/WpfApplication49/MoveActions.vb))
* [TileSelectionHelper.cs](./CS/WpfApplication49/TileSelectionHelper.cs) (VB: [TileSelectionHelper.vb](./VB/WpfApplication49/TileSelectionHelper.vb))
<!-- default file list end -->
# How to implement keyboard navigation in TileLayoutControl


<p>This example illustrates how to implement keyboard navigation in TileLayoutControl.</p><br />
<p>To change a Tile style when it is selected, create the attached IsSelected property and use it as a DataTrigger.</p><br />
<p>To implement this feature, create a SelectionHelper class where subscribe to the TileLayoutControl.KeyDown, TileLayoutControl.ItemPositionChanged and TileLayoutControl.PreviewMouseDown events to change the IsSelected property value.</p><br />
<p>To obtain the next Tile by the direction key, use the TileLayoutControl.ChildAt method that returns a Tile under a specific point.</p>

<br/>



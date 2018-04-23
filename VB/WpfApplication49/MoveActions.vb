Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Shapes
Imports System.Windows
Imports DevExpress.Xpf.LayoutControl
Imports System.Windows.Input

Namespace WpfApplication49
	Friend Class MoveActions

	Public Function GetNextTileByDirrection(ByVal SelectedTile As Integer, ByVal TLC As TileLayoutControl, ByVal key As Key) As Tile
			Dim PrevTileRect As Rect = (TryCast(TLC.Children(SelectedTile), Tile)).Bounds
			Dim P As Point = GetNextPoinWithOffset(PrevTileRect,TLC.ItemSpace,key)
			Dim NextTile As Tile = TryCast(TLC.ChildAt(P), Tile)
			If NextTile Is Nothing Then
				P = GetNextPoinWithOffset(PrevTileRect, TLC.LayerSpace, key)

				NextTile = TryCast(TLC.ChildAt(P), Tile)
			End If
			If NextTile Is Nothing AndAlso (key= Key.Right OrElse key = Key.Left) Then
				NextTile = MoveToNextGroup(P, TLC)
			End If
			Return NextTile

	End Function

	 Public Function GetNextPoinWithOffset(ByVal PrevTileRect As Rect, ByVal offset As Double, ByVal key As Key) As Point
			Select Case key
				Case Key.Right
					Return New Point(PrevTileRect.Right+ offset, PrevTileRect.Y)
				Case Key.Left
					Return New Point(PrevTileRect.Left-offset, PrevTileRect.Y)
				Case Key.Down
					Return New Point(PrevTileRect.X, PrevTileRect.Bottom + offset)
				Case Key.Up
					Return New Point(PrevTileRect.X,PrevTileRect.Top - offset)
			End Select
			Return New Point(0,0)
	 End Function


		Public Function MoveToNextGroup(ByVal StartPoint As Point, ByVal TLC As TileLayoutControl) As Tile
			For i As Double = StartPoint.Y To 1 Step -10
				If TLC.ChildAt(New Point(StartPoint.X, i)) IsNot Nothing Then
					 Return TryCast(TLC.ChildAt(New Point(StartPoint.X, i)), Tile)
				End If
			Next i
			Return Nothing
		End Function
	End Class
End Namespace

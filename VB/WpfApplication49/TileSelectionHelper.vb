Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.Xpf.LayoutControl
Imports System.Windows
Imports System.Windows.Input

Namespace WpfApplication49
	Public Class TileSelectionHelper
		Public Sub New(ByVal Owner As TileLayoutControl)
			TileLayoutControl = Owner
			SelectedTile = -1
			AddHandler TileLayoutControl.KeyDown, AddressOf TLC_KeyDown
			AddHandler TileLayoutControl.ItemPositionChanged, AddressOf TLC_ItemPositionChanged
			AddHandler TileLayoutControl.PreviewMouseDown, AddressOf TLC_PreviewMouseDown
			Actions = New MoveActions()
		End Sub
		Private Actions As MoveActions
		Private Sub TLC_PreviewMouseDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			If TypeOf e.Source Is Tile Then
				SelectedTile = TileLayoutControl.Children.IndexOf(TryCast(e.Source, Tile))
			End If
		End Sub

		Private Sub TLC_ItemPositionChanged(ByVal sender As Object, ByVal e As DevExpress.Xpf.Core.ValueChangedEventArgs(Of Integer))
			SelectedTile = e.NewValue
		End Sub

		Private Sub TLC_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
			TileMovement(e.Key)
		End Sub

		#Region "Properties"

		Private _SelectedTile As Integer
		Private _TLC As TileLayoutControl

		Public Property TileLayoutControl() As TileLayoutControl
			Get
				Return _TLC
			End Get
			Set(ByVal value As TileLayoutControl)
				_TLC = value
			End Set
		End Property



		Public Shared ReadOnly IsSelectedProperty As DependencyProperty = DependencyProperty.RegisterAttached("IsSelected", GetType(Boolean), GetType(TileSelectionHelper), New UIPropertyMetadata(False, New PropertyChangedCallback(AddressOf OnIsSelectedChanged)))

		Public Shared Function GetIsSelected(ByVal target As DependencyObject) As Boolean
			Return CBool(target.GetValue(IsSelectedProperty))
		End Function

		Public Shared Sub SetIsSelected(ByVal target As DependencyObject, ByVal value As Boolean)
			target.SetValue(IsSelectedProperty, value)
		End Sub

		Public Shared Sub OnIsSelectedChanged(ByVal o As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
			OnIsSelectedChanged(o, CBool(e.OldValue), CBool(e.NewValue))
		End Sub

		Private Shared Sub OnIsSelectedChanged(ByVal o As DependencyObject, ByVal oldValue As Boolean, ByVal newValue As Boolean)


		End Sub
		#End Region

		Public Sub DeselectTile()
			SetIsSelected(TileLayoutControl.Children(SelectedTile), False)
			SelectedTile = -1
		End Sub
		Public Sub PressTile()
			TryCast(TileLayoutControl.Children(SelectedTile), ITile).Click()
		End Sub
		Public Sub TileMovement(ByVal key As Key)
			If SelectedTile < 0 Then
				SelectedTile = 0
				SetIsSelected(TileLayoutControl.Children(0), True)
				Return
			End If
			Select Case key
				Case Key.Right
					MoveToRight()
				Case Key.Left
					MoveToLeft()
				Case Key.Down
					MoveToDown()
				Case Key.Up
					MoveToUp()
				Case Key.Escape
					DeselectTile()
					Return
				Case Key.Enter
					PressTile()
					Return
			End Select
		End Sub

		Public Sub MoveToRight()
			MoveCore(Key.Right)
		End Sub

		Public Sub MoveToLeft()
			MoveCore(Key.Left)
		End Sub

		Private Sub MoveCore(ByVal key As Key)
			Dim NextTile As Tile = Actions.GetNextTileByDirrection(SelectedTile, TileLayoutControl, key)
			If TileLayoutControl.Children.IndexOf(TryCast(NextTile, UIElement)) < 0 Then
				Return
			End If
			SelectedTile = TileLayoutControl.Children.IndexOf(NextTile)
			TileLayoutControl.BringChildIntoView(NextTile, False)
		End Sub


		Public Sub MoveToDown()
			MoveCore(Key.Down)

		End Sub

		Public Sub MoveToUp()
			MoveCore(Key.Up)

		End Sub
		Public Property SelectedTile() As Integer
			Get
				Return _SelectedTile
			End Get
			Set(ByVal value As Integer)
				If _SelectedTile > -1 Then
					SetIsSelected(TileLayoutControl.Children(_SelectedTile), False)
				End If
				_SelectedTile = value
				If _SelectedTile > -1 Then
				SetIsSelected(TileLayoutControl.Children(_SelectedTile), True)
				End If
			End Set
		End Property

	End Class
End Namespace

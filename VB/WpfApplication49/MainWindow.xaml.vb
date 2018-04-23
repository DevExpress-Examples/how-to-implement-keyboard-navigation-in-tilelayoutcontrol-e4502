Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Collections.ObjectModel

Namespace WpfApplication49
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
			SelectionHelper = New TileSelectionHelper(tileLayoutControl1)
			Dim list As New ObservableCollection(Of String)()
			For i As Integer = 0 To 9
				list.Add(i.ToString())

			Next i
			tileLayoutControl1.ItemsSource = list
			tileLayoutControl1.Focus()
		End Sub


		Private SelectionHelper As TileSelectionHelper

	End Class
End Namespace

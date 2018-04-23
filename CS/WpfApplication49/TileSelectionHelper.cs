using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpf.LayoutControl;
using System.Windows;
using System.Windows.Input;

namespace WpfApplication49
{
    public class TileSelectionHelper
    {
        public TileSelectionHelper(TileLayoutControl Owner) 
        {
            TileLayoutControl = Owner;
            SelectedTile = -1;
            TileLayoutControl.KeyDown += new KeyEventHandler(TLC_KeyDown);
            TileLayoutControl.ItemPositionChanged += new DevExpress.Xpf.Core.ValueChangedEventHandler<int>(TLC_ItemPositionChanged);
            TileLayoutControl.PreviewMouseDown += new MouseButtonEventHandler(TLC_PreviewMouseDown);
            Actions = new MoveActions();
        }
        MoveActions Actions;
        void TLC_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is Tile)
                SelectedTile = TileLayoutControl.Children.IndexOf(e.Source as Tile);
        }

        void TLC_ItemPositionChanged(object sender, DevExpress.Xpf.Core.ValueChangedEventArgs<int> e)
        {
            SelectedTile = e.NewValue;
        }

        void TLC_KeyDown(object sender, KeyEventArgs e)
        {
            TileMovement(e.Key);
        }

        #region Properties

        private  int _SelectedTile;
        private TileLayoutControl _TLC;

        public TileLayoutControl TileLayoutControl
        {
            get { return _TLC; }
            set { _TLC = value; }
        }

    

        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.RegisterAttached("IsSelected", typeof(bool), typeof(TileSelectionHelper), new UIPropertyMetadata(false, new PropertyChangedCallback(OnIsSelectedChanged)));

        public static bool GetIsSelected(DependencyObject target)
        {
            return (bool)target.GetValue(IsSelectedProperty);
        }

        public static void SetIsSelected(DependencyObject target, bool value)
        {
            target.SetValue(IsSelectedProperty, value);
        }

        public static void OnIsSelectedChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            OnIsSelectedChanged(o, (bool)e.OldValue, (bool)e.NewValue);
        }

        private static void OnIsSelectedChanged(DependencyObject o, bool oldValue, bool newValue)
        {
            
            
        }
        #endregion

        public void DeselectTile()
        {
            SetIsSelected(TileLayoutControl.Children[SelectedTile], false);
            SelectedTile = -1;
        }
        public void PressTile()
        {
            (TileLayoutControl.Children[SelectedTile] as ITile).Click();
        }
        public void TileMovement(Key key)
        {
            if (SelectedTile < 0)
            {
                SelectedTile = 0;
                SetIsSelected(TileLayoutControl.Children[0], true);
                return;
            }
            switch (key)
            {
                case Key.Right: MoveToRight(); break;
                case Key.Left: MoveToLeft(); break;
                case Key.Down: MoveToDown(); break;
                case Key.Up: MoveToUp(); break;
                case Key.Escape: DeselectTile(); return;
                case Key.Enter: PressTile(); return;
            }
        }

        public void MoveToRight()
        {
            MoveCore(Key.Right);
        }

        public void MoveToLeft()
        {
            MoveCore(Key.Left);
        }

        private void MoveCore(Key key)
        {
            Tile NextTile = Actions.GetNextTileByDirrection(SelectedTile, TileLayoutControl, key);
            if (TileLayoutControl.Children.IndexOf(NextTile as UIElement) < 0) return;
            SelectedTile = TileLayoutControl.Children.IndexOf(NextTile);
            TileLayoutControl.BringChildIntoView(NextTile, false);
        }


        public void MoveToDown()
        {
            MoveCore(Key.Down);

        }

        public void MoveToUp()
        {
            MoveCore(Key.Up);

        }
        public  int SelectedTile
        {
            get { return _SelectedTile; }
            set 
            {
                if (_SelectedTile > -1)
                { SetIsSelected(TileLayoutControl.Children[_SelectedTile], false); }
                _SelectedTile = value;
                if (_SelectedTile > -1)
                SetIsSelected(TileLayoutControl.Children[_SelectedTile], true);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using System.Windows;
using DevExpress.Xpf.LayoutControl;
using System.Windows.Input;

namespace WpfApplication49
{
    class MoveActions
    {

    public Tile GetNextTileByDirrection(int SelectedTile,TileLayoutControl TLC,Key key)
        {
            Rect PrevTileRect = (TLC.Children[SelectedTile] as Tile).Bounds;
            Point P = GetNextPoinWithOffset(PrevTileRect,TLC.ItemSpace,key);
            Tile NextTile = TLC.ChildAt(P) as Tile;
            if (NextTile == null)
            {
                P = GetNextPoinWithOffset(PrevTileRect, TLC.LayerSpace, key); ;
                NextTile = TLC.ChildAt(P) as Tile;
            }
            if (NextTile == null && (key== Key.Right || key == Key.Left))
            {
                NextTile = MoveToNextGroup(P, TLC);
            }
            return NextTile;
        
        }

     public Point GetNextPoinWithOffset(Rect PrevTileRect,double offset,Key key)
        {
            switch (key)
            {
                case Key.Right: return new Point(PrevTileRect.Right+ offset, PrevTileRect.Y);
                case Key.Left: return new Point(PrevTileRect.Left-offset, PrevTileRect.Y);
                case Key.Down: return new Point(PrevTileRect.X, PrevTileRect.Bottom + offset);
                case Key.Up: return new Point(PrevTileRect.X,PrevTileRect.Top - offset);
            }
            return new Point(0,0);
        }


        public Tile MoveToNextGroup(Point StartPoint,TileLayoutControl TLC)
        {
            for (Double i = StartPoint.Y; i > 0; i -= 10)
            {
                if (TLC.ChildAt(new Point(StartPoint.X, i)) != null)
                {
                     return TLC.ChildAt(new Point(StartPoint.X, i)) as Tile;
                }
            }
            return null;
        }
    }
}

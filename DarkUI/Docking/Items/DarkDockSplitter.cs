﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace DarkUI
{
    public class DarkDockSplitter
    {
        #region Field Region

        private Control _parentControl;
        private Control _control;
        private DarkSplitterType _splitterType;
        private DarkTranslucentForm _overlayForm;

        #endregion

        #region Property Region

        public Rectangle Bounds { get; set; }

        public Cursor ResizeCursor { get; private set; }

        #endregion

        #region Constructor Region

        public DarkDockSplitter(Control parentControl, Control control, DarkSplitterType splitterType)
        {
            _parentControl = parentControl;
            _control = control;
            _splitterType = splitterType;
            _overlayForm = new DarkTranslucentForm(Color.Black);

            switch (_splitterType)
            {
                case DarkSplitterType.Left:
                case DarkSplitterType.Right:
                    ResizeCursor = Cursors.SizeWE;
                    break;
                case DarkSplitterType.Top:
                case DarkSplitterType.Bottom:
                    ResizeCursor = Cursors.SizeNS;
                    break;
            }
        }

        #endregion

        #region Method Region

        public void ShowOverlay()
        {
            UpdateOverlay(new Point(0, 0));

            _overlayForm.Show();
            _overlayForm.BringToFront();
        }

        public void HideOverlay()
        {
            _overlayForm.Hide();
        }

        public void UpdateOverlay(Point difference)
        {
            var bounds = new Rectangle(Bounds.Location, Bounds.Size);

            switch (_splitterType)
            {
                case DarkSplitterType.Left:
                    bounds.Location = new Point(bounds.Location.X - difference.X, bounds.Location.Y);
                    break;
                case DarkSplitterType.Right:
                    bounds.Location = new Point(bounds.Location.X - difference.X, bounds.Location.Y);
                    break;
                case DarkSplitterType.Top:
                    bounds.Location = new Point(bounds.Location.X, bounds.Location.Y - difference.Y);
                    break;
                case DarkSplitterType.Bottom:
                    bounds.Location = new Point(bounds.Location.X, bounds.Location.Y - difference.Y);
                    break;
            }

            _overlayForm.Location = bounds.Location;
            _overlayForm.Size = bounds.Size;
        }

        public void Move(Point difference)
        {
            switch (_splitterType)
            {
                case DarkSplitterType.Left:
                    _control.Width += difference.X;
                    break;
                case DarkSplitterType.Right:
                    _control.Width -= difference.X;
                    break;
                case DarkSplitterType.Top:
                    _control.Height += difference.Y;
                    break;
                case DarkSplitterType.Bottom:
                    _control.Height -= difference.Y;
                    break;
            }

            UpdateBounds();
        }

        public void UpdateBounds()
        {
            var bounds = _parentControl.RectangleToScreen(_control.Bounds);

            switch (_splitterType)
            {
                case DarkSplitterType.Left:
                    Bounds = new Rectangle(bounds.Left - 2, bounds.Top, 5, bounds.Height);
                    break;
                case DarkSplitterType.Right:
                    Bounds = new Rectangle(bounds.Right - 3, bounds.Top, 5, bounds.Height);
                    break;
                case DarkSplitterType.Top:
                    Bounds = new Rectangle(bounds.Left, bounds.Top - 2, bounds.Width, 5);
                    break;
                case DarkSplitterType.Bottom:
                    Bounds = new Rectangle(bounds.Left, bounds.Bottom - 5, bounds.Width, 5);
                    break;
            }
        }

        #endregion
    }
}
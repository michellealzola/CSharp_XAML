using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace BasicDrawingVisual
{
    public class HostVisual : FrameworkElement
    {
        private readonly DrawingVisual _drawingVisual;

        public HostVisual(DrawingVisual drawingVisual)
        {
            _drawingVisual = drawingVisual;
            AddVisualChild(_drawingVisual);
            AddLogicalChild(_drawingVisual);
        }

        protected override int VisualChildrenCount => 1;

        protected override Visual GetVisualChild(int index)
        {
            if (index != 0)
            {
                throw new ArgumentOutOfRangeException("index");
            }
            return _drawingVisual;
        }
    }
}

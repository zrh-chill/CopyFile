using HelixToolkit.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HelixToolKitApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private LinesVisual3D wireframeVisual;
        private PointsVisual3D pointsVisual;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void HelixViewport3D_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
        
        protected virtual RayMeshGeometry3DHitTestResult FindHit(Point position)
        {
            RayMeshGeometry3DHitTestResult result = null;
            HitTestFilterCallback hitFilterCallback = oFilter =>
            {
                // Test for the object value you want to filter. 
                if (oFilter.GetType() == typeof(MeshVisual3D))
                    return HitTestFilterBehavior.ContinueSkipSelfAndChildren;
                return HitTestFilterBehavior.Continue;
            };

            HitTestResultCallback hitTestCallback = hit =>
            {
                var rayHit = hit as RayMeshGeometry3DHitTestResult;
                if (rayHit?.MeshHit == null)
                    return HitTestResultBehavior.Continue;
                var tagObject = rayHit.ModelHit.GetValue(TagProperty);
                if (tagObject == null)
                    return HitTestResultBehavior.Continue;

                result = rayHit;
                return HitTestResultBehavior.Stop;
            };

            var hitParams = new PointHitTestParameters(position);
            VisualTreeHelper.HitTest(Viewport.Viewport, hitFilterCallback, hitTestCallback, hitParams);
            return result;
        }

    }
}

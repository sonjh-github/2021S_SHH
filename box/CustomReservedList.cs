using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Components;

namespace BoxStation.box
{
    class CustomReservedList: RecyclerViewItem
    {
        private Button btn;
        private TextLabel stationLabel;
        private TextLabel boxNumberLabel;
        private TextLabel pWLabel;
        private TextLabel presentCostLabel;

        public CustomReservedList()
        {
            //LG DISPLAY 1920 * 1080
            List<double> ratio = new List<double>();
            ratio.Add(Window.Instance.WindowSize.Width / 1920.0);
            ratio.Add(Window.Instance.WindowSize.Height / 1080.0);

            double minRatio = ratio.Min();
            float sizeW = Window.Instance.WindowSize.Width * 0.9f;
            float sizeH = Window.Instance.WindowSize.Height * 0.1f;
            Size = new Size(sizeW, sizeH);
            

            //버튼(틀), 클릭시 detail info
            btn = new Button()
            {
                StyleName = "ReservedListButton",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                PivotPoint = Tizen.NUI.PivotPoint.Center,
                PositionUsesPivotPoint = true,
                BackgroundColor = Color.White,
                BackgroundImage = "*Resource*/images/buxLine.png",
            };
            
            btn.Clicked += Btn_Clicked;
            Add(btn);

            //StationName
            stationLabel = new TextLabel()
            {
                PointSize = (float)Math.Round(minRatio * 60),
                ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                Padding = new Extents(20, 20, 20, 20),
                PositionUsesPivotPoint = true,
            };
            Add(stationLabel);
            //stationLabel.SetBinding(TextLabel.TextProperty, "StationName");
            stationLabel.Text = "충남대학교 정류장";

            //BoxNumber
            boxNumberLabel = new TextLabel()
            {
                PointSize = (float)Math.Round(minRatio * 60),
                Padding = new Extents(20, 20, 20, 20),

                ParentOrigin = Tizen.NUI.ParentOrigin.BottomLeft,
                PivotPoint = Tizen.NUI.PivotPoint.BottomLeft,
                PositionUsesPivotPoint = true,
            };
            Add(boxNumberLabel);
            //boxNumberLabel.SetBinding(TextLabel.TextProperty, "BoxNumber"+"번 사물함");
            boxNumberLabel.Text = "1번 사물함";


            pWLabel = new TextLabel()
            {
                PointSize = (float)Math.Round(minRatio * 80),
                Padding = new Extents(20, 20, 20, 20),

                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                PivotPoint = Tizen.NUI.PivotPoint.Center,
                PositionUsesPivotPoint = true,
            };
            Add(pWLabel);
            //pWLabel.SetBinding(TextLabel.TextProperty, "PW");
            pWLabel.Text = "1234";


            //Cost
            presentCostLabel = new TextLabel()
            {
                PointSize = (float)Math.Round(minRatio * 80),
                Padding = new Extents(20, 20, 20, 20),

                ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight,
                PivotPoint = Tizen.NUI.PivotPoint.CenterRight,
                PositionUsesPivotPoint = true,
            };
            Add(presentCostLabel);
            //reservedStuffLabel.SetBinding(TextLabel.TextProperty, "ReservedDate");
            presentCostLabel.Text = "2134123";

        }

        private void Btn_Clicked(object sender, ClickedEventArgs e)
        {
            ReservedListPopup reservedListPopup = new ReservedListPopup();
            reservedListPopup.BindingContext = this.BindingContext;
            reservedListPopup.ShowPopUpPage();
        }
    }
}

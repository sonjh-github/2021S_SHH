using System;
using System.Collections.Generic;
using System.Linq;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Components;

namespace BoxStation
{
    public partial class ReservedList : ContentPage
    {
        private float tableTextSize;
        public ReservedList()
        {
            InitializeComponent();
            //Set table title text size
            //LG DISPLAY 1920 * 1080
            List<double> ratio = new List<double>();
            ratio.Add(Window.Instance.WindowSize.Width / 1920.0);
            ratio.Add(Window.Instance.WindowSize.Height / 1080.0);

            double minRatio = ratio.Min();
            tableTextSize = (float)Math.Round(minRatio * 70);

            reservedLocation.PointSize = tableTextSize;
            reservedPw.PointSize = tableTextSize;
            reservedCost.PointSize = tableTextSize;


            List<Data.Boxes> dataSource = new List<Data.Boxes>();
            foreach (var item in Data.Resources.Boxes)
            {
                dataSource.Add(new Data.Boxes(item.bst, item.bxn, item.isO, item.isP,item.stf,item.pw,item.date));
            }

            CollectionView reservedListContainerView = new CollectionView()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                Padding= new Extents(10, 100, 100, 10),
                ItemsSource = dataSource,
                ItemsLayouter = new LinearLayouter(),
                ItemTemplate = new DataTemplate(() =>
                {
                    return new box.CustomReservedList();
                }),

            };
            reservedList.Add(reservedListContainerView);

            
            
            

        }


    }
}

using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.Collections.Generic;

namespace BoxStation.bus
{
    public partial class Purchase : ContentPage
    {
        public Purchase()
        {
            InitializeComponent();

            List<Data.Buses> busesDataSource = new List<Data.Buses>();
            foreach (var item in Data.Resources.Buses)
            {
                busesDataSource.Add(new Data.Buses(item.bst, item.bsn, item.desti, item.min, item.loc));
            }
            busAppBar.Title = busesDataSource[0].BusStation;
            //NONE.Add(new CustomBus(busesDataSource[0], 0.00f));
            bus1.Add(new CustomBus(busesDataSource[0], 0.1f));
            bus2.Add(new CustomBus(busesDataSource[1], 0.1f));
            bus3.Add(new CustomBus(busesDataSource[2], 0.1f));
            bus4.Add(new CustomBus(busesDataSource[3], 0.1f));
            //collectionView에 보여주기. 
        }

        private bool Button_TouchEvent(object source, TouchEventArgs e)
        {
            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(new bus.Money());
            return true;
        }
    }
}

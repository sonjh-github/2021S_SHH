using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Components;
using System.Net.Http;

namespace BoxStation.bus
{
    public partial class Bus : ContentPage
    {
        public Bus()
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

        private async void Button_Clicked(object sender, ClickedEventArgs e)
        {
            string weather;
            weather = await new HttpClient().GetStringAsync("http://api.weatherapi.com/v1/current.json?key=76baf26e0abb49ac886122656212808&q=Daejeon&aqi=yes");
            string[] val_w = weather.Split('"');

            string degree = val_w[36];
            string raindrop = val_w[38];

            string w_sen = "대전의 체감온도는 " + degree[1] + degree[2] + degree[3] + degree[4] + "도, 예상 강수량은 " + raindrop[1] + raindrop[2] + raindrop[3] + "mm입니다. ";
            weather_val.Text = w_sen;
        }

        private async void Button_Clicked_1(object sender, ClickedEventArgs e)
        {
            string dust;
            dust = await new HttpClient().GetStringAsync("http://api.airvisual.com/v2/nearest_city?key=6db46eac-7262-4da1-918f-6c5fa12bf0dc");
            string[] val_l = dust.Split('"');
            dust_val.Text = val_l[62];
            string d_sen = "대전의 미세먼지는 " + dust_val.Text[1] + dust_val.Text[2] + "ppm입니다.";
            dust_val.Text = d_sen;
        }

        private bool Button_TouchEvent(object source, TouchEventArgs e)
        {
            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(new bus.Main2());
            return true;
        }
    }
}

using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BoxStation.bus
{
    public partial class Lock : ContentPage
    {
        public Lock()
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

        private bool enterPW_TouchEvent(object source, TouchEventArgs e)
        {
            SetPasswordOnlyDigit(enterPW);
            return true;
        }

        private void SetPasswordOnlyDigit(TextField field)
        {

            /*hide password 
             * PropertyMap passwordMap = new PropertyMap();
            passwordMap.Add(HiddenInputProperty.Mode, new PropertyValue((int)HiddenInputModeType.HideAll));
            passwordMap.Add(HiddenInputProperty.SubstituteCharacter, new PropertyValue(0x2022));
            field.HiddenInputSettings = passwordMap;*/

            InputMethod inputMethod = new InputMethod();
            inputMethod.PanelLayout = InputMethod.PanelLayoutType.Password;
            field.InputMethodSettings = inputMethod.OutputMap;

            field.TextChanged += (s, e) =>
            {
                string str = Regex.Replace(e.TextField.Text, @"[\D_]", "");
                e.TextField.Text = str;
            };
        }

        private void enterPW_TextChanged(object sender, TextField.TextChangedEventArgs e)
        {
        }

        private void enterPW_MaxLengthReached(object sender, TextEditor.MaxLengthReachedEventArgs e)
        {

        }

        private bool Button_TouchEvent(object source, TouchEventArgs e)
        {
            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(new bus.Confirm());
            return true;
        }
    }
}

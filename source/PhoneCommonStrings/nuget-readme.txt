To use, either access the resource classes directly from the PhoneCommonStrings namespace or bind to them by:

1. Adding the following declaration to App.xaml's root element

	xmlns:pcs="clr-namespace:PhoneCommonStrings;assembly=PhoneCommonStrings"

2. Adding the following to Application.Resources in App.xaml
        
	<pcs:CommonStringsAccessor x:Key="PhoneCommonStrings" />

3. Binding to a value in a page

	<Button Content="{Binding Actions.PinToStartAction, Source={StaticResource PhoneCommonStrings}}" />


NOTE: BindableApplicationBar is recommended for using localized application bar text
Welcome to Crafty Clicks Api Nuget
 This has been upgraded to .net core 3.1 and u
 Step 1 
 
 Install via Nuget 
 
 https://www.nuget.org/packages/CraftyClicks.PostCode.Loookup.1.0.1/1.0.1
 
 nstall-Package CraftyClicks.PostCode.Loookup.1.0.2 -Version 1.0.2
 
 Include the following two urls in the appsettings of your config file.

 <add key="CraftyClicksApiUrl" value="http://pcls1.craftyclicks.co.uk/json/rapidaddress" />
 <add key="CraftyClicksSingleApiUrl" value="http://pcls1.craftyclicks.co.uk/json/rapidaddress" />
  
 Setp 3 
 Add your Crafty Clicks api code to the this can be the default appsettings in 
 web.config or app.config file in the format off.
  
 <add key="CraftyClicksApiKey" value="REPLACE-WITH-YOUR-KEY" />

 Step 4

 Use the following using statments:

 using CraftyClicksPostCodeApi;
 using CraftyClcks.Models;

 Add the following propertie references:

        public static List<ClsAddress> addressList = new List<ClsAddress>();
        public CraftyClicksRapidAddressLoookup  _mCraftyClicks = new  CraftyClicksRapidAddressLoookup();

Step 5
 On  a button click method or simlar can even been within a ajax panel 

           _mCraftyClicks.GetRapidAddressByPostCode(txtPostCode.Text);
            addressList = _mCraftyClicks.addressList;
Thats is thats all there is two it feel free to play about with the various methods that are contained in the dll we will be functions 
in due corse.

This nuget is not copyright Crafty Clicks but David Buckley Crafty Clicks do not support this nuget in any way.
      


Welcome to Crafty Clicks Api Nuget
 This Crafty Clicks api was Created by me David Buckley, to allow .net developers to use the super easy api by Crafty Clicks

 The Crafty Clicks api allows you to look up uk address in single format and multiple to setup the Crafty Clicks in your web app
 or dekstop app please make sure to complete the following setps.

 Step 1 
 Include the following two urls in the appsettings of your config file.

 <add key="CraftyClicksApiUrl" value="http://pcls1.craftyclicks.co.uk/json/rapidaddress" />
 <add key="CraftyClicksSingleApiUrl" value="http://pcls1.craftyclicks.co.uk/json/rapidaddress" />
  
 Setp 2 
 Add your Crafty Clicks api code to the this can be the default appsettings in 
 web.config or app.config file in the format off.
  
 <add key="CraftyClicksApiKey" value="REPLACE-WITH-YOUR-KEY" />

 Step 3 

 Use the following using statments:

 using CraftyClicksPostCodeApi;
 using CraftyClcks.Models;

 Add the following propertie references:

        public static List<ClsAddress> addressList = new List<ClsAddress>();
        public CraftyClicksRapidAddressLoookup  _mCraftyClicks = new  CraftyClicksRapidAddressLoookup();

Step 4 
 On  a button click method or simlar can even been within a ajax panel 

           _mCraftyClicks.GetRapidAddressByPostCode(txtPostCode.Text);
            addressList = _mCraftyClicks.addressList;
Thats is thats all there is two it feel free to play about with the various methods that are contained in the dll we will be functions 
in due corse.

This nuget is not copyright Crafty Clicks but David Buckley Crafty Clicks do not support this nuget in any way.
      


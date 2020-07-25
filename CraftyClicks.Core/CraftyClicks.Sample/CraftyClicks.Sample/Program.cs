using CraftyClcks.Models;
using CraftyClicksPostCodeApi;
using System;
using System.Collections.Generic;

namespace CraftyClicks.Sample {
    class Program {

        static List<ClsAddress> addressList = new List<ClsAddress>();
        static CraftyClicksRapidAddressLoookup _mCraftyClicks = new CraftyClicksRapidAddressLoookup();

        static void Main(string[] args) {
   

            Console.Write("Please enter postcode :");

            string _inputPostCode = Console.ReadLine().Trim();



            _mCraftyClicks.GetRapidAddressByPostCode(_inputPostCode);
            addressList = _mCraftyClicks.addressList;

            string status = _mCraftyClicks.mStatus;

            foreach (var node in addressList) {
                Console.Write("Address Line 1 " + node.AddressLine1 + "\n");
                Console.Write("Address Line 2 " + node.AddressLine2 + "\n");
                Console.Write("County " + node.County + "\n");
                Console.Write("Post Code " + node.PostCode + "\n");

            }
            Console.Write("Error " + status);
            Console.Read();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CraftyClicksPostCodeApi;
using CraftyClcks.Models;
namespace CraftyClicksExampleApp
{
    static class Program
    {
        static List<ClsAddress> addressList = new List<ClsAddress>();
        static CraftyClicksRapidAddressLoookup _mCraftyClicks = new CraftyClicksRapidAddressLoookup();

        static void Main(string[] args)
        {

            Console.Write("Please enter postcode :");

        string _inputPostCode = "BT399YY";


   
            _mCraftyClicks.GetRapidAddressByPostCode(_inputPostCode);
            addressList = _mCraftyClicks.addressList;

            Console.Write(addressList.ToList());

        }
}
}

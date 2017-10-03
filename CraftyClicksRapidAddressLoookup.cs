﻿using CraftyClcks.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CraftyClicksPostCodeApi
{

    public class CraftyClicksRapidAddressLoookup
    {


        public List<ClsAddress> addressList = new List<ClsAddress>();
        public string mStatus { get; set; }
        public string mApiKey { get; set; }
        public string url;
        public void GetRapidAddressByPostCode(string mPostCode)
        {

            mApiKey = ConfigurationManager.AppSettings["CraftyClicksApiKey"];
            string urlToApi = ConfigurationManager.AppSettings["CraftyClicksApiUrl"];
           

            if (!String.IsNullOrEmpty(urlToApi))
            {
                 url = String.Format(urlToApi + "?postcode={0}&response=data_formatted&key={1}",
                  mPostCode, mApiKey);

            }
            else
            {
                 url = String.Format("http://pcls1.craftyclicks.co.uk/json/rapidaddress?postcode={0}&response=data_formatted&key={1}",
              mPostCode, mApiKey);
            }



            //Complete XML HTTP Request
            WebRequest request = WebRequest.Create(url);
            //Complete XML HTTP Response
            WebResponse response = request.GetResponse();

            //Declare and set a stream reader to read the returned XML
            StreamReader reader = new StreamReader(response.GetResponseStream());

            string json = reader.ReadToEnd();
            // Get the requests json object and convert it to in memory dynamic
            // Note: that you are able to convert to a specific object if required.
            var jsonResponseObject = JsonConvert.DeserializeObject<dynamic>(json);
            if (jsonResponseObject != null)
            {
                if (jsonResponseObject.delivery_points != null)
                {
                    //If the node list contains address nodes then move on.
                    int i = 0;

                    foreach (var node in jsonResponseObject.delivery_points)
                    {
                        ClsAddress address = new ClsAddress()
                        {
                            AddressID = i,
                            AddressLine1 = node.line_1,
                            AddressLine2 = node.line_2,

                            County = jsonResponseObject.postal_county,
                            PostCode = jsonResponseObject.postcode,
                            Town = jsonResponseObject.town
                        };

                        addressList.Add(address);
                        i++;
                    }
                }
                else
                {
                    foreach (var node in jsonResponseObject)
                    {
                        // Get the details of the error message and return it the user.
                        switch ((string)node.Value)
                        {
                            case "0001":
                                mStatus = "Post Code not found";
                                break;
                            case "0002":
                                mStatus = "Invalid Post Code format";
                                break;
                            case "7001":
                                mStatus = "Demo limit exceeded";
                                break;
                            case "8001":
                                mStatus = "Invalid or no access token";
                                break;
                            case "8003":
                                mStatus = "Account credit allowance exceeded";
                                break;
                            case "8004":
                                mStatus = "Access denied due to access rules";
                                break;
                            case "8005":
                                mStatus = "Access denied, account suspended";
                                break;
                            case "9001":
                                mStatus = "Internal server error";
                                break;
                            default:
                                mStatus = (string)node.Value;
                                break;
                        }
                    }
                }
      




        }
        }

        public async Task<List<ClsAddress>> GetRapidAddresstByPostCodeAsync(string mPostCode)
        {

            mApiKey = ConfigurationManager.AppSettings["CraftyClicksApiKey"];
            string urlToApi = ConfigurationManager.AppSettings["CraftyClicksApiUrl"];
            string url = String.Format(urlToApi + "?postcode={0}&response=data_formatted&key={1}",
                  mPostCode, mApiKey);


            mApiKey = ConfigurationManager.AppSettings["CraftyClicksApiKey"];


            if (!String.IsNullOrEmpty(urlToApi))
            {
                url = String.Format(urlToApi + "?postcode={0}&response=data_formatted&key={1}",
                 mPostCode, mApiKey);

            }
            else
            {
                url = String.Format("http://pcls1.craftyclicks.co.uk/json/rapidaddress?postcode={0}&response=data_formatted&key={1}",
             mPostCode, mApiKey);
            }
            //Complete XML HTTP Request
            WebRequest request = WebRequest.Create(url);
            //Complete XML HTTP Response
            WebResponse response = request.GetResponse();

            //Declare and set a stream reader to read the returned XML
            StreamReader reader = new StreamReader(response.GetResponseStream());



            string json = reader.ReadToEnd();
            // Get the requests json object and convert it to in memory dynamic
            // Note: that you are able to convert to a specific object if required.
            var jsonResponseObject = JsonConvert.DeserializeObject<dynamic>(json);
            if (jsonResponseObject != null)
            {
                if (jsonResponseObject.delivery_points != null)
                {
                    //If the node list contains address nodes then move on.
                    int i = 0;

                    foreach (var node in jsonResponseObject.delivery_points)
                    {
                        ClsAddress address = new ClsAddress()
                        {
                            AddressID = i,
                            AddressLine1 = node.line_1,
                            AddressLine2 = node.line_2,

                            County = jsonResponseObject.postal_county,
                            PostCode = jsonResponseObject.postcode,
                            Town = jsonResponseObject.town
                        };

                        addressList.Add(address);
                        i++;
                    }
                }
                else
                {
                    foreach (var node in jsonResponseObject)
                    {
                        // Get the details of the error message and return it the user.
                        switch ((string)node.Value)
                        {
                            case "0001":
                                mStatus = "Post Code not found";
                                break;
                            case "0002":
                                mStatus = "Invalid Post Code format";
                                break;
                            case "7001":
                                mStatus = "Demo limit exceeded";
                                break;
                            case "8001":
                                mStatus = "Invalid or no access token";
                                break;
                            case "8003":
                                mStatus = "Account credit allowance exceeded";
                                break;
                            case "8004":
                                mStatus = "Access denied due to access rules";
                                break;
                            case "8005":
                                mStatus = "Access denied, account suspended";
                                break;
                            case "9001":
                                mStatus = "Internal server error";
                                break;
                            default:
                                mStatus = (string)node.Value;
                                break;
                        }
                    }




                  
                }
            
            }
            return await Task.Run(() => addressList);
        }

    }
}

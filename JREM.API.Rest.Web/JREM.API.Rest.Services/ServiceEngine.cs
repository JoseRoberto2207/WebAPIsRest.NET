using JREM.API.Rest.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Net;
using JREM.API.Rest.Core;
using Newtonsoft.Json;

namespace JREM.API.Rest.Services
{
    public class ServiceEngine
    {
        public MethodResponse<PlaceHolder> GetJsonPlaceHolder(string id)
        {
            var response = new MethodResponse<PlaceHolder>();
            try
            {
                var callBackUrl = "https://jsonplaceholder.typicode.com/todos/";
                string url = string.Format("{0}{1}", callBackUrl, id);
                HttpWebRequest http = (HttpWebRequest)WebRequest.Create(url);
                http.Method = "GET";
                http.ContentType = "application/json";
                var res = string.Empty;

                using (System.Net.WebResponse rp = http.GetResponse())
                {
                    if (rp != null)
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(rp.GetResponseStream()))
                        {
                            res = sr.ReadToEnd().Trim();
                        }
                    }
                }
                var placeHolder = JsonConvert.DeserializeObject<PlaceHolder>(res);

                response.Code = 0;
                response.Result = placeHolder;                

                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponse<PlaceHolder>() { Code = -1, Message = "Error en api JsonPlaceHolder: " + ex.Message };
            }            
        }
    }
}

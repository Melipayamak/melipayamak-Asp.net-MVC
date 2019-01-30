public class RestClient
{
    private const string endpoint = "https://rest.payamak-panel.com/api/SendSMS/";
    private const string sendOp = "SendSMS";

    private const string getDeliveryOp = "GetDeliveries2";
    private const string getMessagesOp = "GetMessages";
    private const string getCreditOp = "GetCredit";
    private const string getBasePriceOp = "GetBasePrice";
    private const string getUserNumbersOp = "GetUserNumbers";
    private const string sendByBaseNumberOp = "BaseServiceNumber";

    private string UserName;
    private string Password;

    public RestClient(string username, string password)
    {
        UserName = username;
        Password = password;
    }

    public RestResponse Send(string to, string from, string message, bool isflash)
    {
        var values = new Dictionary<string, string>
        {
            { "username", UserName },
            { "password", Password },
            { "to" , to },
            { "from" , from },
            { "text" , message },
            { "isFlash" , isflash.ToString() }
        };

        var content = new FormUrlEncodedContent(values);

        using (var httpClient = new HttpClient())
        {
            var response = httpClient.PostAsync(endpoint + sendOp, content).Result;
            var responseString = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<RestResponse>(responseString);
        }
    }

    public RestResponse SendByBaseNumber(string text, string to, int bodyId)
    {
        var values = new Dictionary<string, string>
        {
            { "username", UserName },
            { "password", Password },
            { "text" , text },
            { "to" , to },
            { "bodyId" , bodyId }
        };

        var content = new FormUrlEncodedContent(values);

        using (var httpClient = new HttpClient())
        {
            var response = httpClient.PostAsync(endpoint + sendByBaseNumberOp, content).Result;
            var responseString = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<RestResponse>(responseString);
        }
    }

    public RestResponse GetDelivery(long recid)
    {
        var values = new Dictionary<string, string>
        {
            { "UserName", UserName },
            { "PassWord", Password },
            { "recID" , recid.ToString() },
        };

        var content = new FormUrlEncodedContent(values);

        using (var httpClient = new HttpClient())
        {
            var response = httpClient.PostAsync(endpoint + getDeliveryOp, content).Result;
            var responseString = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<RestResponse>(responseString);
        }
    }


    public RestResponse GetMessages(int location, string from, string index, int count)
    {
        var values = new Dictionary<string, string>
        {
            { "UserName", UserName },
            { "PassWord", Password },
            { "Location" , location.ToString() },
            { "From" , from },
            { "Index" , index },
            { "Count" , count.ToString() }
        };

        var content = new FormUrlEncodedContent(values);

        using (var httpClient = new HttpClient())
        {
            var response = httpClient.PostAsync(endpoint + getMessagesOp, content).Result;
            var responseString = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<RestResponse>(responseString);
        }
    }

    public RestResponse GetCredit()
    {
        var values = new Dictionary<string, string>
        {
            { "UserName", UserName },
            { "PassWord", Password },
        };

        var content = new FormUrlEncodedContent(values);

        using (var httpClient = new HttpClient())
        {
            var response = httpClient.PostAsync(endpoint + getCreditOp, content).Result;
            var responseString = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<RestResponse>(responseString);
        }
    }

    public RestResponse GetBasePrice()
    {
        var values = new Dictionary<string, string>
        {
            { "UserName", UserName },
            { "PassWord", Password },
        };

        var content = new FormUrlEncodedContent(values);

        using (var httpClient = new HttpClient())
        {
            var response = httpClient.PostAsync(endpoint + getBasePriceOp, content).Result;
            var responseString = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<RestResponse>(responseString);
        }
    }

    public RestResponse GetUserNumbers()
    {
        var values = new Dictionary<string, string>
        {
            { "UserName", UserName },
            { "PassWord", Password },
        };

        var content = new FormUrlEncodedContent(values);

        using (var httpClient = new HttpClient())
        {
            var response = httpClient.PostAsync(endpoint + getUserNumbersOp, content).Result;
            var responseString = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<RestResponse>(responseString);
        }
    }

}


//response class
public class RestResponse
{
    public string Value { get; set; }
    public int RetStatus { get; set; }
    public string StrRetStatus { get; set; }
}

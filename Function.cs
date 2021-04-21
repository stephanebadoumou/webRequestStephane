using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]


namespace WebRequestApiAssignment9
{
    [Serializable]
    public class Function
    {

        public static readonly HttpClient client = new HttpClient();

        public async Task<ExpandoObject> FunctionHandler(APIGatewayProxyRequest input, ILambdaContext context)
        {
            string lisBestSeller = await client.GetStringAsync("https://api.nytimes.com/svc/books/v3/lists/current/hardcover-fiction.json?api-key=vvIEkOE3bG6qWYYFkU48fZhtv7w9n6Nk");
  
            dynamic sampleObject = JsonConvert.DeserializeObject<ExpandoObject>(lisBestSeller);

            return sampleObject;
        }
    }
}





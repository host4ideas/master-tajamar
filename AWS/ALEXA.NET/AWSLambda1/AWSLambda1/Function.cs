using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Response;
using Amazon.Lambda.Core;
using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
//[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AWSLambda1;

public class Function
{

    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    /// </summary>
    /// <param name="input"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public SkillResponse FunctionHandler(SkillRequest request, ILambdaContext context)
    {
        SkillResponse response = new SkillResponse();
        response.Response = new ResponseBody();
        response.Response.ShouldEndSession = false;
        IOutputSpeech innerResponse = null;
        ILambdaLogger log = context.Logger;
        log.LogLine($"Skill Request Object:" + JsonConvert.SerializeObject(request));
        innerResponse = new PlainTextOutputSpeech();
        (innerResponse as PlainTextOutputSpeech).Text = "Estoy en Alexa con C#!!!";
        response.Response.OutputSpeech = innerResponse;
        response.Version = "1.0";
        return response;
    }
}

using EvalBackendAz.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using System.Net;
using EvalBackendAz.Entities;

namespace EvalBackendAz
{
    public class EventsFunction
    {
        private readonly ILogger<EventsFunction> _logger;
        private readonly IEventServices _eventServices;

        public EventsFunction(ILogger<EventsFunction> logger, IEventServices eventServices)
        {
            _logger = logger;
            _eventServices = eventServices;
        }


        [Function("AddEventsFunction")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "events")] HttpRequestData req)
        {

            try

            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var events = JsonConvert.DeserializeObject<Events>(requestBody);

              
               
                await _eventServices.AddEventsAsync(events);

                var response = req.CreateResponse(HttpStatusCode.Created);
                response.Headers.Add("Content-Type", "application/json");

   

                return response;
            }
            catch (JsonException ex)
            {
                return req.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Internal server error: {ex}");
                return req.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [Function("GetAllEventsFunction")]
        public async Task<HttpResponseData> GetAll([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "events")] HttpRequestData req)
        {
            try
            {
                var allEvents = await _eventServices.GetAllEventsAsync();

                var response = req.CreateResponse(HttpStatusCode.OK);
                response.Headers.Add("Content-Type", "application/json");

                await response.WriteStringAsync(JsonConvert.SerializeObject(allEvents));

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Internal server error: {ex}");
                return req.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [Function("UpdateEventsFunction")]
        public async Task<HttpResponseData> UpdateEvent([HttpTrigger(AuthorizationLevel.Function, "put", Route = "events/{id}")] HttpRequestData req, Guid id)
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var updatedEvent = JsonConvert.DeserializeObject<Events>(requestBody);

                updatedEvent.Id = id;

                await _eventServices.UpdateEventsAsync(updatedEvent);

                var response = req.CreateResponse(HttpStatusCode.OK);
                response.Headers.Add("Content-Type", "application/json");
                await response.WriteStringAsync(JsonConvert.SerializeObject(updatedEvent));

                return response;
            }
            catch (JsonException ex)
            {
                return req.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Internal server error: {ex}");
                return req.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }











    }
}

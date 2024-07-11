using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;

namespace APIEndPointWireMockExample.Support
{
    internal class WireMockProgram
    {
        public static void Main(string[] args)
        {
            var server = WireMockServer.Start(new WireMockServerSettings
            {
                Port = 8080
            });

            // Mock endpoint for borrowing a book
            server.Given(Request.Create().WithPath("/api/books/borrow").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(new { message = "Book borrowed successfully" }));

            // Mock endpoint for returning a book
            server.Given(Request.Create().WithPath("/api/books/return").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(new { message = "Book returned successfully" }));

            // Mock endpoint for checking the status of a book
            server.Given(Request.Create().WithPath("/api/books/status/1").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(new { status = "available" }));

            server.Given(Request.Create().WithPath("/api/books/status/2").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(new { status = "borrowed" }));

            System.Console.WriteLine("WireMock server running at {0}", server.Url);
            System.Console.ReadLine();

            server.Stop();
        }
    }
}

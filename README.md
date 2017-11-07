This demo application demonstrates how to implement communication between Actors and Angular frontend using SignalR. 

Device actor's data (device profile, location, etc) can be updated by sending requests to an API. An API handles request, creates the command and publishes the command through the application. Command handler runs the code, which updates device actor's data and aggregated data. It sends event if command was executed sucessfuly. Aggregated data service sends messages to SignalR hub by groups with some duration, it allows to handle 100K+ updates. Angular client reads these messages and displays devices on the Bing map.

Frameworks and tools:
- .NET 4.6.2
- ASP.Net Core
- FluentValidation
- MediatR
- Microsoft.ServiceFabric
- SignalR
- Angular 4
- Angular CLI 1.5
- Bing Maps
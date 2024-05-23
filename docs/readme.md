# AlphaUrsae Architectual Structure
AlphaUrsae is a **Composable Microservice Architecture** (CMA) which enables you to create enterprise grade applications from a bootstrap blueprint. 

As any other modern architectual blueprint, the oppenionated solution unlike others (e.g: clean architeture or hexagon) is designed to solve individual requirements per host or application. Whether you may have solution-wide components, host-, or application-wide components, the solution blueprint is designed to handle such complexity.

> Unlike other solutions, AlphaUrsae seems more complex with more projects due to the design principle.

### Get to know whats different
With the Composable Microservice Architecture, Services are referred as Applications. Small, uniform and specific implementations of business logic.

In addition, the blueprint is designed with an enterprise focus. Both size and complexity is adhering to the various requirements.

---

## Layers
Like any other architectual blueprint, AlphaUrsae is designed to have layers. The layers are designed to be composable and can be used inside-out.

The layers in prioritized order are:

### Core ###
* **Domain Layer(s)** - The domain layer is the core of the solution. It contains the any domain model. The domain layer is designed to be a pure C# library and can be used in any applications. Whether you implement [domain-driven-design](https://en.wikipedia.org/wiki/Domain-driven_design) (DDD) or a POCO layer, is up to you.  
* **Primitives** - The primitives layer is a layer that contains the basic building blocks of the solution. If you enable a primitives layer, we highly recommend you only have one and this is the inner most layer. Domains projects should inherit from Primitives.
* **Common** - The common layer is a shared layer of the solution. It should be designed as solution wide and preferrably inherted by the domain layer(s). Some prefer to use concrete extensions instead of a common project, which is why the reference blueprint hold a holder for *Extensions*, see below.

### Applications ###
* **Application Layer(s)** - The application layer is the layer that contains the application and business logic. Whether you have one or multiple application layers is a design choice.
  
  > The application layer is designed to be a thin layer that contains the application logic and inherit the domain layer (core). In addition, the application layer can make use of infrastructure services inherited from *Abstractions*.

  Choosing a monolithic architecture would mean you have one application layer. 
 
  Choosing a micro-service architecture would mean you have multiple application layers (per service or application).

  `Inherits Abstractions` 

### Abstractions ###
* **Abstraction(s)** - The abstractions layer is an infrastructure layer that contains the interfaces and abstractions for the infrastructure services. The abstractions layer is intentionally designed to be as thin as possible.

  > Abstractions are implemented in the *Implementations* using Dependency Injection.

### Implementations ###
* **Implementation(s)** - The implementations layer hold the conrete implementation of *Abstractions*. Whether you have a single abstractions projects or multiple, the implementations would mirror these projects 1:1.

  > Implementations are designed to be used in the *Application* layer via *Abstractions* layers using Dependency Injection.

  `Inherits Hostings` 
  `Deppendency Injected via ServiceDefaults`
  `Deppendency Injected via Hosts`

### Hosts ###
Hosts are the main operation points of applications. Per the reference architecture, your hosts may be API driven (most likely a micro-service) or event-driven (most likely a console host). The aim of the architectual blueprint is to be able to service all types of hosts.

* **ApiHosts** - ApiHosts are implemented as ASP.NET Core minimal projects. Each Api should make use of one or more applications.
* **AppHosts** - AppHosts are implemented as console applications.
* **Defaults** - Each host should have service defaults. The ServiceDefaults implements all required defaults and projects required per host.
* **Gateways** - ApiHosts may be unified by a Gateway. A Gateway is designed to route and handle each micro service (application). A common usage of [Microsoft Yarp](https://microsoft.github.io/reverse-proxy/) is recommended.

  `Inherits Hostings` 
  `Deppendency Injected via ServiceDefaults`
  `Deppendency Injected via Hosts`
 
### Hosting ###
For both**Hosts* and *Implementations* external components may be required. Examples of such components are:

* [StackExchange Redis](https://www.nuget.org/packages/StackExchange.Redis)
* Kafka
* [RabbitMQ](https://www.nuget.org/packages/RabbitMQ.Client/7.0.0-alpha.6)
* AWS S3
* Azure Storage
* Azure ServiceBus
* Entity Framework Core
* Etc.

To simplify the dependency integration, the hosting layer is designed to be a thin layer that contains the integration logic for the external components.

You can package each *Hosting* as a Nuget package and use it in your projects.

## Other solution options
* **Extensions** - The extensions layer is designed to be a per-use pluggable layer of the solution. Any extension should be designed as solution wide and preferrably implemented per project where required. 
  
  You can package each *Extensions* as a Nuget package and use it in your projects.

  > Extensions often replace the use of a *Common* layer.

* **Tests** - The tests layer is designed to be a thin layer that contains the test projects. The tests layer is designed to be a mirror of the *Core* layer.

  > The tests layer is designed to provide *integration*, *unit* and *functional* tests.

  ---

  Copyright (c) 2024
# My User API

---
- [x] Create a API project
- [x] Add swagger page
- [ ] Add CRUD endpoints
---
* An HTTP **Client**, such as web browser or app, sends a request as shown below:
```
GET /users HTTP/1.1
Host: http://localhost
Accept-Language: en-us
```
* The host (controller) process the request and sends a response as shown below:
```json
[
  {
    "id": 1,
    "name": "Jon",
    "email": "jon.doe@email.com"
  },
  {
    "id": 2,
    "name": "Jane",
    "email": "jane.doe@email.com"
  }
]
```

* Here's a flowchart showing interactions between different components:

```mermaid
flowchart TB;
style A fill:#008080,stroke:#fff,stroke-width:1px,color:#fff
style DB fill:#006666,stroke:#fff,stroke-width:1px,color:#fff
style C1 fill:#004c4c,stroke:#fff,stroke-width:1px,color:#fff
style C2 fill:#004c4c,stroke:#fff,stroke-width:1px,color:#fff
    
    subgraph API
        direction TB
        A(controller)<-- Read/Write -->DB[(Database)];        
    end

    subgraph Clients
        direction LR
        C1(Web Browser)
        C2(Console App)
    end

    C1<== HTTP Request / Response ==>A;  
    C2<== HTTP Request / Response ==>A;

    

    


```
---
* [Tutorial: Create a web API with ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?WT.mc_id=dotnet-35129-website&view=aspnetcore-7.0&tabs=visual-studio)
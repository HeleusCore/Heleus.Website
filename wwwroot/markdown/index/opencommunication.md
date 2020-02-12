::: { .fas .fa-broadcast-tower .display-3 .text-primary .mb-2 } 
:::

:::mb-5
## Open Communication {.h2 .primary-color}
The communication between you and a Heleus Core service is open and transparent. {.h5}
:::

We use [WebSockets](https://tools.ietf.org/html/rfc6455) as the communication
layer for everything. WebSockets are used for service-to-service and
client-to-service communication. They are a widly adopted standard and can be
used from basically any programming language and even from web browsers. The
communication itself is based on different types of transactions. For identity
validation, a transaction must contain a valid
[signature](https://en.wikipedia.org/wiki/Digital_signature) from your account. {.mb-4}
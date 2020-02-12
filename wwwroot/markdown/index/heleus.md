### The users must have 100% control of their data and privacy {.h3 .text-primary }

We want to build an ecosystem for (free) services and apps that respect the
privacy of the users. We understand that developers need to pay their bills at
the end of the day like everyone else. But the users were conditioned in the
last decades, that digital services should be free. Honestly, would you pay $10 a
month for a messenger or a social network? You probably wouldn't. But developing
something like that costs a lot of money.

And the easiest way to make money to pay the bills is to collect all your data and meta data,
link all this data to build a personal profile and finally use this against you.
Like using psycholocial tricks and algorithems to let you buy stuff that you
don't need or sell ~~illegally~~ your personal data to other external companies
for billions of profit.

We at Heleus Core don't want this anymore. We want to break free. Users
should not pay anymore with their loss of privacy. We provide a new and
better way to offer (free) services that respect the privacy of the users. {.mb-8}

### The Heleus Coin is the foundation for an independent ecosystem {.h3 .text-primary }

At the end of the day, everbody has to pay for their bills. For this reason, we
developed the Heleus Coin. It's a crypto currency, but with a purpose. Usually,
crypto currencies have no other purpose than being a crypto currency. But the
Heleus Coin is more, it is the foundation for our independent ecosystem.

Validated Heleus Core services generate the Heleus Coin as a compensation. And
the more successfull a service is, the more Heleus Coins it generates. And we also
let the users participate in this process as a certain amount of the generated
Heleus Coins go to the users of the service. And the users can use the Heleus Coins
to buy premium content or subscriptions for this or another service as the
Heleus Coin is valid in every Heleus Core service, it is not coupled to one
service.

As you can see, the Heleus Coin is the foundation for our independet Heleus Core
ecosystem. It has a purpose. It is powered by all the Heleus Core services and
the users, that use them on a daily basis. With the Heleus Coin, developers can
break free. They don't have to sell the data of their users to make money. They
can focus on building great apps and services with privacy in mind. {.mb-8}

### The Heleus Account is your anonymous digital identity {.h3 .text-primary }

We wanted to have one account that works accross all the Heleus Core services
that are available and will be available in the future, no matter if the service
is build by us or anyone else. And we wanted to get rid of the problem that you
need a password for everything.

We came to the conclusion to use a digital signature based system, to be exact
the [EdDSA signature scheme Ed25519](https://en.wikipedia.org/wiki/EdDSA). And
to store the public keys for all the accounts, we developed our own [public key
infrastructure](https://en.wikipedia.org/wiki/Public_key_infrastructure) based
on our blockchain technology. Or to make it less tech-savvy: You simply download
our [Heleus app](/heleus), register a new account and you're done.

For Heleus Core services, we used signed keys. Before you can use a Heleue Core
service, you must authorize it. This is done by providing a public key that is
signed with the key from your Heleus Account. This is, again, usually done with
our [Heleus app](/heleus).

By the way, if you want to be more than just a bunch of 32 bytes of random data, you
can use our [Heleus Profile service](/heleus#profile) to setup your own profile
with a name, profile image and more. This is a public service and used by all
other Heleus Core services. {.mb-8}

### The public transaction-based Heleus Database changes data handling fundamentally {.h3 .text-primary }

We wanted to use a new and open way to store user data. Usually, from the outside,
you don't operate on a database directly. You or your app sends a request with the data to
a [Web API](https://en.wikipedia.org/wiki/Web_API). This Web API processes your data
and stores the data in the database. But you have no control over your data or
what kind of data is stored in the database (maybe it contains meta-data that was
secretly collected without your knowledge). If you want to receive data, you
or your app sends a request to the Web API, which queries the database, processes
the data and sends you the result. Again, you see only, what you the developers
of the Web API want you to see. This is what we call a black-box, you don't know
what's inside it, you only have a defined way to communicate with it. And often,
you don't even know how to communicate with this black-box as it's blocked
for third-party developers.

With our Heleus Database, we simply remove this Web API layer, the black-box.
You or your app talks directly to the Heleus Database, if you want to store
or query data. It is not possible to store hidden data, as you would see it.
It's an open and transparent way to store and retrive data.

And to authorize your transaction against a Heleus Database, you must sign
your transaction with the digital signaure key from your Heleus Account (or with
the signed service key). {.mb-8}


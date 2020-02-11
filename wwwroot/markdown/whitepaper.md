# Heleus {.h1 .text-primary .font-weight-light}

### A decentralized back-end infrastructure utilizing distinct blockchains {.docs-heading .font-weight-light .pt-3}

::: {.anchor #js-scroll-to-abstract }
:::

### Abstract {.docs-heading .text-primary .font-weight-light .pt-3}

A generic decentralized back-end would allow to process data in an open and trusted way. The data would be available and verifiable by digital signatures for everyone and would not be hidden in a private back-end. And therefore, the data would be safe from modifications, hacks or censorship. This papers discusses such a decentralized infrastructure and it’s own crypto currency. The core of this infrastructure is the Heleus CoreChain, a blockchain that acts as a thin validation layer for everything. SideChains, which are created by developers and act as the base for their services, process and store the validated data. For paid services, developers can integrate different types of ~~in-app~~ purchases (features, subscriptions and consumables) based on the Heleus Coin.

::: {.anchor #js-scroll-to-introduction }
:::

### Introduction {.docs-heading .text-primary .font-weight-light .pt-3}

In the last years, the blockchain technology and especially the peer-to-peer crypto currencies based on it became more and more popular. They allow open, transparent, replicable, immutable and direct online payments without the need for a financial institute or any other third-party entity. With thousands of different currencies, including the most popular like Bitcoin, Monero, Ethereum and Ripple, there doesn’t seem to be a need for another one. And it is true, there is no need for another crypto currency just for the purpose of having one more. And the blockchain technology is so interesting and has much more to offer than simply transferring money from one account to another.

The idea of Heleus is to use the blockchain technology as a base for a decentralized back-end infrastructure. The goal is to build a self-contained and self-sustaining software ecosystem with it’s own crypto currency. On the one hand, this will allow new types of apps and services with a focus on open and transparent data models and on the other hand, it gives the Heleus Coin a purpose beyond just being a crypto currency.

To understand the principle of Heleus it is important to understand the three pillars it is based on. The first pillar is the CoreChain. It basically acts like any other blockchain by validating input, handling transactions and managing all the accounts. The second pillar are the SideChains (we will call them chains from now on). Developers build their services by using the chain technology, which store all the data that’s relevant to their services. The third pillar is the Heleus Coin and the ~~in-app~~ purchases. Users that want to use services based on Heleus do not send coins directly to the developers or share their accounts with them. Instead, they buy features, subscriptions or consumables, which allows them to operate on the chains.

This paper gives a brief overview of Core and its subsystems and is not intended as a complex and in-depth analysis. Fore more details, please refer the source code of Heleus.

::: {.anchor #js-scroll-to-core }
:::

### Core {.docs-heading .text-primary .font-weight-light .pt-3}

Heleus uses the blockchain technology as the base for its decentralized infrastructure. Unlike other implementations, Heleus does not utilize one huge and monolithic blockchain. Every service based on Heleus uses its own unique blockchain, called SideChain or just chain. To organize all the chains, to validate all the transactions and to handle all the accounts and their balances Heleus uses a blockchain called the CoreChain.

The Heleus Coin, the crypto currency used by Heleus, can only be transferred from and to accounts in the CoreChain. Chains use another concept for payment, ~~in-app~~ purchases. If developers want to charge a fee from the users for their services, they can issue different sorts of ~~in-app~~ purchases.

**Validation Layer** 

The Heleus CoreChain acts as the validation layer for all the data that is relevant to an account or to a chain. The CoreChain actually validates and stores a few types of transactions itself, the CoreTransactions, and their content like account registration, coin transfer from one account to another, ~~in-app~~ purchases and other things. But the CoreChain does not store chain transactions at all.

**Explicit Registration**

Accounts and chains require an explicit registration in the CoreChain. For an account, the issuer has to submit a request containing the public signing key from a generated pair of signing keys. The result of this request is a unique account id. All following transactions for this account require the account id and a digital signature from the private signing key.

A valid account is required to create a chain. The account owner submits a request to register a new chain and receives a unique chain id. After the registration the account owner can setup the service and ~~in-app~~ purchases for the chain.

::: {.anchor #js-scroll-to-sidechains }
:::

### Chains {.docs-heading .text-primary .font-weight-light .pt-3}

The blockchain is a powerful technology but to some extended it is very restricted. Most crypto currencies have exactly one huge blockchain and the possibilities to store data in it are very limited.

**To Fork or not to Fork** 

This leads to one big problem: If developers have specific demands and requirements –  beyond simple payments – that they want to solve with blockchain technology, they are usually forced to run their own blockchain. This is done by creating, for example, an incompatible fork of an already available crypto currency. The developers can now implement all the required features into the fork, but these changes are not compatible with the original anymore. Therefore, they have to build and run their own infrastructure.

Heleus solves this problem of incompatible forks with the use of chains. Developers simply create chains that act just like forks, but are still compatible with Heleus.

**Distinct Databases** 

A chain basically works like a database, decoupled from the CoreChain. The developers define what kind of transactions are allowed and what kind of purchases are required.

The initial release of Heleus will act as a simple NoSQL database, which can store and retrieve arbitrary text or binary values combined with a customizable validation-layer. 

**Custom Signing Keys** 

Every transaction on the CoreChain or a chain must contain a valid digital signature from the account that issued the transaction – Heleus uses Ed25519 for the digital signature. To be able to sign transactions, every account has a unique pair of signing keys. A public key, stored in the account itself and therefore available to everyone that can be used to validate the digital signature and a private key that is used to create a valid signature.

Using digital signatures is a great way for authentication and to generate trust. For a crypto currency, it’s a negligible task to sign all transactions, as a common person has probably a manageable amount of transfers per month. But this is problematic for a back-end where every transaction must be signed (think about a messenger app where you had to sign every message). This would imply that an account has to share its private signing key with other (untrusted) services to make it useable. And that’s a really bad idea.  As soon as the private signing key is shared with someone else the owner basically loses the control over the account. Malicious services can simply transfer all the money to others account or publish the private signing key on the internet.

Heleus Core uses a simple technique to solve this problem by utilizing custom pairs of signing keys for chains. Before an account can send requests to a chain, the owner must authorize it. This is done by sending a signed request to the CoreChain containing a newly generated public signing key and the id of the desired chain. On success of this request the newly generated public signing key is added to the chain and the account owner can send authorized requests to the chain by signing all transactions with the new private signing key. If the private signing key for a chain is lost, the account owner can authorize the chain again with a new pair of signing keys or revoke the old one.

The separation of the signing keys for the CoreChain and the chains is a big increase in security. Sharing the key of a chain can’t harm the account at all as it’s not possible to transfer money to other accounts. And if a key is lost or misused, the account owner can always revoke it.

::: {.anchor #js-scroll-to-coin }
:::

### Coin {.docs-heading .text-primary .font-weight-light .pt-3}

Heleus should be a complete, self-contained and self-sustaining software ecosystem. To achieve this goal and to minimize the external influence, it has its own crypto currency, the Heleus Coin. While it is possible to send money from one account to another account, like it is possible with all the other crypto currencies, the main purpose is to pay for the services based on Heleus.

To make the payments replicable, account owners don’t send coins directly to the developers account, they pay for ~~in-app~~ purchases. These ~~in-app~~ purchases are defined by the developer and have usually a special purpose. Exemplary, when account owners buy a three month subscription for a service, they can use the service back-end for the duration and the purpose of that subscription.

Another purpose of these ~~in-app~~ purchases is the simplification of the payment process. Usually, in a crypto currency, all transactions must be signed with the private signing key of the account owner. And depending on the app or service, this can require a lot of work, depending on the amount of transactions. And this might seduces account owners to give their  private signing keys to untrusted apps or services to simplify this process, which is an absolute no-go that could lead to the loss of all the money in an account. Using the subscription example from above, the account owners only have to sign the purchase transaction of the subscription once and will receive a special subscription token that can be used until it expires. To make the system more flexible, different types of ~~in-app~~ purchases are available in Heleus. Developers can mix all the different types, they are not forced to stick to a single type.

**Features.** A feature is a simple one-time purchase. When users buy a feature for an app or service, they can use it forever.

**Consumables.** A consumable is a product that can be used for one time and is depleted afterwards.

**Subscriptions.** A subscription works like a feature, but only for a certain period of time. The developers decide how long a subscription is valid (there is actually no hard time limit, a subscription can last a few seconds or various month).


::: {.anchor #js-scroll-to-consensus }
:::

### Consensus {.docs-heading .text-primary .font-weight-light .pt-3}

As Heleus is a decentralized infrastructure and more than just a virtual currency, one of the important requirement for the consensus algorithm is a short transaction time. It is not a big problem for a simple money transfer to take minutes, hours – as it’s currently the case for Ethereum and Bitcoin with their Proof of Work consensus algorithm – or even days for a conventional wire transfer. 

But these high delays are not acceptable for back-ends or apps; image you have to wait hours before your friends receive a text in a messenger. You will probably have uninstalled the app before the first text was sent.

This makes most of the current consensus algorithm like Proof of Work or Proof of Stake with their high block times and long confirmation times not really usable. And as every node in a network that uses these algorithms “fights” for itself and tries to be the fastest to gain the reward for generating the next block in the blockchain is not helpful either.

The goal for the Heleus consensus algorithm is to have the nodes in the network “work together” and not “fight each other” and achieve short block- and confirmation-times. As a note, Ripple uses a similar approach where – simplified – 80% of the network have to agree on a transaction.

**Proof of Council** 

For network consensus of the CoreChain, Heleus uses a quorum based voting system called Proof of Council. To speed up the processing time, not every node in the network is part of voting system, but only a small subset, the council.

Finding consensus is done in two phases. In the first phase, every member of the council collects transactions, validates them and shares them with the rest of the council. After a certain amount of time, a council member publishes the list of its validated transitions to all of the other members, which starts phase two, the voting rounds. In that phase, every member votes for this list. If more than 80% of the members agree, the list will be published as proposal to the rest of the network. 

If not enough members agree with a proposed list, they have to share the reason for the disagreement with the issuer of the list. The issuer can now modify the list and remove transactions. This new list will be published to all the council members and the next voting round starts. These voting rounds take place until enough members agree on a list.

It is also possible that another member publishes its own list during the voting rounds, due to network delays or a strong disagreement with the proposed list. In this case, if a proposed list does not get the required 80% of the votes, the list with the most votes during this round will be used as a base for the next voting round.

With the description of Proof of Council, it is easy to define the block- and confirmation-time. Phase 1 and phase 2 can run in parallel as the council can run the voting rounds for the current list while already collecting transactions for the next list. Therefore, the block-time is the maximum time required for either phase 1 or phase 2. The confirmation-time is exactly the same time as the block-time as every proposed list will be confirmed with the next list.

With an exemplary duration of two second for phase 1 and with the assumption that phase 2 should usually take less time than phase 1, the average transaction duration is four seconds plus the network delay.

**Council Members** 

As mentioned before, one of the goals of the consensus algorithm is to make the nodes in the network “work together” and not “fight each other”. This is achieved by selecting a variety of different members into the council and these members can be classified into three different groups. The first group contains the members from the most active chains, the second group contains members from randomly selected chains and the last group are just random members that may or may not belong to a chain. Every group has the same amount of members.

With the selection of these three groups coupled with a random factor, Heleus tries to have a high diversity in the council and to prevent 51% attacks to the network.

With *m > 1* members per group, the total number of votes *v* is

> *v = (3 + 1) * m* { .blockquote-v1 .blockquote-v1--left}

While there are only three groups, the factor is four. The reason for this is the fact, that the members of the most active chains have two votes, while all the other members have only one vote. For a successful vote *v~success~*, more than 75% of the votes have to agree

> *v~success~ = v - m + 1* { .blockquote-v1 .blockquote-v1--left}

and for vote *v~failure~* to fail, at least 25% have to disagree

> *v~failure~ = m* { .blockquote-v1 .blockquote-v1--left}

With an exemplary member count of five per group, there are a total of 20 votes. Of these 20 votes, 16 are required for a successful vote and five are required for a vote to fail. This shows that positive votes of all three groups are required for the council to find agreement.

**Spectre Nodes** 

Finding consensus in a distributed network is a hard problem. Even with a perfect algorithm, different external problems arise, like network latency or the failure of nodes.

To prevent Heleus Core from becoming non- responsive – for example a certain number of members crash and make it therefore impossible to reach the 80% of the votes – special nodes, called spectre nodes, watch the network and council all the time. After a certain amount of time or if they detect malicious behavior, they can complete or overrule the vote of the council. 

The purpose of the spectre nodes is to intervene, when the network does not behave as intended and not to disrupt every vote. The long time goal is to get rid of the spectre nodes in the future, when the Heleus network reaches a certain size and robustness. But at the beginning, they will be an important part of Heleus.

**Chain Consensus**

Consensus for chains works different from the CoreChain consensus. A chain collects all own validated transactions and bundles them in its own block. And instead of validating every transaction through the council, a block needs only at least one valid vote from every council group. With three valid votes, the chain sends a meta transaction to the CoreChain to validate the block. If the council accepts the block, all the included transactions are automatically validated.

The purpose of this separate process is to prevent the council from collapsing. High frequency chains, that maybe have hundreds of transactions a second, would jam the council. Therefore the chain processes all transactions. And the transaction will be validated by a small amount of members only. This ensures fast transactions and a high throughput.

**Rewards / Mining**

There will be a reward for providing computing power. Every member of the council will be rewarded with Heleus Coins. Developers that use Heleus as their base technology should be rewarded for their hard work. If a developer creates a popular service, they might even run it without ~~in-app~~ purchases, and still get enough money for it.

For the last group, the random members, there will be selection process. Maybe through a Proof-of-Work algorithm or maybe otherwise. How the selection process works will be decided in the future.

For all members, there will be an reputation system. The reputation will be based on e.g. response times, processing time, up time etc. The higher the reputation is, the higher will be the reward. The reason for a reputation system is to reward fast, long-living and reliable members.

::: {.anchor #js-scroll-to-conclusion }
:::

### Conclusion {.docs-heading .text-primary .font-weight-light .pt-3}

With the blockchain as a base, it’s own crypto currency and distinct chains, Heleus is more than just a crypto currency, it is a generic back-end. Heleus is made by developers for developers and at the end of the day, they decide if and what they want to use. They can only use the payment system and integrate it into their already existing services without a lot of work. Or they can build new and amazing stuff based on the chains. Heleus might not be the best fit for every service back-end out there, but with the blockchain as a base and the replicable and immutable operations that protects the data from modifications, hacks or censorship it’s a great alternative for all the black-box-services.

**Better Security**

Traditionally, every transaction in the classical blockchain must be signed with the private signing key of the account owner. This can be a clumsy and bothersome process. And sharing the private signing key with unknown apps and services requires a lot of trust and maybe results in the loss of all the coins in an account.

Through the use of the subscriptions and consumables model, all apps and services use their own pair of signing keys. Therefore, they have no access to the owner’s account. This makes it impossible for untrusted or rogue apps and services to harm an account or steal coins.

**Faster Transactions**

With the goal to establish a decentralized app and service infrastructure, transactions have to processed in a short period of time; in an acceptable timeframe for the users.

With the Heleus Proof of Council consensus algorithm, transactions require only seconds and not minutes or hours like in Ethereum or Bitcoin. Furthermore, Heleus is designed with high scalability in mind utilizing multiple Councils at the same time in the future.

**Decentralized Back-end**

Bitcoin and Ethereum are decentralized cryptocurrencies, but they are based on a huge monolithic blockchain. Heleus Core tries to resolve this problem of a monolithic blockchain by utilizing chains. 

Everyone can create new chains. What is done in a chain is up to the creator. Developers can implement smart contracts on the chain or assets management or whatever they want and use these in their services or offer it to other developers. And users can easily and securely use these apps and services. The CoreChain on the other hand just acts as a thin validation layer.

**No historic burdens**

The biggest problems with blockchains like Bitcoin and Ethereum, except the slow transaction times, are their consensus algorithms. Both – Proof or Work and Proof of Stake – have big drawbacks. Basically, the person or company with the deepest pockets always wins. Either by buying the best mining equipment available or by utilizing their high stake.

This will not be the case in Heleus, as the Proof of Council consensus algorithm tries to balance the members by selecting nodes from the top apps and services and on the other hand from a random selection.

**Easy Integration**

Heleus was not made to build just another crypto currency. The idea is to build a decentralized infrastructure that’s easy to integrate into other apps and services.

With the subscriptions and consumables model, which is also used by most of the popular app stores available, app and service developers have a powerful tool that’s easy to integrate.

The ultimate goal is to have a simple payment system and the power of the a public trusted blockchain combined.

**Faster Development**

The CoreChain of Heleus is only a really thin validation layer. The real “action” happens on all the chains.

Therefore, it is much easier to add new features to the Heleus Core infrastructure. Smart contracts, interaction with other blockchains, assets management and many other interesting fields won’t be part of the CoreChain, they will be developed as chains. Maybe by us or maybe by the community.

The separation of the CoreChain and the chain is one of the most interesting parts in Heleus Core and will make it the most flexible blockchain technology in the future.

::: {.anchor #js-scroll-to-terminology }
:::

### Terminology {.docs-heading .text-primary .font-weight-light .pt-3}

Most of the terminology in this paper should be known for people that payed attention to crypto currencies. For new readers, here is a short recap of the most important terms.

**Transaction**

The term transaction can be ambiguous in combination with a crypto currency as it has a different meaning in the finance and software sector. For Heleus Core, the term transaction is used as synonym for an arbitrary valid operation on the blockchain. Therefore, a transaction can be the transfer of money from one account to another, the storage of a binary blob or any other valid type of operation.

**Signature** 

Digital signatures are used as method of authentication. Instead of using passwords or encrypted connections, transactions are signed with the private signing key of the issuer. This produces a digital signature that can be verified by everyone with the public signing key of the issuer. Heleus Core uses Ed25519.

**Block** 

A block is a collection of different transactions. Validated transactions are accumulated over a certain period of time and bundled together in a block. This time is known as block-time.

**Chain**

A chain is a sorted list of blocks. To accomplish the correct order of the chain and the validity of a block, every block contains a reference to the previous block.

**Account** 

An account stores the current balance and the public signing key of the issuer. Unlike other crypto currencies, an account must be registered and the registrar receives a unique id for that account.

**Node** 

A node is a running instance of the Heleus Core software. It’s a single peer that spans, with the help of other nodes, the whole  peer-to-peer network. For crypto currencies that use Proof of Work as consensus algorithm, a node in the peer-to-peer network is often called a miner.

**Request** 

To operate on the blockchain, valid requests must be sent to it. A valid request usually consists of the operation type, the required payload for this transaction and a valid signature from the sending account. Requests are send to a public node.

**Consensus** 

In a peer-to-peer network, consensus means that the nodes try to find agreement on a decision across the network. In case of Heleus Core the nodes try to find consensus which submitted transactions are valid. 

::: {.anchor #js-scroll-to-example }
:::

### Example {.docs-heading .text-primary .font-weight-light .pt-3}

To join all the dots, it is often useful to give an example how everything works and go into details that were previously left out. In this case, the example is a simple image rights management app where photographers can upload their images combined with some meta-data and prove that they are the creators. But in an open way with the help of Heleus and not in a closed-blackbox-way. And to reduce the confusion, the example is split into two parts, the first parts shows what the developers have to do and the second part focuses on the users.

**The Developers** 

These are the required steps to setup and run the chain for the example app. Every Heleus node is also a public endpoint, therefore the app can directly communicate with this node and no other back-end code is required.

- Generate a valid Ed25519 signing key.
- Create an account with the generated signing public key.
- Create a chain based on the newly created account.
- Add a new “image” ~~in-app~~ purchase to the chain. In this case the consumables type is used. The idea is that for every uploaded image, the user needs to have at least one valid “image” consumable.
- Write a custom validation-layer that validates the input data from the transaction, in this case if the meta-data has the correct format and that the image is really an image (the custom validation-layer is optional).
- Setup and run a Heleus node for this chain. To run a trusted node for this chain, a valid chain signing key pair is required.

**The Users** 

This part assumes that the user already installed the Heleus wallet, created an account and transferred enough Heleus Coins to it. This mostly contains what actually happens in the background in Heleus. For the users, it’s just some buttons that need to be pressed.
- The first step involves authorizing the chain. The app generates it’s own Ed25519 signing key and sends it with some meta-data to the Heleus Wallet. The wallet app opens and the user can accept or reject the request from the app. 
- The next step requires to buy the consumables. The behavior is nearly the same in the previous step. A “buy” button redirects the user from the app to the wallet app where the user sees the “image” in-app purchase added by the developer. The user buys the amount of consumables needed and switches back to the app.
- The two steps above might sound complicated, but the user actually doesn’t have to do a lot as most of it is done automatically by the app in the background. And it is also possible to combine the first two steps. The step to add the user to the chain can be delayed and combined with the first in-app purchase.
- Finally, the user is known to the chain and has consumables to be able to upload images. The user takes a picture with the app, adds some meta-data and submits it. The app builds the correct transaction as defined by the developer, signs it with the apps signing key and sends it to the endpoint of the node. The endpoint from the chain makes some initial validations (valid account, valid signature, consumable available) and runs the custom validation-layer. If everything is correct, the transaction is bundled with all the other transactions in a chain block. When the block is validated, the chain sends the block meta-data to the council. The council will check the data and if everything looks fine, it is accepted. The CoreChain stores a reference to the block and the chain gets notified that the block was accepted and stores all its transactions permanently.
- When the transaction is stored in the chain the user gets a notification in the app and everything is done. The image and the meta-data are now stored in an open, transparent, replicable and immutable way and is available to everyone.

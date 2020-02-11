### How does Heleus Service work? [#](#js-scroll-to-howdoesheleuswork) {.h3 .text-primary }
::: {.anchor2 #js-scroll-to-howdoesheleuswork }  
:::
Here's an example, how a common messenger app works: The users selects the
receiver, types the message and presses send. The app sends this message
with some additional data, like the receiver, to a server. The server checks
and processes this data and stores it in a database. The receivers app
afterwards contacts the server and asks for new messages. The server queries
the database and sends it back and the app displays the message.

The communication between the app and the server is what we call a black-box
or a closed system. We don't know how these two components communicate. There
is usually no public documentation available and the service providers typically
don't want to share this knowlege. The goal is that the users use their apps
only. They want to collect sensitive data about the users and show their
advertising.

In Heleus Core, we simply remove the "server" part. A Heleus Service node is basically
a huge open database. Like in the example above, the app would assemble the
data to a transaction, sign the transaction with the correct digital signature
and send it to the database. And the receiver would query the database directly.
And all the communication is based on an open protocol. Everyone can participate.
**No more closed systems, no more vendor lock-in.** {.mb-8}

### Is there a Whitepaper? [#](#js-scroll-to-whitepaper) {.h3 .text-primary }
::: {.anchor2 #js-scroll-to-whitepaper }  
:::
Yes and no. Before we started to work an Heleus Core, we wrote down a
whitepaper with our ideas, goals and expectations. But after a certain amount
of time, when you spent some time to develop such a huge project, you notice
that there are parts, that won't fit. They might sound great in theory, but
are stupid or totally impraticable in reality. And there is a shift in
prority. The more you work on the certain features, you notice that they are
not that important anymore while other features need much more attention.

That why we switch early from a top-down to a bottom-up approach. After we had
a prototype up and running, we started to build our Heleus Apps around Heleus
Core. Through this approach, we could make Heleus Core more **reliable, faster and
scaleable**.

This means that **our inital whitepaper isn't a 100% accurate
representation of Heleus Core anymore**. And we thought it might be better
to put our time into developing Heleus Core further than writing a new
whitepaper. [But our initial whitepaper is still online and you can read
it.](/whitepaper) {.mb-8}

### What is the purpose of Heleus Core? [#](#js-scroll-to-thepurposeofheleus) {.h3 .text-primary }
::: {.anchor2 #js-scroll-to-thepurposeofheleus }  
:::
In the beginning of the web, everything was build around open standards.
Everyone could participate. Websites and emails, as an example, use open
standards. Everyone can build a web browser or email client - just for fun or
to make something better - or integrate it into other products. And there is
competition: companies are fighting hard to build the best, fasted and most
secure web browser. 

But that changed and **the web is dominated by closed system that are completely
incompatible to each other**, like your favorite messenger or social network.
And there is a complete vendor lock-in, you can only use websites and apps that
they provide. And integration into other services is impossible or highly
restricted. This is not acceptable anymore. And we will change that.

If we had open standards for messengers and social networks, users and companies
would again fight to build the best experience for the users. And that is the
purpose of Heleus Core. **We build an open infrastructure where everyone can
participate.** {.mb-8}


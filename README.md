Phosphorus Five - A Web Operating System
===============

Phosphorus Five is a Web Operating System and a full stack Web Application Development Framework, for consuming and developing rich and highly 
interactive and secure web apps. It contains an entirely unique programming language called _"Hyperlambda"_, which 
allows you to orchestrate your apps together, almost as if they were made out of LEGO bricks. You can test 
its [Hello World application online here](https://samples.gaiasoul.com/hello-world).

Phosphorus Five facilitates for an extremely modularised model of _"orchestrating"_ your applications together. 
Below is a screenshot of its _"desktop"_.

![alt screenshot](resources/screenshot-desktop-2.png)

## Installation

If you want to try out Phosphorus Five, you can do a _single click deployment_ of it to your own Virtual Private Server 
[here](https://samples.gaiasoul.com/auto-deployment). This gives you two weeks of testing for _"free"_, and includes server 
resource usage of up to $100 included.

Alternatively, to install the latest binary version of the system on your own Linux/Ubuntu server, run the following commands 
in a Linux/Ubuntu vanilla server terminal window, in order of appearance.

```
wget https://github.com/polterguy/phosphorusfive/releases/download/v5.0/install.sh
chmod +x install.sh
sudo ./install.sh
```

When you're done with one of the above, visit the _"Bazar"_ through your browser, and fill up your system with whatever apps you 
want to install. Below are screenshots of some of the more important apps you can fill up your system with. 
First [Sephia Five](https://github.com/polterguy/sephia-five), which is a military grade PGP cryptographically secured webmail client.

![alt screenshot](resources/screenshot-sephia.png)

Then a screenshot of a secure file sharing system, called [Sulphur Five](https://github.com/polterguy/sulphur-five).

![alt screenshot](resources/screenshot-sulphur.png)

Below is the [Peeples](https://github.com/polterguy/peeples) module, which allows you to manage users in your system.

![alt screenshot](resources/screenshot-peeples.png)

The framework, and its apps, are built with the _"mobile first"_ approach, and renders responsively on every device you have. When you start
Phosphorus Five for the first time, you will be asked for a _"server salt"_ and a _"root"_ password. The system is initially installed completely
empty, which allows you to decide which apps you want to install on top of it, after you have started it. Installing apps is done through the _"Bazar"_,
and the process is cryptographically secured, by demanding apps to be cryptographically signed, with a private PGP key, belonging to the app
developer. By default, only apps developed by T.H. Rose Home Cloud, or more explicitly _me_ that is, are allowed to be installed into your system.
But this is easily modified by adding up a reference to your own private PGP key's fingerprint.

## Downloading the source for the system

To download the source code for the system, go to [Releases](https://github.com/polterguy/phosphorusfive/releases), download
the latest source code for Phosphorus Five. Phosphorus Five (by default) depends upon [Micro](https://github.com/polterguy/micro/releases), 
so make sure you also download Micro, and put the unzipped folder into your _"/p5.webapp/modules/"_ folder, if you intend to use the source version.
It is probably wise to rename your Micro folder to become **exactly** _"micro"_ as you move it into the _"p5.webapp/modules/"_ folder of your Phosphorus
Five root folder - Since this makes upgrades and such easier for you.

Having Micro in your _"modules"_ folder is **crucial** - Since most other modules depends upon Micro being installed. Other modules are
optional. Any module you build yourself, must be put into the _"/core/p5.webapp/modules/"_ folder of your installation. To create your own apps,
you can start out with the [Hello World app](https://github.com/polterguy/hello-world/releases), which creates a _"template"_ for you when creating 
your own apps.

**Notice** - If you intend to use the source version of Phosphorus Five, you must make sure you install GnuPG, since GnuPG is used to manage PGP keys,
which among other things is required when you download and install apps through its _"Bazar"_. For the record, whether or not you install apps through
the _"Bazar"_ or download the zip source files for your apps, doesn't really matter, since the Hyperlambda files for your apps, is distributed as is, 
also when you install apps through the Bazar.

If you intend to use MySQL, either indirectly through e.g. Sephia Five or Sulphur Five etc, or directly in your own code - You must make sure you have
MySQL installed, and that you've modified your web.config file such that the connection string to your MySQL instance is correctly setup.

When you have downloaded the source code for Phosphorus Five and Micro, and installed GnuPG, and optionally MySQL, simply open Visual Studio, 
Xamarin or MonoDevelop, and browse for the _"p5.sln"_ file inside your Phosphorus Five source code folder, and open up this solution.

All of the above dependencies are automatically taken care of when you install the binary version of Phosphorus Five on for instance a Linux/Ubuntu server.

## Creating your own apps

Phosphorus Five is created in C#, but relies upon _"Hyperlambda"_. Hyperlambda is a modularised web application programming language, for
creating highly modularised components. Hyperlambda allows you to seemlessly integrate your modules together, and _"orchestrate"_ building blocks -
Similarly to how you would create things out of LEGO. An example of some Hyperlambda can be found below.

```
create-widget:foo
  element:button
  innerValue:Click me!
  onclick
    set-widget-property:foo
      innerValue:I was clicked!
```

Notice, the primary starting ground for learning how to code in Phosphorus Five can be found [here](https://github.com/polterguy/phosphorusfive-dox).
In addition, the reference documentation can be found as specific README files for each project. To see the documentation for P5, please
refer to these links.

* [Main documentation](https://github.com/polterguy/phosphorusfive-dox), tutorial style dox
* [core](core/), reference documentation
* [plugins](plugins/), reference documentation
* [modules](core/p5.webapp/modules/), how the modularized parts of Phosphorus Five works
* [The Bazar](core/p5.webapp/modules/bazar/), the integrated _"AppStore"_ that comes with P5 out of the box

I recommend you start out with ["The Guide"](https://github.com/polterguy/phosphorusfive-dox), for then to refer back to the reference documentation
for the [plugins](plugins/), as the need surface. Most of the examples in the core and plugin documentation, assumes you are 
using [System42](https://github.com/polterguy/system42), and either its Executor or CMS apps.

### Creating your own "AppStore"

Notice, Phosphorus Five comes with an integrated _"AppStore"_ out of the box, which allows you to create your own Bazars, where you distribute
your apps and components, either for a fee, or as open source projects. This approach, makes it extremely modularized, allowing you to incrementally
create your systems, allowing its users to automatically choose to upgrade theirs, as you create new versions of your apps, or create additional
apps, and/or components. The Bazar features automatic PayPal integration, and such allows you to charge for your apps automatically. This is easily
setup by changing two simple settings in your web.config as you create your own distributions, using e.g. [Hyperbuild](https://github.com/polterguy/hyperbuild).

Please refer to [the Bazar](core/p5.webapp/modules/bazar/) to see how this part of P5 works. However, everything is open source, and you can
actually host your Bazar, without any other requirements but being able to publicly distribute a simple Hyperlambda file, on some web server somewhere.
These parts of P5 is also extremely secure, only allowing installations of modules that have been cryptographically signed, with a trusted PGP key.
Making it very hard for a malicious adversary to being able to execute malicious code on your user's servers. The Bazar is highly configurable,
and you can easily create your own repository of apps, and distribute yourself, using the Bazar. The Bazar features automatic PayPal integration,
if you'd like to provide apps in your Bazar for a fee.

## Hyperlambda

The code further up in this page, is called _"Hyperlambda"_, and is a simple key/value/children tree-structure, allowing for you
to declare something, that P5 refers to as _"lambda"_ or _"Hyperlambda"_. Lambda is the foundation for an execution tree, or graph object,
that is a Turing complete opportunity to declare your apps, through a _"non-programming model"_.

Yet again, you can check out the [Hello World application here](https://samples.gaiasoul.com/hello-world) - Which also allows you to see its code.

I say _"non-programming"_, because really, there is no programming language in P5. Only a bunch of loosely
coupled Active Events, that happens to, in their combined result, create a Turing complete execution
engine, allowing for you to orchestrate your components together, as if they were _"LEGO bricks"_. All this, while retaining your ability 
to create C#/VB/F# code, exactly as you're used to from before.

In fact, if you wish, you could in theory declare your execution trees by using XML or JSON. Although I recommend
using Hyperlambda, due to its much more condens syntax, and lack of overhead.
This trait of Hyperlambda, makes it an excellent choice for creating your own domain specific programming languages. In such a regard, it arguably
brings LISP into the 21st Century. However, don't be fooled by its simplicity. P5 extremely powerful and secure. Below is a screenshot 
of Sephia Five's settings, that are entirely built in Hyperlambda.

![alt screenshot](resources/screenshot-sephia-settings.png)

Sephia Five is a military grade webmail client, with PGP cryptography, extreme security, and some very unique usability traits. Sephia Five
is one of the _"reference implemantations"_ for example applications built with Phosphorus Five. Sephia Five is also open source, and can be 
found [here](https://github.com/polterguy/sephia-five).

## 3 basic innovations

Phosphorus Five consists of three basic innovations.

* Managed Ajax
* Active Events
* Hyperlambda

The Ajax library is created on top of ASP.NET's Web Forms, allowing you to use them the same way you would create a web forms website.
Simply inject them declaratively into your markup, and change their properties and attributes in your codebehind. We say _"managed"_, because
it takes care of all state, Ajax serialization, and dynamic JavaScript inclusion automatically. In fact, when you use the Ajax library, you can
create your web apps, the same way you would normally create a desktop application. The Ajax library is extremely extendible, allowing you to create
your own markup, exactly as you wish. This is because there fundamentally exists only one single Ajax widget in the library. This approach allows 
you to declare your HTML tags, attributes, dynamically remove and change any parts of your DOM element, also during Ajax callbacks.

Active Events allows you to loosely couple your modules together, without having any dependencies between them. Active Events is the _"heart"_ of
Phosphorus Five, allowing for the rich plugin nature in P5. You can easily create your own Active Events, either in Hyperlambda, or in C# if you wish.
You can read an MSDN article about Active Events [here](https://msdn.microsoft.com/en-us/magazine/mt795187).

Hyperlambda, and lambda, is the natural bi-product of Active Events; A Turing complete execution engine, for orchestrating your apps 
together, as shown above in the Hello World example. By combining Active Events together with Managed Ajax and Hyperlambda - Your apps truly
_"comes alive"_, and creating rich web apps, becomes ridiculously easy. You can read an MSDN article about 
Hyperlambda [here](https://msdn.microsoft.com/en-us/magazine/mt809119).

### C#, a dynamic programming language!

These three innovations combined, makes C# become a _"dynamic"_ programming language. In fact, much more dynamic than any other dynamic programming
languages you have ever used.

## Perfect encapsulation and polymorphism

The 3 USPs mentioned above, facilitates for a development model, which allows you to combine your existing C# skills,
creating plugins, where you can assemble your apps, in a loosely coupled architecture. This is in stark
contrast to the traditional way of _"carving out"_ apps, using interfaces for plugins, which often creates a much higher degree of
dependencies between your app's different components.

The paradox is, that due to neither using OOP nor inheritance or types, in any ways, Hyperlambda facilitates for perfect encapsulation, and polymorphism,
without even as much as a trace of classic inheritance, OOP, or types. Hyperlambda is a _"functional programming language"_ on top of the CLR,
making the act of orchestrating CLR modules, loosely coupled together, in a super-dynamic environment, as simple as a walk in the park.

And for the record, I don't mean _"functional"_ as in F#, I mean **truly functional**!! Hyperlambda makes F# seem hopelessly obsolete!

## C# samples

For those only interested in using e.g. the Ajax library, and/or the Active Event implementation, there are some examples of this in 
the [samples folder](/samples/).

## Start coding

The easiest way to create your own P5 apps, is to use it in combination with [System42](https://github.com/polterguy/system42).
This gives you an intellisense environment for your Active Events, and provides a lot of developer tools, in addition to a bunch
of really cool extension widgets. All this in a _"non-CMS environment"_, which means you can create small apps, almost the same way you'd
create a CMS web page.

If you take this approach, which I recommend for beginners - Make sure you put the _"system42"_ folder inside of 
your _"/phosphorusfive/core/p5.webapp/modules/"_ folder, and make sure its name is exactly _"system42"_, without any versioning numbers, 
etc. Then restart your web server process.

After you've played around with System42 for some time, understanding the development model, you can go more hard-core into it, ditch System42,
and create your own apps, entirely from scratch if you wish. The latter approach is what I recommend for building real apps, which you intend
to distribute, and use in real live production sites. If you do, you might want to check out the [Hello World app](https://github.com/polterguy/hello-world).

Notice, regardless of which approach you take when you start out - You must make sure the _"/core/p5.webapp"_ project is your startup project, unless
you intend to evaluate Hyperlambda in a terminal window, using the lambda.exe project.

### Pre-requisites

If you'd like to start using the source code directly, obviously you'll need some sort of .Net building environment. If you're using a Mac or 
a Windows machine, this would probably imply using Visual Studio. On Linux you can use MonoDevelop. In addition, depending upon which apps you'd
like to install, you might also need some sort of GnuPG environment wrapper. I personally use the [GPG Suite](https://gpgtools.org/) for my Mac.
Which you'd like to use, depends upon your main operating system - But it must be something that is compatible with _"GPG"_ or "GNU Privacy Guard"_.

In addition, you might need to install MySQL if you'd like to use MySQL, either in your own applications, or in Sephia Five, Sulphur Five 
or Camphora, etc.

However, the absolutely easiest way of getting started, is actually to start out with a Linux server, and simply execute the installation script
which can be found [here](https://github.com/polterguy/phosphorusfive/releases). This might sound absurd for the uninitiated, but for the most parts,
you actually don't need an IDE to create your own apps in Phosphorus Five. And the installation script, will automatically pull in all dependencies
for you, as you execute it on a Debian based Linux server.

In fact, a simple text editor, such as Notepad+, or something similar, is all the _"IDE"_ you need to create Hyperlambda and Phosphorus Five apps.
And you can create your apps, directly on a production/development server, without even having Visual Studio or anything else installed - If you wish.

## More dox

Some of the folders inside of P5 have specific documentation for that particular module or folder. Feel free to start reading up at e.g.

* [plugins](plugins/)
* [core](core/)

Below is an extensive list of the documentation to all plugins in the core, in on single list, for your convenience. But there might also exist
other P5 components out there, in addition to that it is extremely easy to [roll your own plugin](/samples/p5.active-event-sample-plugin), 
if you know some C# from before.

* [p5.config](/plugins/p5.config) - Accessing your app's configuration settings
* [p5.data](/plugins/p5.data) - A super fast memory based database
* [p5.events](/plugins/p5.events) - Creating custom Active Events from Hyperlambda
* [p5.hyperlambda](/plugins/p5.hyperlambda) - The Hyperlambda parser
* [p5.io](/plugins/p5.io) - File input and output, in addition to folder management
* [p5.lambda](/plugins/p5.lambda) - The core "keywords" in P5
* [p5.math](/plugins/p5.math) - Math Active Events
* [p5.strings](/plugins/p5.strings) - String manipulation in P5
* [p5.types](/plugins/p5.types) - The types supported by P5
* [p5.web](/plugins/p5.web) - Everything related to web (Ajax widgets among other things)
* [p5.auth](/plugins/extras/p5.auth) - User and role management
* [p5.crypto](/plugins/extras/p5.crypto) - Some of the cryptography features of P5, other parts of the cryptography features can be found in p5.mime and p5.io.zip
* [p5.csv](/plugins/extras/p5.csv) - Handling CSV files in P5
* [p5.flickr](/plugins/extras/p5.flickrnet) - Searching for images on Flickr
* [p5.html](/plugins/extras/p5.html) - Parsing and creating HTML in P5
* [p5.http](/plugins/extras/p5.http) - HTTP REST support in P5
* [p5.imaging](/plugins/extras/p5.imaging) - Managing and manipulating images from P5
* [p5.authorization](/plugins/extras/p5.io.authorization) - Authorization features in P5
* [p5.io.zip](/plugins/extras/p5.io.zip) - Zip'ing and unzip'ing files, also supports AES cryptography
* [p5.mail](/plugins/extras/p5.mail) - Complex and rich SMTP and POP3 support, which is far better than the internal .Net classes for accomplishing the same
* [p5.mime](/plugins/extras/p5.mime) - MIME support, in addition to PGP, and handling your GnuPG database
* [p5.mysql](/plugins/extras/p5.mysql) - MySQL data adapter
* [p5.threading](/plugins/extras/p5.threading) - Threading support in P5
* [p5.xml](/plugins/extras/p5.xml) - XML support in P5
* [p5.markdown](/plugins/extras/p5.markdown) - Parsing Markdown snippets
* [p5.json](/plugins/extras/p5.json) - Parsing and creating JSON. __NOT YET RELEASED!!__

## MSDN Magazine articles

P5 have been published twice in Microsoft's MSDN Magazine, with a third article coming up. Read the articles below written by yours truly.

* [Active Events: One design pattern instead of a dozen](https://msdn.microsoft.com/en-us/magazine/mt795187)
* [Make C# more dynamic with Hyperlambda](https://msdn.microsoft.com/en-us/magazine/mt809119)

If you wish to read these articles, you might benefit from reading them sequentially, to make sure you understand Active Events, 
before you dive into Hyperlambda.

## License

Phosphorus Five is free and open source software, and licensed under the terms
of the Gnu Public License, version 3, in addition to that commercially license are available for a fee. Read more about
our Quid Pro Quo license terms at [my website](https://gaiasoul.com/license/). But basically, to make a long story short, you will
have to acquire the right to create closed source applications, by [purchasing a license](https://gaiasoul.com/license/).
If you only want to create open source applications, and/or plugins, this is not relevant, and you can simply use the Open Source version.

**Hint** - If you're a system developer, and you're creating apps for clients of yours - You **don't need a license** - Since you can simply
use the Open Source version yourself, and have your client(s) pay for a server license. Purchasing a license, is automated through the Bazar, and optional,
unless you need support beyond what I can provide you with [here](https://github.com/polterguy/phosphorusfive/issues).

## More information

I occasionally blog about P5, when I do, I do so [here](https://gaiasoul.com).

There exists a [code of conduct](CODE_OF_CONDUCT.md) for the project you should read if you wish to participate 
in the project. But basically what it says, is _"be nice"_ and preferably if you can, _"apply humor"_.

I have also deployed Phosphorus Five on my own personal home cloud, which is actually just an old discarded Windows laptop,
which I have upgraded to become a Linux/Ubuntu/Phosphorus Five web server. If you'd like to test it, feel free 
to [vist it here](https://home.gaiasoul.com) - However, be warned, I am running this thing out of my living room, on an old
discarded laptop, with a plain average internet connection.

## Examples

You can also find a more professional type of [example server installation of Phosphorus Five here](https://samples.gaiasoul.com/). However, without
a username/password to the server, there's not really much you can do, besides checking out the _"Hello World"_ application, and seeing my publicly
deployed apps/data.

If you wish to truly test the system, you can easily setup your own Virtual Private Server with Phosphorus Five pre-installed,
with [three simple clicks](https://samples.gaiasoul.com/auto-deployment). This gives you a _"free"_ VPS server with Phosporus Five
pre-installed, where you can play around with it as much as you wish, including test your own apps, or install any of the apps that
comes in the _"Bazar"_ out of the box for free. This is probably the easiest and simplest way to test Phosphorus Five, but it'll cost
you €49 for 2 weeks ot testing, and it requires you to pay €49 through PayPal. [Read more here](https://gaiasoul.com/2017/10/02/get-a-private-phosphorus-five-server-for-e49/).

## Yet again, Phosphorus Five is Free Software

If you're a system developer, and you want to create apps for Phosphorus Five - **You don't need a license** - You can simply use the Open Source version,
and have your client(s) pay for a license!

## Hire me

Need more training or personal assistance in regards to Phosphorus Five, don't hesitate to pass me an email.

thomas@gaiasoul.com

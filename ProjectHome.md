FIX Adapted for Streaming ([FAST](http://fixprotocol.org)) is a highly compressed and underlying transport independent protocol for market data. FAST is a dynamic protocol in which the sender and receiver synchronizes decode and encode procedures for messages and tells the remote party which policy will be used to handle each field of messages.

The original developer of this code is The LaSalle Technology Group and it was ported to C# from their [OpenFAST](http://www.openfast.org/) Java Implementation.

The intended audience of this project is the developers who are building consolidated feed handlers for their custom trading platforms. It can be used to handle the communication protocol between your client applications and a feed consolidation server.

The utility of this library is specifically for finance and trading applications.
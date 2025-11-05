
Update: v0.7

The update includes the peer-to-peer chat client sending and displaying the title of the OS's active window for each peer on the network. This title is automatically queried using the Windows API, then transmitted as part of peer discovery messages, and displayed in a separate list (the active windows list) for each client.

------------------------------------

Update: v0.6

Private Network Chat is a peer-to-peer local network chat application that allows users to discover each other automatically on the local network, exchange messages with low latency.

<img width="733" height="500" alt="image" src="https://github.com/user-attachments/assets/36079a46-9121-4175-8b9c-f0c09360fe8a" />


Simple login with PIN code: A PIN code is used for user identification, which is securely stored using a hash.

Use of unique identifier and username: Each client has a local IP-based software identifier and a configurable, unique username.

Automatic peer discovery: The client sends scheduled broadcasts using the UDP protocol so that other machines on the network can find it.

Messaging via TCP: Messages between peers are transmitted using a direct TCP connection.

Dynamic peer list management: The program continuously monitors the availability of peers and only displays live clients.

Different backgrounds for sent and received messages: In the user interface, sent messages are displayed with a light gray background, and received messages are displayed with a white background.

Real-time status update: Sends a signal on the network when a peer leaves, so the offline user is automatically deleted from the list.

Store settings in a file: Securely store PIN, ID and username in a local file, which is automatically loaded after restart.

User interactions: Send text messages immediately, sound notification of incoming messages, manage login status.

# 💬 TCP Chat Application

A multi-user TCP/IP Chat Application built using **C# .NET WinForms** and **TcpSharp**.

This project demonstrates client-server communication using TCP sockets, allowing multiple users to connect to a server, view online users, and exchange private messages in real time.

---

## 🚀 Features

- User Login with Username
- TCP Server Implementation
- Multiple Client Connections
- Online Users List
- Private Messaging
- Real-Time Communication
- Event-Driven Architecture
- WinForms User Interface
- Client Connection & Disconnection Handling

---

## 🏗️ Architecture

```text
┌─────────────┐
│  Client 1   │
└──────┬──────┘
       │
       │ TCP/IP
       │
┌──────▼──────┐
│   Server    │
│ Port: 9000  │
└──────┬──────┘
       │
       │ TCP/IP
       │
┌──────▼──────┐
│  Client 2   │
└─────────────┘
```

The server manages all connected clients and routes messages between users.

---

## 🛠 Technologies Used

- C#
- .NET 8
- WinForms
- TCP/IP
- TcpSharp Library

---

## 📂 Project Structure

```text
TCP-Chat-Application
│
├── ClientApp
│   ├── frmJoin.cs
│   ├── frmChat.cs
│   ├── Program.cs
│   └── AppSession.cs
│
├── ServerApp
│   ├── Program.cs
│   └── Server Logic
│
└── README.md
```

---

## ⚙️ How It Works

### Step 1

Start the Server Application.

```text
Server listening on Port 9000
```

### Step 2

Launch one or more Client Applications.

### Step 3

Enter a username and connect.

Example:

```text
Jerry
```

### Step 4

Server registers the user.

```text
JOIN|Jerry
```

### Step 5

Server updates all connected clients with the latest user list.

```text
USERLIST|Jerry,Tom
```

### Step 6

Select a user and send messages.

```text
MSG|Tom|Hello Tom
```

### Step 7

Recipient receives the message.

```text
MSG|Jerry: Hello Tom
```

---

## 📡 Communication Protocol

### Join User

```text
JOIN|Username
```

Example

```text
JOIN|Jerry
```

---

### User List

```text
USERLIST|Jerry,Tom,Harry
```

---

### Send Message

```text
MSG|TargetUser|Message
```

Example

```text
MSG|Tom|Hello Tom
```

---

### Receive Message

```text
MSG|Jerry: Hello Tom
```

---

## 🧠 Concepts Practiced

This project helped me learn:

- TCP/IP Networking
- Socket Programming
- Client-Server Architecture
- Multi-Client Communication
- Event Handling
- Thread-Safe UI Updates
- User Session Management
- Custom Protocol Design
- Real-Time Messaging Systems

---

## 📸 Screenshots

### Join Window

<img width="580" height="176" alt="image" src="https://github.com/user-attachments/assets/48f8ef7c-0530-42f3-93b7-eefbf711ad5e" />


---

### Chat Window

<img width="806" height="482" alt="image" src="https://github.com/user-attachments/assets/b3899610-25ac-4f5c-851d-244e8ec39070" />


---

### Multiple Clients Connected

<img width="1316" height="609" alt="image" src="https://github.com/user-attachments/assets/4006e9e0-99a3-4bd0-8653-26d125b2a023" />


---

## 🔮 Future Enhancements

- Group Chat
- Chat Rooms
- Broadcast Messaging
- File Transfer
- Chat History
- User Online/Offline Status
- SQLite / SQL Server Storage
- Message Encryption
- Emoji Support
- User Authentication

---

## 🎯 Learning Outcome

Building this project strengthened my understanding of:

- Network Communication
- TCP Socket Programming
- Message Routing
- Event-Driven Development
- Desktop Application Development with WinForms

This project represents an important step toward developing more advanced networking and system-level applications in C#.

---

## 👨‍💻 Author

**Bishal Shrestha**

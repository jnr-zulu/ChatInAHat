# ChatInAHat

ChatInAHat is a real-time chat application built with ASP.NET Core and SignalR, providing users with a seamless and interactive communication experience.

## Description

ChatInAHat is a modern web-based chat application that allows users to engage in real-time conversations. Built on the robust ASP.NET Core framework and leveraging the power of SignalR for real-time functionality, this application offers a responsive and user-friendly interface for instant messaging.

Key Features:
- Real-time messaging using SignalR
- User authentication and account management
- Responsive design for various devices
- Secure communication

## Getting Started

### Prerequisites

- .NET 6.0 SDK or later
- SQL Server (LocalDB or full instance)
- Visual Studio 2022 or Visual Studio Code

### Installation

1. Clone the repository: git clone https:
   //github.com/jnr-zulu/ChatInAHat.git
   
2. Navigate to the project directory:
   cd ChatInAHat
   
3. Restore the NuGet packages:
   dotnet restore
   
4. Update the database with Entity Framework migrations:
   dotnet ef database update
   
5. Run the application:
    dotnet run

## Usage

After starting the application, navigate to `https://localhost:5001` in your web browser. Create an account or log in to start chatting!

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.


## Acknowledgments

- ASP.NET Core team for the fantastic web framework
- SignalR team for the real-time web functionality

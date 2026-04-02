# PixelWonders

PixelWonders is a Windows Forms application that provides a creative platform for users to create, explore, and interact with pixel art designs and puzzles.

## Features

- **Home Screen:** Central hub for navigation.
- **Design Maker:** Create your own pixel art designs using an interactive grid-based editor.
- **Gallery:** Browse and view a collection of pixel art designs, including your own creations.
- **Jigsaw/Nonogram Puzzles:** Solve puzzles generated from pixel art designs.
- **Design Loader:** Utility for rendering and managing pixel art designs.
- **User Management (Code Only):** Login and registration logic is present in the codebase but not active in the current game flow.

## Tech Stack

- **Language:** C#
- **Framework:** .NET 6.0 (Windows Forms)
- **Database:** SQLite (local file: `PixelWonders.db`)
- **IDE:** Visual Studio 2022
- **UI:** WinForms controls, custom drawing with GDI+

## Getting Started

### Prerequisites

- Windows OS
- [.NET 6.0 or later](https://dotnet.microsoft.com/download)
- Visual Studio 2022

### Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/yourusername/PixelWonders.git
    ```
2. Open the solution in Visual Studio 2022.
3. Restore NuGet packages if prompted.
4. Build the solution.

### Running the Application

- Press `F5` or click **Start** in Visual Studio to launch the application.
- The application will start at the Home screen.

## Project Structure

- `Program.cs` – Application entry point and database initialization.
- `Homescreen.cs` – Home screen form and navigation logic.
- `Gallery.cs` – Gallery form for viewing pixel art.
- `Nonogram.cs` – Nonogram puzzle logic.
- `DesignMaker.cs` – Pixel art design creation and editing.
- `Login.cs` / `Signup.cs` – User authentication (currently unused in UI).

## Notes

- Login and registration forms are present in the codebase but are not shown in the current user flow.
- The application uses a local SQLite database (`PixelWonders.db`) for storing designs and user data.

## License

This project is licensed under the MIT License.
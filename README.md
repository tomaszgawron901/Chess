# Chess

## **Folders Structure**

- **ChessAppSetup** - Setup folder (all you need to create .exe/msi setup files).
- **ChessApplication** - WPF Desktop application.
- **ChessWebApp** - Blazor WebSite application.
- **ChessClassLibrary** - Classes responsible for logic in game.
- **ChessClassLibraryTests** - Unit tests for all classes in **ChessClassLibrary**.

## **Desktop App Instalation**
- **First of all you have to open solution file and build it.**
- To install application go to ChessAppSetup/Debug and open 'ChessAppSetup.msi'/'Setup.exe', or in Solution Explorer right-click on ChessAppSetup and click 'install'.

## **Usage**
- **How to move piece**
  - To select a piece you want to move left-click it (you will see black border around selected piece).
  - To check if the piece can be moved to specific field move the cursor over the field. If border of the field changes to green the move can be executed, if to red the piece can not be moved.
  - To execute move left-click on the field.
  - **Notice that you can not move piece if it would couse king's 'death'.**
- **Game end**
  - **Checkmate** - player have no possibility to save king.
  - **Stalemate** - king isn't checked but can't move to any field or there are only kings on the board left.
- **New Game**
  - To start new game go to options in the upper-left corner and select 'New game'.

# Purpose
Educational project to learn WPF design pattern MVVM and decoupling the UI layer from business logic for better modularity.

# Laborare.Core
Class library containing Data Models and the Service layer with our business logic. 

Currently implementing X Motors, Y Motors, Z Motors, and R Motors.
Each motor can be implemented using RS-232 or TCP communication protocols.
Compatible with the CoolMuscle CM1 and CM2 motors, and UIRobot controller (rotation motor controller).

BCS I/O Boards are automatically detected. 

# 901-42 Handler User Interface
UI created to communicate with Laborare.Core library.

Specification:

X-Motor
Count: 1
Model: CM2
Communication Protocol: RS-232

Y-Motor
Count: 1
Model: CM1
Communication Protocol: TCP IP

Z-Motor
Count: 1
Model: CM1
Communication Protocol: TCP IP

R-Motor
Count: 1
Model: UIRobot
Communication Protocol: RS-232

# Settings
Settings are located in App.settings. This is where you can modify the number of motors and other peripherals used in the user interface.

